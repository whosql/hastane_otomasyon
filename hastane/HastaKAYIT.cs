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
    public partial class HastaKAYIT : Form
    {
        static string baglantiYolu = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\WHOSQL\Documents\verıtabanıdeneme.mdf;Integrated Security = True; Connect Timeout = 30";
        SqlConnection baglanti = new SqlConnection(baglantiYolu);
        SqlCommand komut = new SqlCommand();
        SqlDataAdapter adaptor = new SqlDataAdapter();


        public HastaKAYIT()
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
                SqlCommand komut = new SqlCommand("INSERT INTO HASTALAR (tc,ad,soyad,cinsiyet,dogum_tarihi,adres) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("KAYIT EKLENDİ ...!");
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                baglanti.Close();

            }
        }
    }
}
