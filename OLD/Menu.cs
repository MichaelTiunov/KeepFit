using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using Word = Microsoft.Office.Interop.Word;
using System.Diagnostics;

namespace ZdorovoePitanie
{
    public partial class Menu : Form
    {
        Form mdiChildForm = new Form();
        public Menu()
        {
            InitializeComponent();

        }
        public string cel = "Цель";

        #region Двойной клик по продукту и вызов другой формы
        private void dataGridView2_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //дабл клик на ячейке и составляем меню
            Add form3 = new Add(this);
            form3.Show();
            form3.product = dataGridView2.CurrentRow.Cells[0].Value;
            form3.kkal = dataGridView2.CurrentRow.Cells[1].Value;
            form3.jir = dataGridView2.CurrentRow.Cells[2].Value;
            form3.bel = dataGridView2.CurrentRow.Cells[3].Value;
            form3.ugl = dataGridView2.CurrentRow.Cells[4].Value;
            form3.totalkkal = Convert.ToDouble(textBox16.Text);
            form3.currentkkal = Convert.ToDouble(label18.Text);
            button1.Enabled = true;
            диаграммаСоотношенийToolStripMenuItem.Enabled = true;
        }

        #endregion

        #region Загрузка формы и построение списка продуктов питания
        private void Form2_Load(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=baz.mdb");
            con.Open();
            OleDbTransaction trans = con.BeginTransaction();

            DataTable tbl = new DataTable("source");
            OleDbCommand cmd = new OleDbCommand("SELECT nazvanie_produkta, kaloriinost, jiry, belki, uglevody from pitanie", con, trans);
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(tbl);
            dataGridView2.DataSource = tbl;
            trans.Commit();
            con.Close();
            dataGridView2.Update();
            
            {
               tbl = new DataTable("source");
                cmd = new OleDbCommand("select nazvanie_tipa from tip_produkta", con, trans);
                adapter = new OleDbDataAdapter(cmd);
                adapter.Fill(tbl);
                comboBox1.DataSource = tbl;
                
                con.Close();
                comboBox1.Update();
            }
        }
        #endregion

        #region Строим график
        private void button1_Click(object sender, EventArgs e)
        {
            decimal bp, jp, up, all;
            all = Convert.ToDecimal(textBox13.Text) + Convert.ToDecimal(textBox14.Text) + Convert.ToDecimal(textBox15.Text);
            bp = (Convert.ToDecimal(textBox13.Text) * 100) / all;
            jp = (Convert.ToDecimal(textBox14.Text) * 100) / all;
            up = (Convert.ToDecimal(textBox15.Text) * 100) / all;

            DSootn form6 = new DSootn(this);
            form6.ToolTips[0] = Math.Round(bp).ToString() + "%";
            form6.ToolTips[1] = Math.Round(jp).ToString() + "%";
            form6.ToolTips[2] = Math.Round(up).ToString() + "%";
            form6.Values[0] = Convert.ToDecimal(textBox13.Text);
            form6.Values[1] = Convert.ToDecimal(textBox14.Text);
            form6.Values[2] = Convert.ToDecimal(textBox15.Text);
            
            form6.Show();

        }
        #endregion

        #region Выбираем тип продукта
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tip = comboBox1.SelectedIndex + 1;
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=baz.mdb");
            con.Open();
            OleDbTransaction trans = con.BeginTransaction();

