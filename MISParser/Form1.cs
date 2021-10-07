using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MISP_JsonToDatasets;
using System.IO;
using System.Text.Json;

namespace MISP_TAG
{
    public partial class Form1 : Form
    {
        //フォームで参照する設定情報
        SettingOptions settingOption = new SettingOptions();
        MISP_json_Format misp;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            OptionLoad();
        }

        private void Data_Load_Click(object sender, EventArgs e)
        {
            //WEBのMISPDBから取る
            if (settingOption.GetMISPfromDB)
            {
            }
            //ローカルjsonファイルから取得
            else
            {
                if (File.Exists(settingOption.LocalMISPDataPath))
                {
                    try
                    {
                        misp = MISP_Data_load(settingOption.LocalMISPDataPath);
                        ListboxAdd(AttributeList, DataList_attributes(misp));
                        ListboxAdd(TagList, DataList_tags(misp));
                        MessageBox.Show("完了");
                    }
                    catch
                    {
                        MessageBox.Show("読み込み失敗");
                    }
                }
                else
                {
                    MessageBox.Show("ファイルが存在しません");
                }
            }
        }
        private static void ListboxAdd(ListBox box, List<string> list)
        {
            box.BeginUpdate();
            foreach (string txt in list) { box.Items.Add(txt); }
            box.EndUpdate();
        }
        private static MISP_json_Format MISP_Data_load(string path)
        {
            string json_text;

            using (StreamReader r = new StreamReader(path))
            {
                json_text = r.ReadToEnd();
            }
            return JsonSerializer.Deserialize<MISP_json_Format>(json_text);
        }
        private static List<string> DataList_attributes(MISP_json_Format misp)
        {
            List<String> AttriList = new List<string>();

            foreach (Response r in misp.response)
            {
                foreach (MISP_JsonToDatasets.Attribute a in r.Event.Attribute)
                {
                    if (!(AttriList.Contains(a.type))) { AttriList.Add(a.type); }
                }
            }
            return AttriList;
        }
        private static List<string> DataList_tags(MISP_json_Format misp)
        {
            List<String> TagList = new List<string>();

            foreach (Response r in misp.response)
            {
                foreach (Tag t in r.Event.Tag)
                {
                    if (!(TagList.Contains(t.name))) { TagList.Add(t.name); }
                }
            }
            return TagList;
        }

        private void DatasetOutput_Click(object sender, EventArgs e)
        {

            if (SelectedTagList.Items.Count != 0 && SelectedTagList.Items.Count != 0)
            {
                //csv出力
                Program.Output_Dataset(misp, SelectedAttributeList, SelectedTagList, settingOption);
            }
            else
            {
                MessageBox.Show("Error");
            }

            MessageBox.Show("完成");
        }
        private static List<string> ListBoxSelectedToList(ListBox listbox)
        {
            List<string> list = new List<string>();
            foreach (string s in listbox.SelectedItems) { list.Add(s); }
            return list;
        }



        //設定フォーム開く
        private void ConfigButton_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.MainForm = this;
            f2.SetOption(settingOption);
            f2.ShowDialog();
        }
 
        //前回の設定情報読み取り
        private void OptionLoad()
        {
            string inifilepath = @"./setting.ini";
            if (File.Exists(inifilepath))
            {
                try
                {
                    List<string> loadOption = new List<string>();
                    using (StreamReader r = new StreamReader(inifilepath))
                    {
                        string line;
                        for (int i = 0; (line = r.ReadLine()) != null; i++)
                        {
                            string[] tmp = line.Split('=');
                            loadOption.Add(tmp[1]);
                        }
                        settingOption.SetOption(loadOption);

                    }
                }
                catch
                {
                    settingOption.GetWhoisData = false;
                    settingOption.GetMISPfromDB = false;
                    settingOption.LocalMISPDataPath = @".\MISP\misp.json.ADMIN.json";
                }

            }
            else
            {
                settingOption.GetWhoisData = false;
                settingOption.GetMISPfromDB = false;
                settingOption.LocalMISPDataPath = @".\MISP\misp.json.ADMIN.json";
            }

        }
        //設定フォームからの変更受け取り
        public void OptionModify(SettingOptions so)
        {
            this.settingOption = so;
            OptionOverwrite();
            MessageBox.Show("変更が保存されました");
        }
        //設定情報更新
        private void OptionOverwrite()
        {
            string inifilepath = @"./setting.ini";
            using (StreamWriter w = new StreamWriter(inifilepath))
            {
                w.WriteLine(String.Join("=", "GetMISPfromDB", settingOption.GetMISPfromDB.ToString()));
                w.WriteLine(String.Join("=", "LocalMISPDataPath", settingOption.LocalMISPDataPath));
                w.WriteLine(String.Join("=", "GetMISPfromDBURL", settingOption.GetMISPfromDBURL));
                w.WriteLine(String.Join("=", "GetMISPDBApi", settingOption.GetMISPDBApi));
                w.WriteLine(String.Join("=", "Options", settingOption.Options.ToString()));
                w.WriteLine(String.Join("=", "GetWhoisData", settingOption.GetWhoisData.ToString()));
                w.WriteLine(String.Join("=", "VT", settingOption.VT.ToString()));
                w.WriteLine(String.Join("=", "VTApi", settingOption.VTApi));
            }

        }


        // 【<<】ボタンクリック時の動作
        private void SelectAttributeRemovebutton_Click(object sender, EventArgs e)
        {
            SelectListRemove(SelectedAttributeList);
        }
        private void SelectTagRemovebutton_Click(object sender, EventArgs e)
        {
            SelectListRemove(SelectedTagList);
        }
        private void SelectListRemove(ListBox listbox)
        {
            List<string> selectedItems = ListBoxSelectedToList(listbox);
            foreach (string list in selectedItems) { listbox.Items.Remove(list); }
        }
        // 【<<】ボタンクリック時の動作　ここまで

        // 【>>】ボタンクリック時の動作
        private void SelectAttributeAddButton_Click(object sender, EventArgs e)
        {
            SelectListAdd(AttributeList, SelectedAttributeList);
        }
        private void SelectListAdd(ListBox selectbox, ListBox addbox)
        {
            List<string> datalist = new List<string>();
            foreach (string s in addbox.Items) { datalist.Add(s); }
            foreach (string s in selectbox.SelectedItems) { if (!(datalist.Contains(s))) { datalist.Add(s); } }
            addbox.Items.Clear();
            ListboxAdd(addbox, datalist);
            selectbox.SelectedItems.Clear();
        }
        private void SelectedTagAddbutton_Click(object sender, EventArgs e)
        {
            SelectListAdd(TagList, SelectedTagList);
        }



        // 【>>】ボタンクリック時の動作　ここまで
    }
}
