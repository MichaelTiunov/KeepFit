using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ZdorovoePitanie
{
    
    public partial class Add : Form
    {
        private Menu _mainForm;
        public Add(Menu mainform)
        {
            _mainForm = mainform;
            InitializeComponent();
            
            
        }
        object[] mas;
        public object product, kkal, jir, bel, ugl, totalkkal,currentkkal;
        double k, j, b, u;
        private void button1_Click(object sender, EventArgs e)
        {
            
            double ves = Convert.ToDouble(textBox2.Text);
            k = (ves * Convert.ToDouble(kkal)) / 100;
            j = (ves * Convert.ToDouble(jir)) / 100;
            b = (ves * Convert.ToDouble(bel)) / 100;
            u = (ves * Convert.ToDouble(ugl)) / 100;
             
            mas = new object[2];
            mas[0] = product;
            mas[1] = ves;
            if (radioButton1.Checked)
            {
                _mainForm.dataGridView1.Rows.Add(mas);
                
                _mainForm.textBox1.Text = (Convert.ToDouble(_mainForm.textBox1.Text) + b).ToString();
                _mainForm.textBox2.Text = (Convert.ToDouble(_mainForm.textBox2.Text) + j).ToString();
                _mainForm.textBox3.Text = (Convert.ToDouble(_mainForm.textBox3.Text) + u).ToString();
                _mainForm.textBox5.Text = (Convert.ToDouble(_mainForm.textBox5.Text) + k).ToString();
            }
            if (radioButton2.Checked)
            {
                _mainForm.dataGridView3.Rows.Add(mas);
                _mainForm.textBox4.Text = (Convert.ToDouble(_mainForm.textBox4.Text) + b).ToString();
                _mainForm.textBox6.Text = (Convert.ToDouble(_mainForm.textBox6.Text) + j).ToString();
                _mainForm.textBox7.Text = (Convert.ToDouble(_mainForm.textBox7.Text) + u).ToString();
                _mainForm.textBox8.Text = (Convert.ToDouble(_mainForm.textBox8.Text) + k).ToString();
            }
            if (radioButton3.Checked)
            {
                _mainForm.dataGridView4.Rows.Add(mas);
                _mainForm.textBox9.Text = (Convert.ToDouble(_mainForm.textBox9.Text) + b).ToString();
                _mainForm.textBox10.Text = (Convert.ToDouble(_mainForm.textBox10.Text) + j).ToString();
                _mainForm.textBox11.Text = (Convert.ToDouble(_mainForm.textBox11.Text) + u).ToString();
                _mainForm.textBox12.Text = (Convert.ToDouble(_mainForm.textBox12.Text) + k).ToString();
            }
            _mainForm.textBox13.Text = (Convert.ToDouble(_mainForm.textBox13.Text) + b).ToString();
            _mainForm.textBox14.Text = (Convert.ToDouble(_mainForm.textBox14.Text) + j).ToString();
            _mainForm.textBox15.Text = (Convert.ToDouble(_mainForm.textBox15.Text) + u).ToString();
            _mainForm.textBox16.Text = (Convert.ToDouble(_mainForm.textBox16.Text) + k).ToString();
            if ((Convert.ToDouble(totalkkal) > Convert.ToDouble(currentkkal)) || (Convert.ToDouble(k) > Convert.ToDouble(currentkkal)) || (((Convert.ToDouble(k)+Convert.ToDouble(totalkkal)) > Convert.ToDouble(currentkkal))))
            {
                _mainForm.textBox16.BackColor = Color.Red;
                _mainForm.lblRec.ForeColor = Color.Red;
                _mainForm.lblRec.Text = "Вы превысили дневной\r\n уровень калорийности!";
            }
               
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pitanie_DataSet.produkt_pitania' table. You can move, or remove it, as needed.
            
            
        }

        
    }
}