            DataTable tbl = new DataTable("source");
            OleDbCommand cmd = new OleDbCommand("SELECT nazvanie_produkta, kaloriinost, jiry, belki, uglevody from pitanie WHERE kod_tipa=" + tip + "", con, trans);
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(tbl);
            dataGridView2.DataSource = tbl;
            trans.Commit();
            con.Close();
            dataGridView2.Update();
        }
        #endregion

        #region Сохраняем в Word
        private Word.Application wordapp;

        private void button2_Click(object sender, EventArgs e)
        {
            
                
                 //Создаем объект Word - равносильно запуску Word
                 wordapp = new Word.Application();
                 //Делаем его видимым
                 wordapp.Visible = true;
                 Object template = Type.Missing;
                 Object newTemplate = false;
                 Object documentType = Word.WdNewDocumentType.wdNewBlankDocument;
                 Object visible = true;
                 //Создаем документ 1
                 Word.Document worddocument = wordapp.Documents.Add(
                ref template, ref newTemplate, ref documentType, ref visible);
                 worddocument.Content.Font.Size = 12;
                 worddocument.Content.Font.Bold = 0;
                 worddocument.Content.Font.Underline = Word.WdUnderline.wdUnderlineSingle;
                 worddocument.Content.ParagraphFormat.Alignment =
                 Word.WdParagraphAlignment.wdAlignParagraphLeft;
                 worddocument.Content.ParagraphFormat.LeftIndent =
                  worddocument.Content.Application.CentimetersToPoints((float)2);
                 worddocument.Content.ParagraphFormat.RightIndent =
                  worddocument.Content.Application.CentimetersToPoints((float)1);
                 object unit;
                 object count;
                 object extend;
                 //Курсор ввода устанавливается в начало документа
                 unit = Word.WdUnits.wdStory;
                 extend = Word.WdMovementType.wdMove;
                 wordapp.Selection.HomeKey(ref unit, ref extend);
                
                 //Добавляем параграфы и выводим в них текст
                 wordapp.Selection.TypeParagraph();
                 wordapp.Selection.TypeText("Завтрак");
                
                 wordapp.Selection.TypeParagraph();
                 wordapp.Selection.TypeText("Калорийность: " + textBox5.Text);
                
                 for (int i = 0; i < 1; i++)
                 {
                    
                     for (int j = 0; j < dataGridView1.Rows.Count-1; j++)
                     {
                         wordapp.Selection.TypeParagraph();
                         wordapp.Selection.TypeText(dataGridView1[0,j].Value.ToString()+" / ");
                         wordapp.Selection.TypeText(dataGridView1[1, j].Value.ToString()+"г.");
                        
                     }
                 }
                 //Добавляем параграфы и выводим в них текст
                 wordapp.Selection.TypeParagraph();
                 wordapp.Selection.TypeText("Обед");

                 wordapp.Selection.TypeParagraph();
                 
                 wordapp.Selection.TypeText("Калорийность: " + textBox8.Text);

                 for (int i = 0; i < 1; i++)
                 {

                     for (int j = 0; j < dataGridView3.Rows.Count - 1; j++)
                     {
                         wordapp.Selection.TypeParagraph();
                         wordapp.Selection.TypeText(dataGridView3[0, j].Value.ToString() + " / ");
                         wordapp.Selection.TypeText(dataGridView3[1, j].Value.ToString() + "г.");

                     }
                 }
                 //Добавляем параграфы и выводим в них текст
                 wordapp.Selection.TypeParagraph();
                 wordapp.Selection.TypeText("Ужин");

               
                 wordapp.Selection.TypeParagraph();
                 wordapp.Selection.TypeText("Калорийность: " + textBox12.Text);

                 for (int i = 0; i < 1; i++)
                 {

                     for (int j = 0; j < dataGridView4.Rows.Count - 1; j++)
                     {
                         wordapp.Selection.TypeParagraph();
                         wordapp.Selection.TypeText(dataGridView4[0, j].Value.ToString() + " / ");
                         wordapp.Selection.TypeText(dataGridView4[1, j].Value.ToString() + "г.");

                     }
                 }
                 wordapp.Selection.TypeParagraph();
                 wordapp.Selection.TypeText("Калорийность всего меню: " + textBox16.Text);
        }
        #endregion
        
        #region Удаление продукта из завтрака
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
           if (dataGridView1.CurrentCell.Value == null)
            {
                MessageBox.Show("Невозможно удалить!", "Ошибка удаления");
                return;
            }
            else
            {
                string nazvanie = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                double ves = Convert.ToDouble(dataGridView1.CurrentRow.Cells[1].Value.ToString());
                double b = 0;
                double j = 0;
                double u = 0;
                double k = 0;
                

                DialogResult dr = MessageBox.Show("Вы действительно желаете удалить продукт\r\n '" + nazvanie + "' из своего меню?", "Удаление", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    string sql = "SELECT        nazvanie_produkta, kaloriinost, jiry, belki, uglevody"
                + " FROM pitanie WHERE (nazvanie_produkta = '" + nazvanie + "')";
                    string constr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=baz.mdb";
                    OleDbConnection conn = new OleDbConnection(constr);

                    try
                    {
                        conn.Open();
                        OleDbCommand cmd = new OleDbCommand(sql, conn);
                        OleDbDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            k = Convert.ToDouble(reader[1]);
                            k = Math.Round((k * ves) / 100);
                            j = Convert.ToDouble(reader[2]);
                            j = Math.Round((j * ves) / 100);
                            b = Convert.ToDouble(reader[3]);
                            b = Math.Round((b * ves) / 100);
                            u = Convert.ToDouble(reader[4]);
                            u = Math.Round((u * ves) / 100);
                        }
                        reader.Close();
                        dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message);
                    }
                    finally
                    {
                        conn.Close();

                    }
                    textBox1.Text = (Convert.ToDouble(textBox1.Text) - b).ToString();
                    textBox2.Text = (Convert.ToDouble(textBox2.Text) - j).ToString();
                    textBox3.Text = (Convert.ToDouble(textBox3.Text) - u).ToString();
                    textBox5.Text = (Convert.ToDouble(textBox5.Text) - k).ToString();

                    textBox13.Text = (Convert.ToDouble(textBox13.Text) - b).ToString();
                    textBox14.Text = (Convert.ToDouble(textBox14.Text) - j).ToString();
                    textBox15.Text = (Convert.ToDouble(textBox15.Text) - u).ToString();
                    textBox16.Text = (Convert.ToDouble(textBox16.Text) - k).ToString();
                }
                if (dr == DialogResult.No)
                {
                    return;
                }
                
            }
        }
        #endregion
        #region Удаление продукта из обеда
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (dataGridView3.CurrentCell.Value == null)
            {
                MessageBox.Show("Невозможно удалить!", "Ошибка удаления");
                return;
            }
            else
            {
                string nazvanie = dataGridView3.CurrentRow.Cells[0].Value.ToString();
                double ves = Convert.ToDouble(dataGridView3.CurrentRow.Cells[1].Value.ToString());
                double b = 0;
                double j = 0;
                double u = 0;
                double k = 0;


                DialogResult dr = MessageBox.Show("Вы действительно желаете удалить продукт\r\n '" + nazvanie + "' из своего меню?", "Удаление", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    string sql = "SELECT        nazvanie_produkta, kaloriinost, jiry, belki, uglevody"
                + " FROM pitanie WHERE (nazvanie_produkta = '" + nazvanie + "')";
                    string constr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=baz.mdb";
                    OleDbConnection conn = new OleDbConnection(constr);

                    try
                    {
                        conn.Open();
                        OleDbCommand cmd = new OleDbCommand(sql, conn);
                        OleDbDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            k = Convert.ToDouble(reader[1]);
                            k = Math.Round((k * ves) / 100);
                            j = Convert.ToDouble(reader[2]);
                            j = Math.Round((j * ves) / 100);
                            b = Convert.ToDouble(reader[3]);
                            b = Math.Round((b * ves) / 100);
                            u = Convert.ToDouble(reader[4]);
                            u = Math.Round((u * ves) / 100);
                        }
                        reader.Close();
                        dataGridView3.Rows.Remove(dataGridView3.CurrentRow);
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message);
                    }
                    finally
                    {
                        conn.Close();

                    }
                    textBox4.Text = (Convert.ToDouble(textBox4.Text) - b).ToString();
                    textBox6.Text = (Convert.ToDouble(textBox6.Text) - j).ToString();
                    textBox7.Text = (Convert.ToDouble(textBox7.Text) - u).ToString();
                    textBox8.Text = (Convert.ToDouble(textBox8.Text) - k).ToString();

                    textBox13.Text = (Convert.ToDouble(textBox13.Text) - b).ToString();
                    textBox14.Text = (Convert.ToDouble(textBox14.Text) - j).ToString();
                    textBox15.Text = (Convert.ToDouble(textBox15.Text) - u).ToString();
                    textBox16.Text = (Convert.ToDouble(textBox16.Text) - k).ToString();
                }
                if (dr == DialogResult.No)
                {
                    return;
                }

            }
        }
        #endregion
        #region Удаление продукта из ужина
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (dataGridView4.CurrentCell.Value == null)
            {
                MessageBox.Show("Невозможно удалить!", "Ошибка удаления");
                return;
            }
            else
            {
                string nazvanie = dataGridView4.CurrentRow.Cells[0].Value.ToString();
                double ves = Convert.ToDouble(dataGridView4.CurrentRow.Cells[1].Value.ToString());
                double b = 0;
                double j = 0;
                double u = 0;
                double k = 0;


                DialogResult dr = MessageBox.Show("Вы действительно желаете удалить продукт\r\n '" + nazvanie + "' из своего меню?", "Удаление", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    string sql = "SELECT        nazvanie_produkta, kaloriinost, jiry, belki, uglevody"
                + " FROM pitanie WHERE (nazvanie_produkta = '" + nazvanie + "')";
                    string constr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=baz.mdb";
                    OleDbConnection conn = new OleDbConnection(constr);

                    try
                    {
                        conn.Open();
                        OleDbCommand cmd = new OleDbCommand(sql, conn);
                        OleDbDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            k = Convert.ToDouble(reader[1]);
                            k = Math.Round((k * ves) / 100);
                            j = Convert.ToDouble(reader[2]);
                            j = Math.Round((j * ves) / 100);
                            b = Convert.ToDouble(reader[3]);
                            b = Math.Round((b * ves) / 100);
                            u = Convert.ToDouble(reader[4]);
                            u = Math.Round((u * ves) / 100);
                        }
                        reader.Close();
                        dataGridView4.Rows.Remove(dataGridView4.CurrentRow);
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message);
                    }
                    finally
                    {
                        conn.Close();

                    }
                    textBox9.Text = (Convert.ToDouble(textBox9.Text) - b).ToString();
                    textBox10.Text = (Convert.ToDouble(textBox10.Text) - j).ToString();
                    textBox11.Text = (Convert.ToDouble(textBox11.Text) - u).ToString();
                    textBox12.Text = (Convert.ToDouble(textBox12.Text) - k).ToString();

                    textBox13.Text = (Convert.ToDouble(textBox13.Text) - b).ToString();
                    textBox14.Text = (Convert.ToDouble(textBox14.Text) - j).ToString();
                    textBox15.Text = (Convert.ToDouble(textBox15.Text) - u).ToString();
                    textBox16.Text = (Convert.ToDouble(textBox16.Text) - k).ToString();
                }
                if (dr == DialogResult.No)
                {
                    return;
                }

            }
        }
        #endregion

       
        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search f7 = new Search();
            f7.Show();
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("help.pdf");
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        DSootn d;
        private void диаграммаСоотношенийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            decimal bp, jp, up, all;
            all = Convert.ToDecimal(textBox13.Text) + Convert.ToDecimal(textBox14.Text) + Convert.ToDecimal(textBox15.Text);
            bp = (Convert.ToDecimal(textBox13.Text) * 100) / all;
            jp = (Convert.ToDecimal(textBox14.Text) * 100) / all;
            up = (Convert.ToDecimal(textBox15.Text) * 100) / all;

            DSootn form6 = new DSootn(this);
            form6.ToolTips[0] = Math.Round(bp).ToString() + "%";
            form6.ToolTips[1] = Math.Round(jp).ToString() + "%";
            form6.ToolTips[2] = Math.Round(up).ToString() + "%";
            form6.Values[0] = Convert.ToDecimal(textBox13.Text);
            form6.Values[1] = Convert.ToDecimal(textBox14.Text);
            form6.Values[2] = Convert.ToDecimal(textBox15.Text);

            form6.Show();

        }
        NewProdukt n;
        private void добавитьНовыйПродуктToolStripMenuItem_Click(object sender, EventArgs e)
        {
            n = new NewProdukt();
            n.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            n = new NewProdukt();
            n.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       
        

        
        }
    }
