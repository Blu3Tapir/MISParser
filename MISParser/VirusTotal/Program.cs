using System.Collections.Generic;
using System.Net; // Web Client 用
using Newtonsoft.Json; // NewtonSoft の導入
using Newtonsoft.Json.Linq; // JObject の導入


namespace ConsoleApp1
{
    class Program
    {

        public static List<string> GetVTData(string api_key_input, string file_id_input)
        {
            List<string> result = GetPackers(api_key_input, file_id_input);

            return result;
        }

        static List<string> GetPackers(string api_key, string file_id)
        {
            // Web クライアント（HTTP要求、HTTP応答）
            using (WebClient web_client = new WebClient())
            {
                // HTTPリクエストヘッダーに x-apikey を追加指定。
                web_client.Headers.Set("x-apikey", api_key);

                // VirusTotal にアップロードされている id からファイル情報を取得するためのURL
                string url_vt_file = "https://www.virustotal.com/api/v3/files/";


                // 出力用文字列のビルダー
                System.Text.StringBuilder packers_sb = new System.Text.StringBuilder();
                // 出力用List
                List<string> packers_list = new List<string>();

                try
                {
                    // VTに対してJSON要求
                    string response_string = web_client.DownloadString(url_vt_file + file_id);

                    // JSONのシリアライザー
                    JsonSerializer json_serializer = new JsonSerializer();
                    using (JsonTextReader json_reader = new JsonTextReader(new System.IO.StringReader(response_string)))
                    {
                        while (json_reader.Read())
                        {
                            // JSONのキーの開始符号に合致するものをストリームに流す
                            if (json_reader.TokenType == JsonToken.StartObject)
                            {
                                // ストリームから得られたJSONオブジェクト
                                var json_object = JObject.ReadFrom(json_reader);
                                // https://developers.virustotal.com/reference#peid によると、packers は次の形式で得られる。
                                //  {
                                //      "data": {
                                //          ...
                                //          "attributes" : {
                                //              ...
                                //              "packers": {
                                //                  "<string>": "<string>", ...
                                //              }
                                //          }
                                //      }
                                //  }

                                // JObject として packers を取得。
                                JObject packers = (JObject)json_object.SelectToken("data.attributes.packers");
                                if (packers != null)
                                {
                                    foreach (var item in packers)
                                    {
                                        // tools names
                                        string toolname = item.Key;

                                        // identified packers
                                        string packername = item.Value.ToString();

                                        // 出力用文字列
                                        // ■ダブルクオーテーション出力の場合
                                        //packers_list.Add("\"" + item.Key + "\", \"" + item.Value.ToString() + "\"");

                                        // ■カンマ置換出力の場合
                                        packers_list.Add(item.Key + ", " + item.Value.ToString() );
                                    }
                                }
                                else
                                {
                                    // パッカーが存在しないidの場合。
                                    packers_list.Add("\"_\", \"_\"");
                                }
                            }
                        }
                    }
                }
                catch (WebException e)
                {
                    packers_list.Add("error, error");
                }
                return packers_list;
            }
        }
    }
}
