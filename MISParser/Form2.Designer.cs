
namespace MISP_TAG
{
    partial class Form2
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
            this.SettingModifyButton = new System.Windows.Forms.Button();
            this.MISPLoadPath = new System.Windows.Forms.ComboBox();
            this.InputPath = new System.Windows.Forms.TextBox();
            this.InputPathInfo = new System.Windows.Forms.Label();
            this.OptionCheckbox = new System.Windows.Forms.CheckBox();
            this.GetWhoisCheckbox = new System.Windows.Forms.CheckBox();
            this.GetVirustotalCheckbox = new System.Windows.Forms.CheckBox();
            this.VirustotalAPIKey = new System.Windows.Forms.TextBox();
            this.SettingCancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SettingModifyButton
            // 
            this.SettingModifyButton.Location = new System.Drawing.Point(377, 234);
            this.SettingModifyButton.Name = "SettingModifyButton";
            this.SettingModifyButton.Size = new System.Drawing.Size(122, 29);
            this.SettingModifyButton.TabIndex = 0;
            this.SettingModifyButton.Text = "設定更新";
            this.SettingModifyButton.UseVisualStyleBackColor = true;
            this.SettingModifyButton.Click += new System.EventHandler(this.SettingModifyButton_Click);
            // 
            // MISPLoadPath
            // 
            this.MISPLoadPath.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MISPLoadPath.FormattingEnabled = true;
            this.MISPLoadPath.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MISPLoadPath.Location = new System.Drawing.Point(36, 61);
            this.MISPLoadPath.Name = "MISPLoadPath";
            this.MISPLoadPath.Size = new System.Drawing.Size(133, 23);
            this.MISPLoadPath.TabIndex = 1;
            this.MISPLoadPath.SelectedIndexChanged += new System.EventHandler(this.MISPLoadPath_SelectedIndexChanged);
            // 
            // InputPath
            // 
            this.InputPath.Location = new System.Drawing.Point(173, 61);
            this.InputPath.Name = "InputPath";
            this.InputPath.Size = new System.Drawing.Size(453, 23);
            this.InputPath.TabIndex = 2;
            // 
            // InputPathInfo
            // 
            this.InputPathInfo.AutoSize = true;
            this.InputPathInfo.Location = new System.Drawing.Point(175, 43);
            this.InputPathInfo.Name = "InputPathInfo";
            this.InputPathInfo.Size = new System.Drawing.Size(38, 15);
            this.InputPathInfo.TabIndex = 3;
            this.InputPathInfo.Text = "label1";
            // 
            // OptionCheckbox
            // 
            this.OptionCheckbox.AutoSize = true;
            this.OptionCheckbox.Location = new System.Drawing.Point(34, 99);
            this.OptionCheckbox.Name = "OptionCheckbox";
            this.OptionCheckbox.Size = new System.Drawing.Size(131, 19);
            this.OptionCheckbox.TabIndex = 6;
            this.OptionCheckbox.Text = "オプションを有効にする";
            this.OptionCheckbox.UseVisualStyleBackColor = true;
            this.OptionCheckbox.CheckedChanged += new System.EventHandler(this.OptionCheckbox_CheckedChanged);
            // 
            // GetWhoisCheckbox
            // 
            this.GetWhoisCheckbox.AutoSize = true;
            this.GetWhoisCheckbox.Location = new System.Drawing.Point(52, 124);
            this.GetWhoisCheckbox.Name = "GetWhoisCheckbox";
            this.GetWhoisCheckbox.Size = new System.Drawing.Size(199, 19);
            this.GetWhoisCheckbox.TabIndex = 7;
            this.GetWhoisCheckbox.Text = "国コードの取得 対象：ip-src,dst-ip";
            this.GetWhoisCheckbox.UseVisualStyleBackColor = true;
            // 
            // GetVirustotalCheckbox
            // 
            this.GetVirustotalCheckbox.AutoSize = true;
            this.GetVirustotalCheckbox.Location = new System.Drawing.Point(52, 149);
            this.GetVirustotalCheckbox.Name = "GetVirustotalCheckbox";
            this.GetVirustotalCheckbox.Size = new System.Drawing.Size(324, 19);
            this.GetVirustotalCheckbox.TabIndex = 8;
            this.GetVirustotalCheckbox.Text = "VirusTotal情報の取得 対象:sha256 （試作のため４件まで）";
            this.GetVirustotalCheckbox.UseVisualStyleBackColor = true;
            // 
            // VirustotalAPIKey
            // 
            this.VirustotalAPIKey.Location = new System.Drawing.Point(52, 193);
            this.VirustotalAPIKey.Name = "VirustotalAPIKey";
            this.VirustotalAPIKey.Size = new System.Drawing.Size(574, 23);
            this.VirustotalAPIKey.TabIndex = 9;
            // 
            // SettingCancelButton
            // 
            this.SettingCancelButton.Location = new System.Drawing.Point(506, 235);
            this.SettingCancelButton.Name = "SettingCancelButton";
            this.SettingCancelButton.Size = new System.Drawing.Size(124, 28);
            this.SettingCancelButton.TabIndex = 12;
            this.SettingCancelButton.Text = "キャンセル";
            this.SettingCancelButton.UseVisualStyleBackColor = true;
            this.SettingCancelButton.Click += new System.EventHandler(this.SettingCancelButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 15);
            this.label1.TabIndex = 13;
            this.label1.Text = "VirusTotal API Key";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 275);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SettingCancelButton);
            this.Controls.Add(this.VirustotalAPIKey);
            this.Controls.Add(this.GetVirustotalCheckbox);
            this.Controls.Add(this.GetWhoisCheckbox);
            this.Controls.Add(this.OptionCheckbox);
            this.Controls.Add(this.InputPathInfo);
            this.Controls.Add(this.InputPath);
            this.Controls.Add(this.MISPLoadPath);
            this.Controls.Add(this.SettingModifyButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Name = "Form2";
            this.Text = "設定";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SettingModifyButton;
        private System.Windows.Forms.ComboBox MISPLoadPath;
        private System.Windows.Forms.TextBox InputPath;
        private System.Windows.Forms.Label InputPathInfo;
        private System.Windows.Forms.CheckBox OptionCheckbox;
        private System.Windows.Forms.CheckBox GetWhoisCheckbox;
        private System.Windows.Forms.CheckBox GetVirustotalCheckbox;
        private System.Windows.Forms.TextBox VirustotalAPIKey;
        private System.Windows.Forms.Button SettingCancelButton;
        private System.Windows.Forms.Label label1;
    }
}