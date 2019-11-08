using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cnit.Testor.Core.UI.Server;
using System.Globalization;

namespace Cnit.Testor.Core.UI.Edit
{
    internal partial class TestSettings : UserControl
    {
        private TestSettingsAdapter _adapter;
        private bool _isInited;

        private bool _isServerMode;

        public bool IsServerMode
        {
            get
            {
                return _isServerMode;
            }
            set
            {
                _isServerMode = value;
            }
        }

        public TestSettings()
        {
            InitializeComponent();
            ProjectState.ProjectSaving += new EventHandler(ProjectState_ProjectSaving);
        }

        public void SetDataSet(TestSettingsAdapter adapter)
        {
            _isInited = false;
            _adapter = adapter;
            tbTestName.Text = _adapter.TestName;
            cbIsActive.Checked = _adapter.IsActive;
            cbIsLimitedActive.Enabled = cbIsActive.Checked;
            cbAllowAdmitQuestions.Checked = adapter.AllowAdmitQuestions;
            cbShowTestResult.Checked = _adapter.ShowTestResult;
            cbShowDetailsTestResults.Checked = _adapter.ShowDetailsTestResult;
            cbShowRightAnswersCount.Checked = _adapter.ShowRightAnswersCount;
            cbVariantsMode.SelectedIndex = _adapter.VariantsMode;
            cbIsLimitedActive.Checked = (_adapter.BeginTime != DateTime.MinValue || _adapter.EndTime != DateTime.MinValue);
            if (!cbIsLimitedActive.Checked)
            {
                DateTime notDateTime = DateTime.Now;
                DateTime valueDateTime = new DateTime(notDateTime.Year, notDateTime.Month, notDateTime.Day, 0, 0, 0, 0);
                dtpTimeStart.Value = valueDateTime;
                dtpTimeEnd.Value = valueDateTime;
            }
            else
            {
                dtpTimeStart.Value = _adapter.BeginTime;
                dtpTimeEnd.Value = _adapter.EndTime;
            }
            tbDescription.Text = _adapter.Description;
            cbHasTimeLimit.Checked = (_adapter.TimeLimit != 0);
            nudTimeLimit.Value = _adapter.TimeLimit;
            cbPassagesNumber.Checked = (_adapter.PassagesNumber != 0);
            nudPassagesNumber.Value = _adapter.PassagesNumber;
            cbQuestionsNumber.Checked = (_adapter.QuestionsNumber != 0);
            nudQuestionsNumber.Value = _adapter.QuestionsNumber;
            cbPassingScore.Checked = (_adapter.PassingScore != 0);
            txtPassingScore.Text = _adapter.PassingScore.ToString();
            cbQuestionsNumber.Enabled = !_adapter.IsMasterTest;
            cbVariantsMode.Enabled = _adapter.IsMasterTest;
            _isInited = true;
        }

        void ProjectState_ProjectSaving(object sender, EventArgs e)
        {
            if (_adapter == null)
                return;
            tbTestName_Leave(null, new EventArgs());
            nudTimeLimit_ValueChanged(this, new EventArgs());
            nudPassagesNumber_ValueChanged(this, new EventArgs());
            nudQuestionsNumber_ValueChanged(this, new EventArgs());
            nudPassingScore_TextChanged(this, new EventArgs());
        }

        public void ProjectClosing()
        {
            ProjectState.ProjectSaving -= new EventHandler(ProjectState_ProjectSaving);
        }

        private void cbVariantsMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            _adapter.VariantsMode = cbVariantsMode.SelectedIndex;
        }

        private void cbIsActive_CheckedChanged(object sender, EventArgs e)
        {
            _adapter.IsActive = cbIsActive.Checked;
            cbIsLimitedActive.Enabled = cbIsActive.Checked;
            dtpTimeStart.Enabled = (cbIsLimitedActive.Checked && cbIsActive.Checked);
            dtpTimeEnd.Enabled = (cbIsLimitedActive.Checked && cbIsActive.Checked);
        }

