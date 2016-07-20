using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace WFA4
{
    public partial class Form1 : Form
    {
                   
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string sql;
            //string mssqlconexion = "Data Source=LAB210-01;" +
            //                  "Initial Catalog=bd_empresa;" +
            //                  "Integrated Security=True;"; // +
            //                  //"User ID=UserName;" + 
            //                  //"Password=Password;";

            string mysqlconexion = "server=sql5.freemysqlhosting.net;" +
                "Port=3306;" +
                "Database=sql5127732;" +
                "Uid=sql5127732;" +
                "Pwd=KQfgCmGNJw;";
                 
            DataTable dt = new DataTable();
            sql = "select " +
                "cedula" + " as 'Cedula'," + 
                "nombre" + " as Nombre," +
                "apellido" + " as Apellido," +
                "direccion" + " as Direccion," +
                "provincia" + " as 'Provincia'" +
                " from " +
                "Persona";


              
            //SqlConnection mssqlconn = new SqlConnection(conexion);
            //sqlconn.Open();

            MySqlConnection mysqlconn = new MySqlConnection(mysqlconexion);
            mysqlconn.Open();

            //SqlDataAdapter sqlda = new SqlDataAdapter(sql, sqlconn);
            //sqlda.Fill(dt);
            //sqlconn.Close();

            MySqlDataAdapter mysqlda = new MySqlDataAdapter(sql, mysqlconn);
            
            mysqlda.Fill(dt);
            mysqlconn.Close(); 

            dataGridView1.DataSource = dt;


           
            DataTable dt1 = new DataTable();
            dt1 = new DataTable();
            sql = "select " +
                "id_provincia," +
                "nom_provincia" +
                " from " +
                "Provincia";

            mysqlconn = new MySqlConnection(mysqlconexion);
            mysqlconn.Open();

            mysqlda = new MySqlDataAdapter(sql, mysqlconn);
            mysqlda.Fill(dt1);
            mysqlconn.Close(); 
            
            int value;
            for (int i = 0; i< dt1.Rows.Count; i ++)
            {

                comboBox1.Items.Insert(i, dt1.Rows[i][1].ToString());
            }
            comboBox1.SelectedIndex = 0;

            //dt = new DataTable();
            //sql = "select " +
            //    "id_salario," +
            //    "tipo" +
            //    " from " +
            //    "salario";
            //sqlconn = new SqlConnection(conexion);
            //sqlconn.Open();
            //sqlda = new SqlDataAdapter(sql, sqlconn);
            //sqlda.Fill(dt);
            //sqlconn.Close();
            //int value;
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //   // comboBox1.Items.Add(dt.Rows[i][1].ToString());
            //    value = Convert.ToInt16(dt.Rows[i][1].ToString());
            //    comboBox1.Items.Insert(i, dt.Rows[i][1].ToString());
            //}
            //comboBox1.SelectedIndex = 0;
            

        }      

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";            
            textBox4.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //string conexion = "Data Source=LAB210-01;Initial Catalog=bd_empresa;Integrated Security=True;"; //'User ID=UserName;Password=Password;
            //SqlConnection sqlconn = new SqlConnection(conexion);
            //sqlconn.Open();
            //SqlCommand sqlcomm = new SqlCommand();

            string mysqlconexion = "server=sql5.freemysqlhosting.net;" +
                "Port=3306;" +
                "Database=sql5127732;" +
                "Uid=sql5127732;" +
                "Pwd=KQfgCmGNJw;";
            MySqlConnection mysqlconn = new MySqlConnection(mysqlconexion);            

            MySqlCommand mysqlcomm = new MySqlCommand();
            string sql;
            DataTable dt = new DataTable();
            sql = "insert into Persona (" +
                "cedula," + 
                "nombre," + 
                "apellido," + 
                "direccion," +
                "provincia" +
                ") values (" +
                "'" + textBox1.Text + "'," + 
                "'" + textBox2.Text + "'," + 
                "'" + textBox3.Text + "'," +
                "'" + textBox4.Text + "'," +
                "'" + comboBox1.Text + "'" +
                ")";

            mysqlconn.Open();
            mysqlcomm.Connection = mysqlconn;
            mysqlcomm.CommandText = sql;
            mysqlcomm.CommandType = CommandType.Text;
            mysqlcomm.ExecuteNonQuery();

            sql = "select " +
                "cedula" + " as 'Cedula'," + 
                "nombre" + " as Nombre," +
                "apellido" + " as Apellido," +
                 "direccion" + " as Direccion," +
                "provincia" + " as 'Provincia'" +
                " from " +
                "Persona";  
 
            //sqlconn.Open();
            //SqlDataAdapter sqlda = new SqlDataAdapter(sql, sqlconn);
            //sqlda.Fill(dt);
            //sqlconn.Close();

            MySqlDataAdapter mysqlda = new MySqlDataAdapter(sql, mysqlconn);
            mysqlda.Fill(dt);
            mysqlconn.Close(); 

            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                //TextBox1.Text = DataGridView1(0, DataGridView1.CurrentRow.Index).Value
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                comboBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //string conexion = "Data Source=LAB210-01;" +
            //                  "Initial Catalog=bd_empresa;" +
            //                  "Integrated Security=True;"; //'User ID=UserName;Password=Password;
            //SqlConnection sqlconn = new SqlConnection(conexion);
            //sqlconn.Open();
            //SqlCommand sqlcomm = new SqlCommand();
            string mysqlconexion = "server=sql5.freemysqlhosting.net;" +
                "Port=3306;" +
                "Database=sql5127732;" +
                "Uid=sql5127732;" +
                "Pwd=KQfgCmGNJw;";
            MySqlConnection mysqlconn = new MySqlConnection(mysqlconexion);

            MySqlCommand mysqlcomm = new MySqlCommand();
            string sql;
            DataTable dt = new DataTable();
            sql = "update" +
            " Persona " +
            "set " +
            "nombre  = '" + textBox2.Text + "'," +
            "apellido = '" + textBox3.Text + "'," +
            "direccion = '" + textBox4.Text + "'," +
            "provincia = '" + comboBox1.Text + "'" + 
            " where cedula = " + textBox1.Text;
            //sqlcomm.Connection = sqlconn;
            //sqlcomm.CommandText = sql;
            //sqlcomm.CommandType = CommandType.Text;
            //sqlcomm.ExecuteNonQuery();
            //sqlconn.Close();
            mysqlconn.Open();
            mysqlcomm.Connection = mysqlconn;
            mysqlcomm.CommandText = sql;
            mysqlcomm.CommandType = CommandType.Text;
            mysqlcomm.ExecuteNonQuery();
            sql = "select " +
                "cedula" + " as 'Cédula'," +
                "nombre" + " as Nombre," +
                "apellido" + " as Apellido," +
                 "direccion" + " as Direccion," +
                "provincia" + " as 'Provincia'" +
                "from " +
                "Persona";
            //sqlconn.Open();
            //SqlDataAdapter sqlda = new SqlDataAdapter(sql, sqlconn);
            //sqlda.Fill(dt);
            //sqlconn.Close();
            MySqlDataAdapter mysqlda = new MySqlDataAdapter(sql, mysqlconn);
            mysqlda.Fill(dt);
            mysqlconn.Close(); 
            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string mysqlconexion = "server=sql5.freemysqlhosting.net;" +
                "Port=3306;" +
                "Database=sql5127732;" +
                "Uid=sql5127732;" +
                "Pwd=KQfgCmGNJw;";
            MySqlConnection mysqlconn = new MySqlConnection(mysqlconexion);

            MySqlCommand mysqlcomm = new MySqlCommand();
            string sql;
            DataTable dt = new DataTable();
            sql = "delete from" +
            " Persona " +
            " where " +
            "cedula = " + textBox1.Text;
            mysqlconn.Open();
            mysqlcomm.Connection = mysqlconn;
            mysqlcomm.CommandText = sql;
            mysqlcomm.CommandType = CommandType.Text;
            mysqlcomm.ExecuteNonQuery();
            sql = "select " +
                "cedula" + " as 'Cédula'," +
                "nombre" + " as Nombre," +
                "apellido" + " as Apellido," +
                 "direccion" + " as Direccion," +
                "provincia" + " as 'Provincia'" +
                "from " +
                "Persona";
            MySqlDataAdapter mysqlda = new MySqlDataAdapter(sql, mysqlconn);
            mysqlda.Fill(dt);
            mysqlconn.Close();
            dataGridView1.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string mysqlconexion = "server=sql5.freemysqlhosting.net;" +
                "Port=3306;" +
                "Database=sql5127732;" +
                "Uid=sql5127732;" +
                "Pwd=KQfgCmGNJw;";
            MySqlConnection mysqlconn = new MySqlConnection(mysqlconexion);

            MySqlCommand mysqlcomm = new MySqlCommand();
            string sql;
            DataTable dt = new DataTable();
            sql = "select " +
                "cedula," +
                "nombre," +
                "apellido," +
                "direccion," +
                "provincia" +
                " from " +
                "Persona" + 
                " where " +
                "cedula =" + textBox1.Text;
            mysqlconn.Open();
            mysqlcomm.Connection = mysqlconn;
            mysqlcomm.CommandText = sql;
            mysqlcomm.CommandType = CommandType.Text;
            mysqlcomm.ExecuteNonQuery();
            MySqlDataAdapter mysqlda = new MySqlDataAdapter(sql, mysqlconn);
            mysqlda.Fill(dt);
            mysqlconn.Close();
            textBox2.Text = dt.Rows[0][1].ToString();
            textBox3.Text = dt.Rows[0][2].ToString(); 
            textBox4.Text = dt.Rows[0][3].ToString();
            comboBox1.Text = dt.Rows[0][3].ToString(); 
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }        

    }
}
