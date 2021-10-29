using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace lab3_sql
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\UZNU\Cch\2kurs\lab3_sql\Database1.mdf;Integrated Security=True";
        private void beforeAll()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dataT = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand getAll = new SqlCommand(
                "SELECT * FROM TournamentParticipant",
                connection
                );
            SqlDataAdapter adapt = new SqlDataAdapter(getAll);
            connection.Open();
            adapt.Fill(dataT);
            connection.Close();

            dataGridView1.DataSource = dataT;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            beforeAll();
            DataTable dataT = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand getData= new SqlCommand(
                "SELECT * FROM TournamentParticipant WHERE Sex = @Sex",
                connection
                );
            getData.Parameters.AddWithValue("Sex", "Male");
            SqlDataAdapter adapt = new SqlDataAdapter(getData);
            connection.Open();
            adapt.Fill(dataT);
            connection.Close();

            dataGridView1.DataSource = dataT;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            beforeAll();
            DataTable dataT = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand getData = new SqlCommand(
                "SELECT TOP(1) * FROM TournamentParticipant ORDER BY Age",
                connection
                );
            SqlDataAdapter adapt = new SqlDataAdapter(getData);
            connection.Open();
            adapt.Fill(dataT);
            connection.Close();

            dataGridView1.DataSource = dataT;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            beforeAll();
            DataTable dataT = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand getData = new SqlCommand(
                "SELECT Country, COUNT(Country) FROM TournamentParticipant GROUP BY Country",
                connection
                );
            SqlDataAdapter adapt = new SqlDataAdapter(getData);
            connection.Open();
            adapt.Fill(dataT);
            connection.Close();

            dataGridView1.DataSource = dataT;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            beforeAll();
            DataTable dataT = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand getData = new SqlCommand(
                "SELECT * FROM TournamentParticipant",
                connection
                );
            SqlCommand changeData = new SqlCommand(
                "UPDATE TournamentParticipant SET Age = Age + 17",
                connection
                );
            SqlDataAdapter adapt = new SqlDataAdapter(getData);
            connection.Open();
            changeData.ExecuteNonQuery();
            adapt.Fill(dataT);
            connection.Close();

            dataGridView1.DataSource = dataT;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            beforeAll();
            DataTable dataT = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand getData = new SqlCommand(
                "SELECT * FROM TournamentParticipant",
                connection
                );
            SqlCommand changeData = new SqlCommand(
                "WITH Database1 AS (SELECT TOP(1) * FROM TournamentParticipant ORDER BY Age) DELETE FROM Database1",
                connection
                );
            SqlDataAdapter adapt = new SqlDataAdapter(getData);
            connection.Open();
            changeData.ExecuteNonQuery();
            adapt.Fill(dataT);
            connection.Close();

            dataGridView1.DataSource = dataT;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DataTable dataT = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand getExp1 = new SqlCommand(
                "SELECT Age FROM TournamentParticipant WHERE Age operator ANY (SELECT Age FROM TournamentParticipant WHERE Age > 17)",
                connection
                );
            SqlCommand getExp2 = new SqlCommand(
               "SELECT Age FROM TournamentParticipant WHERE Age operator ALL (SELECT Age FROM TournamentParticipant WHERE Age > 17)",
               connection
               );
            SqlDataAdapter adapt1 = new SqlDataAdapter(getExp1);
            SqlDataAdapter adapt2 = new SqlDataAdapter(getExp2);
            connection.Open();
            adapt1.Fill(dataT);
            adapt2.Fill(dataT);
            connection.Close();

            dataGridView1.DataSource = dataT;
        }
    }
}
