using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cnit.Testor.Core.Server;

namespace Cnit.Testor.Core.UI
{
    public partial class CreateTreeForm : Form
    {
        public TestorTreeItem[] TestorItems
        {
            get
            {
                TreeNode rootNode = new TreeNode();
                int position = -1;
                ProcessLine(rootNode, 0, ref position);
                return ProcessItems(rootNode);
            }
        }

        private TestorTreeItem[] ProcessItems(TreeNode rootNode)
        {
            List<TestorTreeItem> retValue = new List<TestorTreeItem>();
            foreach (TreeNode tn in rootNode.Nodes)
            {
                TestorTreeItem item = new TestorTreeItem();
                item.ItemName = tn.Text;
                item.ItemType = TestorItemType.Group;
                item.SubItems = ProcessItems(tn);
                retValue.Add(item);
            }
            return retValue.ToArray();
        }

        public TreeNode[] Items
        {
            get
            {
                TreeNode rootNode = new TreeNode();
                int position = -1;
                ProcessLine(rootNode, 0, ref position);
                List<TreeNode> retValue = new List<TreeNode>();
                foreach (TreeNode node in rootNode.Nodes)
                    retValue.Add(node);
                return retValue.ToArray();
            }
        }

        private void ProcessLine(TreeNode parentNode, int xCount, ref int position)
        {
            try
            {
                TreeNode lastNode = null;
                position++;
                while (position < richTextBox.Lines.Length)
                {
                    string line = richTextBox.Lines[position];
                    int x = 0;
                    foreach (var ch in line)
                    {
                        if (ch != '\t')
                            break;
                        x++;
                    }
                    if (x == xCount)
                    {
                        line = line.Trim();
                        if(line.Length!=0){
                        lastNode = new TreeNode(line);
                        parentNode.Nodes.Add(lastNode);
                        }
                    }
                    else if (x < xCount)
                    {
                        position--;
                        return;
                    }
                    else if (x > xCount)
                    {
                        line = line.Trim();
                        if (line.Length != 0)
                        {
                            lastNode = parentNode.Nodes[parentNode.Nodes.Count - 1];
                            TreeNode tn = new TreeNode(line);
                            lastNode.Nodes.Add(tn);
                            ProcessLine(lastNode, x, ref  position);
                        }
                    }
                    position++;
                }
            }
            catch (Exception ex)
            {
                SystemMessage.ShowErrorMessage(ex.Message);
            }
        }

        public CreateTreeForm(string labelTxt,string titleTxt)
        {
            InitializeComponent();
            labelMain.Text = labelTxt;
            this.Text = titleTxt;
        }

        private void richTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            int line = richTextBox.GetLineFromCharIndex(richTextBox.SelectionStart);
            if (e.KeyChar == '\r')
            {
                string stringLine = richTextBox.Lines[line - 1];
                if (stringLine.Trim().Length == 0)
                {
                    richTextBox.SelectionStart--;
                    richTextBox.SelectionLength = 1;
                    richTextBox.SelectedText = String.Empty;
                    e.Handled = true;
                    return;
                }
                int index = GetPreTabIndex(line);
                if (index > 0)
                {
                    string selText = String.Empty;
                    for (; index != 0; index--)
                    {
                        selText += "\t";
                    }
                    richTextBox.SelectedText = selText;
                }
                e.Handled = true;
            }
            else if (e.KeyChar == '\t')
            {
                if (line == 0 || HasNsC(line))
                {
                    e.Handled = true;
                    return;
                }
                int index = GetPreTabIndex(line);
                if (index >= 0)
                {
                    string stringLine = richTextBox.Lines[line];
                    int rCount = 0;
                    foreach (var ch in stringLine)
                    {
                        if (ch != '\t')
                            break;
                        rCount++;
                    }
                    if (rCount > index)
                        e.Handled = true;
                }
            }
            else if (e.KeyChar == ' ')
            {
                bool isNsC = HasNsC(line);
                if (!isNsC)
                    e.Handled = true;
            }
        }

        private bool HasNsC(int line)
        {
            bool retValue = false;
            string stringLine = String.Empty;
            if (richTextBox.Lines.Length != 0)
                stringLine = richTextBox.Lines[line];
            int lineStart = richTextBox.GetFirstCharIndexOfCurrentLine();
            int currentChar = richTextBox.SelectionStart;
            int text = currentChar - lineStart;
            for (int i = 0; i < text; i++)
            {
                if (stringLine[i] != '\t')
                    return true;
            }
            return retValue;
        }

        private int GetPreTabIndex(int line)
        {
            int retValue = 0;
            if (line > 0)
            {
                string s = richTextBox.Lines[line - 1];
                foreach (var ch in s)
                {
                    if (ch != '\t')
                        break;
                    retValue++;
                }
            }
            return retValue;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
