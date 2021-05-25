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
    public partial class admin_ilaçlar : Form
    {

        static string baglantiYolu = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\WHOSQL\Documents\verıtabanıdeneme.mdf;Integrated Security = True; Connect Timeout = 30";
        SqlConnection baglanti = new SqlConnection(baglantiYolu);
        SqlCommand komut = new SqlCommand();
        SqlDataAdapter adaptor = new SqlDataAdapter();



        public admin_ilaçlar()
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
                SqlCommand komut = new SqlCommand("INSERT INTO İLACLAR (ilaç_id,ilaç_ad,ilaç_amac,ilaç_fiyat) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')", baglanti);
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
            komut = new SqlCommand("SELECT * from İLACLAR ", baglanti);
            SqlDataReader reader = komut.ExecuteReader();
            reader.Read();

            if (reader.HasRows)
            {
                textBox1.Text = reader["ilaç_id"].ToString();
                textBox2.Text = reader["ilaç_ad"].ToString();
                textBox3.Text = reader["ilaç_amac"].ToString();
                textBox4.Text = reader["ilaç_fiyat"].ToString();
            }
            reader.Close();
            adaptor.SelectCommand = new SqlCommand("SELECT ilaç_id,ilaç_ad,ilaç_amac,ilaç_fiyat from İLACLAR", baglanti);
            adaptor.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["ilaç_id"].Value.ToString();
                textBox2.Text = row.Cells["ilaç_ad"].Value.ToString();
                textBox3.Text = row.Cells["ilaç_amac"].Value.ToString();
                textBox4.Text = row.Cells["ilaç_fiyat"].Value.ToString();




            }



        }

        private void button3_Click(object sender, EventArgs e)
        {




            {


                try
                {
                    DataSet ds = new DataSet();
                    if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                    ds.Clear();
                    SqlCommand komut = new SqlCommand("UPDATE İLACLAR SET ilaç_id ='" + textBox1.Text + "', ilaç_ad ='" + textBox2.Text + "', ilaç_amac ='" + textBox3.Text + "', ilaç_fiyat ='" + textBox4.Text + "' WHERE ilaç_id = '" + textBox1.Text + "'", baglanti);

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
                SqlCommand komut = new SqlCommand("DELETE FROM İLACLAR WHERE ilaç_id ='" + textBox1.Text + "'", baglanti);
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
