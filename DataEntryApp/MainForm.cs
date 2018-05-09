using DataEntryApp.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DataEntryApp
{
    public enum ListViewState
    {
        All,
        Unassigned,
        Assigned,
    }
    public partial class MainForm : Form
    {
        public ListViewState ListViewState { get; set; }

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

                    CalculateMetrics();
                    PopulateStatusList();
                    PopulateSpecialList();
                    PopulateTemporaryList();
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
                    var result = (from guest in context.Guests
                                  where (guest.Name.ToUpper() + " " + guest.Surname.ToUpper()).Contains(key) &&
                                  !context.Tokens.Any(q => q.GuestID == guest.ID)
                                  select guest).ToList();

                    if (result.Count > 0)
                    {
                        this.Results_View.BeginUpdate();

                        this.Results_View.Items.Clear();

                        result.All(delegate (Guest guest)
                        {
                            var item = new ListViewItem()
                            {
                                Text = guest.Title,
                            };

                            item.SubItems.Add(guest.Name);
                            item.SubItems.Add(guest.Surname);
                            item.SubItems.Add(guest.Position);
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

            this.Special_Level_Combo.SelectedIndex = 0;

            PcscReader.Initialize();
            PcscReader.CardScanned += PcscReader_CardScanned;
            PcscReader.Error += PcscReader_Error;
        }

        string lastErrorMessage = "";

        private void PcscReader_Error(string message)
        {
            if (lastErrorMessage != message)
            {
                lastErrorMessage = message;

                ClearInput();
            }
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
            this.Temp_Uid_Box.Text = "";
            this.Special_Uid_Box.Text = "";
            this.Search_Box.Text = "";

            this.Media_Uid_Box.Text = "";
            this.Media_List.Items.Clear();
            this.Search_Media_Box.Text = "";


            this.Focus();
        }

        private void PcscReader_CardScanned(string uid)
        {
            ClearInput();

            using (var context = new EventEntities())
            {
                var exists = context.Tokens.FirstOrDefault(q => q.Uid == uid);
                var exists2 = context.TemporaryCards.FirstOrDefault(q => q.Uid == uid);
                var exists3 = context.SpecialCards.FirstOrDefault(q => q.Uid == uid);
                var exists4 = context.MediaCards.FirstOrDefault(q => q.Uid == uid);
                //var exists5 = context.VipCards.FirstOrDefault(q => q)

                if (exists != null)
                {
                    var guest = context.Guests.FirstOrDefault(q => q.ID == exists.GuestID);

                    if (guest != null)
                        MessageBox.Show(string.Format("This card already belongs to {0}.", guest.FullName), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else if (exists2 != null)
                {
                    string message = string.Format("This card [{0}] is already registered as a temporary card with a serial code of: {1}", exists2.Uid, exists2.Serial);

                    MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (exists3 != null)
                {
                    string message = string.Format("This card [{0}] is already registered as a special card with {1} access level.", exists3.Uid, exists3.Level);

                    MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (exists4 != null)
                {
                    string message = string.Format("This card [{0}] is already registered as a media/reporter card to {1} - {2}", exists4.Uid, exists4.Name, exists4.Outlet);

                    MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    this.Uid_Box.Text = uid;
                    this.Temp_Uid_Box.Text = uid;
                    this.Special_Uid_Box.Text = uid;
                    this.Media_Uid_Box.Text = uid;


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
            }
        }

        private void Assign_Button_Click(object sender, EventArgs e)
        {
            AssignSelectedItem();
        }

        void AssignSelectedItem()
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
            using (var context = new EventEntities())
            {
                var totalGuests = context.Guests.Count();
                var unassigned = (from guest in context.Guests
                                  where !context.Tokens.Any(q => q.GuestID == guest.ID)
                                  select guest.ID).ToList().Count();

                var assigned = (from guest in context.Guests
                                where context.Tokens.Any(q => q.GuestID == guest.ID)
                                select guest.ID).ToList().Count();

                var crew = context.SpecialCards.Where(q => q.Level == "Crew").Count();
                var protocol = context.SpecialCards.Where(q => q.Level == "Protocol").Count();
                var media = context.MediaCards.Where(q => q.Uid != null && q.Uid.Length > 0).Count();

                this.Total_Guests_Label.Text = totalGuests.ToString();
                this.Unassigned_Guests_Label.Text = unassigned.ToString();
                this.Assigned_Guests_Label.Text = assigned.ToString();
                this.Crew_Cards_Label.Text = crew.ToString();
                this.Protocol_Cards_Label.Text = protocol.ToString();
                this.Media_Cards_Label.Text = media.ToString();
            }
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

        private void Results_View_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                AssignSelectedItem();
        }

        private void Radio_CheckedChanged(object sender, EventArgs e)
        {
            if (All_Radio.Checked)
                ListViewState = ListViewState.All;
            else if (Unassigned_Radio.Checked)
                ListViewState = ListViewState.Unassigned;
            else if (Assigned_Radio.Checked)
                ListViewState = ListViewState.Assigned;

            PopulateStatusList();
        }

        private void Status_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Status_List.SelectedItems != null && this.Status_List.SelectedItems.Count > 0)
            {
                var item = this.Status_List.SelectedItems[0];

                if (item.Text.Length > 0)
                    this.Delete_Button.Enabled = true;
                else
                    this.Delete_Button.Enabled = false;
            }
            else
                this.Delete_Button.Enabled = false;
        }

        private void PopulateStatusList()
        {
            using (var context = new EventEntities())
            {
                List<GuestAudit> result = new List<GuestAudit>();

                switch (ListViewState)
                {
                    case ListViewState.All:
                        {
                            result = (from guest in context.Guests
                                      join token in context.Tokens on guest.ID equals token.GuestID into joined
                                      from t in joined.DefaultIfEmpty()
                                      select new GuestAudit()
                                      {
                                          ID = guest.ID,
                                          Uid = t.Uid,
                                          Title = guest.Title,
                                          Name = guest.Name,
                                          Surname = guest.Surname,
                                          Position = guest.Position,
                                          Organization = guest.Organization,
                                      }).OrderBy(q => q.Name).ToList();


                            break;
                        }

                    case ListViewState.Unassigned:
                        {
                            result = (from guest in context.Guests
                                      where !context.Tokens.Any(q => q.GuestID == guest.ID)
                                      select new GuestAudit()
                                      {
                                          ID = guest.ID,
                                          Uid = "",
                                          Title = guest.Title,
                                          Name = guest.Name,
                                          Surname = guest.Surname,
                                          Position = guest.Position,
                                          Organization = guest.Organization,
                                      }).OrderBy(q => q.Name).ToList();

                            break;
                        }

                    case ListViewState.Assigned:
                        {
                            result = (from guest in context.Guests
                                      join token in context.Tokens on guest.ID equals token.GuestID
                                      where context.Tokens.Any(q => q.GuestID == guest.ID)
                                      select new GuestAudit()
                                      {
                                          ID = guest.ID,
                                          Uid = token.Uid,
                                          Title = guest.Title,
                                          Name = guest.Name,
                                          Surname = guest.Surname,
                                          Position = guest.Position,
                                          Organization = guest.Organization,
                                      }).OrderBy(q => q.Name).ToList();

                            break;
                        }
                }

                if (result.Count > 0)
                {
                    this.Status_List.BeginUpdate();
                    this.Status_List.Items.Clear();

                    result.All(delegate (GuestAudit audit)
                    {
                        var item = new ListViewItem();
                        item.Tag = audit.ID;
                        item.Text = audit.Uid;
                        item.SubItems.Add(audit.Title);
                        item.SubItems.Add(audit.Name);
                        item.SubItems.Add(audit.Surname);
                        item.SubItems.Add(audit.Position);
                        item.SubItems.Add(audit.Organization);

                        this.Status_List.Items.Add(item);

                        return true;
                    });

                    this.Status_List.EndUpdate();
                }
                else
                {
                    this.Status_List.BeginUpdate();
                    this.Status_List.Items.Clear();
                    this.Status_List.EndUpdate();
                }
            }
        }

        void PopulateSpecialList()
        {
            this.Special_List.BeginUpdate();
            this.Special_List.Items.Clear();

            using (var context = new EventEntities())
            {
                var specialCards = context.SpecialCards.OrderByDescending(q => q.ID).ToList();

                specialCards.All(delegate (SpecialCard card)
                {
                    var item = new ListViewItem();
                    item.Tag = card.ID;
                    item.Text = card.Uid;
                    item.SubItems.Add(card.Level);

                    this.Special_List.Items.Add(item);

                    return true;
                });
            }

            this.Special_List.EndUpdate();
        }

        private void PopulateTemporaryList()
        {
            this.Temporary_List.BeginUpdate();
            this.Temporary_List.Items.Clear();

            using (var context = new EventEntities())
            {
                var cards = context.TemporaryCards.ToList();

                cards.All(delegate (TemporaryCard card)
                {
                    var item = new ListViewItem();
                    item.Tag = card.ID;
                    item.Text = card.Uid;
                    item.SubItems.Add(card.Serial);

                    this.Temporary_List.Items.Add(item);


                    return true;
                });
            }

            this.Temporary_List.EndUpdate();
        }

        private void Delete_Button_Click(object sender, EventArgs e)
        {
            if (this.Status_List.SelectedItems != null)
            {
                var item = this.Status_List.SelectedItems[0];

                var uid = item.Text;

                if (uid.Length > 0)
                {
                    string question = string.Format("{0} uid related to a quest will be deleted, are you sure?", uid);

                    if (MessageBox.Show(question, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        using (var context = new EventEntities())
                        {
                            var existingRecord = context.Tokens.FirstOrDefault(q => q.Uid == uid);

                            if (existingRecord != null)
                            {
                                context.Tokens.Remove(existingRecord);
                                context.SaveChanges();

                                PopulateStatusList();
                            }
                        }
                    }
                }
            }
        }

        private void Add_Button_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.Temp_Uid_Box.Text)
                && !string.IsNullOrEmpty(this.Serial_Box.Text))
            {
                using (var context = new EventEntities())
                {
                    var card = new TemporaryCard()
                    {
                        Uid = this.Temp_Uid_Box.Text,
                        Serial = this.Serial_Box.Text
                    };

                    context.TemporaryCards.Add(card);
                    context.SaveChanges();

                    ClearInput();
                    PopulateTemporaryList();
                }
            }
        }

        private void Add_Special_Button_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.Special_Uid_Box.Text) && this.Special_Uid_Box.Text.Length > 0)
            {
                using (var context = new EventEntities())
                {
                    var card = new SpecialCard()
                    {
                        Level = this.Special_Level_Combo.SelectedItem.ToString(),
                        Uid = this.Special_Uid_Box.Text
                    };

                    context.SpecialCards.Add(card);
                    context.SaveChanges();

                    ClearInput();
                    PopulateSpecialList();
                    CalculateMetrics();
                }
            }
        }

        private void Special_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Special_List.SelectedItems != null && this.Special_List.SelectedItems.Count > 0)
            {
                this.Delete_Special_Button.Enabled = true;
            }
            else
                this.Delete_Special_Button.Enabled = false;
        }

        private void Delete_Special_Button_Click(object sender, EventArgs e)
        {
            if (this.Special_List.SelectedItems != null && this.Special_List.SelectedItems.Count > 0)
            {
                var item = this.Special_List.SelectedItems[0];

                var id = Convert.ToInt32(item.Tag);

                using (var context = new EventEntities())
                {
                    var exists = context.SpecialCards.FirstOrDefault(q => q.ID == id);

                    if (exists != null)
                    {
                        context.SpecialCards.Remove(exists);
                        context.SaveChanges();

                        PopulateSpecialList();
                    }
                }
            }
        }

        private void Delete_Temporary_Button_Click(object sender, EventArgs e)
        {
            if (this.Temporary_List.SelectedItems != null &&
                this.Temporary_List.SelectedItems.Count > 0)
            {
                var item = this.Temporary_List.SelectedItems[0];
                var id = Convert.ToInt32(item.Tag);

                using (var context = new EventEntities())
                {
                    var existing = context.TemporaryCards.FirstOrDefault(q => q.ID == id);

                    if (existing != null)
                    {
                        context.TemporaryCards.Remove(existing);
                        context.SaveChanges();

                        ClearInput();
                    }
                }

                PopulateTemporaryList();
            }
        }

        private void Temporary_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Temporary_List.SelectedItems != null &&
                this.Temporary_List.SelectedItems.Count > 0)
            {
                this.Delete_Temporary_Button.Enabled = true;
            }
            else
                this.Delete_Temporary_Button.Enabled = false;
        }

        private void Search_Media_Box_TextChanged(object sender, EventArgs e)
        {
            if (this.Search_Media_Box.Text.Length > 0)
            {
                var key = this.Search_Media_Box.Text.ToUpper();

                using (var context = new EventEntities())
                {
                    var result = (from m in context.MediaCards
                                  where m.Name.ToUpper().Contains(key) &&
                                  m.Uid == null
                                  select m).ToList();

                    if (result.Count > 0)
                    {
                        this.Media_List.BeginUpdate();
                        this.Media_List.Items.Clear();

                        result.All(delegate (MediaCard card)
                        {
                            var item = new ListViewItem()
                            {
                                Text = card.Name,
                            };

                            item.SubItems.Add(card.Outlet);
                            item.Tag = card.ID;

                            this.Media_List.Items.Add(item);

                            return true;
                        });

                        this.Media_List.EndUpdate();
                    }
                    else
                        this.Media_List.Items.Clear();
                }
            }
        }

        private void Media_List_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Media_List.Enabled && Media_List.Items != null && Media_List.Items.Count > 0)
            {
                ListViewHitTestInfo info = this.Media_List.HitTest(e.X, e.Y);
                ListViewItem item = info.Item;

                if (item != null && !string.IsNullOrEmpty(this.Media_Uid_Box.Text))
                {
                    var uid = this.Media_Uid_Box.Text;
                    var name = item.SubItems[0].Text;

                    string message = string.Format("{0} uid will be assigned to media/report \"{1}\", are you sure?", uid, name);

                    if (MessageBox.Show(message, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        var cardId = Convert.ToInt32(item.Tag);

                        AssignMediaCard(uid, cardId);
                    }
                }
            }
        }

        private void AssignMediaCard(string uid, int cardId)
        {
            if (uid.Length > 0)
            {
                using (var context = new EventEntities())
                {
                    var card = context.MediaCards.FirstOrDefault(q => q.ID == cardId);

                    if (card != null)
                    {
                        card.Uid = uid;
                        context.SaveChanges();

                        ClearInput();
                        CalculateMetrics();
                    }

                }
            }
        }

        private void Media_List_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
