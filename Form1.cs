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

        int i_timer_sbor;

        public string GetConnectionString()
        {
            return "Data Source=" + textBox1.Text + ";Initial Catalog=" + textBox2.Text + ";Persist Security Info=True;User ID=" + textBox3.Text + ";Password=" + textBox4.Text + ";MultipleActiveResultSets=True";

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = GetConnectionString();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();

            // запрос
            string sql_V = "SELECT [id]"+
                              " ,[id_channel]"+
                              " ,[short_name]" +
                              " ,[obis_hex]" +
                              " ,[obis_decimal]" +
                              " ,[comments_]" +
                              " ,[unit_measurement]" +
                                " FROM[waviot_data].[dbo].[channels_list]";
            // объект для выполнения SQL-запроса
            SqlCommand command_v = new SqlCommand(sql_V, connection);

            command_v.ExecuteNonQuery();
            System.Data.SqlClient.SqlDataAdapter DA = new System.Data.SqlClient.SqlDataAdapter(command_v);
            DataTable DT = new DataTable();
            DA.Fill(DT);
             dataGridView6.DataSource = DT;
            dataGridView6.Columns[0].Width = 30;
            dataGridView6.Columns[1].HeaderText = "№";                      dataGridView6.Columns[1].Width = 30;
            dataGridView6.Columns[2].HeaderText = "Канал";                  dataGridView6.Columns[2].Width = 140;
            dataGridView6.Columns[3].HeaderText = "Короткое наз.";          dataGridView6.Columns[3].Width = 50;
            dataGridView6.Columns[4].HeaderText = "16HEX";                  dataGridView6.Columns[4].Width = 80;
            dataGridView6.Columns[5].HeaderText = "DEC";                    dataGridView6.Columns[5].Width = 80;
            dataGridView6.Columns[6].HeaderText = "Определение";            dataGridView6.Columns[6].Width = 180;
            dataGridView6.Columns[7].HeaderText = "Измер.";                 dataGridView6.Columns[7].Width = 50;


            
            //закрываем и освобождаем ресурсы
            connection.Close();
            connection.Dispose();


           

        }

        private string getContent(string url)
        {
            try
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
            catch (WebException ex)
            {
                return null;

            }
            
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
           // MessageBox.Show(str0.ToString());

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
                                    Application.DoEvents();
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
                                                values4.Clear();
                                            }



                                        }
                                        values3.Clear();
                                    }







                                }
                                values2.Clear();

                            }
                        }

                    }

                }

            }
            values.Clear();
            connection.Close();
            connection.Dispose();

            toolStripStatusLabel1.Text = "1";
            toolStripStatusLabel9.Text = "0";

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
                    Application.DoEvents();
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
                                Application.DoEvents();
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
                            values.Clear();
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


            toolStripStatusLabel2.Text = "1";
            toolStripStatusLabel9.Text = "0";
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



        public class ModemList
        {            
            public List<Modems_data> modems;
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

                    Application.DoEvents();

                    string json = getContent("https://lk.curog.ru/api.tree/get_modems/?id=" + reader.GetInt32(0).ToString() + "&key=9778a18d58d75bf6d569d31ef277c2cc");
                    Newtonsoft.Json.Linq.JObject resultObject = Newtonsoft.Json.Linq.JObject.Parse(json);

                    var str1 = resultObject["modems"].ToString();
                    

                    string str0 = resultObject["status"].ToString();
                    if (str0 == "ok")
                    {
                        if (str1 != "[]" && str1 != null)
                        {
                            //  str1 = str1.Trim(new Char[] { '[', ']' });
                            str1 = "\"modems:\"" + str1;                          
                            ModemList ss = JsonConvert.DeserializeObject<ModemList>(json);
                            // записываем данные в таблицу по модемам modems
                            foreach (var obj in ss.modems)
                            {

                                //запрос на существование id в базе
                                // запрос
                                string id_modem_5 = "";
                                string sql5_1 = "SELECT [id_16hex] FROM [waviot_data].[dbo].[modems] WHERE [id_16hex]='" + obj.id + "'";
                                // объект для выполнения SQL-запроса
                                SqlCommand command5_1 = new SqlCommand(sql5_1, connection);
                                // выполняем запрос и получаем ответ
                                if (command5_1.ExecuteScalar() != null)
                                {
                                    id_modem_5 = command5_1.ExecuteScalar().ToString();
                                }


                                if (id_modem_5 == obj.id)
                                {
                                    // запрос
                                    string sql4_0 = "UPDATE [waviot_data].[dbo].[modems] " +
                                                        "  SET    " +

                                                                         "  [id_tree_el] = '" + reader.GetInt32(0).ToString() + "'" +
                                                                         " ,[modem_type] = '" + obj.modem_type + "' " +
                                                                         " ,[modem_full_type] = '" + obj.modem_full_type + "' " +
                                                                         " ,[modem_modification] = '" + obj.modem_modification + "' " +
                                                                         " ,[protocol_id] = '" + obj.protocol_id + "' " +
                                                                         " ,[flavor_id] = '" + obj.flavor_id + "' " +
                                                                         " ,[last_station_time] = '" + obj.last_station_time + "' " +
                                                                         " ,[last_config_time] = '" + obj.last_config_time + "' " +
                                                                         " ,[hw_version] = '" + obj.hw_version + "' " +
                                                                         " ,[sw_version] = '" + obj.sw_version + "' " +
                                                                         " ,[latitude] = '" + obj.latitude + "' " +
                                                                         " ,[longitude] = '" + obj.longitude + "' " +
                                                                         " ,[reg_way] = '" + obj.reg_way + "' " +
                                                                         " ,[reg_date] = '" + obj.reg_date + "' " +
                                                                         " ,[disabled] = '" + obj.disabled + "' " +
                                                                         " ,[temperature] = '" + obj.temperature + "' " +
                                                                         " ,[battery] = '" + obj.battery + "' " +
                                                                         " ,[battery_type] = '" + obj.battery_type + "' " +
                                                                         " ,[last_info_message] = '" + obj.last_info_message + "' " +
                                                                         " ,[value_formats] = '" + obj.value_formats + "' " +
                                                                         " ,[is_balance] = '" + obj.is_balance + "' " +
                                                                         " ,[dl_enabled] = '" + obj.dl_enabled + "' " +
                                                                         " ,[dl_change_timestamp] = '" + obj.dl_change_timestamp + "' " +
                                                                         " ,[last_snr] = '" + obj.last_snr + "' " +
                                                                         " ,[previous_snr] = '" + obj.previous_snr + "' " +
                                                                         " ,[last_rssi] = '" + obj.last_rssi + "' " +
                                                                         " ,[previous_rssi] = '" + obj.previous_rssi + "' " +
                                                                         " ,[station_id] = '" + obj.station_id + "' " +

                                                        " WHERE  " +
                                                        "     [id_16hex] = '" + obj.id + "' " +
                                                        " ";
                                    // объект для выполнения SQL-запроса
                                    SqlCommand command5_0 = new SqlCommand(sql4_0, connection);
                                    command5_0.ExecuteNonQuery();
                                }
                                else
                                {


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
                                                                           " '" + obj.id + "', " +
                                                                           " '" + obj.modem_type + "', " +
                                                                           " '" + obj.modem_full_type + "', " +
                                                                           " '" + obj.modem_modification + "', " +
                                                                           " '" + obj.protocol_id + "', " +
                                                                           " '" + obj.flavor_id + "', " +
                                                                           " '" + obj.last_station_time + "', " +
                                                                           " '" + obj.last_config_time + "', " +
                                                                           " '" + obj.hw_version + "', " +
                                                                           " '" + obj.sw_version + "', " +
                                                                           " '" + obj.latitude + "', " +
                                                                           " '" + obj.longitude + "', " +
                                                                           " '" + obj.reg_way + "', " +
                                                                           " '" + obj.reg_date + "', " +
                                                                           " '" + obj.disabled + "', " +
                                                                           " '" + obj.temperature + "', " +
                                                                           " '" + obj.battery + "', " +
                                                                           " '" + obj.battery_type + "', " +
                                                                           " '" + obj.last_info_message + "', " +
                                                                           " '" + obj.value_formats + "', " +
                                                                           " '" + obj.is_balance + "', " +
                                                                           " '" + obj.dl_enabled + "', " +
                                                                           " '" + obj.dl_change_timestamp + "', " +
                                                                           " '" + obj.last_snr + "', " +
                                                                           " '" + obj.previous_snr + "', " +
                                                                           " '" + obj.last_rssi + "', " +
                                                                           " '" + obj.previous_rssi + "', " +
                                                                           " '" + obj.station_id + "' " +
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


            toolStripStatusLabel3.Text = "1";
            toolStripStatusLabel9.Text = "0";
        }
















        /// <summary>
        /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// /////////////////////////////получение данных об устройстве divices - канал модема
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>














       

        public class Event
        {
            public string timestamp { get; set; }
            public string code { get; set; }
        }


        //public class EventList
        //{
        //    public List<Event> events { get; set; }
        //}

        public class Registr
        {
            public string id { get; set; }
            public string name { get; set; }
            public string channel_id { get; set; }
            public string unit_id { get; set; }
            public string offset { get; set; }
            public object modem_value { get; set; }
            public object last_value { get; set; }
            public object last_value_timestamp { get; set; }
            public object billing_init_value { get; set; }
            public object billing_init_timestamp { get; set; }
            public object events { get; set; }
        }

       
        public class Devices
        {
            public string id { get; set; }
            public string name { get; set; }
            public string class_name { get; set; }
            public string device_sn { get; set; }
            public string modem_id { get; set; }
            public object device_time { get; set; }
            public string config_time { get; set; }
            public string timezone { get; set; }
            public object registrators { get; set; }
        }

     

        public class Root_devices
        {
            public string status { get; set; }
            public List<Devices> devices { get; set; }
        }













        private void button3_Click_1(object sender, EventArgs e)
        {


           

            string connectionString = GetConnectionString();

            SqlConnection connection = new SqlConnection();

            connection.ConnectionString = connectionString;

            connection.Open();


            string sql = "SELECT DISTINCT [id_tree_el] FROM [waviot_data].[dbo].[modems]";

            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();


            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string json = getContent("https://lk.curog.ru/api.data/get_full_element_info/?id=" + reader.GetInt32(0).ToString() + "&key=9778a18d58d75bf6d569d31ef277c2cc");
                    Newtonsoft.Json.Linq.JObject resultObject = Newtonsoft.Json.Linq.JObject.Parse(json);

                    var str0 = resultObject["status"].ToString();
                    var str1 = resultObject["devices"].ToString();

                    
                    if (str0 == "ok")
                    {
                        if (str1 != "")
                        {

                            var output = JsonConvert.DeserializeObject<Dictionary<string, Devices>>(str1);

                            if (output != null)
                            {

                                foreach (KeyValuePair<string, Devices> keyValue in output)
                                {
                                    
                                    //запись в базу devices
                                    Application.DoEvents();
                                    //запрос на существование id в базе
                                    // запрос
                                    string device_id_4 = "";
                                    string sql4_1 = "SELECT [device_id] FROM [waviot_data].[dbo].[devices] WHERE [device_id]='" + keyValue.Value.id + "'";
                                    // объект для выполнения SQL-запроса
                                    SqlCommand command4_1 = new SqlCommand(sql4_1, connection);
                                    // выполняем запрос и получаем ответ
                                    if (command4_1.ExecuteScalar() != null)
                                    {
                                        device_id_4 = command4_1.ExecuteScalar().ToString();
                                    }


                                    if (device_id_4 == keyValue.Value.id)
                                    {
                                        // запрос
                                        string sql4_0 = "UPDATE [waviot_data].[dbo].[devices] " +
                                                            "  SET    " +
                                                            " [name]='" + keyValue.Value.name + "' " +
                                                            " ,[class_name]='" + keyValue.Value.class_name + "' " +
                                                            " ,[device_sn]='" + keyValue.Value.device_sn + "' " +
                                                            " ,[modem_id]='" + keyValue.Value.modem_id + "' " +
                                                            " ,[device_time]='" + keyValue.Value.device_time + "' " +
                                                            " ,[config_time]='" + keyValue.Value.config_time + "' " +
                                                            " ,[timezone]='" + keyValue.Value.timezone + "' "+
                                        " WHERE  " +
                                                            "     [device_id] = '" + keyValue.Value.id + "' " +
                                                            " ";
                                        // объект для выполнения SQL-запроса
                                        SqlCommand command4_0 = new SqlCommand(sql4_0, connection);
                                        command4_0.ExecuteNonQuery();
                                    }
                                    else
                                    {
                                        string sql4 = "" +
                                         "INSERT INTO [waviot_data].[dbo].[devices] ( " +
                                                                          " [device_id] " +
                                                                          " ,[name] " +
                                                                          " ,[class_name] " +
                                                                          " ,[device_sn] " +
                                                                          " ,[modem_id] " +
                                                                          " ,[device_time] " +
                                                                          " ,[config_time] " +
                                                                          " ,[timezone] ) " +
                                                                           " VALUES ( " +
                                                                           " '" + keyValue.Value.id + "', " +
                                                                           " '" + keyValue.Value.name + "', " +
                                                                           " '" + keyValue.Value.class_name + "', " +
                                                                           " '" + keyValue.Value.device_sn + "', " +
                                                                           " '" + keyValue.Value.modem_id + "', " +
                                                                           " '" + keyValue.Value.device_time + "', " +
                                                                           " '" + keyValue.Value.config_time + "', " +
                                                                           " '" + keyValue.Value.timezone + "' " +
                                                                           " )";
                                       
                                        SqlCommand command4 = new SqlCommand(sql4, connection);
                                        command4.ExecuteNonQuery();
                                    }
                                    //////////////////////////////////////////////////////////////////
                                    if (keyValue.Key != null && keyValue.Value.registrators != null)
                                    {

                                        var output2 = JsonConvert.DeserializeObject<Dictionary<string, Registr>>(keyValue.Value.registrators.ToString());
                                        foreach (KeyValuePair<string, Registr> keyValue2 in output2)
                                        {
                                            //   MessageBox.Show(keyValue2.Key + "---" + keyValue2.Value.id);

                                            //запись в базу registrators
                                            Application.DoEvents();
                                            if (device_id_4 == keyValue.Value.id)
                                            {
                                                // запрос
                                                string sql5_0 = "UPDATE [waviot_data].[dbo].[registrators] " +
                                                                    "  SET    " +
                                                                    " [channel]='" + keyValue2.Value.channel_id + "' " +                                                                                                                                     
                                                " WHERE  " +
                                                                    "     [device_id] = '" + keyValue.Value.id + "' " +
                                                                    " ";
                                                // объект для выполнения SQL-запроса
                                                SqlCommand command5_0 = new SqlCommand(sql5_0, connection);
                                                command5_0.ExecuteNonQuery();

                                                // запрос
                                                string sql6_0 = "UPDATE [waviot_data].[dbo].[registrators_channel] " +
                                                                    "  SET    " +
                                                                    " [id_registrators]             ='" + keyValue2.Value.id + "' " +
                                                                    " ,[name]                       ='" + keyValue2.Value.name + "' " +
                                                                    " ,[channel_id]                 ='" + keyValue2.Value.channel_id + "' " +
                                                                    " ,[unit_id]                    ='" + keyValue2.Value.unit_id + "' " +
                                                                    " ,[offset]                     ='" + keyValue2.Value.offset + "' " +
                                                                    " ,[modem_value]                ='" + keyValue2.Value.modem_value + "' " +
                                                                    " ,[last_value]                 ='" + keyValue2.Value.last_value + "' " +
                                                                    " ,[last_value_timestamp]       ='" + keyValue2.Value.last_value_timestamp + "' " +
                                                                    " ,[billing_init_value]         ='" + keyValue2.Value.billing_init_value + "' " +
                                                                    " ,[billing_init_timestamp]     ='" + keyValue2.Value.billing_init_timestamp + "' " +                                                                    
                                                " WHERE  " +
                                                                    "     [device_id] = '" + keyValue.Value.id + "' " +
                                                                    " ";
                                                // объект для выполнения SQL-запроса
                                                SqlCommand command6_0 = new SqlCommand(sql6_0, connection);
                                                command6_0.ExecuteNonQuery();
                                            }
                                            else
                                            {
                                                string sql5 = "INSERT INTO [waviot_data].[dbo].[registrators] ( " +
                                                                                      "[device_id] " +
                                                                                      ",[channel] ) " +
                                                                                   " VALUES ( " +
                                                                                   " '" + keyValue.Value.id + "', " +
                                                                                   " '" + keyValue2.Value.channel_id + "' " +
                                                                                   " )";
                                                // объект для выполнения SQL-запроса
                                                SqlCommand command5 = new SqlCommand(sql5, connection);
                                                command5.ExecuteNonQuery();
                                                //////////////////////////////////////////////////////////////////
                                                ///
                                                //запись в базу registrators_channel                                           

                                                string sql6 = "INSERT INTO [waviot_data].[dbo].[registrators_channel] ( " +
                                                                                            " [device_id] " +
                                                                                            "  ,[id_registrators] " +
                                                                                            "  ,[name] " +
                                                                                            "  ,[channel_id] " +
                                                                                            "  ,[unit_id] " +
                                                                                            "  ,[offset] " +
                                                                                            "  ,[modem_value] " +
                                                                                            "  ,[last_value] " +
                                                                                            "  ,[last_value_timestamp] " +
                                                                                            "  ,[billing_init_value] " +
                                                                                            "  ,[billing_init_timestamp] " +
                                                                                            ") " +
                                                                                       " VALUES ( " +
                                                                                       " '" + keyValue.Value.id + "', " +
                                                                                       " '" + keyValue2.Value.id + "', " +
                                                                                       " '" + keyValue2.Value.name + "', " +
                                                                                       " '" + keyValue2.Value.channel_id + "', " +
                                                                                       " '" + keyValue2.Value.unit_id + "', " +
                                                                                       " '" + keyValue2.Value.offset + "', " +
                                                                                       " '" + keyValue2.Value.modem_value + "', " +
                                                                                       " '" + keyValue2.Value.last_value + "', " +
                                                                                       " '" + keyValue2.Value.last_value_timestamp + "', " +
                                                                                       " '" + keyValue2.Value.billing_init_value + "', " +
                                                                                       " '" + keyValue2.Value.billing_init_timestamp + "' " +
                                                                                       " )";
                                                // объект для выполнения SQL-запроса
                                                SqlCommand command6 = new SqlCommand(sql6, connection);
                                                command6.ExecuteNonQuery();
                                            }
                                            //////////////////////////////////////////////////////////////////

                                            if (keyValue2.Value.events != "" && keyValue2.Value.events != "[]" && keyValue2.Value.events != null)
                                            {

                                                string str1events = keyValue2.Value.events.ToString();
                                                ////последний массив вложенный массив данных в events
                                                ///

                                              

                                                List<Event> list = JsonConvert.DeserializeObject<List<Event>>(str1events);


                                                foreach (var obj in list)
                                                {
                                                    // MessageBox.Show(obj.timestamp.ToString() + "----" + obj.code.ToString());

                                                    //запись в базу registrators_events                                          
                                                    if (device_id_4 == keyValue.Value.id)
                                                    {
                                                        // запрос
                                                        string sql7_0 = "UPDATE [waviot_data].[dbo].[registrators_events] " +
                                                                            "  SET    " +
                                                                            " [registrators_id]='" + keyValue2.Value.id + "' " +
                                                                            " ,[channel]='" + keyValue2.Value.channel_id + "' " +
                                                                            " ,[timestamp]='" + obj.timestamp + "' " +
                                                                            " ,[code]='" + obj.code + "' " +
                                                        " WHERE  " +
                                                                            "     [device_id] = '" + keyValue.Value.id + "' " +
                                                                            " ";
                                                        // объект для выполнения SQL-запроса
                                                        SqlCommand command7_0 = new SqlCommand(sql7_0, connection);
                                                        command7_0.ExecuteNonQuery();
                                                    }
                                                    else
                                                    {
                                                        string sql7 = "INSERT INTO [waviot_data].[dbo].[registrators_events] ( " +
                                                                                                " [device_id] " +
                                                                                                " ,[registrators_id] " +
                                                                                                " ,[channel] " +
                                                                                                " ,[timestamp] " +
                                                                                                " ,[code] " +
                                                                                                ") " +
                                                                                           " VALUES ( " +
                                                                                           " '" + keyValue.Value.id + "', " +
                                                                                           " '" + keyValue2.Value.id + "', " +
                                                                                           " '" + keyValue2.Value.channel_id + "', " +
                                                                                           " '" + obj.timestamp + "', " +
                                                                                           " '" + obj.code + "' " +
                                                                                           " )";
                                                        // объект для выполнения SQL-запроса
                                                        SqlCommand command7 = new SqlCommand(sql7, connection);
                                                        command7.ExecuteNonQuery();
                                                    }
                                                    //////////////////////////////////////////////////////////////////

                                                }
                                                list.Clear();

                                            }
                                        }
                                        output2.Clear();
                                    }

                                }
                            }
                            output.Clear();
                        }

                    }
                }
            }

            dataGridView4.Rows.Clear();
            dataGridView7.Rows.Clear();
            dataGridView8.Rows.Clear();
            dataGridView9.Rows.Clear();
            //запрос
            string sql_V = "SELECT * " +
                           "FROM [waviot_data].[dbo].[modems]";
            // объект для выполнения SQL-запроса
            SqlCommand command_v = new SqlCommand(sql_V, connection);

            command_v.ExecuteNonQuery();
            System.Data.SqlClient.SqlDataAdapter DA = new System.Data.SqlClient.SqlDataAdapter(command_v);
            DataTable DT = new DataTable();
            DA.Fill(DT);
            dataGridView4.DataSource = DT;

            //запрос
            string sql_V_1 = "SELECT * " +
                           "FROM [waviot_data].[dbo].[modems]";
            // объект для выполнения SQL-запроса
            SqlCommand command_v_1 = new SqlCommand(sql_V_1, connection);

            command_v_1.ExecuteNonQuery();
            System.Data.SqlClient.SqlDataAdapter DA_1 = new System.Data.SqlClient.SqlDataAdapter(command_v_1);
            DataTable DT_1 = new DataTable();
            DA.Fill(DT_1);
            dataGridView7.DataSource = DT_1;

            //запрос
            string sql_V_2 = "SELECT * " +
                           "FROM [waviot_data].[dbo].[modems]";
            // объект для выполнения SQL-запроса
            SqlCommand command_v_2 = new SqlCommand(sql_V_2, connection);

            command_v_2.ExecuteNonQuery();
            System.Data.SqlClient.SqlDataAdapter DA_2 = new System.Data.SqlClient.SqlDataAdapter(command_v_2);
            DataTable DT_2 = new DataTable();
            DA.Fill(DT_2);
            dataGridView8.DataSource = DT_2;

            //запрос
            string sql_V_3 = "SELECT * " +
                           "FROM [waviot_data].[dbo].[modems]";
            // объект для выполнения SQL-запроса
            SqlCommand command_v_3 = new SqlCommand(sql_V_3, connection);

            command_v_3.ExecuteNonQuery();
            System.Data.SqlClient.SqlDataAdapter DA_3 = new System.Data.SqlClient.SqlDataAdapter(command_v_3);
            DataTable DT_3 = new DataTable();
            DA_3.Fill(DT_3);
            dataGridView9.DataSource = DT_3;

            connection.Close();
            connection.Dispose();

            toolStripStatusLabel4.Text = "1";
            toolStripStatusLabel9.Text = "0";
        }










        /// <summary>
        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// //////////////////////////////////////////////////////////////Получение основных данных о модеме
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
               

        public class PhobosSyncData_a
        {
            [JsonProperty("modem_id")]
            public string modem_id { get; set; }

            [JsonProperty("sync_subject")]
            public string sync_subject { get; set; }

            [JsonProperty("sync_timestamp")]
            public string sync_timestamp { get; set; }

            [JsonProperty("request_status")]
            public string request_status { get; set; }

            [JsonProperty("user_id")]
            public string user_id { get; set; }

            [JsonProperty("username")]
            public string username { get; set; }

            [JsonProperty("display_name")]
            public string display_name { get; set; }

            [JsonProperty("role")]
            public string role { get; set; }

            [JsonProperty("company_id")]
            public string company_id { get; set; }

            [JsonProperty("company_name")]
            public string company_name { get; set; }

           
        }



        public class PhobosSyncData_list
        {
            public List<PhobosSyncData_a> phobos_sync_data;
        }


        private void button5_Click(object sender, EventArgs e)
        {



            string connectionString = GetConnectionString();

            SqlConnection connection = new SqlConnection();

            connection.ConnectionString = connectionString;

            connection.Open();


            string sql = "SELECT [id_16hex] FROM [waviot_data].[dbo].[modems]";

            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();


            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Application.DoEvents();
                    string json = getContent("https://lk.curog.ru/api.modem/info/?id=" + reader.GetString(0) + "&key=9778a18d58d75bf6d569d31ef277c2cc");
                    Newtonsoft.Json.Linq.JObject resultObject = Newtonsoft.Json.Linq.JObject.Parse(json);
                    var str0 = resultObject["status"].ToString();
                    //  Root_modem output = JsonConvert.DeserializeObject<Root_modem>(json);

                    if (str0 == "ok")
                    {
                        textBox6.Text = json;

                        var str1 = resultObject["modem"]?["id"].ToString();
                       

                        string saving_interval = "";

                        string value_alignment = "";
                        string send_profile = "";

                        string p1_c = "";
                        string p1_p = "";
                        string p1_t = "";

                        string p2_c = "";
                        string p2_p = "";
                        string p2_t = "";

                        string p3_c = "";
                        string p3_p = "";
                        string p3_t = "";

                        string p4_c = "";
                        string p4_p = "";
                        string p4_t = "";


                        string tariffs = "";


                        if (resultObject["modem"]?["phobos_data"]?["load_profile"].ToString() != "")
                        {
                            saving_interval = resultObject["modem"]?["phobos_data"]?["load_profile"]?["saving_interval"].ToString();

                            value_alignment = resultObject["modem"]?["phobos_data"]?["load_profile"]?["value_alignment"].ToString();
                            send_profile = resultObject["modem"]?["phobos_data"]?["load_profile"]?["send_profile"].ToString();

                            p1_c = resultObject["modem"]?["phobos_data"]?["load_profile"]?["p1_c"].ToString();
                            p1_p = resultObject["modem"]?["phobos_data"]?["load_profile"]?["p1_p"].ToString();
                            p1_t = resultObject["modem"]?["phobos_data"]?["load_profile"]?["p1_t"].ToString();

                            p2_c = resultObject["modem"]?["phobos_data"]?["load_profile"]?["p2_c"].ToString();
                            p2_p = resultObject["modem"]?["phobos_data"]?["load_profile"]?["p2_p"].ToString();
                            p2_t = resultObject["modem"]?["phobos_data"]?["load_profile"]?["p2_t"].ToString();

                            p3_c = resultObject["modem"]?["phobos_data"]?["load_profile"]?["p3_c"].ToString();
                            p3_p = resultObject["modem"]?["phobos_data"]?["load_profile"]?["p3_p"].ToString();
                            p3_t = resultObject["modem"]?["phobos_data"]?["load_profile"]?["p3_t"].ToString();

                            p4_c = resultObject["modem"]?["phobos_data"]?["load_profile"]?["p4_c"].ToString();
                            p4_p = resultObject["modem"]?["phobos_data"]?["load_profile"]?["p4_p"].ToString();
                            p4_t = resultObject["modem"]?["phobos_data"]?["load_profile"]?["p4_t"].ToString();

                        }
                        if (resultObject["modem"]?["phobos_data"]?["tariffs"].ToString() != "")
                        {


                            tariffs = resultObject["modem"]?["phobos_data"]?["tariffs"].ToString();

                        }

                        //проверка на существования повторных показаний
                        string id_2 = "";
                        string sql1_1 = "SELECT [id] FROM [waviot_data].[dbo].[modem_info] WHERE [modem_id]='" + resultObject["modem"]?["id"].ToString() + "' ";
                        // объект для выполнения SQL-запроса
                        SqlCommand command1_1 = new SqlCommand(sql1_1, connection);
                        // выполняем запрос и получаем ответ
                        if (command1_1.ExecuteScalar() != null)
                        {
                            id_2 = command1_1.ExecuteScalar().ToString();
                        }
                        if (id_2 == "")
                        {


                            string sql7 = "INSERT INTO [waviot_data].[dbo].[modem_info] ( " +
                                                                                              " [modem_id] " +
                                                                                              " ,[modem_type] " +
                                                                                              " ,[protocol_id] " +
                                                                                              " ,[last_station_time] " +
                                                                                              " ,[last_config_time] " +
                                                                                              " ,[hw_version] " +
                                                                                              " ,[sw_version] " +
                                                                                              " ,[latitude] " +
                                                                                              " ,[longitude] " +
                                                                                              " ,[temperature] " +
                                                                                              " ,[battery] " +
                                                                                              " ,[battery_type] " +
                                                                                              " ,[is_balance] " +
                                                                                              " ,[last_info_message] " +
                                                                                              " ,[dl_change_timestamp] " +
                                                                                              " ,[last_station_time_date] " +
                                                                                              " ,[phobos_data_model] " +
                                                                                              " ,[phobos_data_hw_version] " +
                                                                                              " ,[phobos_data_sw_version] " +
                                                                                              " ,[phobos_data_load_profile_saving_interval] " +
                                                                                              " ,[phobos_data_load_profile_value_alignment] " +
                                                                                              " ,[phobos_data_load_profile_send_profile] " +
                                                                                              " ,[phobos_data_load_profile_p1_c] " +
                                                                                              " ,[phobos_data_load_profile_p1_p] " +
                                                                                              " ,[phobos_data_load_profile_p1_t] " +
                                                                                              " ,[phobos_data_load_profile_p2_c] " +
                                                                                              " ,[phobos_data_load_profile_p2_p] " +
                                                                                              " ,[phobos_data_load_profile_p2_t] " +
                                                                                              " ,[phobos_data_load_profile_p3_c] " +
                                                                                              " ,[phobos_data_load_profile_p3_p] " +
                                                                                              " ,[phobos_data_load_profile_p3_t] " +
                                                                                              " ,[phobos_data_load_profile_p4_c] " +
                                                                                              " ,[phobos_data_load_profile_p4_p] " +
                                                                                              " ,[phobos_data_load_profile_p4_t] " +
                                                                                              " ,[phobos_data_tariffs] " +
                                                                                              " ,[phobos_data_events_filter] " +
                                                                                              " ,[phobos_data_remote_display] " +
                                                                                              " ,[phobos_data_meter_state] " +
                                                                                              " ,[phobos_data_load_limit] " +
                                                                                               ") " +
                                                                                          " VALUES ( " +
                                                                                          " '" + resultObject["modem"]?["id"].ToString() + "', " +
                                                                                          " '" + resultObject["modem"]?["modem_type"].ToString() + "', " +
                                                                                          " '" + resultObject["modem"]?["protocol_id"].ToString() + "', " +
                                                                                          " '" + resultObject["modem"]?["last_station_time"].ToString() + "', " +
                                                                                          " '" + resultObject["modem"]?["last_config_time"].ToString() + "', " +
                                                                                          " '" + resultObject["modem"]?["hw_version"].ToString() + "', " +
                                                                                          " '" + resultObject["modem"]?["sw_version"].ToString() + "', " +
                                                                                          " '" + resultObject["modem"]?["latitude"].ToString() + "', " +
                                                                                          " '" + resultObject["modem"]?["longitude"].ToString() + "', " +
                                                                                          " '" + resultObject["modem"]?["temperature"].ToString() + "', " +
                                                                                          " '" + resultObject["modem"]?["battery"].ToString() + "', " +
                                                                                          " '" + resultObject["modem"]?["battery_type"].ToString() + "', " +
                                                                                          " '" + resultObject["modem"]?["is_balance"].ToString() + "', " +
                                                                                          " '" + resultObject["modem"]?["last_info_message"].ToString() + "', " +
                                                                                          " '" + resultObject["modem"]?["dl_change_timestamp"].ToString() + "', " +
                                                                                          " '" + resultObject["modem"]?["last_station_time_date"].ToString() + "', " +

                                                                                          " '" + resultObject["modem"]?["phobos_data"]?["model"].ToString() + "', " +
                                                                                          " '" + resultObject["modem"]?["phobos_data"]?["hw_version"].ToString() + "', " +
                                                                                          " '" + resultObject["modem"]?["phobos_data"]?["sw_version"].ToString() + "', " +


                                                                                            " '" + saving_interval + "', " +
                                                                                            " '" + value_alignment + "', " +
                                                                                            " '" + send_profile + "', " +

                                                                                            " '" + p1_c + "', " +
                                                                                            " '" + p1_p + "', " +
                                                                                            " '" + p1_t + "', " +

                                                                                            " '" + p2_c + "', " +
                                                                                            " '" + p2_p + "', " +
                                                                                            " '" + p2_t + "', " +

                                                                                            " '" + p3_c + "', " +
                                                                                            " '" + p3_p + "', " +
                                                                                            " '" + p3_t + "', " +

                                                                                            " '" + p4_c + "', " +
                                                                                            " '" + p4_p + "', " +
                                                                                            " '" + p4_t + "', " +

                                                                                            " '" + tariffs + "', " +


                                                                                          " '" + resultObject["modem"]?["phobos_data"]?["events_filter"].ToString() + "', " +
                                                                                          " '" + resultObject["modem"]?["phobos_data"]?["remote_display"].ToString() + "', " +
                                                                                          " '" + resultObject["modem"]?["phobos_data"]?["meter_state"].ToString() + "', " +
                                                                                          " '" + resultObject["modem"]?["phobos_data"]?["load_limit"].ToString() + "' " +

                                                                                          " )";
                            // объект для выполнения SQL-запроса
                            SqlCommand command7 = new SqlCommand(sql7, connection);
                            command7.ExecuteNonQuery();


                            PhobosSyncData_list ss = JsonConvert.DeserializeObject<PhobosSyncData_list>(resultObject["modem"].ToString());
                            if (ss != null)
                            {

                                if (ss.phobos_sync_data != null)
                                {

                                    foreach (var obj in ss.phobos_sync_data)
                                    {
                                        Application.DoEvents();
                                        string sql8 = "INSERT INTO [waviot_data].[dbo].[modem_phobos_sync_data] ( " +
                                                                                                             "  [modem_id] " +
                                                                                                             "  ,[sync_subject] " +
                                                                                                             "  ,[sync_timestamp] " +
                                                                                                             "  ,[request_status] " +
                                                                                                             "  ,[user_id] " +
                                                                                                             "  ,[username] " +
                                                                                                             "  ,[display_name] " +
                                                                                                             "  ,[role] " +
                                                                                                             "  ,[company_id] " +
                                                                                                             "  ,[company_name] " +
                                                                                                               ") " +
                                                                                                          " VALUES ( " +
                                                                                                          " '" + resultObject["modem"]?["id"].ToString() + "', " +
                                                                                                          " '" + obj.sync_subject + "', " +
                                                                                                          " '" + obj.sync_timestamp + "', " +
                                                                                                          " '" + obj.request_status + "', " +
                                                                                                          " '" + obj.user_id + "', " +
                                                                                                          " '" + obj.username + "', " +
                                                                                                          " '" + obj.display_name + "', " +
                                                                                                          " '" + obj.role + "', " +
                                                                                                          " '" + obj.company_id + "', " +
                                                                                                          " '" + obj.company_name + "' " +
                                                                                                          " )";
                                        // объект для выполнения SQL-запроса
                                        SqlCommand command8 = new SqlCommand(sql8, connection);
                                        command8.ExecuteNonQuery();
                                    }
                                }
                            }
                            ss.phobos_sync_data.Clear();

                        } else
                        {
                            string sql7_0u = "UPDATE [waviot_data].[dbo].[modem_info] " +
                                                                          "  SET    " +                                                                        


                                                                                "[modem_type]= '" + resultObject["modem"]?["modem_type"].ToString() + "', " +
                                                                                "[protocol_id]= '" + resultObject["modem"]?["protocol_id"].ToString() + "', " +
                                                                                "[last_station_time]= '" + resultObject["modem"]?["last_station_time"].ToString() + "', " +
                                                                                "[last_config_time]= '" + resultObject["modem"]?["last_config_time"].ToString() + "', " +
                                                                                "[hw_version]= '" + resultObject["modem"]?["hw_version"].ToString() + "', " +
                                                                                "[sw_version]= '" + resultObject["modem"]?["sw_version"].ToString() + "', " +
                                                                                "[latitude]= '" + resultObject["modem"]?["latitude"].ToString() + "', " +
                                                                                "[longitude]= '" + resultObject["modem"]?["longitude"].ToString() + "', " +
                                                                                "[temperature]= '" + resultObject["modem"]?["temperature"].ToString() + "', " +
                                                                                "[battery]= '" + resultObject["modem"]?["battery"].ToString() + "', " +
                                                                                "[battery_type]= '" + resultObject["modem"]?["battery_type"].ToString() + "', " +
                                                                                "[is_balance]= '" + resultObject["modem"]?["is_balance"].ToString() + "', " +
                                                                                "[last_info_message]= '" + resultObject["modem"]?["last_info_message"].ToString() + "', " +
                                                                                "[dl_change_timestamp]= '" + resultObject["modem"]?["dl_change_timestamp"].ToString() + "', " +
                                                                                "[last_station_time_date]= '" + resultObject["modem"]?["last_station_time_date"].ToString() + "', " +

                                                                                "[phobos_data_model]= '" + resultObject["modem"]?["phobos_data"]?["model"].ToString() + "', " +
                                                                                "[phobos_data_hw_version]= '" + resultObject["modem"]?["phobos_data"]?["hw_version"].ToString() + "', " +
                                                                                "[phobos_data_sw_version]= '" + resultObject["modem"]?["phobos_data"]?["sw_version"].ToString() + "', " +

                                                                                "[phobos_data_load_profile_saving_interval]= '" + saving_interval + "', " +
                                                                                "[phobos_data_load_profile_value_alignment]= '" + value_alignment + "', " +
                                                                                "[phobos_data_load_profile_send_profile]= '" + send_profile + "', " +

                                                                                "[phobos_data_load_profile_p1_c]= '" + p1_c + "', " +
                                                                                "[phobos_data_load_profile_p1_p]= '" + p1_p + "', " +
                                                                                "[phobos_data_load_profile_p1_t]= '" + p1_t + "', " +

                                                                                "[phobos_data_load_profile_p2_c]= '" + p2_c + "', " +
                                                                                "[phobos_data_load_profile_p2_p]= '" + p2_p + "', " +
                                                                                "[phobos_data_load_profile_p2_t]= '" + p2_t + "', " +

                                                                                "[phobos_data_load_profile_p3_c]= '" + p3_c + "', " +
                                                                                "[phobos_data_load_profile_p3_p]= '" + p3_p + "', " +
                                                                                "[phobos_data_load_profile_p3_t]= '" + p3_t + "', " +

                                                                                "[phobos_data_load_profile_p4_c]= '" + p4_c + "', " +
                                                                                "[phobos_data_load_profile_p4_p]= '" + p4_p + "', " +
                                                                                "[phobos_data_load_profile_p4_t]= '" + p4_t + "', " +

                                                                                "[phobos_data_tariffs]= '" + tariffs + "', " +


                                                                                "[phobos_data_events_filter]= '" + resultObject["modem"]?["phobos_data"]?["events_filter"].ToString() + "', " +
                                                                                "[phobos_data_remote_display]= '" + resultObject["modem"]?["phobos_data"]?["remote_display"].ToString() + "', " +
                                                                                "[phobos_data_meter_state]= '" + resultObject["modem"]?["phobos_data"]?["meter_state"].ToString() + "', " +
                                                                                "[phobos_data_load_limit]= '" + resultObject["modem"]?["phobos_data"]?["load_limit"].ToString() + "' " +


                                                      " WHERE  " +
                                                                          "     [modem_id] = '" + resultObject["modem"]?["id"].ToString() + "' " +
                                                                          " ";
                            // объект для выполнения SQL-запроса
                            SqlCommand command7_0u = new SqlCommand(sql7_0u, connection);
                            command7_0u.ExecuteNonQuery();



                            PhobosSyncData_list ss = JsonConvert.DeserializeObject<PhobosSyncData_list>(resultObject["modem"].ToString());
                            if (ss != null)
                            {

                                if (ss.phobos_sync_data != null)
                                {

                                    foreach (var obj in ss.phobos_sync_data)
                                    {


                                        Application.DoEvents();
                                        string sql7_1u = "UPDATE [waviot_data].[dbo].[modem_phobos_sync_data] " +
                                                                         "  SET    " +
                                                                                        "[sync_subject]= '" + obj.sync_subject + "', " +
                                                                                        "[sync_timestamp]= '" + obj.sync_timestamp + "', " +
                                                                                        "[request_status]= '" + obj.request_status + "', " +
                                                                                        "[user_id]= '" + obj.user_id + "', " +
                                                                                        "[username]= '" + obj.username + "', " +
                                                                                        "[display_name]= '" + obj.display_name + "', " +
                                                                                        "[role]= '" + obj.role + "', " +
                                                                                        "[company_id]= '" + obj.company_id + "', " +
                                                                                        "[company_name]= '" + obj.company_name + "' " +



                                                     " WHERE  " +
                                                                         "     [modem_id] = '" + resultObject["modem"]?["id"].ToString() + "' " +
                                                                         " ";
                                        // объект для выполнения SQL-запроса
                                        SqlCommand command7_1u = new SqlCommand(sql7_1u, connection);
                                        command7_1u.ExecuteNonQuery();

                                    }
                                }
                            }
                            ss.phobos_sync_data.Clear();

                        }


                    }

                }
            }




            dataGridView10.Rows.Clear();
            // запрос
            string sql_V = "SELECT * " +
                           "FROM [waviot_data].[dbo].[modem_info]";
            // объект для выполнения SQL-запроса
            SqlCommand command_v = new SqlCommand(sql_V, connection);

            command_v.ExecuteNonQuery();
            System.Data.SqlClient.SqlDataAdapter DA = new System.Data.SqlClient.SqlDataAdapter(command_v);
            DataTable DT = new DataTable();
            DA.Fill(DT);
            dataGridView10.DataSource = DT;
            //закрываем и освобождаем ресурсы         


            connection.Close();
            connection.Dispose();


            toolStripStatusLabel5.Text = "1";
            toolStripStatusLabel9.Text = "0";
        }











        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// ////////////////////////////////////показания счетчиков
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>





        private void button6_Click(object sender, EventArgs e)
        {
            int sec_period = Convert.ToInt32(textBox5.Text) * 60 * 60;
            int unixTimestamp2 = (int)DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            int sec_from = unixTimestamp2 - sec_period;

            dataGridView5.Rows.Clear();

            string connectionString = GetConnectionString();

            SqlConnection connection = new SqlConnection();

            connection.ConnectionString = connectionString;

            connection.Open();





            //////////////получение ссписка каналов из таблицы
            string in_channels_select_id = "";
            foreach (DataGridViewRow row in dataGridView6.Rows)
            {
                if (Convert.ToBoolean(row.Cells[Column7.Name].Value) == true && row.Cells[1].Value != null)
                {
                    in_channels_select_id = in_channels_select_id + "," + row.Cells[1].Value.ToString();
                }
            }
            in_channels_select_id = in_channels_select_id.Trim(new Char[] { ' ', ',' });
            /////////////////////////////////////////////////////

            if (in_channels_select_id != "")
            {
                string sql = "SELECT [id_16hex], [id]  FROM [waviot_data].[dbo].[modems]";

                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();


                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Application.DoEvents();
                        //перебор каналов учета
                        string sql2 = "SELECT [id_channel], [id] FROM [waviot_data].[dbo].[channels_list] WHERE [id] IN (" + in_channels_select_id + ")";

                        SqlCommand command2 = new SqlCommand(sql2, connection);
                        SqlDataReader reader2 = command2.ExecuteReader();


                        if (reader2.HasRows)
                        {
                            while (reader2.Read())
                            {
                                
                                Application.DoEvents();
                                string json = getContent("https://lk.curog.ru/api.data/get_modem_channel_values/?modem_id=" + reader.GetString(0) + "&channel=" + reader2.GetString(0) + " " +
                                    " &from=" + sec_from + " " +
                                    " &to=" + unixTimestamp2 + " " +
                                    "  &key=9778a18d58d75bf6d569d31ef277c2cc");
                                if (json != null)
                                {
                                    Newtonsoft.Json.Linq.JObject resultObject = Newtonsoft.Json.Linq.JObject.Parse(json);
                                    var str1 = resultObject["values"].ToString();
                                    string str0 = resultObject["status"].ToString();
                                    if (str1 != null && str1 != "")
                                    {
                                        if (str0 == "ok")
                                        {

                                            var output = JsonConvert.DeserializeObject<Dictionary<string, string>>(str1);

                                            if (output != null)
                                            {

                                                textBox6.Text = json;

                                                foreach (KeyValuePair<string, string> keyValue in output)
                                                {
                                                    Application.DoEvents();
                                                    //  MessageBox.Show(keyValue.Key + "----" + keyValue.Value);
                                                    // проверяем на нулевые значения разрешено или нет
                                                    if (checkBox1.Checked == false)
                                                    {
                                                        if (keyValue.Value != "0.0000")
                                                        {
                                                            string id_2 = "";
                                                            //проверка на существования повторных показаний
                                                            string sql1_1 = "SELECT [id] FROM [waviot_data].[dbo].[metering] WHERE [timestamp_]='" + keyValue.Key + "' AND [value_]='" + keyValue.Value + "' AND [modem_id]='" + reader.GetInt32(1).ToString() + "' AND [chanel_id]='" + reader2.GetInt32(1).ToString() + "'";
                                                            // объект для выполнения SQL-запроса
                                                            SqlCommand command1_1 = new SqlCommand(sql1_1, connection);
                                                            // выполняем запрос и получаем ответ
                                                            if (command1_1.ExecuteScalar() != null)
                                                            {
                                                                id_2 = command1_1.ExecuteScalar().ToString();
                                                            }
                                                            if (id_2 == "")
                                                            {
                                                                string sql4 = "INSERT INTO [waviot_data].[dbo].[metering] ( " +
                                                                                            "  [modem_id] " +
                                                                                            " ,[chanel_id] " +
                                                                                            " ,[timestamp_] " +
                                                                                            " ,[value_] " +
                                                                                            " )" +
                                                                                              " VALUES ( " +
                                                                                              " '" + reader.GetInt32(1).ToString() + "', " +
                                                                                              " '" + reader2.GetInt32(1).ToString() + "', " +
                                                                                              " '" + keyValue.Key + "', " +
                                                                                              " '" + keyValue.Value + "' " +
                                                                                              " )";

                                                                // объект для выполнения SQL-запроса
                                                                SqlCommand command4 = new SqlCommand(sql4, connection);
                                                                command4.ExecuteNonQuery();
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        string id_2 = "";
                                                        //проверка на существования повторных показаний
                                                        string sql1_1 = "SELECT [id] FROM [waviot_data].[dbo].[metering] WHERE [timestamp_]='" + keyValue.Key + "' AND [value_]='" + keyValue.Value + "' AND [modem_id]='" + reader.GetInt32(1).ToString() + "' AND [chanel_id]='" + reader2.GetInt32(1).ToString() + "'";
                                                        // объект для выполнения SQL-запроса
                                                        SqlCommand command1_1 = new SqlCommand(sql1_1, connection);
                                                        // выполняем запрос и получаем ответ
                                                        if (command1_1.ExecuteScalar() != null)
                                                        {
                                                            id_2 = command1_1.ExecuteScalar().ToString();
                                                        }
                                                        if (id_2 == "")
                                                        {
                                                            string sql4 = "INSERT INTO [waviot_data].[dbo].[metering] ( " +
                                                                                        "  [modem_id] " +
                                                                                        " ,[chanel_id] " +
                                                                                        " ,[timestamp_] " +
                                                                                        " ,[value_] " +
                                                                                        " )" +
                                                                                          " VALUES ( " +
                                                                                          " '" + reader.GetInt32(1).ToString() + "', " +
                                                                                          " '" + reader2.GetInt32(1).ToString() + "', " +
                                                                                          " '" + keyValue.Key + "', " +
                                                                                          " '" + keyValue.Value + "' " +
                                                                                          " )";

                                                            // объект для выполнения SQL-запроса
                                                            SqlCommand command4 = new SqlCommand(sql4, connection);
                                                            command4.ExecuteNonQuery();
                                                        }
                                                    }
                                                }
                                            }
                                            output.Clear();
                                        }
                                    }
                                }

                            }
                        }




                    }
                }
            }
            else
            {
                textBox6.Text = "Необходимо выбрать хоть один канал.";
            }

            // запрос
            string sql_V = "SELECT * " +
                           "FROM [waviot_data].[dbo].[metering]";
            // объект для выполнения SQL-запроса
            SqlCommand command_v = new SqlCommand(sql_V, connection);

            command_v.ExecuteNonQuery();
            System.Data.SqlClient.SqlDataAdapter DA = new System.Data.SqlClient.SqlDataAdapter(command_v);
            DataTable DT = new DataTable();
            DA.Fill(DT);
            dataGridView5.DataSource = DT;
            //закрываем и освобождаем ресурсы         


            connection.Close();
            connection.Dispose();

            toolStripStatusLabel6.Text = "1";
            toolStripStatusLabel9.Text = "0";
        }



































        internal static string UnixToDate(int Timestamp, string ConvertFormat)
        {
            DateTime ConvertedUnixTime = DateTimeOffset.FromUnixTimeSeconds(Timestamp).DateTime;
            return ConvertedUnixTime.ToString(ConvertFormat);
        }

        private void button7_Click(object sender, EventArgs e)
        {
          //  var timestamp = DateTime.Now.ToFileTime();
            int unixTimestamp = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            int unixTimestamp2 = (int)DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            MessageBox.Show(UnixToDate(unixTimestamp, "dd-MM-yyyy HH:mm:ss"));
            MessageBox.Show(UnixToDate(unixTimestamp2, "dd-MM-yyyy HH:mm:ss"));
            MessageBox.Show(unixTimestamp.ToString());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //записывам 
           
            foreach (DataGridViewRow row in dataGridView6.Rows)
            {
                if (Convert.ToBoolean(row.Cells[Column7.Name].Value) == true && row.Cells[1].Value!=null)
                {
                   textBox6.Text = textBox6.Text + row.Cells[1].Value.ToString();
                }
            }
            
           

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void button9_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView6.Rows)
            {
                row.Cells[Column7.Name].Value = true;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView6.Rows)
            {
                row.Cells[Column7.Name].Value = false;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView6.Rows)
            {
                row.Cells[Column7.Name].Value = false;
            }
            dataGridView6[0, 0].Value = true;
            dataGridView6[0, 1].Value = true;
            dataGridView6[0, 4].Value = true;
            dataGridView6[0, 5].Value = true;
            dataGridView6[0, 6].Value = true;
            dataGridView6[0, 9].Value = true;
            dataGridView6[0, 10].Value = true;
            dataGridView6[0, 11].Value = true;
            dataGridView6[0, 14].Value = true;
            dataGridView6[0, 15].Value = true;
            dataGridView6[0, 16].Value = true;
            dataGridView6[0, 19].Value = true;
            dataGridView6[0, 48].Value = true;
            dataGridView6[0, 52].Value = true;
            dataGridView6[0, 57].Value = true;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            timer1_sbor.Enabled = true;

            if (toolStripStatusLabel1.Text == "0" && toolStripStatusLabel2.Text == "0" && toolStripStatusLabel3.Text == "0" && toolStripStatusLabel4.Text == "0" && toolStripStatusLabel5.Text == "0" && toolStripStatusLabel6.Text == "0" && toolStripStatusLabel9.Text == "0")
            {
                toolStripStatusLabel8.Text = "Построение древа. Шаг 1";
                toolStripStatusLabel9.Text = "1";
                button4.PerformClick();
            }

            if (toolStripStatusLabel1.Text == "1" && toolStripStatusLabel2.Text == "0" && toolStripStatusLabel3.Text == "0" && toolStripStatusLabel4.Text == "0" && toolStripStatusLabel5.Text == "0" && toolStripStatusLabel6.Text == "0" && toolStripStatusLabel9.Text == "0")
            {
                toolStripStatusLabel8.Text = "Построение древа. Шаг 2";
                toolStripStatusLabel9.Text = "1";
                button1.PerformClick();
            }

            if (toolStripStatusLabel1.Text == "1" && toolStripStatusLabel2.Text == "1" && toolStripStatusLabel3.Text == "0" && toolStripStatusLabel4.Text == "0" && toolStripStatusLabel5.Text == "0" && toolStripStatusLabel6.Text == "0" && toolStripStatusLabel9.Text == "0")
            {
                toolStripStatusLabel8.Text = "Модемы";
                toolStripStatusLabel9.Text = "1";
                button2.PerformClick();
            }

            if (toolStripStatusLabel1.Text == "1" && toolStripStatusLabel2.Text == "1" && toolStripStatusLabel3.Text == "1" && toolStripStatusLabel4.Text == "0" && toolStripStatusLabel5.Text == "0" && toolStripStatusLabel6.Text == "0" && toolStripStatusLabel9.Text == "0")
            {
                toolStripStatusLabel8.Text = "Устройства";
                toolStripStatusLabel9.Text = "1";
                button3.PerformClick();
            }

            if (toolStripStatusLabel1.Text == "1" && toolStripStatusLabel2.Text == "1" && toolStripStatusLabel3.Text == "1" && toolStripStatusLabel4.Text == "1" && toolStripStatusLabel5.Text == "0" && toolStripStatusLabel6.Text == "0" && toolStripStatusLabel9.Text == "0")
            {
                toolStripStatusLabel8.Text = "Информация о модеме";
                toolStripStatusLabel9.Text = "1";
                button5.PerformClick();
            }

            if (toolStripStatusLabel1.Text == "1" && toolStripStatusLabel2.Text == "1" && toolStripStatusLabel3.Text == "1" && toolStripStatusLabel4.Text == "1" && toolStripStatusLabel5.Text == "1" && toolStripStatusLabel6.Text == "0" && toolStripStatusLabel9.Text == "0")
            {
                toolStripStatusLabel8.Text = "Показания";
                toolStripStatusLabel9.Text = "1";
                button6.PerformClick();
            }

            if (toolStripStatusLabel1.Text == "1" && toolStripStatusLabel2.Text == "1" && toolStripStatusLabel3.Text == "1" && toolStripStatusLabel4.Text == "1" && toolStripStatusLabel5.Text == "1" && toolStripStatusLabel6.Text == "1" && toolStripStatusLabel9.Text == "0")
            {
                toolStripStatusLabel8.Text = "Все данные скачаны. Завршено.";

                toolStripStatusLabel9.Text = "1";

                toolStripStatusLabel1.Text = "0";
                toolStripStatusLabel2.Text = "0";
                toolStripStatusLabel3.Text = "0";
                toolStripStatusLabel4.Text = "0";
                toolStripStatusLabel5.Text = "0";
                toolStripStatusLabel6.Text = "0";
            }
            
        }

        private void timer1_sbor_Tick(object sender, EventArgs e)
        {
            i_timer_sbor++;
            label3.Text = Convert.ToString(i_timer_sbor);
            if (Convert.ToInt32(label3.Text)>=Convert.ToInt32(textBox8.Text))
            {
                if (toolStripStatusLabel1.Text == "1" && toolStripStatusLabel2.Text == "1" && toolStripStatusLabel3.Text == "1" && toolStripStatusLabel4.Text == "1" && toolStripStatusLabel5.Text == "1" && toolStripStatusLabel6.Text == "1")
                {
                    i_timer_sbor = 0;
                    toolStripStatusLabel9.Text = "0";
                    button12.PerformClick();

                }
            }

            button12.PerformClick();
            toolStripStatusLabel9.Text = "1";
            

        }
    }
    }

