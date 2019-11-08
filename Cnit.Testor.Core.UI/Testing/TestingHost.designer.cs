namespace Cnit.Testor.Core.UI.Testing
{
	partial class TestingHost
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestingHost));
            this.btnNext = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.labelStudentName = new System.Windows.Forms.Label();
            this.labelStudent = new System.Windows.Forms.Label();
            this.pbCalc = new System.Windows.Forms.PictureBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lblScore = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.lblTimeLimit = new System.Windows.Forms.ToolStripLabel();
            this.lblTestName = new System.Windows.Forms.ToolStripLabel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panelWeb = new System.Windows.Forms.Panel();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCalc)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.panelWeb.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNext.Location = new System.Drawing.Point(667, 15);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(156, 52);
            this.btnNext.TabIndex = 1;
            this.btnNext.TabStop = false;
            this.btnNext.Text = "NextQuestion";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            this.btnNext.Enter += new System.EventHandler(this.btnNext_Enter);
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.White;
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel.Controls.Add(this.labelStudentName);
            this.panel.Controls.Add(this.labelStudent);
            this.panel.Controls.Add(this.pbCalc);
            this.panel.Controls.Add(this.btnSubmit);
            this.panel.Controls.Add(this.btnNext);
            this.panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel.Location = new System.Drawing.Point(0, 482);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(844, 82);
            this.panel.TabIndex = 4;
            // 
            // labelStudentName
            // 
            this.labelStudentName.AutoSize = true;
            this.labelStudentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelStudentName.Location = new System.Drawing.Point(70, 39);
            this.labelStudentName.Name = "labelStudentName";
            this.labelStudentName.Size = new System.Drawing.Size(135, 24);
            this.labelStudentName.TabIndex = 5;
            this.labelStudentName.Text = "[StudentName]";
            this.labelStudentName.Visible = false;
            // 
            // labelStudent
            // 
            this.labelStudent.AutoSize = true;
            this.labelStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelStudent.Location = new System.Drawing.Point(70, 15);
            this.labelStudent.Name = "labelStudent";
            this.labelStudent.Size = new System.Drawing.Size(91, 24);
            this.labelStudent.TabIndex = 4;
            this.labelStudent.Text = "Студент:";
            this.labelStudent.Visible = false;
            // 
            // pbCalc
            // 
            this.pbCalc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbCalc.Image = ((System.Drawing.Image)(resources.GetObject("pbCalc.Image")));
            this.pbCalc.Location = new System.Drawing.Point(16, 15);
            this.pbCalc.Name = "pbCalc";
            this.pbCalc.Size = new System.Drawing.Size(48, 48);
            this.pbCalc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbCalc.TabIndex = 3;
            this.pbCalc.TabStop = false;
            this.pbCalc.Visible = false;
            this.pbCalc.Click += new System.EventHandler(this.pbCalc_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSubmit.Image = ((System.Drawing.Image)(resources.GetObject("btnSubmit.Image")));
            this.btnSubmit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSubmit.Location = new System.Drawing.Point(505, 15);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(156, 52);
            this.btnSubmit.TabIndex = 2;
            this.btnSubmit.TabStop = false;
            this.btnSubmit.Text = "Ответить";
            this.btnSubmit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Visible = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            this.btnSubmit.Enter += new System.EventHandler(this.btnNext_Enter);
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExit,
            this.toolStripSeparator1,
            this.lblScore,
            this.toolStripSeparator,
            this.lblTimeLimit,
            this.lblTestName});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip.ShowItemToolTips = false;
            this.toolStrip.Size = new System.Drawing.Size(844, 32);
            this.toolStrip.TabIndex = 6;
            // 
            // btnExit
            // 
            this.btnExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(27, 29);
            this.btnExit.Text = "Х";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 32);
            // 
            // lblScore
            // 
            this.lblScore.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblScore.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(66, 29);
            this.lblScore.Text = "[Score]";
            this.lblScore.Visible = false;
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 32);
            this.toolStripSeparator.Visible = false;
            // 
            // lblTimeLimit
            // 
            this.lblTimeLimit.ActiveLinkColor = System.Drawing.Color.Red;
            this.lblTimeLimit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblTimeLimit.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.lblTimeLimit.ForeColor = System.Drawing.Color.Black;
            this.lblTimeLimit.Name = "lblTimeLimit";
            this.lblTimeLimit.Size = new System.Drawing.Size(98, 29);
            this.lblTimeLimit.Text = "[TimeLimit]";
            this.lblTimeLimit.Visible = false;
            // 
            // lblTestName
            // 
            this.lblTestName.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.lblTestName.Name = "lblTestName";
            this.lblTestName.Size = new System.Drawing.Size(101, 29);
            this.lblTestName.Text = "[TestName]";
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // panelWeb
            // 
            this.panelWeb.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelWeb.Controls.Add(this.webBrowser);
            this.panelWeb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWeb.Location = new System.Drawing.Point(0, 32);
            this.panelWeb.Name = "panelWeb";
            this.panelWeb.Size = new System.Drawing.Size(844, 450);
            this.panelWeb.TabIndex = 7;
            // 
            // webBrowser
            // 
            this.webBrowser.AllowWebBrowserDrop = false;
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser.Location = new System.Drawing.Point(0, 0);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(840, 446);
            this.webBrowser.TabIndex = 8;
            this.webBrowser.WebBrowserShortcutsEnabled = false;
            this.webBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser_DocumentCompleted);
            // 
            // TestingHost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelWeb);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.panel);
            this.DoubleBuffered = true;
            this.Name = "TestingHost";
            this.Size = new System.Drawing.Size(844, 564);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCalc)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.panelWeb.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnSubmit;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Panel panel;
		private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripLabel lblScore;
		private System.Windows.Forms.ToolStripLabel lblTimeLimit;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Panel panelWeb;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.ToolStripLabel lblTestName;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.PictureBox pbCalc;
        private System.Windows.Forms.Label labelStudent;
        private System.Windows.Forms.Label labelStudentName;
	}
}
