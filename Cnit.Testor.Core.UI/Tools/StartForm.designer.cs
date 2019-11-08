namespace Cnit.Testor.Core.UI
{
    partial class StartForm
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
            this.panelContent = new System.Windows.Forms.Panel();
            this.llCreateFromWord = new System.Windows.Forms.LinkLabel();
            this.llGoToTestor = new System.Windows.Forms.LinkLabel();
            this.llOpenProject = new System.Windows.Forms.LinkLabel();
            this.llCreateProject = new System.Windows.Forms.LinkLabel();
            this.panel = new System.Windows.Forms.Panel();
            this.pictureBoxMain = new System.Windows.Forms.PictureBox();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.panelContent.SuspendLayout();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContent
            // 
            this.panelContent.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelContent.Controls.Add(this.llCreateFromWord);
            this.panelContent.Controls.Add(this.llGoToTestor);
            this.panelContent.Controls.Add(this.llOpenProject);
            this.panelContent.Controls.Add(this.llCreateProject);
            this.panelContent.Controls.Add(this.pictureBoxMain);
            this.panelContent.Location = new System.Drawing.Point(195, 190);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(501, 224);
            this.panelContent.TabIndex = 1;
            // 
            // llCreateFromWord
            // 
            this.llCreateFromWord.AutoSize = true;
            this.llCreateFromWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.llCreateFromWord.Location = new System.Drawing.Point(149, 135);
            this.llCreateFromWord.Name = "llCreateFromWord";
            this.llCreateFromWord.Size = new System.Drawing.Size(290, 20);
            this.llCreateFromWord.TabIndex = 2;
            this.llCreateFromWord.TabStop = true;
            this.llCreateFromWord.Text = "Создать проект из Word документов";
            this.llCreateFromWord.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llCreateFromWord_LinkClicked);
            // 
            // llGoToTestor
            // 
            this.llGoToTestor.AutoSize = true;
            this.llGoToTestor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.llGoToTestor.Location = new System.Drawing.Point(149, 162);
            this.llGoToTestor.Name = "llGoToTestor";
            this.llGoToTestor.Size = new System.Drawing.Size(225, 20);
            this.llGoToTestor.TabIndex = 3;
            this.llGoToTestor.TabStop = true;
            this.llGoToTestor.Text = "Перейти на сайт программы";
            this.llGoToTestor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelGoToTestor_LinkClicked);
            // 
            // llOpenProject
            // 
            this.llOpenProject.AutoSize = true;
            this.llOpenProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.llOpenProject.Location = new System.Drawing.Point(149, 80);
            this.llOpenProject.Name = "llOpenProject";
            this.llOpenProject.Size = new System.Drawing.Size(133, 20);
            this.llOpenProject.TabIndex = 0;
            this.llOpenProject.TabStop = true;
            this.llOpenProject.Text = "Открыть проект";
            this.llOpenProject.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelOpenProject_LinkClicked);
            // 
            // llCreateProject
            // 
            this.llCreateProject.AutoSize = true;
            this.llCreateProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.llCreateProject.Location = new System.Drawing.Point(149, 107);
            this.llCreateProject.Name = "llCreateProject";
            this.llCreateProject.Size = new System.Drawing.Size(299, 20);
            this.llCreateProject.TabIndex = 1;
            this.llCreateProject.TabStop = true;
            this.llCreateProject.Text = "Создать новый проект (набор тестов)";
            this.llCreateProject.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelCreateProject_LinkClicked);
            // 
            // panel
            // 
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel.Controls.Add(this.pictureBoxLogo);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(891, 605);
            this.panel.TabIndex = 2;
            // 
            // pictureBoxMain
            // 
            this.pictureBoxMain.Image = global::Cnit.Testor.Core.UI.Properties.Resources.Image;
            this.pictureBoxMain.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxMain.Name = "pictureBoxMain";
            this.pictureBoxMain.Size = new System.Drawing.Size(488, 216);
            this.pictureBoxMain.TabIndex = 2;
            this.pictureBoxMain.TabStop = false;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxLogo.Image = global::Cnit.Testor.Core.UI.Properties.Resources.logo;
            this.pictureBoxLogo.Location = new System.Drawing.Point(488, 3);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(396, 143);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 3;
            this.pictureBoxLogo.TabStop = false;
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(891, 605);
            this.ControlBox = false;
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StartForm";
            this.Text = "Стартовая страница";
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.LinkLabel llGoToTestor;
        private System.Windows.Forms.LinkLabel llOpenProject;
        private System.Windows.Forms.LinkLabel llCreateProject;
        private System.Windows.Forms.PictureBox pictureBoxMain;
        private System.Windows.Forms.LinkLabel llCreateFromWord;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.PictureBox pictureBoxLogo;

    }
}