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
    public partial class admin_sekreterler : Form
    {


        static string baglantiYolu = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\WHOSQL\Documents\verıtabanıdeneme.mdf;Integrated Security = True; Connect Timeout = 30";
        SqlConnection baglanti = new SqlConnection(baglantiYolu);
        SqlCommand komut = new SqlCommand();
        SqlDataAdapter adaptor = new SqlDataAdapter();


        public admin_sekreterler()
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
                SqlCommand komut = new SqlCommand("DELETE FROM Sekreterler WHERE sekreter_id ='" + textBox1.Text + "'", baglanti);
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

        private void button1_Click(object sender, EventArgs e)
        {


            try
            {
                DataSet ds = new DataSet();
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                ds.Clear();
                SqlCommand komut = new SqlCommand("INSERT INTO Sekreterler (sekreter_id,sekreter_sifre,sekreter_klinik,sekreter_ad,sekreter_soyad) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')", baglanti);
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
                textBox1.Text = row.Cells["sekreter_id"].Value.ToString();
                textBox2.Text = row.Cells["sekreter_sifre"].Value.ToString();
                textBox3.Text = row.Cells["sekreter_klinik"].Value.ToString();
                textBox4.Text = row.Cells["sekreter_ad"].Value.ToString();
                textBox5.Text = row.Cells["sekreter_soyad"].Value.ToString();



            }



        }

        private void button2_Click(object sender, EventArgs e)
        {




            DataSet ds = new DataSet();
            if (baglanti.State == ConnectionState.Closed) baglanti.Open();
            komut = new SqlCommand("SELECT * from Sekreterler ", baglanti);
            SqlDataReader reader = komut.ExecuteReader();
            reader.Read();

            if (reader.HasRows)
            {
                textBox1.Text = reader["sekreter_id"].ToString();
                textBox2.Text = reader["sekreter_sifre"].ToString();
                textBox3.Text = reader["sekreter_klinik"].ToString();
                textBox4.Text = reader["sekreter_ad"].ToString();
                textBox5.Text = reader["sekreter_soyad"].ToString();
            }
            reader.Close();
            adaptor.SelectCommand = new SqlCommand("SELECT sekreter_id,sekreter_sifre,sekreter_klinik,sekreter_ad,sekreter_soyad from Sekreterler", baglanti);
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
                    SqlCommand komut = new SqlCommand("UPDATE Sekreterler SET sekreter_id ='" + textBox1.Text + "', sekreter_sifre ='" + textBox2.Text + "', sekreter_klinik ='" + textBox3.Text + "', sekreter_ad ='" + textBox4.Text + "', sekreter_soyad ='" + textBox5.Text + "'  WHERE sekreter_id = '" + textBox1.Text + "'", baglanti);

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
