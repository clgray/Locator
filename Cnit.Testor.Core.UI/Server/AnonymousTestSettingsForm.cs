using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cnit.Testor.Core.Server;

namespace Cnit.Testor.Core.UI.Server
{
    public partial class AnonymousTestSettingsForm : Form
    {
        private TestorTreeItem _selectedFolder;

        public AnonymousTestSettingsForm()
        {
            InitializeComponent();
            string policy = StaticServerProvider.HelperService.GetPropertyValue(SystemProperties.ANONYMOUS_POLICY);
            if (policy == "-1")
                radioButtonNone.Checked = true;
            else if (policy == "0")
                radioButtonAll.Checked = true;
            else
            {
                radioButtonFolder.Checked = true;
                var folders = StaticServerProvider.TestEdit.GetTestParents(int.Parse(policy));
                if (folders.Length == 0)
                    radioButtonNone.Checked = true;
                else
                {
                    _selectedFolder = folders[0];
                    while (_selectedFolder.SubItems != null && _selectedFolder.SubItems.Length != 0)
                        _selectedFolder = _selectedFolder.SubItems[0];
                    textBoxFolder.Text = _selectedFolder.ItemName;
                }
            }
        }

        private void radioButtonFolder_CheckedChanged(object sender, EventArgs e)
        {
            textBoxFolder.Enabled = radioButtonFolder.Checked;
            buttonSelectFolder.Enabled = radioButtonFolder.Checked;
        }

        private void buttonSelectFolder_Click(object sender, EventArgs e)
        {
            SelectSingleItemForm selectGroup = new SelectSingleItemForm(TestingServerItemType.FolderTree);
            if (selectGroup.ShowDialog() != DialogResult.OK)
                return;
            _selectedFolder = selectGroup.SelectedItem;
            if (_selectedFolder != null)
                textBoxFolder.Text = _selectedFolder.ItemName;
            else
                textBoxFolder.Text = String.Empty;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            string value = String.Empty;
            if (radioButtonNone.Checked)
                value = "-1";
            else if (radioButtonAll.Checked)
                value = "0";
            else
                value = _selectedFolder.ItemId.ToString();
            StaticServerProvider.HelperService.SetPropertyValue(SystemProperties.ANONYMOUS_POLICY, value);
        }
    }
}
