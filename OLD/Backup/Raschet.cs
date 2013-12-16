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
            double ves, vozrast, rost, inS;//вес, возраст, рост,
            //индекс Соловёва(окружность запястья)
            double brok, imt;// индекс массы тела, вес Брока
            double mng, mwg;//нижняя и верхняя граница веса тела
            double vesL;//вес по формуле Лоренца
            string pol;//пол
            string cel;//цель
            string activity;//активность
            double bms;//базовая метаболическая скорость
            double tdee;//ежедневное количество калорий
            //
            //свойства...
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
            public void TotalDEE()//определяем ежедневную потребность в калориях
            {
                if (Activity == "Сидячий образ жизни")
                {
                    TDEE = BMS * 1.2;
                }
                if (Activity == "Средняя активность")
                {
                    TDEE = BMS * 1.375;
                }
                if (Activity == "Высокая активность")
                {
                    TDEE = BMS * 1.55;
                }
                if (Activity == "Очень высокая активность")
                {
                    TDEE = BMS * 1.725;
                }
            }
            public void TotalPlusCel()
            {
                
                if (Cel == "Увеличение веса")
                {
                    TDEE += (TDEE * 10) / 100;
                }
                if (Cel == "Поддержание веса")
                {
                    TDEE += (TDEE * 0.1) / 100;
                }
                if (Cel == "Уменьшение веса")
                {
                    TDEE -= (TDEE * 10) / 100;
                }
            }
            public void BaseMetabolicSpeed()//определяем метаболическую скорость
                //нужна для подсчёта калорийности...
            {
                if (Pol == "м")//проверяем пол
                {
                    BMS = 66 + (13.7 * Ves) + (5 * Rost) - (6.8 * Vozrast);
                }
                if (Pol == "ж")//проверяем пол
                {
                    BMS = 65.5 + (9.6 * Ves) + (1.8 * Rost) - (4.7 * Vozrast);
                }
            }
            public double IMT(out string znach)//вычисление индекса массы тела
            {
                //выходной параметр znach выдаст нам расшифровку индекса
                double r=Rost/100;//делаем рост из см в метры
                Imt = Ves / Math.Pow(r, 2);
                Imt=Math.Round(Imt, 2);//округляем до 2 знаков
                string z = "";//временная переменная
                if (Imt < 15)//проверка индекса и расшифровка
                {
                    z = "Острый дефицит веса";
                }
                if ((Imt>=15)&&(Imt<20))
                {
                    z = "Дефицит веса";
                }
                if ((Imt >= 20) && (Imt < 25))
                {
                    z = "Нормальный вес";
                }
                if ((Imt >= 25) && (Imt <= 30))
                {
                    z = "Избыточный вес";
                }
                if (Imt > 30)
                {
                    z = "Ожирение";
                }
                znach = z;//присваиваем значение выходному параметру
                return Imt;//возврат имт
            }
            public double IMTU(out string znach,out string teloslozh)
                //уточнённая формула индекса массы тела...
            {
                string t = "";//временная переменная
                double r = Rost/100;//рост в метры
                if (Pol == "м")//проверяем пол
                {
                    Imt = Math.Round((19 * Ves / (InS * Math.Pow(r, 2))), 2);//формула
                    if (InS < 18)
                    {
                        t = "Тонкокостное телосложение";
                    }
                    if ((InS >= 18)&&(InS <= 20))
                    {
                        t = "Нормокостное телосложение";
                    }
                    if (InS > 20)
                    {
                        t = "Ширококостное телосложение";
                    }
                }
                if (Pol == "ж")
                {
                    Imt = Math.Round((16 * Ves / (InS * Math.Pow(r, 2))),2);
                    if (InS < 15)
                    {
                        t = "Тонкокостное телосложение";
                    }
                    if ((InS >= 15) && (InS <= 17))
                    {
                        t = "Нормокостное телосложение";
                    }
                    if (InS > 17)
                    {
                        t = "Ширококостное телосложение";
                    }
                }
                string z = "";//временная переменная
                if (Imt < 15)//проверка индекса и расшифровка
                {
                    z = "Острый дефицит веса";
                }
                if ((Imt >= 15) && (Imt < 20))
                {
                    z = "Дефицит веса";
                }
                if ((Imt >= 20) && (Imt < 25))
                {
                    z = "Нормальный вес";
                }
                if ((Imt >= 25) && (Imt <= 30))
                {
                    z = "Избыточный вес";
                }
                if (Imt > 30)
                {
                    z = "Ожирение";
                }
                teloslozh = t;//присваиваем значение выходному параметру
                znach = z;//присваиваем значение выходному параметру
                return Imt;//возврат имт

            }//вычисление уточнённого имт
            //исходя из телосложения
            public double VesBroka()//Расчёт по формуле Брока !!!Неточная формула!!!
            {
                if (Rost <= 165)//проверка на рост чем выше тем больше вычитаем
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
                //определяем нижнюю и верхнюю границы веса
            {
                double r = Rost/100;//рост в метры
                double ng = 0; //временные переменные
                double wg = 0; 
                if (Pol == "м")
                {
                    ng = (20 * InS * Math.Pow(r, 2)) / 19;
                    wg = (25 * InS * Math.Pow(r, 2)) / 19;
                }
                if (Pol == "ж")
                {
                    ng = (20 * InS * Math.Pow(r, 2)) / 16;
                    wg = (25 * InS * Math.Pow(r, 2)) / 16;
                }
                n = Math.Round(ng,2);//округляем границы весов
                w = Math.Round(wg,2);
            }//вычисление границ
            //веса
            public double VesLorenca()//вес Лоренца
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
            int n = 50;//вес начинается с 50 кг.
    
            for (int i = 0; i < 100; i++)
            {
                comboBox1.Items.Add(n);//добавляем элемент
               
                n += 1;//увеличиваем вес на 10 кг.
               
            }
            int v = 20;//возраст начинается с 20 лет
            for (int i = 0; i < 60; i++)
            {
                comboBox2.Items.Add(v);
                v += 1;
            }
            comboBox3.Items.Add("Увеличение веса");
            comboBox3.Items.Add("Поддержание веса");
            comboBox3.Items.Add("Уменьшение веса");

            comboBox4.Items.Add("Сидячий образ жизни");
            comboBox4.Items.Add("Средняя активность");
            comboBox4.Items.Add("Высокая активность");
            comboBox4.Items.Add("Очень высокая активность");
     
        }
        
        public Menu f2;



        DVesa f5 = new DVesa();

        private void button1_Click(object sender, EventArgs e)
        {
            //Создаём пользователя и вычисляем ИМТ
            u = new User();
            u.Ves = Convert.ToDouble(comboBox1.Text);
            u.Rost = Convert.ToDouble(numericUpDown1.Value);
            u.Vozrast = Convert.ToDouble(comboBox2.Text);
            u.Pol = radioButton1.Checked ? "м" : "ж";//если выбран первый переключатель, то пол мужской в противном случае пол - женский
            u.Cel = comboBox3.Text;//выбираем цель
            u.Activity = comboBox4.Text;//выбираем активность
            //пол будет мужской в противном случае - женский.
            u.InS = Convert.ToDouble(numericUpDown2.Value);//выбираем окружность запястья
            u.BaseMetabolicSpeed();//определяем метаболическую скорость
            u.TotalDEE();//определяем ежедневные калории в зависимости от метаболизма и активности
            u.TotalPlusCel();//пересчитываем калории в зависимости от цели
            groupBox2.Enabled = false;
            string znach = ""; //для значения выходного параметра в методе
            label5.Text = u.IMT(out znach).ToString() + "\r\n" + znach;//выводим имт и расшифровку
            label6.Text = u.VesBroka().ToString() + " кг."; //выводим вес Брока
            znach = "";//обнуляем строчку
            string teloslozh = "";//для значения выходного параметра в методе
            label8.Text = u.IMTU(out znach, out teloslozh) + "\r\n" + znach + "\r\n"
                + teloslozh;//выводит имт(уточнённый) + расшифровка + тип телосложения
            double n = 0, w = 0;//для значения выходного параметра в методе
            u.GranicaVesa(out n, out w);//вычисляем границы веса
            label9.Text = "Нижняя граница веса: " + n.ToString() + "\r\n"
                + "Верхняя граница веса: " + w.ToString();
            label10.Text = u.VesLorenca().ToString() + " кг.";//вес Лоренца
            button3.Enabled = true;
            f5.ves = u.Ves;
            f5.vesn = n;
            f5.vesv = w;
            диаграммаВесаToolStripMenuItem.Enabled = true;
            toolStripMenuItem1.Enabled = true;
        }
        //КНОПКА ОЧИСТКИ ФОРМЫ
        private void button4_Click_1(object sender, EventArgs e)
        {
            label5.Text = "";
            label6.Text = "";
            label8.Text = "";
            label9.Text = "";
            label10.Text = "";
            groupBox2.Enabled = true;
            button3.Enabled = false;
            диаграммаВесаToolStripMenuItem.Enabled = false;
            toolStripMenuItem1.Enabled = false;
        }
        //кнопка рекомендации и составление меню
        private void button3_Click_1(object sender, EventArgs e)
        {
            f2 = new Menu();//создаём и показываем форму
            f2.Show();
            if (comboBox3.Text == "Увеличение веса")
            {
                f2.label20.Text = "увеличения веса:";
            }
            if (comboBox3.Text=="Поддержание веса")
            {
                f2.label20.Text = "поддержания веса:";
            }
            if (comboBox3.Text=="Уменьшение веса")
            {
                f2.label20.Text = "снижения веса:";
            }
            f2.label18.Text = u.TDEE.ToString();//выводим ежедневную калорийность
            f2.cel = u.Cel;
        }
        NewProdukt f4;
        
        
        private void диаграммаВесаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f5.Show();
            
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void добавлениеToolStripMenuItem_Click(object sender, EventArgs e)
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
            диаграммаВесаToolStripMenuItem.Enabled = false;
            toolStripMenuItem1.Enabled = false;
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("help.chm");
        }

       
       

        

        

        


       





    }
}