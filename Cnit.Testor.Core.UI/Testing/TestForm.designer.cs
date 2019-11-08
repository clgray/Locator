namespace Cnit.Testor.Core.UI.Testing
{
    partial class TestForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.testingHost = new Cnit.Testor.Core.UI.Testing.TestingHost();
			this.SuspendLayout();
			// 
			// testingHost
			// 
			this.testingHost.Dock = System.Windows.Forms.DockStyle.Fill;
			this.testingHost.Location = new System.Drawing.Point(0, 0);
			this.testingHost.Name = "testingHost";
			this.testingHost.Size = new System.Drawing.Size(964, 451);
			this.testingHost.TabIndex = 0;
			// 
			// TestForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(964, 451);
			this.Controls.Add(this.testingHost);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MinimizeBox = false;
			this.Name = "TestForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Тестирование";
			this.TopMost = true;
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TestHtmlContentForm_FormClosing);
			this.ResumeLayout(false);

        }

        #endregion

		private TestingHost testingHost;

	}
}