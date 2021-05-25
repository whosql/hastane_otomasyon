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
    public partial class ADMİNGİRİŞ : Form
    {
        public ADMİNGİRİŞ()
        {
            InitializeComponent();
        }


        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        private void button1_Click(object sender, EventArgs e)
        {
            string ad = textBox1.Text;
            string sifre = textBox2.Text;
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\WHOSQL\Documents\verıtabanıdeneme.mdf;Integrated Security=True;Connect Timeout=30");
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM Admins where admin_id='" + textBox1.Text + "'AND admin_sifre='" + textBox2.Text+ "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                ADMİNPLATFORM adminfrm = new ADMİNPLATFORM();
                adminfrm.Show();
            }
            else
            {
                MessageBox.Show("KULLANICI ADI veya ŞİFRE HATALI ...!");
            }
            con.Close();
        }
    }
}
