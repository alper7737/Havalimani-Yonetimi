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

namespace Havalimanı
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("server = .;Initial Catalog = dbairport;Integrated Security = SSPI");
        SqlCommand cmd;

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Transparent;
        }

        private void button3_Click(object sender, EventArgs e)
        { 
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
  
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "select *  from tblkayit where eposta=@eposta and sifre=@sif";
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@eposta", textBox1.Text.ToString());
            cmd.Parameters.AddWithValue("@sif", textBox2.Text.ToString());
            con.Open();
            SqlDataReader oku = cmd.ExecuteReader();
            if (oku.Read())
            {
                Form3 f3 = new Form3();
                f3.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("yanlış girş");
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }
    }
}
