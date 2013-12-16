using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
namespace ZdorovoePitanie
{
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=baz.mdb");
                con.Open();
                OleDbTransaction trans = con.BeginTransaction();

                DataTable tbl = new DataTable("source");
                OleDbCommand cmd = new OleDbCommand("SELECT nazvanie_produkta, kaloriinost, jiry, belki, uglevody from pitanie", con, trans);
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                adapter.Fill(tbl);
                dataGridView1.DataSource = tbl;
                trans.Commit();
                con.Close();
                dataGridView1.Update();
                
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        private void SearchP(string s,string ch)
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=baz.mdb");
            con.Open();
            OleDbTransaction trans = con.BeginTransaction();

            DataTable tbl = new DataTable("source");
            OleDbCommand cmd = new OleDbCommand("SELECT nazvanie_produkta, kaloriinost, jiry, belki, uglevody FROM pitanie WHERE "+ch+" LIKE '" + s + "%'", con, trans);
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(tbl);
            dataGridView1.DataSource = tbl;
            trans.Commit();
            con.Close();
            dataGridView1.Update();
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SearchP(textBox1.Text, "nazvanie_produkta");            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            SearchP(textBox2.Text, "kaloriinost");
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            SearchP(textBox3.Text, "belki");
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            SearchP(textBox4.Text, "jiry");
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            SearchP(textBox5.Text, "uglevody");
        }

        
    }
}
