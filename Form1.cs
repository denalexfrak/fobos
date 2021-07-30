using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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



        public string GetConnectionString()
        {
            return "Data Source=" + textBox1.Text + ";Initial Catalog=" + textBox2.Text + ";Persist Security Info=True;User ID=" + textBox3.Text + ";Password=" + textBox4.Text + ";MultipleActiveResultSets=True";

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


            string connectionString = GetConnectionString();

            SqlConnection connection = new SqlConnection();

            connection.ConnectionString = connectionString;

            connection.Open();



            int i_1 = 0;
            if (str1 != "[]" && str0 == "ok")
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

                            //запрос на существование id в базе
                            // запрос
                            string id_tree_el = "";
                            string sql1_1 = "SELECT [id_tree_el] FROM [waviot_data].[dbo].[tree_elements] WHERE [id_tree_el]='" + account2.id.ToString() + "'";
                            // объект для выполнения SQL-запроса
                            SqlCommand command1_1 = new SqlCommand(sql1_1, connection);
                            // выполняем запрос и получаем ответ
                            if (command1_1.ExecuteScalar() != null)
                            {
                                id_tree_el = command1_1.ExecuteScalar().ToString();
                            }


                            if (id_tree_el == account2.id.ToString())
                            {
                                // запрос
                                string sql1_0 = "UPDATE [waviot_data].[dbo].[tree_elements] " +
                                                    "  SET    " +
                                                    "     [name] = '" + account2.name.ToString() + "' " +
                                                    "    ,[type] = '" + account2.type.ToString() + "' " +
                                                    " WHERE  " +
                                                    "     [id_tree_el] = '" + account2.id.ToString() + "' " +
                                                    " ";
                                // объект для выполнения SQL-запроса
                                SqlCommand command1_0 = new SqlCommand(sql1_0, connection);
                                command1_0.ExecuteNonQuery();
                            }
                            else
                            {
                                // запрос
                                string sql1 = "INSERT INTO [waviot_data].[dbo].[tree_elements] ( " +
                                                    "      " +
                                                    "     [id_tree_el] " +
                                                    "     ,[name] " +
                                                    "     ,[type] " +
                                                    "     ,[parent_id_tree_el] " +
                                                    "     ,[deleted] " +
                                                    "     ,[lastname] " +
                                                    "     ,[firstname] " +
                                                    "     ,[middlename] " +
                                                    "     ,[appartment] " +
                                                    "     ,[city] " +
                                                    "     ,[district] " +
                                                    "     ,[street] " +
                                                    "     ,[locality] " +
                                                    "     ,[building] " +
                                                    "     ,[entrance] " +
                                                    "     ,[account] " +
                                                    "     ,[vm_code] " +
                                                    "     ,[ovm_code]) " +
                                                    " VALUES ( " +
                                                    " '" + account2.id.ToString() + "', " +
                                                    " '" + account2.name.ToString() + "', " +
                                                    " '" + account2.type.ToString() + "', " +
                                                    " '', " +
                                                    " '', " +
                                                    " '', " +
                                                    " '', " +
                                                    " '', " +
                                                    " '', " +
                                                    " '', " +
                                                    " '', " +
                                                    " '', " +
                                                    " '', " +
                                                    " '', " +
                                                    " '', " +
                                                    " '', " +
                                                    " '', " +
                                                    " '' " +
                                                    " )";
                                // объект для выполнения SQL-запроса
                                SqlCommand command1 = new SqlCommand(sql1, connection);
                                command1.ExecuteNonQuery();

                            }


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
                                    //запрос на существование id в базе
                                    // запрос
                                    string id_tree_el_3 = "";
                                    string sql3_1 = "SELECT [id_tree_el] FROM [waviot_data].[dbo].[tree_elements] WHERE [id_tree_el]='" + account3.id.ToString() + "'";
                                    // объект для выполнения SQL-запроса
                                    SqlCommand command3_1 = new SqlCommand(sql3_1, connection);
                                    // выполняем запрос и получаем ответ
                                    if (command3_1.ExecuteScalar() != null)
                                    {
                                        id_tree_el_3 = command3_1.ExecuteScalar().ToString();
                                    }


                                    if (id_tree_el_3 == account3.id.ToString())
                                    {
                                        // запрос
                                        string sql2_0 = "UPDATE [waviot_data].[dbo].[tree_elements] " +
                                                            "  SET    " +
                                                            "     [name] = '" + account3.name.ToString() + "' " +
                                                            "    ,[type] = '" + account3.type.ToString() + "' " +
                                                            "    ,[parent_id_tree_el] = '" + account2.id.ToString() + "' " +
                                                            " WHERE  " +
                                                            "     [id_tree_el] = '" + account3.id.ToString() + "' " +
                                                            " ";
                                        // объект для выполнения SQL-запроса
                                        SqlCommand command3_0 = new SqlCommand(sql2_0, connection);
                                        command3_0.ExecuteNonQuery();
                                    }
                                    else
                                    {
                                        // запрос
                                        string sql2 = "INSERT INTO [waviot_data].[dbo].[tree_elements] ( " +
                                                        "      " +
                                                        "     [id_tree_el] " +
                                                        "     ,[name] " +
                                                        "     ,[type] " +
                                                        "     ,[parent_id_tree_el] " +
                                                        "     ,[deleted] " +
                                                        "     ,[lastname] " +
                                                        "     ,[firstname] " +
                                                        "     ,[middlename] " +
                                                        "     ,[appartment] " +
                                                        "     ,[city] " +
                                                        "     ,[district] " +
                                                        "     ,[street] " +
                                                        "     ,[locality] " +
                                                        "     ,[building] " +
                                                        "     ,[entrance] " +
                                                        "     ,[account] " +
                                                        "     ,[vm_code] " +
                                                        "     ,[ovm_code]) " +
                                                        " VALUES ( " +
                                                        " '" + account3.id.ToString() + "', " +
                                                        " '" + account3.name.ToString() + "', " +
                                                        " '" + account3.type.ToString() + "', " +
                                                        " '" + account2.id.ToString() + "', " +
                                                        " '', " +
                                                        " '', " +
                                                        " '', " +
                                                        " '', " +
                                                        " '', " +
                                                        " '', " +
                                                        " '', " +
                                                        " '', " +
                                                        " '', " +
                                                        " '', " +
                                                        " '', " +
                                                        " '', " +
                                                        " '', " +
                                                        " '' " +
                                                        " )";
                                        // объект для выполнения SQL-запроса
                                        SqlCommand command2 = new SqlCommand(sql2, connection);
                                        command2.ExecuteNonQuery();
                                    }
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
                                            //запрос на существование id в базе
                                            // запрос
                                            string id_tree_el_4 = "";
                                            string sql4_1 = "SELECT [id_tree_el] FROM [waviot_data].[dbo].[tree_elements] WHERE [id_tree_el]='" + account4.id.ToString() + "'";
                                            // объект для выполнения SQL-запроса
                                            SqlCommand command4_1 = new SqlCommand(sql4_1, connection);
                                            // выполняем запрос и получаем ответ
                                            if (command4_1.ExecuteScalar() != null)
                                            {
                                                id_tree_el_4 = command4_1.ExecuteScalar().ToString();
                                            }


                                            if (id_tree_el_4 == account4.id.ToString())
                                            {
                                                // запрос
                                                string sql3_0 = "UPDATE [waviot_data].[dbo].[tree_elements] " +
                                                                    "  SET    " +
                                                                    "     [name] = '" + account4.name.ToString() + "' " +
                                                                    "    ,[type] = '" + account4.type.ToString() + "' " +
                                                                    "    ,[parent_id_tree_el] = '" + account3.id.ToString() + "' " +
                                                                    " WHERE  " +
                                                                    "     [id_tree_el] = '" + account4.id.ToString() + "' " +
                                                                    " ";
                                                // объект для выполнения SQL-запроса
                                                SqlCommand command4_0 = new SqlCommand(sql3_0, connection);
                                                command4_0.ExecuteNonQuery();
                                            }
                                            else
                                            {
                                                // запрос
                                                string sql3 = "INSERT INTO [waviot_data].[dbo].[tree_elements] ( " +
                                                            "      " +
                                                            "     [id_tree_el] " +
                                                            "     ,[name] " +
                                                            "     ,[type] " +
                                                            "     ,[parent_id_tree_el] " +
                                                            "     ,[deleted] " +
                                                            "     ,[lastname] " +
                                                            "     ,[firstname] " +
                                                            "     ,[middlename] " +
                                                            "     ,[appartment] " +
                                                            "     ,[city] " +
                                                            "     ,[district] " +
                                                            "     ,[street] " +
                                                            "     ,[locality] " +
                                                            "     ,[building] " +
                                                            "     ,[entrance] " +
                                                            "     ,[account] " +
                                                            "     ,[vm_code] " +
                                                            "     ,[ovm_code]) " +
                                                            " VALUES ( " +
                                                            " '" + account4.id.ToString() + "', " +
                                                            " '" + account4.name.ToString() + "', " +
                                                            " '" + account4.type.ToString() + "', " +
                                                            " '" + account3.id.ToString() + "', " +
                                                            " '', " +
                                                            " '', " +
                                                            " '', " +
                                                            " '', " +
                                                            " '', " +
                                                            " '', " +
                                                            " '', " +
                                                            " '', " +
                                                            " '', " +
                                                            " '', " +
                                                            " '', " +
                                                            " '', " +
                                                            " '', " +
                                                            " '' " +
                                                            " )";
                                                // объект для выполнения SQL-запроса
                                                SqlCommand command3 = new SqlCommand(sql3, connection);
                                                command3.ExecuteNonQuery();
                                            }
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

                                                    //запрос на существование id в базе
                                                    // запрос
                                                    string id_tree_el_5 = "";
                                                    string sql5_1 = "SELECT [id_tree_el] FROM [waviot_data].[dbo].[tree_elements] WHERE [id_tree_el]='" + account5.id.ToString() + "'";
                                                    // объект для выполнения SQL-запроса
                                                    SqlCommand command5_1 = new SqlCommand(sql5_1, connection);
                                                    // выполняем запрос и получаем ответ
                                                    if (command5_1.ExecuteScalar() != null)
                                                    {
                                                        id_tree_el_5 = command5_1.ExecuteScalar().ToString();
                                                    }


                                                    if (id_tree_el_5 == account5.id.ToString())
                                                    {
                                                        // запрос
                                                        string sql4_0 = "UPDATE [waviot_data].[dbo].[tree_elements] " +
                                                                            "  SET    " +
                                                                            "     [name] = '" + account5.name.ToString() + "' " +
                                                                            "    ,[type] = '" + account5.type.ToString() + "' " +
                                                                            "    ,[parent_id_tree_el] = '" + account4.id.ToString() + "' " +
                                                                            " WHERE  " +
                                                                            "     [id_tree_el] = '" + account5.id.ToString() + "' " +
                                                                            " ";
                                                        // объект для выполнения SQL-запроса
                                                        SqlCommand command5_0 = new SqlCommand(sql4_0, connection);
                                                        command5_0.ExecuteNonQuery();
                                                    }
                                                    else
                                                    {
                                                        // запрос
                                                        string sql4 = "INSERT INTO [waviot_data].[dbo].[tree_elements] ( " +
                                                                    "      " +
                                                                    "     [id_tree_el] " +
                                                                    "     ,[name] " +
                                                                    "     ,[type] " +
                                                                    "     ,[parent_id_tree_el] " +
                                                                    "     ,[deleted] " +
                                                                    "     ,[lastname] " +
                                                                    "     ,[firstname] " +
                                                                    "     ,[middlename] " +
                                                                    "     ,[appartment] " +
                                                                    "     ,[city] " +
                                                                    "     ,[district] " +
                                                                    "     ,[street] " +
                                                                    "     ,[locality] " +
                                                                    "     ,[building] " +
                                                                    "     ,[entrance] " +
                                                                    "     ,[account] " +
                                                                    "     ,[vm_code] " +
                                                                    "     ,[ovm_code]) " +
                                                                    " VALUES ( " +
                                                                    " '" + account5.id.ToString() + "', " +
                                                                    " '" + account5.name.ToString() + "', " +
                                                                    " '" + account5.type.ToString() + "', " +
                                                                    " '" + account4.id.ToString() + "', " +
                                                                    " '', " +
                                                                    " '', " +
                                                                    " '', " +
                                                                    " '', " +
                                                                    " '', " +
                                                                    " '', " +
                                                                    " '', " +
                                                                    " '', " +
                                                                    " '', " +
                                                                    " '', " +
                                                                    " '', " +
                                                                    " '', " +
                                                                    " '', " +
                                                                    " '' " +
                                                                    " )";
                                                        // объект для выполнения SQL-запроса
                                                        SqlCommand command4 = new SqlCommand(sql4, connection);
                                                        command4.ExecuteNonQuery();
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

            connection.Close();
            connection.Dispose();

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

        private void button2_Click_2(object sender, EventArgs e)
        {


        }













        class Get_Tree
        {
            [JsonProperty("id")]
            public string id { get; set; }

            [JsonProperty("path")]
            public string path { get; set; }

            [JsonProperty("name")]
            public string name { get; set; }

            [JsonProperty("type")]
            public string type { get; set; }

            [JsonProperty("timezone_id")]
            public string timezone_id { get; set; }

            [JsonProperty("deleted")]
            public string deleted { get; set; }

            [JsonProperty("company_id")]
            public string company_id { get; set; }

            [JsonProperty("tariff_id")]
            public string tariff_id { get; set; }

            [JsonProperty("weight")]
            public string weight { get; set; }

            [JsonProperty("latitude")]
            public string latitude { get; set; }

            [JsonProperty("longitude")]
            public string longitude { get; set; }

            [JsonProperty("ovm_available")]
            public string ovm_available { get; set; }

            [JsonProperty("lastname")]
            public string lastname { get; set; }

            [JsonProperty("firstname")]
            public string firstname { get; set; }

            [JsonProperty("middlename")]
            public string middlename { get; set; }

            [JsonProperty("point_type")]
            public string point_type { get; set; }

            [JsonProperty("appartment")]
            public string appartment { get; set; }

            [JsonProperty("city")]
            public string city { get; set; }

            [JsonProperty("district")]
            public string district { get; set; }

            [JsonProperty("street")]
            public string street { get; set; }

            [JsonProperty("locality")]
            public string locality { get; set; }

            [JsonProperty("building")]
            public string building { get; set; }

            [JsonProperty("entrance")]
            public string entrance { get; set; }

            [JsonProperty("floor")]
            public string floor { get; set; }

            [JsonProperty("account")]
            public string account { get; set; }

            [JsonProperty("transformer_substation")]
            public string transformer_substation { get; set; }

            [JsonProperty("vm_code")]
            public string vm_code { get; set; }

            [JsonProperty("ovm_code")]
            public string ovm_code { get; set; }

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();

            string connectionString = GetConnectionString();

            SqlConnection connection = new SqlConnection();

            connection.ConnectionString = connectionString;

            connection.Open();


            string sql = "SELECT [id_tree_el] FROM [waviot_data].[dbo].[tree_elements] ORDER BY [id]";

            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();


            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    // MessageBox.Show(reader.GetInt32(0).ToString()+ " -- " +reader.GetString(1));

                    string json = getContent("https://lk.curog.ru/api.tree/get_elements/?id=" + reader.GetInt32(0).ToString() + "&key=9778a18d58d75bf6d569d31ef277c2cc");
                    Newtonsoft.Json.Linq.JObject resultObject = Newtonsoft.Json.Linq.JObject.Parse(json);

                    var str1 = resultObject["elements"].ToString();
                    string str0 = resultObject["status"].ToString();
                    if (str0 == "ok")
                    {
                        if (str1 != "[]" && str1 != null)
                        {

                            Dictionary<string, Get_Tree> values = JsonConvert.DeserializeObject<Dictionary<string, Get_Tree>>(str1);
                            foreach (KeyValuePair<string, Get_Tree> keyValue4 in values)
                            {
                                var str2 = resultObject["elements"]?[keyValue4.Key].ToString();
                                if (str2 != "[]")
                                {
                                    Get_Tree account5 = JsonConvert.DeserializeObject<Get_Tree>(str2);

                                    // запрос -  дозаполняем таблицу ovm_code
                                    string sql4_0 = "UPDATE [waviot_data].[dbo].[tree_elements] " +
                                                        "  SET    " +
                                                        "     [deleted] = '" + account5.deleted.ToString() + "' " +
                                                        "    ,[lastname] = '" + account5.lastname.ToString() + "' " +
                                                        "    ,[firstname] = '" + account5.firstname.ToString() + "' " +
                                                        "    ,[middlename] = '" + account5.middlename.ToString() + "' " +
                                                        "    ,[appartment] = '" + account5.appartment.ToString() + "' " +
                                                        "    ,[city] = '" + account5.city.ToString() + "' " +
                                                        "    ,[district] = '" + account5.district + "' " +
                                                        "    ,[street] = '" + account5.street.ToString() + "' " +
                                                        "    ,[locality] = '" + account5.locality + "' " +
                                                        "    ,[building] = '" + account5.building.ToString() + "' " +
                                                        "    ,[entrance] = '" + account5.entrance.ToString() + "' " +
                                                        "    ,[account]= '" + account5.account.ToString() + "' " +
                                                        "    ,[vm_code] = '" + account5.vm_code + "' " +
                                                        "    ,[ovm_code] = '" + account5.ovm_code + "' " +
                                                        " WHERE  " +
                                                        "     [id_tree_el] = '" + keyValue4.Key + "' " +
                                                        " ";
                                    // объект для выполнения SQL-запроса
                                    SqlCommand command5_0 = new SqlCommand(sql4_0, connection);
                                    command5_0.ExecuteNonQuery();
                                    //  dataGridView1.Rows[i_1].Cells[1].Value = Convert.ToString(account5.id.ToString());
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            reader.Close();









            // запрос
            string sql_V = "SELECT [id], [id_tree_el], [name], [type], " +
                           "  [parent_id_tree_el] [deleted], [lastname], [firstname], [middlename], [appartment], [city], [district], [street] " +
                           " ,[locality], [building], [entrance], [account], [vm_code], [ovm_code] " +
                           "FROM [waviot_data].[dbo].[tree_elements]";
            // объект для выполнения SQL-запроса
            SqlCommand command_v = new SqlCommand(sql_V, connection);

            command_v.ExecuteNonQuery();
            System.Data.SqlClient.SqlDataAdapter DA = new System.Data.SqlClient.SqlDataAdapter(command_v);
            DataTable DT = new DataTable();
            DA.Fill(DT);
            dataGridView2.DataSource = DT;





            //закрываем и освобождаем ресурсы
            connection.Close();
            connection.Dispose();

        }



















        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// загрузка модемов
        /// </summary>



        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
       



        public class Modems_data
        {
            [JsonProperty("id")]
            public string id { get; set; }

            [JsonProperty("modem_type")]
            public string modem_type { get; set; }

            [JsonProperty("modem_full_type")]
            public string modem_full_type { get; set; }

            [JsonProperty("modem_modification")]
            public string modem_modification { get; set; }

            [JsonProperty("protocol_id")]
            public string protocol_id { get; set; }

            [JsonProperty("flavor_id")]
            public string flavor_id { get; set; }

            [JsonProperty("last_station_time")]
            public string last_station_time { get; set; }

            [JsonProperty("last_config_time")]
            public string last_config_time { get; set; }

            [JsonProperty("hw_version")]
            public string hw_version { get; set; }

            [JsonProperty("sw_version")]
            public string sw_version { get; set; }

            [JsonProperty("latitude")]
            public string latitude { get; set; }

            [JsonProperty("longitude")]
            public string longitude { get; set; }

            [JsonProperty("reg_way")]
            public string reg_way { get; set; }

            [JsonProperty("reg_date")]
            public string reg_date { get; set; }

            [JsonProperty("disabled")]
            public string disabled { get; set; }

            [JsonProperty("temperature")]
            public string temperature { get; set; }

            [JsonProperty("battery")]
            public string battery { get; set; }

            [JsonProperty("battery_type")]
            public string battery_type { get; set; }

            [JsonProperty("last_info_message")]
            public string last_info_message { get; set; }

            [JsonProperty("value_formats")]
            public string value_formats { get; set; }

            [JsonProperty("is_balance")]
            public string is_balance { get; set; }

            [JsonProperty("dl_enabled")]
            public string dl_enabled { get; set; }

            [JsonProperty("dl_change_timestamp")]
            public string dl_change_timestamp { get; set; }

            [JsonProperty("last_snr")]
            public string last_snr { get; set; }

            [JsonProperty("previous_snr")]
            public string previous_snr { get; set; }

            [JsonProperty("last_rssi")]
            public string last_rssi { get; set; }

            [JsonProperty("previous_rssi")]
            public string previous_rssi { get; set; }

            [JsonProperty("station_id")]
            public string station_id { get; set; }

        }

       

        private void button2_Click_3(object sender, EventArgs e)
        {






            dataGridView3.Rows.Clear();

            string connectionString = GetConnectionString();

            SqlConnection connection = new SqlConnection();

            connection.ConnectionString = connectionString;

            connection.Open();


            string sql = "SELECT [id_tree_el] FROM [waviot_data].[dbo].[tree_elements]";

            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();


            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    

                    string json = getContent("https://lk.curog.ru/api.tree/get_modems/?id=" + reader.GetInt32(0).ToString() + "&key=9778a18d58d75bf6d569d31ef277c2cc");
                    Newtonsoft.Json.Linq.JObject resultObject = Newtonsoft.Json.Linq.JObject.Parse(json);

                    var str1 = resultObject["modems"].ToString();
                    

                    string str0 = resultObject["status"].ToString();
                    if (str0 == "ok")
                    {
                        if (str1 != "[]" && str1 != null)
                        {
                            str1 = str1.Trim(new Char[] { '[', ']' });
                            MessageBox.Show(str1.ToString());
                            Modems_data modems_d = JsonConvert.DeserializeObject<Modems_data>(str1);

                           // записываем данные в таблицу по модемам modems
                           //   MessageBox.Show(modems_d.last_config_time);
                            //MessageBox.Show(reader.GetInt32(0).ToString());
                            //MessageBox.Show(modems_d.id);
                            //MessageBox.Show(modems_d.modem_type);
                            //MessageBox.Show(modems_d.modem_full_type);
                            //MessageBox.Show(modems_d.modem_modification);
                            //MessageBox.Show(modems_d.protocol_id);
                            //MessageBox.Show(modems_d.flavor_id);
                            //MessageBox.Show(modems_d.last_station_time);
                            //MessageBox.Show(modems_d.last_config_time);
                            //MessageBox.Show(modems_d.hw_version);
                            //MessageBox.Show(modems_d.sw_version);
                            //MessageBox.Show(modems_d.latitude);
                            //MessageBox.Show(modems_d.longitude);
                            //MessageBox.Show(modems_d.reg_way);
                            //MessageBox.Show(modems_d.reg_date);
                            //MessageBox.Show(modems_d.disabled);
                            //MessageBox.Show(modems_d.temperature);
                            //MessageBox.Show(modems_d.battery);
                            //MessageBox.Show(modems_d.battery_type);
                            //MessageBox.Show(modems_d.last_info_message);
                            //MessageBox.Show(modems_d.value_formats);
                            //MessageBox.Show(modems_d.is_balance);
                            //MessageBox.Show(modems_d.dl_enabled);
                            //MessageBox.Show(modems_d.dl_change_timestamp);
                            //MessageBox.Show(modems_d.last_snr);
                            //MessageBox.Show(modems_d.previous_snr);
                            //MessageBox.Show(modems_d.last_rssi);
                            //MessageBox.Show(modems_d.previous_rssi);
                            //MessageBox.Show(modems_d.station_id);
                            Application.DoEvents();

                            string sql4 = "INSERT INTO [waviot_data].[dbo].[modems] ( " +                                                                 
                                                                 "  [id_tree_el] " +
                                                                 " ,[id_16hex] " +
                                                                 " ,[modem_type] " +
                                                                 " ,[modem_full_type] " +
                                                                 " ,[modem_modification] " +
                                                                 " ,[protocol_id] " +
                                                                 " ,[flavor_id] " +
                                                                 " ,[last_station_time] " +
                                                                 " ,[last_config_time] " +
                                                                 " ,[hw_version] " +
                                                                 " ,[sw_version] " +
                                                                 " ,[latitude] " +
                                                                 " ,[longitude] " +
                                                                 " ,[reg_way] " +
                                                                 " ,[reg_date] " +
                                                                 " ,[disabled] " +
                                                                 " ,[temperature] " +
                                                                 " ,[battery] " +
                                                                 " ,[battery_type] " +
                                                                 " ,[last_info_message] " +
                                                                 " ,[value_formats] " +
                                                                 " ,[is_balance] " +
                                                                 " ,[dl_enabled] " +
                                                                 " ,[dl_change_timestamp] " +
                                                                 " ,[last_snr] " +
                                                                 " ,[previous_snr] " +
                                                                 " ,[last_rssi] " +
                                                                 " ,[previous_rssi] " +
                                                                 " ,[station_id] )" +
                                                                   " VALUES ( " +
                                                                   " '" + reader.GetInt32(0).ToString() + "', " +
                                                                   " '" + modems_d.id + "', " +
                                                                   " '" + modems_d.modem_type + "', " +
                                                                   " '" + modems_d.modem_full_type + "', " +
                                                                   " '" + modems_d.modem_modification + "', " +
                                                                   " '" + modems_d.protocol_id + "', " +
                                                                   " '" + modems_d.flavor_id + "', " +
                                                                   " '" + modems_d.last_station_time + "', " +
                                                                   " '" + modems_d.last_config_time + "', " +
                                                                   " '" + modems_d.hw_version + "', " +
                                                                   " '" + modems_d.sw_version + "', " +
                                                                   " '" + modems_d.latitude + "', " +
                                                                   " '" + modems_d.longitude + "', " +
                                                                   " '" + modems_d.reg_way + "', " +
                                                                   " '" + modems_d.reg_date + "', " +
                                                                   " '" + modems_d.disabled + "', " +
                                                                   " '" + modems_d.temperature + "', " +
                                                                   " '" + modems_d.battery + "', " +
                                                                   " '" + modems_d.battery_type + "', " +
                                                                   " '" + modems_d.last_info_message + "', " +
                                                                   " '" + modems_d.value_formats + "', " +
                                                                   " '" + modems_d.is_balance + "', " +
                                                                   " '" + modems_d.dl_enabled + "', " +
                                                                   " '" + modems_d.dl_change_timestamp + "', " +
                                                                   " '" + modems_d.last_snr + "', " +
                                                                   " '" + modems_d.previous_snr + "', " +                                                                  
                                                                   " '" + modems_d.last_rssi + "', " +
                                                                   " '" + modems_d.previous_rssi + "', " +
                                                                   " '" + modems_d.station_id + "' " +
                                                                   " )";
                            // объект для выполнения SQL-запроса
                            SqlCommand command4 = new SqlCommand(sql4, connection);
                            command4.ExecuteNonQuery();





                        }
                    }
                }
            }


            // запрос
            string sql_V = "SELECT * " +
                           "FROM [waviot_data].[dbo].[modems]";
            // объект для выполнения SQL-запроса
            SqlCommand command_v = new SqlCommand(sql_V, connection);

            command_v.ExecuteNonQuery();
            System.Data.SqlClient.SqlDataAdapter DA = new System.Data.SqlClient.SqlDataAdapter(command_v);
            DataTable DT = new DataTable();
            DA.Fill(DT);
            dataGridView3.DataSource = DT;
            //закрываем и освобождаем ресурсы
            connection.Close();
            connection.Dispose();
        }
    }
    }

