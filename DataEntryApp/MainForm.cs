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
                        this.listView1.BeginUpdate();

                        this.listView1.Items.Clear();

                        result.All(delegate (Guest quest)
                        {
                            var item = new ListViewItem()
                            {
                                Text = quest.Prefix,
                            };

                            item.SubItems.Add(quest.Name);
                            item.SubItems.Add(quest.Surname);
                            item.SubItems.Add(quest.Role);
                            item.SubItems.Add(quest.Organization);

                            listView1.Items.Add(item);

                            return true;
                        });

                        this.listView1.EndUpdate();
                    }
                    else
                        this.listView1.Items.Clear();
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
            this.listView1.Items.Clear();
            this.button2.Enabled = false;
            this.button3.Enabled = false;
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
                    this.Search_Box.Focus();
                    this.listView1.Enabled = true;
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            PcscReader.InvokeScanned("0x0000000");
        }
    }
}
