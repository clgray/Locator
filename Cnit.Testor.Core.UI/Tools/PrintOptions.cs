using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cnit.Testor.Core.UI
{
    public partial class PrintOptions : Form
    {
        public PrintOptions()
        {
            InitializeComponent();
        }

        public int SelectedMode
        {
            get
            {
                return comboBoxMode.SelectedIndex;
            }
        }

        public PrintOptions(List<string> availableFields)
        {
            InitializeComponent();
            comboBoxMode.SelectedIndex = 0;
            foreach (string field in availableFields)
            {
                bool isChecked = true;
                if (field == "Отчество" || field == "№ студенческого" || field == "Группа"
                    || field == "Время тестирования" || field == "Время начала")
                    isChecked = false;
                chklst.Items.Add(field, isChecked);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public List<string> GetSelectedColumns()
        {
            List<string> lst = new List<string>();
            foreach (object item in chklst.CheckedItems)
                    lst.Add(item.ToString());
            return lst;
        }

        public bool PrintAllRows
        {
            get { return true; }
        }

        public bool FitToPageWidth
        {
            get { return true; }
        }

    }
}