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

            [JsonProperty("id")]
            public string id { get; set; }
            [JsonProperty("name")]
            public string name { get; set; }
            [JsonProperty("type")]
            public string type { get; set; }
        }


        class Tree3
        {
            [JsonProperty("id")]
            public string id { get; set; }
            [JsonProperty("name")]
            public string name { get; set; }
            [JsonProperty("type")]
            public string type { get; set; }
        }

        class Tree4_1
        {
            [JsonProperty("id")]
            public string id { get; set; }
            [JsonProperty("name")]
            public string name { get; set; }
            [JsonProperty("type")]
            public string type { get; set; }
        }

        class Tree4
        {
            [JsonProperty("id")]
            public string id { get; set; }
            [JsonProperty("name")]
            public string name { get; set; }
            [JsonProperty("type")]
            public string type { get; set; }
        }

        class Tree5
        {
            [JsonProperty("id")]
            public string id { get; set; }
            [JsonProperty("name")]
            public string name { get; set; }
            [JsonProperty("type")]
            public string type { get; set; }
        }

        class Tree5_1
        {
            [JsonProperty("id")]
            public string id { get; set; }
            [JsonProperty("name")]
            public string name { get; set; }
            [JsonProperty("type")]
            public string type { get; set; }
        }

        class Tree6
        {
            [JsonProperty("id")]
            public string id { get; set; }
            [JsonProperty("name")]
            public string name { get; set; }
            [JsonProperty("type")]
            public string type { get; set; }
        }

        class Tree6_1
        {
            [JsonProperty("id")]
            public string id { get; set; }
            [JsonProperty("name")]
            public string name { get; set; }
            [JsonProperty("type")]
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
            dataGridView1.Rows.Clear();

            string json = getContent("https://lk.curog.ru/api.tree/get_tree/?id=17236&key=9778a18d58d75bf6d569d31ef277c2cc");

            Newtonsoft.Json.Linq.JObject resultObject = Newtonsoft.Json.Linq.JObject.Parse(json);
            var str1 = resultObject["tree"].ToString();
            string str0 = resultObject["status"].ToString();
            MessageBox.Show(str0.ToString());

            Dictionary<string, Tree> values = JsonConvert.DeserializeObject<Dictionary<string, Tree>>(str1);

            int i_1 = 0;
            if (str1 != "[]" && str0=="ok")
            {
                    foreach (KeyValuePair<string, Tree> keyValue in values)
                    {
                    //1-я итерация самый верхний уровень
                
                    Tree2 account1 = JsonConvert.DeserializeObject<Tree2>(str1);

                    if (keyValue.Key != null)
                    {
                        Application.DoEvents();

                        //1-й уровень поиск данных на втором уровне                    
                        var str2 = resultObject["tree"]?[keyValue.Key].ToString();
                        if (str2 != "[]")
                        {
                            Tree3 account2 = JsonConvert.DeserializeObject<Tree3>(str2);

                            //заполняем таблицу 1-го уровня древа
                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[i_1].Cells[0].Value = Convert.ToString(i_1 + 1);
                            dataGridView1.Rows[i_1].Cells[1].Value = Convert.ToString(account2.id.ToString());
                            dataGridView1.Rows[i_1].Cells[2].Value = Convert.ToString(account2.name.ToString());
                            dataGridView1.Rows[i_1].Cells[3].Value = Convert.ToString(account2.type.ToString());
                            i_1++;





                            //2-я итерация перебор второго уровня
                            string json2 = getContent(@"https://lk.curog.ru/api.tree/get_tree/?id=" + keyValue.Key + "&key=9778a18d58d75bf6d569d31ef277c2cc");
                            Newtonsoft.Json.Linq.JObject resultObject2 = Newtonsoft.Json.Linq.JObject.Parse(json2);
                            var str3 = resultObject2["tree"].ToString();
                            if (str3 != "[]")
                            {

                                Dictionary<string, Tree4> values2 = JsonConvert.DeserializeObject<Dictionary<string, Tree4>>(str3);
                                foreach (KeyValuePair<string, Tree4> keyValue2 in values2)
                                {
                                    var str3_1 = resultObject2["tree"]?[keyValue2.Key].ToString();
                                    Tree4_1 account3 = JsonConvert.DeserializeObject<Tree4_1>(str3_1);
                                    //заполняем таблицу 2-го уровня древа
                                    dataGridView1.Rows.Add();
                                    dataGridView1.Rows[i_1].Cells[0].Value = Convert.ToString(i_1);
                                    dataGridView1.Rows[i_1].Cells[1].Value = Convert.ToString(account3.id.ToString());
                                    dataGridView1.Rows[i_1].Cells[2].Value = Convert.ToString(account3.name.ToString());
                                    dataGridView1.Rows[i_1].Cells[3].Value = Convert.ToString(account3.type.ToString());
                                    dataGridView1.Rows[i_1].Cells[4].Value = Convert.ToString(account2.id.ToString());
                                    i_1++;


                                    //3-я итерация перебор третьего уровня
                                    string json3 = getContent(@"https://lk.curog.ru/api.tree/get_tree/?id=" + keyValue2.Key + "&key=9778a18d58d75bf6d569d31ef277c2cc");
                                    Newtonsoft.Json.Linq.JObject resultObject3 = Newtonsoft.Json.Linq.JObject.Parse(json3);
                                    var str4 = resultObject3["tree"].ToString();
                                    if (str4 != "[]")
                                    {
                                        Dictionary<string, Tree5> values3 = JsonConvert.DeserializeObject<Dictionary<string, Tree5>>(str4);
                                        foreach (KeyValuePair<string, Tree5> keyValue3 in values3)
                                        {
                                            var str4_1 = resultObject3["tree"]?[keyValue3.Key].ToString();
                                            Tree5_1 account4 = JsonConvert.DeserializeObject<Tree5_1>(str4_1);
                                            //заполняем таблицу 2-го уровня древа
                                            dataGridView1.Rows.Add();
                                            dataGridView1.Rows[i_1].Cells[0].Value = Convert.ToString(i_1);
                                            dataGridView1.Rows[i_1].Cells[1].Value = Convert.ToString(account4.id.ToString());
                                            dataGridView1.Rows[i_1].Cells[2].Value = Convert.ToString(account4.name.ToString());
                                            dataGridView1.Rows[i_1].Cells[3].Value = Convert.ToString(account4.type.ToString());
                                            dataGridView1.Rows[i_1].Cells[4].Value = Convert.ToString(account3.id.ToString());
                                            i_1++;



                                            //4-я итерация
                                            string json4 = getContent(@"https://lk.curog.ru/api.tree/get_tree/?id=" + keyValue3.Key + "&key=9778a18d58d75bf6d569d31ef277c2cc");
                                            Newtonsoft.Json.Linq.JObject resultObject4 = Newtonsoft.Json.Linq.JObject.Parse(json4);
                                            var str5 = resultObject4["tree"].ToString();
                                            if (str5 != "[]")
                                            {
                                                Dictionary<string, Tree6> values4 = JsonConvert.DeserializeObject<Dictionary<string, Tree6>>(str5);
                                                foreach (KeyValuePair<string, Tree6> keyValue4 in values4)
                                                {
                                                    var str5_1 = resultObject4["tree"]?[keyValue4.Key].ToString();
                                                    Tree6_1 account5 = JsonConvert.DeserializeObject<Tree6_1>(str5_1);
                                                    //заполняем таблицу 2-го уровня древа
                                                    dataGridView1.Rows.Add();
                                                    dataGridView1.Rows[i_1].Cells[0].Value = Convert.ToString(i_1);
                                                    dataGridView1.Rows[i_1].Cells[1].Value = Convert.ToString(account5.id.ToString());
                                                    dataGridView1.Rows[i_1].Cells[2].Value = Convert.ToString(account5.name.ToString());
                                                    dataGridView1.Rows[i_1].Cells[3].Value = Convert.ToString(account5.type.ToString());
                                                    dataGridView1.Rows[i_1].Cells[4].Value = Convert.ToString(account4.id.ToString());
                                                    i_1++;


                                                }
                                            }



                                        }
                                    }







                                }

                            }
                        }

                         } 

                    }

            }

        }


      








        private void button1_Click(object sender, EventArgs e)
        {

          
        }





        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }
    }
    }

