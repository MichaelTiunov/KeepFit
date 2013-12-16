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
    public partial class Upr : Form
    {
        public Upr()
        {
            InitializeComponent();
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=baz.mdb");
                con.Open();
                OleDbTransaction trans = con.BeginTransaction();

                DataTable tbl = new DataTable("source");
                OleDbCommand cmd = new OleDbCommand("select nazvanie_k_upr from upr", con, trans);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listBox1.Items.Add(reader[0].ToString());
                }

                trans.Commit();
                con.Close();
                con.Open();
                cmd = new OleDbCommand("SELECT nazvanie FROM kompleks", con, trans);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    comboBox1.Items.Add(reader[0].ToString());
                }
                listBox1.Update();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image = null;
                string upr = listBox1.SelectedItem.ToString();
                OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=baz.mdb");
                con.Open();
                OleDbTransaction trans = con.BeginTransaction();

                DataTable tbl = new DataTable("source");
                OleDbCommand cmd = new OleDbCommand("SELECT nazvanie_k_upr, opisanie, link FROM upr WHERE (nazvanie_k_upr = '" + upr + "')", con, trans);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    textBox1.Text = upr;
                    textBox2.Text = reader[1].ToString();
                    if (reader[2].ToString() != "")
                    {
                        Bitmap myimage = new Bitmap(Application.StartupPath + @"\image\" + reader[2].ToString());
                        pictureBox1.Image =(Image)myimage;
                    }
                }
                reader.Close();
                trans.Commit();
                con.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.Clear();
                int id = comboBox1.SelectedIndex + 1;
                OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=baz.mdb");
                con.Open();
                OleDbTransaction trans = con.BeginTransaction();

                DataTable tbl = new DataTable("source");
                OleDbCommand cmd = new OleDbCommand("SELECT id_kompleksa, nazvanie_k_upr FROM upr WHERE id_kompleksa=" + id + "", con, trans);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listBox1.Items.Add(reader[1].ToString());
                }
                listBox1.Update();
                trans.Commit();
                con.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
