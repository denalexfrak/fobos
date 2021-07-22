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






        public enum AddressType
        {
            
        }

        public class Address
        {
            public string City { get; set; }
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
            
            var str3 = resultObject["tree"]?["16590"]?["16591"].ToString();
           
            Dictionary<string, Tree> values = JsonConvert.DeserializeObject<Dictionary<string, Tree>>(str1);
          

            foreach (KeyValuePair<string, Tree> keyValue in values)
            {
                //1-я итерация самый верхний уровень
                dataGridView1.Rows.Add(keyValue.Key);
                Tree2 account1 = JsonConvert.DeserializeObject<Tree2>(str1);
                if (account1.name != null)
                {
                  //  MessageBox.Show(account1.name.ToString());
                }

                //1-й уровень поиск данных на втором уровне
                var str2 = resultObject["tree"]?[keyValue.Key].ToString();
                Tree2 account2 = JsonConvert.DeserializeObject<Tree2>(str2);
                if (account2.name != null)
                {
                 //   MessageBox.Show(account2.name.ToString());
                }


                //2-я итерация перебор второго уровня               
                Dictionary<AddressType, Address> values2 = JsonConvert.DeserializeObject<Dictionary<AddressType, Address>>(str2);

                //foreach (KeyValuePair<string, Tree3> keyValue2 in values2)
                //   {
                // dataGridView2.Rows.Add(keyValue2.Key);
                //       MessageBox.Show(keyValue2.Key.ToString());
                //   }

            }


          //  Tree2 account = JsonConvert.DeserializeObject<Tree2>(str3);
          //  MessageBox.Show(account.name.ToString());

           // Tree2 account2 = JsonConvert.DeserializeObject<Tree2>(str2);         
          //  MessageBox.Show(account2.name.ToString());

          //  Tree2 account3 = JsonConvert.DeserializeObject<Tree2>(str1);
          //  if (account3.name != null)
          //  {
          //      MessageBox.Show(account3.name.ToString());
          //  }
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

