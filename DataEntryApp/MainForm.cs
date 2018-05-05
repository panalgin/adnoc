using DataEntryApp.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.Entity.Core.EntityClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataEntryApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Connect_Button_Click(object sender, EventArgs e)
        {
            var server = this.Server_Box.Text;
            var catalog = this.Catalog_Box.Text;
            var user = this.Username_Box.Text;
            var password = this.Password_Box.Text;

            Settings.Default.Server = server;
            Settings.Default.Catalog = catalog;
            Settings.Default.Username = user;
            Settings.Default.Password = password;

            Settings.Default.Save();

            try
            {
                using (var db = new EventEntities())
                {
                    var guests = db.Guests.ToList();
                    MessageBox.Show("Connection was successfull.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Search_Box_TextChanged(object sender, EventArgs e)
        {
            if (this.Search_Box.Text.Length > 0)
            {
                var key = this.Search_Box.Text.ToUpper();

                using (var context = new EventEntities())
                {
                    var result = context.Guests.Where(q => (q.Name.ToUpper() + " " + q.Surname.ToUpper()).Contains(key)).ToList();

                    if (result.Count > 0)
                    {
                        this.Results_View.BeginUpdate();

                        this.Results_View.Items.Clear();

                        result.All(delegate (Guest guest)
                        {
                            var item = new ListViewItem()
                            {
                                Text = guest.Prefix,
                            };

                            item.SubItems.Add(guest.Name);
                            item.SubItems.Add(guest.Surname);
                            item.SubItems.Add(guest.Role);
                            item.SubItems.Add(guest.Organization);
                            item.Tag = guest.ID;

                            Results_View.Items.Add(item);

                            return true;
                        });

                        this.Results_View.EndUpdate();
                    }
                    else
                        this.Results_View.Items.Clear();
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Settings.Default.Reload();
            var set = Settings.Default;

            this.Server_Box.Text = set.Server;
            this.Catalog_Box.Text = set.Catalog;
            this.Username_Box.Text = set.Username;
            this.Password_Box.Text = set.Password;

            PcscReader.Initialize();
            PcscReader.CardScanned += PcscReader_CardScanned;
            PcscReader.Error += PcscReader_Error;
        }

        private void PcscReader_Error(string message)
        {
            ClearInput();

        }

        private void ClearInput()
        {
            this.Uid_Box.Text = "";
            this.Search_Box.Text = "";
            this.Search_Box.Enabled = false;
            this.Results_View.Items.Clear();
            this.Results_View.Enabled = false;
            this.Assign_Button.Enabled = false;
            this.Cancel_Button.Enabled = false;

            this.Focus();
        }

        private void PcscReader_CardScanned(string uid)
        {
            ClearInput();

            using (var context = new EventEntities())
            {
                var exists = context.Tokens.FirstOrDefault(q => q.Uid == uid);

                if (exists != null)
                {
                    var guest = context.Guests.FirstOrDefault(q => q.ID == exists.GuestID);

                    if (guest != null)
                        MessageBox.Show(string.Format("This card already belongs to {0}.", guest.FullName), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    this.Uid_Box.Text = uid;
                    this.Search_Box.Enabled = true;
                    this.Cancel_Button.Enabled = true;
                    this.Search_Box.Focus();

                    this.Results_View.Enabled = true;
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            PcscReader.InvokeScanned("0x0000000");
        }

        private void Results_View_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Results_View.SelectedItems != null && this.Results_View.SelectedItems.Count > 0)
            {
                this.Assign_Button.Enabled = true;
                this.Cancel_Button.Enabled = true;
            }
            else
            {
                this.Assign_Button.Enabled = false;
                this.Cancel_Button.Enabled = false;
            }
        }

        private void Assign_Button_Click(object sender, EventArgs e)
        {
            if (this.Results_View.SelectedItems != null && this.Results_View.SelectedItems.Count > 0)
            {
                var uid = this.Uid_Box.Text;
                var guestId = Convert.ToInt32(this.Results_View.SelectedItems[0].Tag);

                AssignCardToGuest(uid, guestId);
            }
        }

        private void AssignCardToGuest(string uid, int guestId)
        {
            using (var context = new EventEntities())
            {
                var exists = context.Tokens.FirstOrDefault(q => q.Uid == uid);

                if (exists == null)
                {
                    var guest = context.Guests.FirstOrDefault(q => q.ID == guestId);

                    if (guest != null && MessageBox.Show(string.Format("Do you want to assign card uid [{0}] to guest [{1}]", uid, guest.FullName), "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        var token = new Token()
                        {
                            Uid = uid,
                            GuestID = guestId
                        };

                        context.Tokens.Add(token);
                        context.SaveChanges();
                        ClearInput();
                    }
                }
            }

            CalculateMetrics();
        }

        private void CalculateMetrics()
        {

        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            ClearInput();
        }

        private void Results_View_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Results_View.Enabled && Results_View.Items != null && Results_View.Items.Count > 0)
            {
                ListViewHitTestInfo info = this.Results_View.HitTest(e.X, e.Y);
                ListViewItem item = info.Item;

                if (item != null && !string.IsNullOrEmpty(this.Uid_Box.Text))
                {
                    var uid = this.Uid_Box.Text;
                    var guestId = Convert.ToInt32(item.Tag);

                    AssignCardToGuest(uid, guestId);
                }
            }
        }

        private void Search_Box_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (!string.IsNullOrEmpty(this.Uid_Box.Text) 
                    && this.Search_Box.Text.Length >= 2 
                    && this.Results_View.Items != null 
                    && this.Results_View.Items.Count > 0)
                {
                    var item = this.Results_View.Items[0];

                    var uid = this.Uid_Box.Text;
                    var guestId = Convert.ToInt32(item.Tag);

                    AssignCardToGuest(uid, guestId);
                }
            }
        }
    }
}
