using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Net;
using System.Text;



namespace GetCountryCode
{
    class Program
    {
        //IPアドレスソート用関数ここから
        static int CompareRIR(IPRIR a, IPRIR b)
        {
            return ipSort(a.ip, b.ip);
        }
        static int CompareTargetIP(TargetIP a, TargetIP b)
        {
            return ipSort(a.ip, b.ip);
        }
        //IPアドレスの比較
        static int ipSort(byte[] a, byte[] b)
        {
            for (int i = 0; i < 4; i++)
            {
                if (a[i] > b[i]) { return 1; } 
                if (a[i] < b[i]) { return -1; }
            }
            //同一IPの場合は0
            return 0;
        }
        //IPアドレスソート用関数ここまで

        public static List<TargetIP> GetCountryCode(List<TargetIP> targetIPs,List<IPRIR> RIRList)
        {
            //読み込んだCountryCodeのリストを昇順にソート
            RIRList.Sort(CompareRIR);
            //検索対象IPアドレスを昇順にソート
            targetIPs.Sort(CompareTargetIP);
            //検索
            targetIPs = SetTargetCountryCode(RIRList, targetIPs);
            return targetIPs;
        }

        //割り当て検索
        private static List<TargetIP> SetTargetCountryCode(List<IPRIR> rIRList, List<TargetIP> targetIPs)
        {

            int rirCount = 0;

            foreach (TargetIP targetIP in targetIPs)
            {
                if (rirCount == rIRList.Count)
                {
                    targetIP.SetSourceCC("-", "-","-");
                }
                else
                {
                    while (ipSort(targetIP.ip, rIRList[rirCount].ip) == 1)
                    {

                        if (ipSort(targetIP.ip, rIRList[rirCount].ipLimit) == 1)
                        {
                            rirCount++;
                            //RIR割り当ての最終リストまで到達したら検索をやめる
                            if (rirCount == rIRList.Count)
                            {
                                break;
                            }
                        }
                        else
                        {
                            targetIP.SetSourceCC(rIRList[rirCount].source, rIRList[rirCount].CountryCode,rIRList[rirCount].networkRange);
                            break;
                        }
                    }
                }
            }
            return targetIPs;
        }
 
        //RIRの割り当て読み込み
        public static List<IPRIR> SetRIRList()
        {
            List<IPRIR> RIRList = new List<IPRIR>();
            string[] rirurls ={
                    "ftp://ftp.arin.net/pub/stats/arin/delegated-arin-extended-latest",
                    "ftp://ftp.ripe.net/pub/stats/ripencc/delegated-ripencc-extended-latest",
                    "ftp://ftp.apnic.net/pub/stats/apnic/delegated-apnic-extended-latest",
                    "ftp://ftp.lacnic.net/pub/stats/lacnic/delegated-lacnic-extended-latest",
                    "ftp://ftp.afrinic.net/pub/stats/afrinic/delegated-afrinic-extended-latest"
            };

            string line;

            foreach (string rirurl in rirurls)
            {
                WebClient wc = new WebClient();
                Stream st = wc.OpenRead(rirurl);

                using (StreamReader r = new StreamReader(st, Encoding.GetEncoding("utf-8")))
                {
                    while ((line = r.ReadLine()) != null)
                    {
                        string[] tmp = line.Split('|');
                        if (tmp.Length > 3)
                        {
                            if ((string.Equals(tmp[2], "ipv4")) && Regex.IsMatch(tmp[3], @"^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$"))
                            {
                                RIRList.Add(new IPRIR(tmp[0], tmp[1], tmp[3], tmp[4], tmp[5]));
                            }
                        }
                    }
                }
                st.Close();
            }
            return RIRList;
        }
    }
}
