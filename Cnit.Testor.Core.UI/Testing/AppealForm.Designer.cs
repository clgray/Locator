namespace Cnit.Testor.Core.UI
{
    partial class AppealForm
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
			  System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppealForm));
			  this.toolStrip = new System.Windows.Forms.ToolStrip();
			  this.tsbBackQuest = new System.Windows.Forms.ToolStripButton();
			  this.tsbForwardQuest = new System.Windows.Forms.ToolStripButton();
			  this.panel = new System.Windows.Forms.Panel();
			  this.webBrowser = new System.Windows.Forms.WebBrowser();
			  this.toolStrip.SuspendLayout();
			  this.panel.SuspendLayout();
			  this.SuspendLayout();
			  // 
			  // toolStrip
			  // 
			  this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbBackQuest,
            this.tsbForwardQuest});
			  this.toolStrip.Location = new System.Drawing.Point(0, 0);
			  this.toolStrip.Name = "toolStrip";
			  this.toolStrip.Size = new System.Drawing.Size(884, 25);
			  this.toolStrip.TabIndex = 1;
			  this.toolStrip.Text = "toolStrip1";
			  // 
			  // tsbBackQuest
			  // 
			  this.tsbBackQuest.Image = ((System.Drawing.Image) (resources.GetObject("tsbBackQuest.Image")));
			  this.tsbBackQuest.ImageTransparentColor = System.Drawing.Color.Magenta;
			  this.tsbBackQuest.Name = "tsbBackQuest";
			  this.tsbBackQuest.Size = new System.Drawing.Size(144, 22);
			  this.tsbBackQuest.Text = "Предыдущий вопрос";
			  this.tsbBackQuest.Click += new System.EventHandler(this.tsbBackQuest_Click);
			  // 
			  // tsbForwardQuest
			  // 
			  this.tsbForwardQuest.Image = ((System.Drawing.Image) (resources.GetObject("tsbForwardQuest.Image")));
			  this.tsbForwardQuest.ImageTransparentColor = System.Drawing.Color.Magenta;
			  this.tsbForwardQuest.Name = "tsbForwardQuest";
			  this.tsbForwardQuest.Size = new System.Drawing.Size(138, 22);
			  this.tsbForwardQuest.Text = "Следующий вопрос";
			  this.tsbForwardQuest.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			  this.tsbForwardQuest.Click += new System.EventHandler(this.tsbForwardQuest_Click);
			  // 
			  // panel
			  // 
			  this.panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			  this.panel.Controls.Add(this.webBrowser);
			  this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
			  this.panel.Location = new System.Drawing.Point(0, 25);
			  this.panel.Name = "panel";
			  this.panel.Size = new System.Drawing.Size(884, 452);
			  this.panel.TabIndex = 2;
			  // 
			  // webBrowser
			  // 
			  this.webBrowser.AllowWebBrowserDrop = false;
			  this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
			  this.webBrowser.IsWebBrowserContextMenuEnabled = false;
			  this.webBrowser.Location = new System.Drawing.Point(0, 0);
			  this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
			  this.webBrowser.Name = "webBrowser";
			  this.webBrowser.Size = new System.Drawing.Size(880, 448);
			  this.webBrowser.TabIndex = 0;
			  this.webBrowser.WebBrowserShortcutsEnabled = false;
			  // 
			  // AppealForm
			  // 
			  this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			  this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			  this.ClientSize = new System.Drawing.Size(884, 477);
			  this.Controls.Add(this.panel);
			  this.Controls.Add(this.toolStrip);
			  this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
			  this.MaximizeBox = false;
			  this.MinimizeBox = false;
			  this.Name = "AppealForm";
			  this.ShowInTaskbar = false;
			  this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			  this.Text = "Апеляция";
			  this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AppealForm_FormClosed);
			  this.toolStrip.ResumeLayout(false);
			  this.toolStrip.PerformLayout();
			  this.panel.ResumeLayout(false);
			  this.ResumeLayout(false);
			  this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tsbBackQuest;
        private System.Windows.Forms.ToolStripButton tsbForwardQuest;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.WebBrowser webBrowser;


    }
}