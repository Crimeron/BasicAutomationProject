
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace OtomasyonProject
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SQLiteConnection connection=new SQLiteConnection("Data Source=C:\\Users\\Emrhn\\Documents\\SQLMurat\\dbKocatapeSonDers.db");
        private void btnList_Click(object sender, EventArgs e)
        {
            connection.Open();
            SQLiteCommand command = new SQLiteCommand("select * from tblcategory",connection);
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            connection.Open();
            SQLiteCommand command = new SQLiteCommand("insert into tblcategory (categoryname) values (@p1)",connection);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Kategori Başaralı Şekilde Kaydedildi");
        }
    }
}
