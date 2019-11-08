using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cnit.Testor.Core.UI.Edit;

namespace Cnit.Testor.Core.UI
{
    public partial class StartForm: Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void linkLabelCreateProject_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProjectState.CreateProject();
        }

        private void linkLabelOpenProject_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProjectState.OpenProject();
        }

        private void linkLabelGoToTestor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try { System.Diagnostics.Process.Start("http://beta.testor.ru/testedit"); }
            catch { }
        }

        private void llCreateFromWord_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProjectState.CreateProjectFromWord();
        }
    }
}
