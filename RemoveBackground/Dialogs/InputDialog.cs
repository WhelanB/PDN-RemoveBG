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

namespace RemoveBackground
{
    public partial class InputDialog : Form
    {
        public string apiKey;
        public InputDialog()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            apiKey = apiKeyInput.Text;
        }

        private void GetApiKeyLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            getApiKeyLabel.LinkVisited = true;
            System.Diagnostics.Process.Start("https://www.remove.bg/dashboard#api-key");
        }

        private void OpenConfigLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openConfigLabel.LinkVisited = true;
            System.Diagnostics.Process.Start(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }
    }
}
