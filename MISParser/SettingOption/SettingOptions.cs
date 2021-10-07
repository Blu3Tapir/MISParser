using System;
using System.Collections.Generic;
using System.Text;

namespace MISP_TAG
{
    public class SettingOptions
    {

        public bool GetMISPfromDB { set; get; }
        public string LocalMISPDataPath { set; get; }
        public string GetMISPfromDBURL { set; get; }
        public string GetMISPDBApi { set; get; }
        public bool Options { set; get; }
        public bool GetWhoisData { set; get; }
        public bool VT { set; get; }
        public string VTApi { set; get; } 


        public SettingOptions()
        {

        }

        public void SetOption(List<string> settingini)
        {
            this.GetMISPfromDB = Convert.ToBoolean(settingini[0]);
            this.LocalMISPDataPath = settingini[1];
            this.GetMISPfromDBURL = settingini[2];
            this.GetMISPDBApi = settingini[3];
            this.Options = Convert.ToBoolean(settingini[4]);
            this.GetWhoisData = Convert.ToBoolean(settingini[5]);
            this.VT = Convert.ToBoolean(settingini[6]);
            this.VTApi = settingini[7];
        }


    }
}
