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
    public partial class Form3 : Form
    {
        string sql;


        string mysqlconexion = "server=sql5.freemysqlhosting.net;" +
            "Port=3306;" +
            "Database=sql5127732;" +
            "Uid=sql5127732;" +
            "Pwd=KQfgCmGNJw;";

        public Form3()
        {
            InitializeComponent();


        }



        private void Form3_Load_1(object sender, EventArgs e)
        {
            

            DataTable dt1 = new DataTable();
            dt1 = new DataTable();
            sql = "select " +
                "id_provincia," +
                "nom_provincia" +
                " from " +
                "Provincia";

            MySqlConnection mysqlconn = new MySqlConnection(mysqlconexion);
            mysqlconn.Open();

            MySqlDataAdapter mysqlda = new MySqlDataAdapter(sql, mysqlconn);

            mysqlda.Fill(dt1);
            mysqlconn.Close();

            dataGridView1.DataSource = dt1;




        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection mysqlconn = new MySqlConnection(mysqlconexion);

            MySqlCommand mysqlcomm = new MySqlCommand();
            string sql;
           // DataTable dt = new DataTable();
            sql = "insert into Provincia (" +
               "id_provincia," +
               "nom_provincia" +
               ") values (" +
               "'" + textBox1.Text + "'," +
               "'" + textBox2.Text + "'" +
               ")";
            mysqlconn.Open();
            mysqlcomm.Connection = mysqlconn;
            mysqlcomm.CommandText = sql;
            mysqlcomm.CommandType = CommandType.Text;
            mysqlcomm.ExecuteNonQuery();

            DataTable dt1 = new DataTable();
            dt1 = new DataTable();
            sql = "select " +
                "id_provincia," +
                "nom_provincia" +
                " from " +
                "Provincia";

            mysqlconn = new MySqlConnection(mysqlconexion);
            mysqlconn.Open();

            MySqlDataAdapter mysqlda = new MySqlDataAdapter(sql, mysqlconn);

            mysqlda.Fill(dt1);
            mysqlconn.Close();

            dataGridView1.DataSource = dt1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection mysqlconn = new MySqlConnection(mysqlconexion);

            MySqlCommand mysqlcomm = new MySqlCommand();
            string sql;
            DataTable dt = new DataTable();
            sql = "update from Provincia set nom_provincia = " + textBox2.Text + "where id_provincia = " + textBox1.Text;

            mysqlconn.Open();
            mysqlcomm.Connection = mysqlconn;
            mysqlcomm.CommandText = sql;
            mysqlcomm.CommandType = CommandType.Text;
            mysqlcomm.ExecuteNonQuery();

            DataTable dt1 = new DataTable();
            dt1 = new DataTable();
            sql = "select " +
                "id_provincia," +
                "nom_provincia" +
                " from " +
                "Provincia";

           mysqlconn = new MySqlConnection(mysqlconexion);
            mysqlconn.Open();

            MySqlDataAdapter mysqlda = new MySqlDataAdapter(sql, mysqlconn);

            mysqlda.Fill(dt1);
            mysqlconn.Close();

            dataGridView1.DataSource = dt1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection mysqlconn = new MySqlConnection(mysqlconexion);

            MySqlCommand mysqlcomm = new MySqlCommand();
            string sql;
            DataTable dt = new DataTable();
            sql = "delete from Provincia where id_provincia =" + textBox1.Text;
            mysqlconn.Open();
            mysqlcomm.Connection = mysqlconn;
            mysqlcomm.CommandText = sql;
            mysqlcomm.CommandType = CommandType.Text;
            mysqlcomm.ExecuteNonQuery();

            DataTable dt1 = new DataTable();
            dt1 = new DataTable();
            sql = "select " +
                "id_provincia," +
                "nom_provincia" +
                " from " +
                "Provincia";

             mysqlconn = new MySqlConnection(mysqlconexion);
            mysqlconn.Open();

            MySqlDataAdapter mysqlda = new MySqlDataAdapter(sql, mysqlconn);

            mysqlda.Fill(dt1);
            mysqlconn.Close();

            dataGridView1.DataSource = dt1;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            }
            }
    }
}
