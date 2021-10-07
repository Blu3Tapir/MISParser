using System;


namespace GetCountryCode
{
    class IPRIR
    {
        public string source { get; private set; }
        public string CountryCode { get; private set; }
        public byte[] ip { get; private set; } = new byte[4];
        public byte[] ipLimit { get; private set; } = new byte[4];
        public string ipAddress { get; private set; }
        public int ipRange { get; private set; }
        public string networkRange { get; private set; }
        public string date { get; private set; }

        
        public IPRIR(string source,string CountryCode,string IPAddress,string ipRange,string date)
        {
            string[] ipaddr = IPAddress.Split('.');
            for (int i = 0; i < 4; i++) { ip[i] = Convert.ToByte(ipaddr[i]); }
            
            this.ipLimit = SetipLimit(ip, ipRange);
            this.ipRange = Convert.ToInt32(ipRange);
            this.CountryCode = CountryCode;
            this.ipAddress = IPAddress;
            this.networkRange = IPAddress + RangeToNetworkMask(ipRange);
            this.source = source;
            this.date = date;
        }

        private string RangeToNetworkMask(string ipRange)
        {
            int range = Convert.ToInt32(ipRange);
            int networkRange = 32;
            for(int i = 0;i < 32; i++)
            {
                range = range / 2;
                if(range == 0)
                {
                    networkRange = networkRange - i;
                    break; 
                }
            }
            return @"/" + networkRange.ToString(); 
        }

        private byte[] SetipLimit(byte[] ip,string range)
        {
            byte[] limit = new byte[4];
            int[] ipstart = new int[4];
            int[] sum = new int[4];
            int r = Convert.ToInt32(range);
            int tmp = 0;
            
            for(int i=3;i>=0;i--)
            {
                ipstart[i] = Convert.ToInt16(ip[i]);
                sum[i] = r % 256;
                r = r / 256;
            }

            for(int i=3;i>=0;i--)
            {
                ipstart[i] = ipstart[i] + sum[i] + tmp;
                //繰り上がり処理
                if(ipstart[i] > 255)
                {
                    tmp = ipstart[i] / 255;
                    ipstart[i] = ipstart[i] % 256;
                }
                else { tmp = 0 ; }
                limit[i] = Convert.ToByte(ipstart[i]);
            }
            return limit;
        }

    }
}
