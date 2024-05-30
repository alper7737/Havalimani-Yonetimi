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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("server = .;Initial Catalog = dbairport;Integrated Security = SSPI");
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        void göster()
        {
            string sorgu = "select * from tblbilet";
            da = new SqlDataAdapter(sorgu, con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "tblbilet");
            con.Close();
            dataGridView1.DataSource = ds.Tables["tblbilet"];
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox6.Items.Clear();
            string datas = ("select şehir from tblşehir where şehir_id=(select ülke_id from tblülke where ülke=@ülke)");
            cmd = new SqlCommand(datas, con);
            cmd.Parameters.AddWithValue("@ülke", comboBox1.Text.ToString());
            SqlDataReader dr;
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox6.Items.Add(dr["şehir"]);
            }
            con.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            {
                pictureBox1.BackColor = Color.Transparent;
                string datas = "select * from tblülke";
                cmd = new SqlCommand(datas, con);
                SqlDataReader dr;
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox6.Items.Add(dr["ülke"]);
                }
                con.Close();
            }
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
                göster();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string datas = "insert into tblbilet(nereden,nereye,businnes,economic) values (@nereden,@nereye,@businnes,@economic)";
            cmd = new SqlCommand(datas, con);
            cmd.Parameters.AddWithValue("@nereden", textBox1.Text);
            cmd.Parameters.AddWithValue("@nereye", textBox2.Text);
            cmd.Parameters.AddWithValue("@businnes", radioButton1.Text);
            cmd.Parameters.AddWithValue("@economic", radioButton2.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            göster();
            koltuk kol = new koltuk();
            kol.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox6.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            radioButton1.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            radioButton2.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            string datas = ("select şehir from tblşehir where şehir_id=(select ülke_id from tblülke where ülke=@ülke)");
            cmd = new SqlCommand(datas, con);
            cmd.Parameters.AddWithValue("@ülke", comboBox1.Text.ToString());
            SqlDataReader dr;
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox3.Items.Add(dr["şehir"]);
            }
            con.Close();
        }

        private void comboBox6_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            string datas = ("select şehir from tblşehir where şehir_id=(select ülke_id from tblülke where ülke=@ülke)");
            cmd = new SqlCommand(datas, con);
            cmd.Parameters.AddWithValue("@ülke", comboBox6.Text.ToString());
            SqlDataReader dr;
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr["şehir"]);
            }
            con.Close();
        }


    }
}
