using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace fobos_w
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private string getContent(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = "GET";
            request.Accept = "application/json";
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            StringBuilder output = new StringBuilder();
            output.Append(reader.ReadToEnd());
            response.Close();
            return output.ToString();
        }





    



      

      

        class Tree
        {
            [JsonProperty("id")]
            public string id { get; set; }
            [JsonProperty("name")]
            public string name { get; set; }
            [JsonProperty("type")]
            public string type { get; set; }
        }

        class Tree2
        {
           
            public string id { get; set; }
         
            public string name { get; set; }
           
            public string type { get; set; }
        }

        private void button2_Click(object sender, EventArgs e)
        {            

        }

        private void button3_Click(object sender, EventArgs e)
        {     
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string json = getContent("https://lk.curog.ru/api.tree/get_tree/?id=14029&key=9778a18d58d75bf6d569d31ef277c2cc");

            Newtonsoft.Json.Linq.JObject resultObject = Newtonsoft.Json.Linq.JObject.Parse(json);            
            var str = resultObject["tree"].ToString();
            var str2 = resultObject["tree"]?["16590"].ToString();
            var str3 = resultObject["tree"]?["16590"]?["16591"].ToString();
            //MessageBox.Show(str2.ToString());

            //string json2 = JsonConvert.SerializeObject(str, Formatting.None);

            //Newtonsoft.Json.Linq.JObject resultObject2 = Newtonsoft.Json.Linq.JObject.Parse(json2);
            //var str2 = resultObject["15730"].ToString();

            // MessageBox.Show(str.ToString());
            Dictionary<string, Tree> values = JsonConvert.DeserializeObject<Dictionary<string, Tree>>(str);
          //  Dictionary<string, Tree2> values2 = JsonConvert.DeserializeObject<Dictionary<string, Tree2>>(str2);

            foreach (KeyValuePair<string, Tree> keyValue in values)
            {
                dataGridView1.Rows.Add(keyValue.Key);
               
                //    Newtonsoft.Json.Linq.JObject resultObject2 = Newtonsoft.Json.Linq.JObject.Parse(json);                
                //    var str2 = resultObject2["tree"]?["16590"].ToString();
                //    Dictionary<string, Tree2> values2 = JsonConvert.DeserializeObject<Dictionary<string, Tree2>>(str2);

                //    foreach (KeyValuePair2<string, Tree2> keyValue2 in values2)
                //    {
                        dataGridView2.Rows.Add(keyValue.Value);
                //    }
            }


            Tree2 account = JsonConvert.DeserializeObject<Tree2>(str3);
            MessageBox.Show(account.name.ToString());

            Tree2 account2 = JsonConvert.DeserializeObject<Tree2>(str2);         
            MessageBox.Show(account2.name.ToString());
            //for (int x1 = 0; x1 <  data_tree2.Count; x1++)
            //{
            //    string row = data_tree2[x1];

            //}
        }




      




         class Order
                {
                    [JsonProperty("id")]
                    public string id { get; set; }
                    [JsonProperty("name")]
                    public string name { get; set; }
                    [JsonProperty("type")]
                    public string type { get; set; }            
                }




        private void button1_Click(object sender, EventArgs e)
        {

          
        }





        private void button2_Click_1(object sender, EventArgs e)
        {

        }
    }
    }

