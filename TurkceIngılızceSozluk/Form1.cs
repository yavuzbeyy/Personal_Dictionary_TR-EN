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

namespace TurkceIngılızceSozluk
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Data Source=.;Initial Catalog=tr_eng_words;Integrated Security=True

        SqlConnection baglanti = new SqlConnection(@"Data Source=.;Initial Catalog=tr_eng_words;Integrated Security=True");
        
        //Bring Button
        private void button2_Click(object sender, EventArgs e)
        {
           
            baglanti.Open();
            SqlCommand getirmeKomutu = new SqlCommand("SELECT TOP 1 turkish_word,english_word FROM Words ORDER BY NEWID()", baglanti);
            SqlDataReader read = getirmeKomutu.ExecuteReader();

            while(read.Read())
            {
                textBox1.Text = read["turkish_word"].ToString();
                textBox2.Text = read["english_word"].ToString();
            }

            baglanti.Close();
        }


        // Add Button
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand eklemekomutu = new SqlCommand("insert into Words (turkish_word,english_word) values (@turkce,@ingilizce)", baglanti);
            eklemekomutu.Parameters.AddWithValue("@turkce", textBox1.Text);
            eklemekomutu.Parameters.AddWithValue("@ingilizce", textBox2.Text);
            eklemekomutu.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Successfully Added");

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
