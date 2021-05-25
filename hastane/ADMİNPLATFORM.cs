using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hastane
{
    public partial class ADMİNPLATFORM : Form
    {
        public ADMİNPLATFORM()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            admin_ilaçlar adminilaç = new admin_ilaçlar();
            adminilaç.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            admin_klinik adminklinik = new admin_klinik();
            adminklinik.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            admin_hastaliklar adminhastaliklar = new admin_hastaliklar();
            adminhastaliklar.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            admin_tahliller admintahlil = new admin_tahliller();
            admintahlil.Show();

        }

        private void button6_Click(object sender, EventArgs e)
        {

            admin_admins adminler = new admin_admins();
            adminler.Show();


        }

        private void button7_Click(object sender, EventArgs e)
        {


            admin_sekreterler sekreterg = new admin_sekreterler();
            sekreterg.Show();


        }
    }
}
