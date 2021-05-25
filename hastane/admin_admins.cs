using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace hastane
{
    public partial class admin_admins : Form

    {
        static string baglantiYolu = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\WHOSQL\Documents\verıtabanıdeneme.mdf;Integrated Security = True; Connect Timeout = 30";
        SqlConnection baglanti = new SqlConnection(baglantiYolu);
        SqlCommand komut = new SqlCommand();
        SqlDataAdapter adaptor = new SqlDataAdapter();



        public admin_admins()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            try
            {
                DataSet ds = new DataSet();
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                ds.Clear();
                SqlCommand komut = new SqlCommand("INSERT INTO Admins (admin_id,admin_sifre) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "')", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("KAYIT EKLENDİ ...!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                baglanti.Close();

            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["admin_id"].Value.ToString();
                textBox2.Text = row.Cells["admin_sifre"].Value.ToString();





            }



        }

        private void button2_Click(object sender, EventArgs e)
        {


            DataSet ds = new DataSet();
            if (baglanti.State == ConnectionState.Closed) baglanti.Open();
            komut = new SqlCommand("SELECT * from Admins ", baglanti);
            SqlDataReader reader = komut.ExecuteReader();
            reader.Read();

            if (reader.HasRows)
            {
                textBox1.Text = reader["admin_id"].ToString();
                textBox2.Text = reader["admin_sifre"].ToString();

            }
            reader.Close();
            adaptor.SelectCommand = new SqlCommand("SELECT admin_id,admin_sifre from Admins", baglanti);
            adaptor.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();




        }

        private void button3_Click(object sender, EventArgs e)
        {



            {


                try
                {
                    DataSet ds = new DataSet();
                    if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                    ds.Clear();
                    SqlCommand komut = new SqlCommand("UPDATE Admins SET admin_id ='" + textBox1.Text + "', admin_sifre ='" + textBox2.Text + "' WHERE admin_id = '" + textBox1.Text + "'", baglanti);

                    komut.ExecuteNonQuery();
                    dataGridView1.Update();
                    baglanti.Close();
                    MessageBox.Show("KAYIT GÜNCELLENDİ ...!");

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    baglanti.Close();
                }


            }



        }

        private void button4_Click(object sender, EventArgs e)
        {



            try
            {
                DataSet ds = new DataSet();
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                ds.Clear();
                SqlCommand komut = new SqlCommand("DELETE FROM Admins WHERE admin_id ='" + textBox1.Text + "'", baglanti);
                komut.ExecuteNonQuery();
                dataGridView1.Update();
                dataGridView1.Refresh();
                baglanti.Close();
                MessageBox.Show("KAYIT SİLİNDİ ...!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                baglanti.Close();

            }



        }
    }
}
