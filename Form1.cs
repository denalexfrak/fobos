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


        class Tree3
        {
            public string id { get; set; }

            public string name { get; set; }

            public string type { get; set; }
        }

        class Tree4
        {
            public string id { get; set; }

            public string name { get; set; }

            public string type { get; set; }
        }

        class Tree5
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
            var str1 = resultObject["tree"].ToString();

           

            Dictionary<string, Tree> values = JsonConvert.DeserializeObject<Dictionary<string, Tree>>(str1);


            foreach (KeyValuePair<string, Tree> keyValue in values)
            {
                //1-я итерация самый верхний уровень
                
                Tree2 account1 = JsonConvert.DeserializeObject<Tree2>(str1);

                if (keyValue.Key != null)
                {

                    //1-й уровень поиск данных на втором уровне
                    dataGridView1.Rows.Add(keyValue.Key);
                    var str2 = resultObject["tree"]?[keyValue.Key].ToString();
                    Tree3 account2 = JsonConvert.DeserializeObject<Tree3>(str2);



                    //    MessageBox.Show(account2.id.ToString()+ "--" +account2.name.ToString() + "--" + account2.type.ToString());



                    //2-я итерация перебор второго уровня
                    string json2 = getContent(@"https://lk.curog.ru/api.tree/get_tree/?id=" + keyValue.Key + "&key=9778a18d58d75bf6d569d31ef277c2cc");
                    Newtonsoft.Json.Linq.JObject resultObject2 = Newtonsoft.Json.Linq.JObject.Parse(json2);
                    var str3 = resultObject2["tree"].ToString();
                    if (str3 != "[]")
                    {
                        
                          Dictionary<string, Tree4> values2 = JsonConvert.DeserializeObject<Dictionary<string, Tree4>>(str3);
                          foreach (KeyValuePair<string, Tree4> keyValue2 in values2)
                            {
                        //    Tree4 account2 = JsonConvert.DeserializeObject<Tree4>(str1);
                        //         MessageBox.Show(keyValue2.Key.ToString());
                             dataGridView2.Rows.Add(keyValue2.Key);


                        //3-я итерация перебор третьего уровня
                        string json3 = getContent(@"https://lk.curog.ru/api.tree/get_tree/?id=" + keyValue2.Key + "&key=9778a18d58d75bf6d569d31ef277c2cc");
                        Newtonsoft.Json.Linq.JObject resultObject3 = Newtonsoft.Json.Linq.JObject.Parse(json3);
                        var str4 = resultObject3["tree"].ToString();
                            if (str4 != "[]")
                            {
                                Dictionary<string, Tree5> values3 = JsonConvert.DeserializeObject<Dictionary<string, Tree5>>(str4);
                                foreach (KeyValuePair<string, Tree5> keyValue3 in values3)
                                {
                                    //    MessageBox.Show(keyValue3.Key.ToString());
                                    dataGridView3.Rows.Add(keyValue3.Key);
                                }
                            }

                    }

                    }


                    //  }

                }

            }

        }


      








        private void button1_Click(object sender, EventArgs e)
        {

          
        }





        private void button2_Click_1(object sender, EventArgs e)
        {

        }
    }
    }

