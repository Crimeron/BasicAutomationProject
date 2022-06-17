using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SQLite;

namespace OtomasyonProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SQLiteConnection connection = new SQLiteConnection(@"Data Source=C:\Users\Emrhn\Desktop\kocatepedb.db");
        private void btnList_Click(object sender, EventArgs e)
        {
            connection.Open();
            SQLiteCommand command = new SQLiteCommand("select * from tblcategory", connection);
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();
        }



        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            connection.Open();
            SQLiteCommand command = new SQLiteCommand("insert into tblcategory (name) values (@p1)", connection);
            command.Parameters.AddWithValue("@p1", txt2.Text);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Category Saved Successfully");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            connection.Open();
            SQLiteCommand command = new SQLiteCommand("delete from tblcategory where id=@p1",connection);
            command.Parameters.AddWithValue("@p1",textBox1.Text);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Category deleted successfully");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            connection.Open();
            SQLiteCommand command = new SQLiteCommand("update tblcategory set name=@p1 where id=@p2",connection);
            command.Parameters.AddWithValue("@p1", txt2.Text);
            command.Parameters.AddWithValue("@p2", textBox1.Text);
            command.ExecuteNonQuery();
            connection.Close ();
            MessageBox.Show("Category Updated Successfully");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            connection.Open ();
            SQLiteCommand command = new SQLiteCommand("Select count(*) from tblcategory", connection);
            SQLiteDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                label4.Text = dr[0].ToString();
            }
            connection.Close ();
        }
    }
}