        private void cbIsLimitedActive_CheckedChanged(object sender, EventArgs e)
        {
            dtpTimeStart.Enabled = (cbIsLimitedActive.Checked && cbIsActive.Checked);
            dtpTimeEnd.Enabled = (cbIsLimitedActive.Checked && cbIsActive.Checked);
            if (!cbIsLimitedActive.Checked)
            {
                _adapter.BeginTime = DateTime.MinValue;
                _adapter.EndTime = DateTime.MinValue;
            }
            else
            {
                dtpTimeStart_ValueChanged(this, new EventArgs());
                dtpTimeEnd_ValueChanged(this, new EventArgs());
            }
        }

        private void dtpTimeStart_ValueChanged(object sender, EventArgs e)
        {
            if (_isInited && cbIsLimitedActive.Checked)
            {
                _adapter.BeginTime = dtpTimeStart.Value;
            }
        }

        private void dtpTimeEnd_ValueChanged(object sender, EventArgs e)
        {
            if (_isInited && cbIsLimitedActive.Checked)
            {
                _adapter.EndTime = dtpTimeEnd.Value;
            }
        }

        private void cbAllowAdmitQuestions_CheckedChanged(object sender, EventArgs e)
        {
            _adapter.AllowAdmitQuestions = cbAllowAdmitQuestions.Checked;
        }

        private void cbShowTestResult_CheckedChanged(object sender, EventArgs e)
        {
            _adapter.ShowTestResult = cbShowTestResult.Checked;
            cbShowDetailsTestResults.Enabled = cbShowTestResult.Checked;
        }

        private void cbShowDetailsTestResults_CheckedChanged(object sender, EventArgs e)
        {
            _adapter.ShowDetailsTestResult = cbShowDetailsTestResults.Checked;
        }

        private void cbShowRightAnswersCount_CheckedChanged(object sender, EventArgs e)
        {
            _adapter.ShowRightAnswersCount = cbShowRightAnswersCount.Checked;
        }

        private void tbDescription_TextChanged(object sender, EventArgs e)
        {
            _adapter.Description = tbDescription.Text;
        }

        private void cbHasTimeLimit_CheckedChanged(object sender, EventArgs e)
        {
            nudTimeLimit.Enabled = cbHasTimeLimit.Checked;
            lbMinute.Enabled = nudTimeLimit.Enabled;
            nudPassagesNumber.Enabled = cbPassagesNumber.Checked;
            nudQuestionsNumber.Enabled = cbQuestionsNumber.Checked;
            txtPassingScore.Enabled = cbPassingScore.Checked;
            if (!cbHasTimeLimit.Checked)
                nudTimeLimit.Value = 0;
            if (!cbPassagesNumber.Checked)
                nudPassagesNumber.Value = 0;
            if (!cbQuestionsNumber.Checked)
                nudQuestionsNumber.Value = 0;
            if (!cbPassingScore.Checked)
                txtPassingScore.Text = "0";
        }

        private void nudTimeLimit_ValueChanged(object sender, EventArgs e)
        {
            _adapter.TimeLimit = (int)nudTimeLimit.Value;
        }

        private void nudPassagesNumber_ValueChanged(object sender, EventArgs e)
        {
            _adapter.PassagesNumber = (short)nudPassagesNumber.Value;
        }

        private void nudQuestionsNumber_ValueChanged(object sender, EventArgs e)
        {
            _adapter.QuestionsNumber = (short)nudQuestionsNumber.Value;
            nudQuestionsNumber.Value = _adapter.QuestionsNumber;
        }

        private void llAdditionalSettings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AdditionalSettingsForm adds = new AdditionalSettingsForm(_isServerMode, _adapter);
            adds.ShowDialog();
        }

        private void tbTestName_Leave(object sender, EventArgs e)
        {
            _adapter.TestName = tbTestName.Text;
            tbTestName.Text = _adapter.TestName;
        }

        private void tbTestName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                tbTestName_Leave(sender, new EventArgs());
        }

        private void nudPassingScore_TextChanged(object sender, EventArgs e)
        {
            string txt = txtPassingScore.Text.Trim();
            double value = 0;
            if (String.IsNullOrEmpty(txt) ||
                !double.TryParse(txt, NumberStyles.Any, CultureInfo.CurrentCulture.NumberFormat, out value))
            {
                txtPassingScore.Text = _adapter.PassingScore.ToString();
            }
            else if (cbPassingScore.Checked)
            {
                _adapter.PassingScore = value;
            }
        }
    }
}
