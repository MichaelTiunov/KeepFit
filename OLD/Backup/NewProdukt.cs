using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ZdorovoePitanie
{
    public partial class NewProdukt : Form
    {
        public NewProdukt()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=baz.mdb");
            con.Open();
            OleDbTransaction trans = con.BeginTransaction();

            DataTable tbl = new DataTable("source");
            OleDbCommand cmd = new OleDbCommand("select nazvanie_tipa from tip_produkta", con, trans);
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(tbl);
            comboBox1.DataSource = tbl;

            con.Close();
            comboBox1.Update();

            con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=baz.mdb");
            con.Open();
            trans = con.BeginTransaction();

            tbl = new DataTable("source");
            cmd = new OleDbCommand("SELECT nazvanie_produkta, kaloriinost, jiry, belki, uglevody from pitanie", con, trans);
            adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(tbl);
            dataGridView1.DataSource = tbl;
            trans.Commit();
            con.Close();
            dataGridView1.Update();
        }
        private void GetMaxID(out int id)
        {
            id = 0;
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=baz.mdb");
            con.Open();
            OleDbTransaction trans = con.BeginTransaction();
            DataTable tbl = new DataTable("source");
            OleDbCommand cmd = new OleDbCommand("SELECT MAX(kod_produkta) FROM pitanie", con, trans);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
               id = Convert.ToInt16(reader[0].ToString());
            }
            id++;
            reader.Close();
            trans.Commit();
            con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int id = 0;
                GetMaxID(out id);
                string nazvanie = textBox1.Text;
                double kkal = Convert.ToDouble(textBox2.Text);
                double jir = Convert.ToDouble(textBox3.Text);
                double bel = Convert.ToDouble(textBox4.Text);
                double ugl = Convert.ToDouble(textBox5.Text);
                int kt = comboBox1.SelectedIndex + 1;

                OleDbCommand cmd = new OleDbCommand();
                OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=baz.mdb");
                con.Open();
                DataTable tbl = new DataTable("source");
                cmd = new OleDbCommand("INSERT INTO pitanie"
                + "(kod_produkta,kod_tipa,nazvanie_produkta,kaloriinost,jiry,belki,uglevody) VALUES (@kp, @kt, @np, @k, @j, @b, @u)", con);
                cmd.Parameters.AddWithValue("@kp", id);
                cmd.Parameters.AddWithValue("@kt", kt);
                cmd.Parameters.AddWithValue("@np", nazvanie);
                cmd.Parameters.AddWithValue("@k", kkal);
                cmd.Parameters.AddWithValue("@b", bel);
                cmd.Parameters.AddWithValue("@j", jir);
                cmd.Parameters.AddWithValue("@u", ugl);
                cmd.ExecuteNonQuery();

                con.Close();


                con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=baz.mdb");
                con.Open();
                OleDbTransaction trans = con.BeginTransaction();

                tbl = new DataTable("source");
                cmd = new OleDbCommand("SELECT nazvanie_produkta, kaloriinost, jiry, belki, uglevody from pitanie", con, trans);
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                adapter.Fill(tbl);
                dataGridView1.DataSource = tbl;
                trans.Commit();
                con.Close();
                dataGridView1.Update();
                MessageBox.Show("Запись успешно добавлена!");
            }
            catch (Exception err)
            {
                MessageBox.Show("Ошибка добавления записи!");
            }
            
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
        }
    }
}
