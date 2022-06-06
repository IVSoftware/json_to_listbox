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
                var model = JsonConvert.DeserializeObject<JsonModel>(text);
                listBoxJsonNames.Items.Add(model);
            }
        }

        class JsonModel
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string TeamName { get; set; }
            public string Password { get; set; }
            public string IsActive { get; set; }
            public string UserId { get; set; }

            public override string ToString() => $"{FirstName} {LastName}";
        }

        private void listBoxJsonNames_SelectedValueChanged(object sender, EventArgs e)
        {
            var model = (JsonModel)listBoxJsonNames.SelectedItem;
            textBoxFirstName.Text = model.FirstName;
            textBoxLastName.Text = model.LastName;
            textBoxUserId.Text = model.UserId;
        }
    }
}
