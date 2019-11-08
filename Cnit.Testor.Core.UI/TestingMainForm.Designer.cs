using Cnit.Testor.Core;
using System;
namespace Cnit.Testor.Core.UI
{
    partial class TestingMainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestingMainForm));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.lblTestSystem = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabelTime = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabelDate = new System.Windows.Forms.ToolStripLabel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTestSystem,
            this.toolStripLabelTime,
            this.toolStripSeparator1,
            this.toolStripLabelDate});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip.ShowItemToolTips = false;
            this.toolStrip.Size = new System.Drawing.Size(829, 28);
            this.toolStrip.TabIndex = 7;
            // 
            // lblTestSystem
            // 
            this.lblTestSystem.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblTestSystem.Margin = new System.Windows.Forms.Padding(0, 4, 4, 4);
            this.lblTestSystem.Name = "lblTestSystem";
            this.lblTestSystem.Size = new System.Drawing.Size(0, 20);
            // 
            // toolStripLabelTime
            // 
            this.toolStripLabelTime.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabelTime.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.toolStripLabelTime.Name = "toolStripLabelTime";
            this.toolStripLabelTime.Size = new System.Drawing.Size(80, 25);
            this.toolStripLabelTime.Text = "00:00:00";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripLabelDate
            // 
            this.toolStripLabelDate.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabelDate.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.toolStripLabelDate.Name = "toolStripLabelDate";
            this.toolStripLabelDate.Size = new System.Drawing.Size(63, 25);
            this.toolStripLabelDate.Text = "[Date]";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 543);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(829, 22);
            this.statusStrip.TabIndex = 9;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(565, 17);
            this.toolStripStatusLabel.Text = "Copyright © 2007-2009 Московский государственный университет приборостроения и ин" +
                "форматики";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Cnit.Testor.Core.UI.Properties.Resources.Aurora1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(829, 565);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.Text = "TestorCore 2.1 Copyright © 2008-2009";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripLabel lblTestSystem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripLabel toolStripLabelTime;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabelDate;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;

    }
}

