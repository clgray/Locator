using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cnit.Testor.Core.UI
{
    public partial class InputBox : Form
    {

        public string Input
        {
            get
            {
                return textBoxText.Text.Trim();
            }
            set
            {
                textBoxText.Text = value;
            }
        }

        public InputBox(string text,string message)
        {
            InitializeComponent();
            this.Text = text;
            labelText.Text = message;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (textBoxText.Text.Trim() == String.Empty)
                MessageBox.Show("Обязательные поля не заполнены.");
            else
                this.DialogResult = DialogResult.OK;
        }

        private void InputBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                buttonOK_Click(this, new EventArgs());
        }
    }
}
