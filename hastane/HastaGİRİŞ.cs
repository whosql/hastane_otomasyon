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
    public partial class HastaGİRİŞ : Form
    {
        public HastaGİRİŞ()
        {
            InitializeComponent();
        }


        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        private void button1_Click(object sender, EventArgs e)
        {

            string ad = textBox1.Text;
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\WHOSQL\Documents\verıtabanıdeneme.mdf;Integrated Security=True;Connect Timeout=30");
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM HASTALAR where tc='" + textBox1.Text + "'";
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                HASTAPLATFORM hastafrm = new HASTAPLATFORM();
                hastafrm.Show();
            }
            else
            {
                MessageBox.Show("KULLANICI BULUNAMADI ...!");
            }

            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HastaKAYIT hastakyt = new HastaKAYIT();
            hastakyt.Show();
        }
    }
}
