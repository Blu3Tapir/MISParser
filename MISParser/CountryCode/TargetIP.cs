using System;
using System.Collections.Generic;
using System.Text;

namespace GetCountryCode
{
    class TargetIP
    {
        public string ipAddress { get; private set; }
        public byte[] ip { get; private set; } = new byte[4];
        public string source { get; private set; } = "-";
        public string CountryCode { get; private set; } = "-";
        public string datasetXID { get; private set; }
        public string networkRange { get; private set; } = "-";

        public TargetIP(string IPAddress,string id)
        {
            string[] ipaddr = IPAddress.Split('.');
            this.datasetXID = id;
            this.ipAddress = IPAddress;
            for (int i = 0; i < 4; i++) { ip[i] = Convert.ToByte(ipaddr[i]); }
        }
        public void SetSourceCC(string source,string CountryCode,string networkRange)
        {
            this.source = source;
            this.CountryCode = CountryCode;
            this.networkRange = networkRange;

        }
        public string output()
        {
            return String.Join(',', ipAddress, source, CountryCode,networkRange);
        }
    }
}
