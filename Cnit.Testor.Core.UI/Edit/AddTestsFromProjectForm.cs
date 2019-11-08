using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cnit.Testor.Core.Packaging;

namespace Cnit.Testor.Core.UI.Edit
{
	internal partial class AddTestsFromProjectForm : Form
	{
		private List<TestHelper> _helpers;

		public AddTestsFromProjectForm(List<TestHelper> helpers)
		{
			InitializeComponent();
			_helpers = helpers;
			foreach (var helper in _helpers)
			{
				if (helper.IsMasterTest)
					continue;
				if (ProjectState.TestHelpers.Where(c => c.TestKey == helper.TestKey).Count() == 0)
					checkedListBoxTests.Items.Add(helper);
			}
			checkBoxAll.Enabled = checkedListBoxTests.Items.Count > 0;
		}

		private void checkBoxAll_CheckedChanged(object sender, EventArgs e)
		{
			bool check = checkBoxAll.Checked;
			for (int i = 0; i < checkedListBoxTests.Items.Count; i++)
				checkedListBoxTests.SetItemChecked(i, check);
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			foreach (var helper in checkedListBoxTests.CheckedItems)
			{
				TestHelper testHelper = (TestHelper)helper;
				TestorData td = testHelper.TestorData;
				if (td == null)
					continue;
				testHelper.TestRequirements = new List<string>();
				ProjectState.TestHelpers.Add(testHelper);
			}
			if (checkedListBoxTests.CheckedItems.Count > 0)
			{
				ProjectState.HasChanges = true;
				ProjectState.OnTestHelpersChanged();
			}
			this.DialogResult = DialogResult.OK;
		}
	}
}
