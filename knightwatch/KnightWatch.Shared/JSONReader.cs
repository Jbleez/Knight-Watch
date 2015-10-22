using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace KnightWatch
{
    [DataContract]
    abstract class JSONReader
    {
        private string baseURI = "http://168.28.189.116/KnightWatch/";
        public string lastResp = "JSONReader";

        public async void read(int refresh = 10000)
        {
            HttpClient htClient = new HttpClient();
            string url = this.baseURI + this.webURI();
            try
            {
                this.lastResp = await htClient.GetStringAsync(url);
                this.parse(this.lastResp);
            }
            catch (Exception ex)
            {
                this.parse(this.dummyReply());
                lastResp = url + " // " + ex.ToString();
                // maybe do some error logging;
            }

            await Task.Delay(refresh); // 10 secs
            this.read();
        }

        public string stringify()
        {
            MemoryStream stream1 = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(this.GetType());
            ser.WriteObject(stream1, this);
            stream1.Position = 0;
            StreamReader sr = new StreamReader(stream1);
            return sr.ReadToEnd();
        }

        abstract public string webURI();
        abstract public string dummyReply();
        abstract public void parse(string reply);
    }
}
