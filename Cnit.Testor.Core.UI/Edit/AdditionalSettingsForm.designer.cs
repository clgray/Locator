namespace Cnit.Testor.Core.UI.Edit
{
    partial class AdditionalSettingsForm
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
            this.tabPageReq = new System.Windows.Forms.TabPage();
            this.buttonAddReq = new System.Windows.Forms.Button();
            this.clbAddSettings = new System.Windows.Forms.CheckedListBox();
            this.lblReq = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabPageReq.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPageReq
            // 
            this.tabPageReq.Controls.Add(this.buttonAddReq);
            this.tabPageReq.Controls.Add(this.clbAddSettings);
            this.tabPageReq.Controls.Add(this.lblReq);
            this.tabPageReq.Location = new System.Drawing.Point(4, 22);
            this.tabPageReq.Name = "tabPageReq";
            this.tabPageReq.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageReq.Size = new System.Drawing.Size(500, 421);
            this.tabPageReq.TabIndex = 0;
            this.tabPageReq.Text = "Зависимости";
            this.tabPageReq.UseVisualStyleBackColor = true;
            // 
            // buttonAddReq
            // 
            this.buttonAddReq.Location = new System.Drawing.Point(383, 6);
            this.buttonAddReq.Name = "buttonAddReq";
            this.buttonAddReq.Size = new System.Drawing.Size(112, 23);
            this.buttonAddReq.TabIndex = 2;
            this.buttonAddReq.Text = "Добавить тесты...";
            this.buttonAddReq.UseVisualStyleBackColor = true;
            this.buttonAddReq.Click += new System.EventHandler(this.buttonAddReq_Click);
            // 
            // clbAddSettings
            // 
            this.clbAddSettings.CheckOnClick = true;
            this.clbAddSettings.FormattingEnabled = true;
            this.clbAddSettings.Location = new System.Drawing.Point(9, 34);
            this.clbAddSettings.Name = "clbAddSettings";
            this.clbAddSettings.ScrollAlwaysVisible = true;
            this.clbAddSettings.Size = new System.Drawing.Size(485, 379);
            this.clbAddSettings.TabIndex = 1;
            // 
            // lblReq
            // 
            this.lblReq.AutoSize = true;
            this.lblReq.Location = new System.Drawing.Point(6, 11);
            this.lblReq.Name = "lblReq";
            this.lblReq.Size = new System.Drawing.Size(228, 13);
            this.lblReq.TabIndex = 0;
            this.lblReq.Text = "Для прохождения теста необходимо сдать:";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageReq);
            this.tabControl.Location = new System.Drawing.Point(3, 2);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(508, 447);
            this.tabControl.TabIndex = 0;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(355, 455);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(436, 455);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // AdditionalSettingsForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(514, 486);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdditionalSettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Дополнительные настройки";
            this.tabPageReq.ResumeLayout(false);
            this.tabPageReq.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPageReq;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblReq;
        private System.Windows.Forms.CheckedListBox clbAddSettings;
        private System.Windows.Forms.Button buttonAddReq;
    }
}