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
    public partial class admin_klinik : Form
    {


        static string baglantiYolu = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\WHOSQL\Documents\verıtabanıdeneme.mdf;Integrated Security = True; Connect Timeout = 30";
        SqlConnection baglanti = new SqlConnection(baglantiYolu);
        SqlCommand komut = new SqlCommand();
        SqlDataAdapter adaptor = new SqlDataAdapter();



        public admin_klinik()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {



            try
            {
                DataSet ds = new DataSet();
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                ds.Clear();
                SqlCommand komut = new SqlCommand("DELETE FROM Klinikler WHERE klinik_id ='" + textBox1.Text + "'", baglanti);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["klinik_id"].Value.ToString();
                textBox2.Text = row.Cells["klinik_ad"].Value.ToString();
              




            }




        }

        private void button1_Click(object sender, EventArgs e)
        {


            try
            {
                DataSet ds = new DataSet();
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                ds.Clear();
                SqlCommand komut = new SqlCommand("INSERT INTO klinikler (klinik_id,klinik_ad) VALUES ('" + textBox1.Text + "','" + textBox2.Text  + "')", baglanti);
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

        private void button2_Click(object sender, EventArgs e)
        {



            DataSet ds = new DataSet();
            if (baglanti.State == ConnectionState.Closed) baglanti.Open();
            komut = new SqlCommand("SELECT * from Klinikler ", baglanti);
            SqlDataReader reader = komut.ExecuteReader();
            reader.Read();

            if (reader.HasRows)
            {
                textBox1.Text = reader["klinik_id"].ToString();
                textBox2.Text = reader["klinik_ad"].ToString();
               
            }
            reader.Close();
            adaptor.SelectCommand = new SqlCommand("SELECT klinik_id,klinik_ad from Klinikler", baglanti);
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
                    SqlCommand komut = new SqlCommand("UPDATE Klinikler SET klinik_id ='" + textBox1.Text + "', klinik_ad ='" + textBox2.Text  + "' WHERE klinik_id = '" + textBox1.Text + "'", baglanti);

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
    }
}
