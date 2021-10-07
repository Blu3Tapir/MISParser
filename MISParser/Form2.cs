using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MISP_TAG
{
    public partial class Form2 : Form
    {
        public Form1 MainForm;
        public SettingOptions settingOption;
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            Set_From2();
            Set_SettingOptions();
        }
        private void Set_From2()
        {
            MISPLoadPath.Items.Add("local File(Json)");
        }

        //Form2呼び出し時の設定反映
        private void Set_SettingOptions()
        {
            if (settingOption.GetMISPfromDB) 
            { 
                SelectLoadMISPDatabase();
                InputPath.Text = this.settingOption.GetMISPfromDBURL;
            }
            else 
            {
                SelectLoadLocalFile();
                InputPath.Text = this.settingOption.LocalMISPDataPath;
            }
            OptionCheckbox.Checked = this.settingOption.Options;
            if (this.settingOption.Options)
            {
                GetWhoisCheckbox.Checked = this.settingOption.GetWhoisData ;
                GetVirustotalCheckbox.Checked = this.settingOption.VT;
                VirustotalAPIKey.Text = this.settingOption.VTApi;
            }
            else
            {
                GetWhoisCheckbox.Checked = false; ;
                GetVirustotalCheckbox.Checked = false;
                VirustotalAPIKey.Text = "";
            }

        }


        public void SetOption(SettingOptions so)
        {
            this.settingOption = so;
        }

        private void SettingModify()
        {
            if (String.Equals(MISPLoadPath.SelectedItem, "MISP Server")) 
            {
                this.settingOption.GetMISPfromDB = true;
                this.settingOption.GetMISPfromDBURL = InputPath.Text;

            }
            if (String.Equals(MISPLoadPath.SelectedItem, "local File(Json)")) 
            {
                this.settingOption.GetMISPfromDB = false;
                this.settingOption.LocalMISPDataPath = InputPath.Text;
            }

            this.settingOption.Options = OptionCheckbox.Checked;
            if (this.settingOption.Options)
            {
                this.settingOption.GetWhoisData = GetWhoisCheckbox.Checked;
                this.settingOption.VT = GetVirustotalCheckbox.Checked;
                this.settingOption.VTApi = VirustotalAPIKey.Text;

            }
            else
            {
                this.settingOption.GetWhoisData = false;
                this.settingOption.VT = false;
                this.settingOption.VTApi = "";

            }
        }

        private void SettingModifyButton_Click(object sender, EventArgs e)
        {
            SettingModify();
            if(MainForm != null)
            {
                MainForm.OptionModify(settingOption);
            }
            this.Close();
        }
        private void SettingCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void MISPLoadPath_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (String.Equals(MISPLoadPath.SelectedItem, "MISP Server")) { SelectLoadMISPDatabase(); }
            if (String.Equals(MISPLoadPath.SelectedItem, "local File(Json)")) { SelectLoadLocalFile(); }
        }



        private void SelectLoadMISPDatabase()
        {
            MISPLoadPath.SelectedIndex = 1;
            InputPathInfo.Text = "MISP Database URI";
            InputPath.Text = settingOption.GetMISPfromDBURL;
            OptionCheck();
        }
        private void SelectLoadLocalFile()
        {
            MISPLoadPath.SelectedIndex = 0;
            InputPathInfo.Text = "File Path";
            InputPath.Text = settingOption.LocalMISPDataPath;
            OptionCheck();
        }
        private void OptionCheck()
        {
            if (OptionCheckbox.Checked)
            {
                GetWhoisCheckbox.Enabled = true;
                GetVirustotalCheckbox.Enabled = true;
                VirustotalAPIKey.Enabled = true;
            }
            else
            {
                GetWhoisCheckbox.Enabled = false;
                GetVirustotalCheckbox.Enabled = false;
                VirustotalAPIKey.Enabled = false;
            }
        }

        private void OptionCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            OptionCheck();
        }

    }
}
