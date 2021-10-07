
namespace MISP_TAG
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.AttributeList = new System.Windows.Forms.ListBox();
            this.TagList = new System.Windows.Forms.ListBox();
            this.SelectedAttributeList = new System.Windows.Forms.ListBox();
            this.SelectedTagList = new System.Windows.Forms.ListBox();
            this.Data_Load = new System.Windows.Forms.Button();
            this.SelectAttributeAddButton = new System.Windows.Forms.Button();
            this.SelectedTagAddbutton = new System.Windows.Forms.Button();
            this.DatasetOutput = new System.Windows.Forms.Button();
            this.SelectTagRemovebutton = new System.Windows.Forms.Button();
            this.SelectAttributeRemovebutton = new System.Windows.Forms.Button();
            this.ConfigButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AttributeList
            // 
            this.AttributeList.FormattingEnabled = true;
            this.AttributeList.ItemHeight = 15;
            this.AttributeList.Location = new System.Drawing.Point(12, 58);
            this.AttributeList.Name = "AttributeList";
            this.AttributeList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.AttributeList.Size = new System.Drawing.Size(181, 379);
            this.AttributeList.TabIndex = 0;
            // 
            // TagList
            // 
            this.TagList.FormattingEnabled = true;
            this.TagList.ItemHeight = 15;
            this.TagList.Location = new System.Drawing.Point(501, 58);
            this.TagList.Name = "TagList";
            this.TagList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.TagList.Size = new System.Drawing.Size(181, 379);
            this.TagList.TabIndex = 1;
            // 
            // SelectedAttributeList
            // 
            this.SelectedAttributeList.FormattingEnabled = true;
            this.SelectedAttributeList.ItemHeight = 15;
            this.SelectedAttributeList.Location = new System.Drawing.Point(249, 58);
            this.SelectedAttributeList.Name = "SelectedAttributeList";
            this.SelectedAttributeList.Size = new System.Drawing.Size(181, 379);
            this.SelectedAttributeList.TabIndex = 2;
            // 
            // SelectedTagList
            // 
            this.SelectedTagList.FormattingEnabled = true;
            this.SelectedTagList.ItemHeight = 15;
            this.SelectedTagList.Location = new System.Drawing.Point(735, 58);
            this.SelectedTagList.Name = "SelectedTagList";
            this.SelectedTagList.Size = new System.Drawing.Size(181, 379);
            this.SelectedTagList.TabIndex = 3;
            // 
            // Data_Load
            // 
            this.Data_Load.Location = new System.Drawing.Point(688, 12);
            this.Data_Load.Name = "Data_Load";
            this.Data_Load.Size = new System.Drawing.Size(121, 24);
            this.Data_Load.TabIndex = 4;
            this.Data_Load.Text = "MISPデータ読み込み";
            this.Data_Load.UseVisualStyleBackColor = true;
            this.Data_Load.Click += new System.EventHandler(this.Data_Load_Click);
            // 
            // SelectAttributeAddButton
            // 
            this.SelectAttributeAddButton.Location = new System.Drawing.Point(199, 161);
            this.SelectAttributeAddButton.Name = "SelectAttributeAddButton";
            this.SelectAttributeAddButton.Size = new System.Drawing.Size(44, 28);
            this.SelectAttributeAddButton.TabIndex = 5;
            this.SelectAttributeAddButton.Text = ">>";
            this.SelectAttributeAddButton.UseVisualStyleBackColor = true;
            this.SelectAttributeAddButton.Click += new System.EventHandler(this.SelectAttributeAddButton_Click);
            // 
            // SelectedTagAddbutton
            // 
            this.SelectedTagAddbutton.Location = new System.Drawing.Point(688, 163);
            this.SelectedTagAddbutton.Name = "SelectedTagAddbutton";
            this.SelectedTagAddbutton.Size = new System.Drawing.Size(41, 28);
            this.SelectedTagAddbutton.TabIndex = 6;
            this.SelectedTagAddbutton.Text = ">>";
            this.SelectedTagAddbutton.UseVisualStyleBackColor = true;
            this.SelectedTagAddbutton.Click += new System.EventHandler(this.SelectedTagAddbutton_Click);
            // 
            // DatasetOutput
            // 
            this.DatasetOutput.Location = new System.Drawing.Point(815, 12);
            this.DatasetOutput.Name = "DatasetOutput";
            this.DatasetOutput.Size = new System.Drawing.Size(104, 25);
            this.DatasetOutput.TabIndex = 7;
            this.DatasetOutput.Text = "データセット出力";
            this.DatasetOutput.UseVisualStyleBackColor = true;
            this.DatasetOutput.Click += new System.EventHandler(this.DatasetOutput_Click);
            // 
            // SelectTagRemovebutton
            // 
            this.SelectTagRemovebutton.Location = new System.Drawing.Point(688, 244);
            this.SelectTagRemovebutton.Name = "SelectTagRemovebutton";
            this.SelectTagRemovebutton.Size = new System.Drawing.Size(40, 29);
            this.SelectTagRemovebutton.TabIndex = 8;
            this.SelectTagRemovebutton.Text = "<<";
            this.SelectTagRemovebutton.UseVisualStyleBackColor = true;
            this.SelectTagRemovebutton.Click += new System.EventHandler(this.SelectTagRemovebutton_Click);
            // 
            // SelectAttributeRemovebutton
            // 
            this.SelectAttributeRemovebutton.Location = new System.Drawing.Point(199, 244);
            this.SelectAttributeRemovebutton.Name = "SelectAttributeRemovebutton";
            this.SelectAttributeRemovebutton.Size = new System.Drawing.Size(44, 29);
            this.SelectAttributeRemovebutton.TabIndex = 9;
            this.SelectAttributeRemovebutton.Text = "<<";
            this.SelectAttributeRemovebutton.UseVisualStyleBackColor = true;
            this.SelectAttributeRemovebutton.Click += new System.EventHandler(this.SelectAttributeRemovebutton_Click);
            // 
            // ConfigButton
            // 
            this.ConfigButton.Location = new System.Drawing.Point(581, 12);
            this.ConfigButton.Name = "ConfigButton";
            this.ConfigButton.Size = new System.Drawing.Size(101, 23);
            this.ConfigButton.TabIndex = 10;
            this.ConfigButton.Text = "設定";
            this.ConfigButton.UseVisualStyleBackColor = true;
            this.ConfigButton.Click += new System.EventHandler(this.ConfigButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 458);
            this.Controls.Add(this.ConfigButton);
            this.Controls.Add(this.SelectAttributeRemovebutton);
            this.Controls.Add(this.SelectTagRemovebutton);
            this.Controls.Add(this.DatasetOutput);
            this.Controls.Add(this.SelectedTagAddbutton);
            this.Controls.Add(this.SelectAttributeAddButton);
            this.Controls.Add(this.Data_Load);
            this.Controls.Add(this.SelectedTagList);
            this.Controls.Add(this.SelectedAttributeList);
            this.Controls.Add(this.TagList);
            this.Controls.Add(this.AttributeList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "MISParser";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox AttributeList;
        private System.Windows.Forms.ListBox TagList;
        private System.Windows.Forms.ListBox SelectedAttributeList;
        private System.Windows.Forms.ListBox SelectedTagList;
        private System.Windows.Forms.Button Data_Load;
        private System.Windows.Forms.Button SelectAttributeAddButton;
        private System.Windows.Forms.Button SelectedTagAddbutton;
        private System.Windows.Forms.Button DatasetOutput;
        private System.Windows.Forms.Button SelectTagRemovebutton;
        private System.Windows.Forms.Button SelectAttributeRemovebutton;
        private System.Windows.Forms.Button ConfigButton;
    }
}

