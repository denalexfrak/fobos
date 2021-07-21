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





    



        private void button1_Click(object sender, EventArgs e)
        {         


        }


        class RootObject
        {
            public Dictionary<string, Tree> trees { get; set; }
        }

        class Tree
        {
            public string name { get; set; }
            public string type { get; set; }
            public string id { get; set; }
        }

        class Tree2
        {
            public string name { get; set; }
            public string type { get; set; }
            public string id { get; set; }
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
            Dictionary<string, Tree> values = JsonConvert.DeserializeObject<Dictionary<string, Tree>>(str);

            foreach (KeyValuePair<string, Tree> keyValue in values)
            {
                dataGridView1.Rows.Add(keyValue.Key); 
            }

           
        }
    }
    }

