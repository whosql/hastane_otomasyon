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
    public partial class AdminDOKTORLAR : Form
    {

        static string baglantiYolu = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\WHOSQL\Documents\verıtabanıdeneme.mdf;Integrated Security = True; Connect Timeout = 30";
        SqlConnection baglanti = new SqlConnection(baglantiYolu);
        SqlCommand komut = new SqlCommand();
        SqlDataAdapter adaptor = new SqlDataAdapter();





        public AdminDOKTORLAR()
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
                SqlCommand komut = new SqlCommand("INSERT INTO DOKTORS (doktor_id,doktor_ad,doktor_soyad,doktor_klinik) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')", baglanti);
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
            komut = new SqlCommand("SELECT * from DOKTORS ", baglanti);
            SqlDataReader reader = komut.ExecuteReader();
            reader.Read();

            if (reader.HasRows)
            {
                textBox1.Text = reader["doktor_id"].ToString();
                textBox2.Text = reader["doktor_ad"].ToString();
                textBox3.Text = reader["doktor_soyad"].ToString();
                textBox4.Text = reader["doktor_klinik"].ToString();
            }
            reader.Close();
            adaptor.SelectCommand = new SqlCommand("SELECT doktor_id,doktor_ad,doktor_soyad,doktor_klinik from DOKTORS", baglanti);
            adaptor.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }



        private void button4_Click(object sender, EventArgs e)
        {

            {


                try
                {
                    DataSet ds = new DataSet();
                    if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                    ds.Clear();
                    SqlCommand komut = new SqlCommand("UPDATE DOKTORS SET doktor_id ='" + textBox1.Text + "', doktor_ad ='" + textBox2.Text + "', doktor_soyad ='" + textBox3.Text + "', doktor_klinik ='" + textBox4.Text + "' WHERE doktor_id = '" + textBox1.Text + "'", baglanti);

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

        private void button3_Click(object sender, EventArgs e)
        {


            try
            {
                DataSet ds = new DataSet();
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                ds.Clear();
                SqlCommand komut = new SqlCommand("DELETE FROM DOKTORS WHERE doktor_id ='" + textBox1.Text + "'", baglanti);
                komut.ExecuteNonQuery();
                dataGridView1.Update();
                dataGridView1.Refresh();
                baglanti.Close();
                MessageBox.Show("KAYIT SİLİNDİ ...!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                baglanti.Close();
                    
            }



        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {



            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["doktor_id"].Value.ToString();
                textBox2.Text = row.Cells["doktor_ad"].Value.ToString();
                textBox3.Text = row.Cells["doktor_soyad"].Value.ToString();
                textBox4.Text = row.Cells["doktor_klinik"].Value.ToString();




            }



        }
    }
}
