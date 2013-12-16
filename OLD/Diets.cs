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
    public partial class Diets : Form
    {
        public Diets()
        {
            InitializeComponent();
        }
        string zab="";
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
           
            try
            {
                zab = listBox1.SelectedItem.ToString();
                OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=baz.mdb");
                con.Open();
                OleDbTransaction trans = con.BeginTransaction();
                int i = listBox1.SelectedIndex + 1;
                DataTable tbl = new DataTable("source");
                string sql = "SELECT DISTINCT zabolevania.zabolevanie, Dieta.dieta, Rekomend_prod.rec_pr, Iskluch_prod.iskluch_pr "
                             + "FROM (((((Dieta INNER JOIN "
                         + "zabolevania ON Dieta.id_diety = zabolevania.id_dyety) INNER JOIN "
                         + "Rec ON Dieta.id_diety = Rec.id_diety) INNER JOIN "
                         + "Rekomend_prod ON Dieta.id_diety = Rekomend_prod.id_diety AND Rec.id_rec = Rekomend_prod.id_rec) INNER JOIN "
                         + "Zap ON Dieta.id_diety = Zap.id_diety) INNER JOIN "
                         + "Iskluch_prod ON Dieta.id_diety = Iskluch_prod.id_diety AND Zap.id_iskluh_prod = Iskluch_prod.id_iskluh_prod) "
                        + "WHERE (zabolevania.zabolevanie = '"+zab+"')";
                OleDbCommand cmd = new OleDbCommand(sql, con, trans);
               
                OleDbDataReader reader = cmd.ExecuteReader();
                label1.Text=zab;
                string s = "";
                string s1 = "";
                while (reader.Read())
                {
                    
                    s = reader[2].ToString();
                    s1 = reader[3].ToString();
                }
                textBox1.Text = s;
                textBox2.Text = s1;
                reader.Close();
                trans.Commit();
                s = "";
                s1 = "";
                con.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            try
            {
               
                OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=baz.mdb");
                con.Open();
                OleDbTransaction trans = con.BeginTransaction();
                
                DataTable tbl = new DataTable("source");
                string sql = " Select t.[Название приёма], t.[Название продукта]  from ( "
                              + "    SELECT distinct null as [Название продукта], priem.nazvanie_priema as [Название приёма], priem.id_priema "
                              + "  FROM ((((zabolevania INNER JOIN  "
                              + "  Dieta ON zabolevania.id_dyety = Dieta.id_diety) INNER JOIN  "
                              + "  sostav_diety ON Dieta.id_diety = sostav_diety.id_diety) INNER JOIN  "
                              + "  pitanie ON sostav_diety.kod_produkta = pitanie.kod_produkta) INNER JOIN  "
                              + "  priem ON sostav_diety.id_priema = priem.id_priema)  "
                              + "  WHERE (zabolevania.zabolevanie = '" + zab + "') "
                              + "UNION ALL "
                              + "SELECT pitanie.nazvanie_produkta as [Название продукта], null as [Название приёма], priem.id_priema "
                              + "      FROM ((((zabolevania INNER JOIN  "
                              + "   Dieta ON zabolevania.id_dyety = Dieta.id_diety) INNER JOIN  "
                              + "   sostav_diety ON Dieta.id_diety = sostav_diety.id_diety) INNER JOIN  "
                              + "   pitanie ON sostav_diety.kod_produkta = pitanie.kod_produkta) INNER JOIN  "
                              + "   priem ON sostav_diety.id_priema = priem.id_priema)  "
                              + "  WHERE (zabolevania.zabolevanie = '" + zab + "') "
                              + ") t "
                              + "order by  priem.id_priema, t.[Название приёма] DESC ";





                OleDbCommand cmd = new OleDbCommand(sql, con, trans);
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                adapter.SelectCommand = cmd;
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                dataGridView1.DataSource = dataset.Tables[0];
                adapter.Update(dataset);

                trans.Commit();
               
                con.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            
        }

        private void Diets_Load(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=baz.mdb");
            con.Open();
            OleDbTransaction trans = con.BeginTransaction();

            DataTable tbl = new DataTable("source");
            OleDbCommand cmd = new OleDbCommand("select zabolevanie from zabolevania", con, trans);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                listBox1.Items.Add(reader[0].ToString());
            }
            listBox1.Update();
        }

       
    }
}
