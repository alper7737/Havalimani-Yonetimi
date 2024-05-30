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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("server = .;Initial Catalog = dbairport;Integrated Security = SSPI");
        SqlCommand cmd;


        private void Form2_Load(object sender, EventArgs e)
        {
                string datas = "select * from tblülke";
                cmd = new SqlCommand(datas, con);
                SqlDataReader dr;
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr["ülke"]);
                }
                con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from tblkayit where eposta=@eposta and sifre=@sif";
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@eposta", textBox1.Text);
            cmd.Parameters.AddWithValue("@sif", textBox2.Text);
            con.Open();
            SqlDataReader oku = cmd.ExecuteReader();
            if (oku.Read())
            {
                MessageBox.Show("kullanıcı var");
            }
            else
            {
                con.Close();
                string sorgu2 = "insert into tblkayit (eposta,sifre,tckimlik,ad,soyad,tel,dogum,adres,resim)values (@eposta,@sif,@tc,@ad,@soyad,tel,@dogum,@adres,@resim)";
                cmd = new SqlCommand(sorgu2, con);
                cmd.Parameters.AddWithValue("@eposta", textBox1.Text);
                cmd.Parameters.AddWithValue("@sif", textBox2.Text);
                cmd.Parameters.AddWithValue("@tc", textBox3.Text);
                cmd.Parameters.AddWithValue("@ad", textBox4.Text);
                cmd.Parameters.AddWithValue("@soyad", textBox5.Text);
                cmd.Parameters.AddWithValue("@tel", textBox6.Text);
                cmd.Parameters.AddWithValue("@dogum", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@adres", textBox7.Text);
                cmd.Parameters.AddWithValue("@resim", pictureBox1.ImageLocation);
                con.Open();
                MessageBox.Show("Kayıt Yapıldı!");
                Form1 f1 = new Form1();
                f1.Show();
                this.Hide();
                cmd.ExecuteNonQuery();
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.ShowDialog();
            pictureBox1.ImageLocation = op.FileName;
        }
    }
}
