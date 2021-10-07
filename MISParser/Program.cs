using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MISP_JsonToDatasets;
using System.IO;
using GetCountryCode;
using System.Text.RegularExpressions;


namespace MISP_TAG
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        
        public static void Output_Dataset(MISP_json_Format misp,ListBox attributes,ListBox tags,SettingOptions settingoption)
        {
            List<datasets> tagdatasets = SelectTagCreate(misp,tags);

            List<datasetX> datasetX = new List<datasetX>();
            try
            {
                //�I�v�V�����ɂ��ǉ��f�[�^�擾
                datasetX = OptionDataX(misp, settingoption, attributes);
            }
            catch
            {
                MessageBox.Show("�O���f�[�^�̎�荞�݂Ɏ��s���܂����B\r\n�I�v�V�����𖳌��ɂ��܂��B");
                datasetX = new List<datasetX>();
            }

            //�o�͗p�t�H���_�쐬
            string FolderPath = CreateFolder();
            
            List<string> attriList = ListBoxToList(attributes);
            List<string> taglist = ListBoxToList(tags);
            
            //�f�[�^�o��
            Output(misp,FolderPath,attriList,tagdatasets);
            
            //�I�v�V�����ɂ��ǉ��f�[�^�o��
            if (datasetX != null)
            {
                OutputExternalData(FolderPath, datasetX, tagdatasets);
            }

            //�I�������\�[�X�A�^�O���L�^����t�@�C���쐬
            OutputIniFile(FolderPath,attriList, taglist);
            

        }


        private static List<datasets> SelectTagCreate(MISP_json_Format misp, ListBox tags)
        {
            List<datasets> taglist = new List<datasets>();
            List<string> tag = ListBoxToList(tags);
            foreach (Response r in misp.response)
            {
                int[] tagcolumn = new int[tags.Items.Count + 1];
                foreach (Tag t in r.Event.Tag)
                {
                    for(int i=0;i<tags.Items.Count;i++)
                    {
                        if (string.Equals(t.name, tag[i])){ tagcolumn[i] = 1;}
                    }
                }
                taglist.Add(new datasets(r.Event.id.ToString(), string.Join(",",tagcolumnToString(tagcolumn)))) ;
            }
            return taglist;
        }
        private static void OutputIniFile(string FolderPath,List<string> attriList,List<string> tagList)
        {
            //�ݒ�t�@�C���o�́i�������j
            //using (StreamWriter w = new StreamWriter(FolderPath + @"/DatasetSetting.ini"))
            //{
            //    w.WriteLine("�ysource�z");
            //    foreach (string str in attriList) { w.WriteLine(str); }
            //    w.WriteLine("�ytag�z");
            //    foreach (string str in tagList) { w.WriteLine(str); };
            //}

            //�o�͂����f�[�^�Z�b�g�̋L�ڌ`���t�@�C��
            string tag = "";
            foreach (string t in tagList) { tag = String.Join(",", tag, "Tag:"+t); }
            tag = String.Join(",",tag, "All Tag(OR):");

            using (StreamWriter w = new StreamWriter(FolderPath + @"/DatasetFormat.txt"))
            {
                foreach(string source in attriList)
                {
                    w.WriteLine(source + @".csv");
                    w.WriteLine(source + tag);
                }
            }
        }
        private static string[] tagcolumnToString(int[] tagcolumn)
        {
            string[] tags = new string[tagcolumn.Length];
            int or = 0;
            for (int i = 0; i < tagcolumn.Length; i++) { or = or ^ tagcolumn[i]; }
            tagcolumn[tagcolumn.Length - 1] = or;
            for (int i = 0; i < tagcolumn.Length; i++) { tags[i] = tagcolumn[i].ToString(); }
            return tags;
        }

        private static List<string> ListBoxToList(ListBox listbox)
        {
            List<string> list = new List<string>();
            foreach (string s in listbox.Items) { list.Add(s); }
            return list;
        }


        private static List<datasetX> OptionDataX(MISP_json_Format misp,SettingOptions so,ListBox attribute)
        {
            List<datasetX> datasetX = new List<datasetX>();
            List<string> types = new List<string>();
            List<string> attr = ListBoxToList(attribute);

            if (so.Options)
            {
                //Whois�����Ɏg�p����\�[�X
                string[] CountryCode = { "ip-src", "ip-dst" };
                //VirusTotal�����Ɏg�p����\�[�X
                string[] vt = { "sha256" };

                if (so.GetWhoisData)
                {
                    foreach (string t in CountryCode)
                    {
                        if (attr.Contains(t)) { types.Add(t); }
                    }
                }
                if (so.VT)
                {
                    foreach (string t in vt)
                    {
                        if (attr.Contains(t)) { types.Add(t); }
                    }
                }
                if (types != null)
                {
                    //MISP����̃f�[�^�擾
                    datasetX = MispToDatasetX(misp, types, datasetX);
                    //�O���f�[�^�擾
                    datasetX = GetData(datasetX, so);
                }
            }
            return datasetX;
        }
        private static List<datasetX> MispToDatasetX(MISP_json_Format misp, List<string> types, List<datasetX> datasetX)
        {
            foreach (Response r in misp.response)
            {
                foreach (MISP_JsonToDatasets.Attribute a in r.Event.Attribute)
                {
                    foreach (string type in types)
                    {
                        if (string.Equals(type, a.type)) { datasetX.Add(new datasetX(r.Event.id, type, a.value)); }
                    }
                }
            }
            return datasetX;
        }

        //�O���f�[�^�擾
        private static List<datasetX> GetData(List<datasetX> datasetX,SettingOptions so)
        {
            //Whois�����Ɏg�p����\�[�X
            string[] CountryCode = { "ip-src", "ip-dst" };
            //VirusTotal�����Ɏg�p����\�[�X
            string[] vt= {"sha256"};

            //������500�܂�
            int VTApiCount = 0;


            //CountoryCode
            List<TargetIP> targetIPs = new List<TargetIP>();
            Int64 datasetIndex = 0;
            //CountryCode���擾���邽�߂Ɉꗗ��WEB����擾����B
            List<IPRIR> RIRList = new List<IPRIR>();
            if (so.GetWhoisData) { RIRList = GetCountryCode.Program.SetRIRList(); }

            foreach (datasetX dataset in datasetX)
            {
                //CountoryCode�̎擾���K�v�ȃf�[�^�Z�b�g��targetIPList�Ɏ��[
                if (CountryCode.Contains(dataset.type) && so.GetWhoisData && Regex.IsMatch(dataset.plainX, @"^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$"))
                {
                    targetIPs.Add(new TargetIP(dataset.plainX,datasetIndex.ToString()));
                }
                //VirusTotalData�̎擾
                if (vt.Contains(dataset.type) && so.VT)
                {
                    if (VTApiCount >= 4)
                    {
                        dataset.SetExternalX("api limit,api limit");
                    }
                    else
                    {
                        //VT ����API�p�̃^�C�}�[�i�S�A�N�Z�X/���j
                        System.Threading.Thread.Sleep(15000);
                        try
                        {
                            //VT����f�[�^�擾
                            dataset.SetExternalX(GetVTDataResult(dataset.plainX, so.VTApi));
                            //dataset.SetExternalX("error");
                        }
                        catch
                        {
                            dataset.SetExternalX("error,error");
                        }
                        VTApiCount++;
                    }
                }
                datasetIndex++;
            }
            if(targetIPs != null)
            {
                targetIPs = GetCountryCode.Program.GetCountryCode(targetIPs, RIRList);
                foreach(TargetIP targetIP in targetIPs)
                {
                    datasetX[Convert.ToInt32(targetIP.datasetXID)].SetExternalX(targetIP.output());
                }
            }

            return datasetX;
        }


        //VirusTotal�f�[�^�擾������
        private static List<string> GetVTDataResult(string plainX, string vTApi)
        {
            List<string> result = ConsoleApp1.Program.GetVTData(vTApi,plainX);
            return result;
        }




        //�o�͗p�֐�
        private static string CreateFolder()
        {
            string path;
            string dt = DateTime.Now.ToString().Replace(" ", "").Replace(@"/", "").Replace(":", "");
            path = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            path = path + @"\Dataset_" + dt;
            Directory.CreateDirectory(path);
            return path;
        }
        private static void Output(MISP_json_Format misp, string path, List<string> attrilist, List<datasets> taglist)
        {
            foreach (string targetSource in attrilist)
            {
                using (StreamWriter w = new StreamWriter(path + @"/" + InvalidCharReplace(targetSource) + ".csv"))
                {
                    foreach (Response r in misp.response)
                    {
                        foreach (MISP_JsonToDatasets.Attribute a in r.Event.Attribute)
                        {
                            if (String.Equals(targetSource, a.type))
                            {
                                foreach (datasets ds in taglist)
                                {
                                    if (string.Equals(ds.output_id(), r.Event.id))
                                    {
                                        w.WriteLine(string.Join(",", a.value,ds.output_format()));
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        private static void OutputExternalData(string path, List<datasetX> datasetX, List<datasets> tagdatasets)
        {
            List<string> types_tmp = new List<string>();
            foreach(datasetX dataset in datasetX){types_tmp.Add(dataset.type);}
            IEnumerable<string> types = types_tmp.Distinct();
            List<string> externalX = new List<string>();

            foreach(string type in types)
            {
                using(StreamWriter w = new StreamWriter(path + @"/" + InvalidCharReplace(type) + "_ExternalData.csv"))
                {
                    foreach(datasetX dataset in datasetX)
                    {
                        if(string.Equals(type,dataset.type))
                        {
                            foreach(datasets tag in tagdatasets)
                            {
                                if (string.Equals(tag.output_id(), dataset.id))
                                {
                                    externalX = dataset.externalX;
                                    foreach (string extX in externalX)
                                    {
                                        w.WriteLine(string.Join(",", extX, tag.output_format()));
                                    }
                                }
                            }
                        }
                    }
                }
            }

            
        }
        //�t�@�C�����Ɏg�p�ł��Ȃ�������̒u��
        private static string InvalidCharReplace(string name)
        {
            char[] invalidChars = Path.GetInvalidFileNameChars();
            foreach(char c in invalidChars)
            {
                name = name.Replace(c, '_');
            }

            return name;
        }
        //�o�͗p�֐������܂�
    }
}
