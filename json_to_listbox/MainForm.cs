using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace json_to_listbox
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            var dir = Path.Combine(
                        Path.GetDirectoryName(Assembly.GetEntryAssembly().Location),
                        "json");

            foreach(var file in Directory.GetFiles(dir, "*.json"))
            {
                var text = File.ReadAllText(file);
                // Having a model makes it easy to convert the Json.
                var model = JsonConvert.DeserializeObject<UserAccount>(text);
                // Adding the model to the list will use the "ToString" method to display it.
                listBoxJsonNames.Items.Add(model);
            }
        }

        class UserAccount
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string TeamName { get; set; }
            public string Password { get; set; }
            public string IsActive { get; set; }
            public string UserId { get; set; }

            // Format how this record should display in the ListBox
            public override string ToString() => $"User: {FirstName} {LastName}";
        }

        private void listBoxJsonNames_SelectedValueChanged(object sender, EventArgs e)
        {
            var model = (UserAccount)listBoxJsonNames.SelectedItem;
            textBoxFirstName.Text = model.FirstName;
            textBoxLastName.Text = model.LastName;
            textBoxUserId.Text = model.UserId;
        }
    }
}
