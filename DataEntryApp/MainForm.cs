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

        private void button1_Click(object sender, EventArgs e)
        {
            using (var db = new EventEntities())
            {
                var guests = db.Guests.ToList();
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

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
