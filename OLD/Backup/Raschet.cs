using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace ZdorovoePitanie
{
    public partial class Raschet : Form
    {
        public class User
        {
            double ves, vozrast, rost, inS;//���, �������, ����,
            //������ �������(���������� ��������)
            double brok, imt;// ������ ����� ����, ��� �����
            double mng, mwg;//������ � ������� ������� ���� ����
            double vesL;//��� �� ������� �������
            string pol;//���
            string cel;//����
            string activity;//����������
            double bms;//������� �������������� ��������
            double tdee;//���������� ���������� �������
            //
            //��������...
            //
            public string Activity
            {
                get;
                set;
            }
            public double TDEE
            {
                get;
                set;
            }
            public double BMS
            {
                get;
                set;
            }
            public string Cel
            {
                get;
                set;
            }
            public double VesL
            {
                get;
                set;
            }
            public double MnG
            {
                get;
                set;
            }
            public double MwG
            {
                get;
                set;
            }
            public string Pol
            {
                get;
                set;
            }
            public double Ves
            {
                get;
                set;
            }
            public double Vozrast
            {
                get;
                set;
            }
            public double Rost
            {
                get;
                set;
            }
            public double InS
            {
                get;
                set;
            }
            public double Imt
            {
                get;
                set;
            }
            public double Brok
            {
                get;
                set;
            }
            public void TotalDEE()//���������� ���������� ����������� � ��������
            {
                if (Activity == "������� ����� �����")
                {
                    TDEE = BMS * 1.2;
                }
                if (Activity == "������� ����������")
                {
                    TDEE = BMS * 1.375;
                }
                if (Activity == "������� ����������")
                {
                    TDEE = BMS * 1.55;
                }
                if (Activity == "����� ������� ����������")
                {
                    TDEE = BMS * 1.725;
                }
            }
            public void TotalPlusCel()
            {
                
                if (Cel == "���������� ����")
                {
                    TDEE += (TDEE * 10) / 100;
                }
                if (Cel == "����������� ����")
                {
                    TDEE += (TDEE * 0.1) / 100;
                }
                if (Cel == "���������� ����")
                {
                    TDEE -= (TDEE * 10) / 100;
                }
            }
            public void BaseMetabolicSpeed()//���������� �������������� ��������
                //����� ��� �������� ������������...
            {
                if (Pol == "�")//��������� ���
                {
                    BMS = 66 + (13.7 * Ves) + (5 * Rost) - (6.8 * Vozrast);
                }
                if (Pol == "�")//��������� ���
                {
                    BMS = 65.5 + (9.6 * Ves) + (1.8 * Rost) - (4.7 * Vozrast);
                }
            }
            public double IMT(out string znach)//���������� ������� ����� ����
            {
                //�������� �������� znach ������ ��� ����������� �������
                double r=Rost/100;//������ ���� �� �� � �����
                Imt = Ves / Math.Pow(r, 2);
                Imt=Math.Round(Imt, 2);//��������� �� 2 ������
                string z = "";//��������� ����������
                if (Imt < 15)//�������� ������� � �����������
                {
                    z = "������ ������� ����";
                }
                if ((Imt>=15)&&(Imt<20))
                {
                    z = "������� ����";
                }
                if ((Imt >= 20) && (Imt < 25))
                {
                    z = "���������� ���";
                }
                if ((Imt >= 25) && (Imt <= 30))
                {
                    z = "���������� ���";
                }
                if (Imt > 30)
                {
                    z = "��������";
                }
                znach = z;//����������� �������� ��������� ���������
                return Imt;//������� ���
            }
            public double IMTU(out string znach,out string teloslozh)
                //��������� ������� ������� ����� ����...
            {
                string t = "";//��������� ����������
                double r = Rost/100;//���� � �����
                if (Pol == "�")//��������� ���
                {
                    Imt = Math.Round((19 * Ves / (InS * Math.Pow(r, 2))), 2);//�������
                    if (InS < 18)
                    {
                        t = "������������ ������������";
                    }
                    if ((InS >= 18)&&(InS <= 20))
                    {
                        t = "������������ ������������";
                    }
                    if (InS > 20)
                    {
                        t = "������������� ������������";
                    }
                }
                if (Pol == "�")
                {
                    Imt = Math.Round((16 * Ves / (InS * Math.Pow(r, 2))),2);
                    if (InS < 15)
                    {
                        t = "������������ ������������";
                    }
                    if ((InS >= 15) && (InS <= 17))
                    {
                        t = "������������ ������������";
                    }
                    if (InS > 17)
                    {
                        t = "������������� ������������";
                    }
                }
                string z = "";//��������� ����������
                if (Imt < 15)//�������� ������� � �����������
                {
                    z = "������ ������� ����";
                }
                if ((Imt >= 15) && (Imt < 20))
                {
                    z = "������� ����";
                }
                if ((Imt >= 20) && (Imt < 25))
                {
                    z = "���������� ���";
                }
                if ((Imt >= 25) && (Imt <= 30))
                {
                    z = "���������� ���";
                }
                if (Imt > 30)
                {
                    z = "��������";
                }
                teloslozh = t;//����������� �������� ��������� ���������
                znach = z;//����������� �������� ��������� ���������
                return Imt;//������� ���

            }//���������� ���������� ���
            //������ �� ������������
            public double VesBroka()//������ �� ������� ����� !!!�������� �������!!!
            {
                if (Rost <= 165)//�������� �� ���� ��� ���� ��� ������ ��������
                {
                    Brok = Rost - 100;
                }
                if ((Rost >= 166) && (Rost <= 175))
                {
                    Brok = Rost - 105;
                }
                if (Rost > 175)
                {
                    Brok = Rost - 110;
                }
                return Brok;
            }
            public void GranicaVesa(out double n, out double w)
                //���������� ������ � ������� ������� ����
            {
                double r = Rost/100;//���� � �����
                double ng = 0; //��������� ����������
                double wg = 0; 
                if (Pol == "�")
                {
                    ng = (20 * InS * Math.Pow(r, 2)) / 19;
                    wg = (25 * InS * Math.Pow(r, 2)) / 19;
                }
                if (Pol == "�")
                {
                    ng = (20 * InS * Math.Pow(r, 2)) / 16;
                    wg = (25 * InS * Math.Pow(r, 2)) / 16;
                }
                n = Math.Round(ng,2);//��������� ������� �����
                w = Math.Round(wg,2);
            }//���������� ������
            //����
            public double VesLorenca()//��� �������
            {
                VesL = (Rost - 100) - 0.25*(Rost - 150);
                return VesL;
            }
        }

      
        public Raschet()
        {
            InitializeComponent();
        }

        User u;
       
        private void Form1_Load(object sender, EventArgs e)
        {
            
            // TODO: This line of code loads data into the 'pitanie_DataSet.produkt_pitania' table. You can move, or remove it, as needed.
            int n = 50;//��� ���������� � 50 ��.
    
            for (int i = 0; i < 100; i++)
            {
                comboBox1.Items.Add(n);//��������� �������
               
                n += 1;//����������� ��� �� 10 ��.
               
            }
            int v = 20;//������� ���������� � 20 ���
            for (int i = 0; i < 60; i++)
            {
                comboBox2.Items.Add(v);
                v += 1;
            }
            comboBox3.Items.Add("���������� ����");
            comboBox3.Items.Add("����������� ����");
            comboBox3.Items.Add("���������� ����");

            comboBox4.Items.Add("������� ����� �����");
            comboBox4.Items.Add("������� ����������");
            comboBox4.Items.Add("������� ����������");
            comboBox4.Items.Add("����� ������� ����������");
     
        }
        
        public Menu f2;



        DVesa f5 = new DVesa();

        private void button1_Click(object sender, EventArgs e)
        {
            //������ ������������ � ��������� ���
            u = new User();
            u.Ves = Convert.ToDouble(comboBox1.Text);
            u.Rost = Convert.ToDouble(numericUpDown1.Value);
            u.Vozrast = Convert.ToDouble(comboBox2.Text);
            u.Pol = radioButton1.Checked ? "�" : "�";//���� ������ ������ �������������, �� ��� ������� � ��������� ������ ��� - �������
            u.Cel = comboBox3.Text;//�������� ����
            u.Activity = comboBox4.Text;//�������� ����������
            //��� ����� ������� � ��������� ������ - �������.
            u.InS = Convert.ToDouble(numericUpDown2.Value);//�������� ���������� ��������
            u.BaseMetabolicSpeed();//���������� �������������� ��������
            u.TotalDEE();//���������� ���������� ������� � ����������� �� ����������� � ����������
            u.TotalPlusCel();//������������� ������� � ����������� �� ����
            groupBox2.Enabled = false;
            string znach = ""; //��� �������� ��������� ��������� � ������
            label5.Text = u.IMT(out znach).ToString() + "\r\n" + znach;//������� ��� � �����������
            label6.Text = u.VesBroka().ToString() + " ��."; //������� ��� �����
            znach = "";//�������� �������
            string teloslozh = "";//��� �������� ��������� ��������� � ������
            label8.Text = u.IMTU(out znach, out teloslozh) + "\r\n" + znach + "\r\n"
                + teloslozh;//������� ���(���������) + ����������� + ��� ������������
            double n = 0, w = 0;//��� �������� ��������� ��������� � ������
            u.GranicaVesa(out n, out w);//��������� ������� ����
            label9.Text = "������ ������� ����: " + n.ToString() + "\r\n"
                + "������� ������� ����: " + w.ToString();
            label10.Text = u.VesLorenca().ToString() + " ��.";//��� �������
            button3.Enabled = true;
            f5.ves = u.Ves;
            f5.vesn = n;
            f5.vesv = w;
            �������������ToolStripMenuItem.Enabled = true;
            toolStripMenuItem1.Enabled = true;
        }
        //������ ������� �����
        private void button4_Click_1(object sender, EventArgs e)
        {
            label5.Text = "";
            label6.Text = "";
            label8.Text = "";
            label9.Text = "";
            label10.Text = "";
            groupBox2.Enabled = true;
            button3.Enabled = false;
            �������������ToolStripMenuItem.Enabled = false;
            toolStripMenuItem1.Enabled = false;
        }
        //������ ������������ � ����������� ����
        private void button3_Click_1(object sender, EventArgs e)
        {
            f2 = new Menu();//������ � ���������� �����
            f2.Show();
            if (comboBox3.Text == "���������� ����")
            {
                f2.label20.Text = "���������� ����:";
            }
            if (comboBox3.Text=="����������� ����")
            {
                f2.label20.Text = "����������� ����:";
            }
            if (comboBox3.Text=="���������� ����")
            {
                f2.label20.Text = "�������� ����:";
            }
            f2.label18.Text = u.TDEE.ToString();//������� ���������� ������������
            f2.cel = u.Cel;
        }
        NewProdukt f4;
        
        
        private void �������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f5.Show();
            
        }

        private void �����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ����������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f4 = new NewProdukt();
            f4.Show();
        }
        Menu m;
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            m = new Menu();
            m.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            label5.Text = "";
            label6.Text = "";
            label8.Text = "";
            label9.Text = "";
            label10.Text = "";
            groupBox2.Enabled = true;
            button3.Enabled = false;
            �������������ToolStripMenuItem.Enabled = false;
            toolStripMenuItem1.Enabled = false;
        }

        private void �������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("help.chm");
        }

       
       

        

        

        


       





    }
}