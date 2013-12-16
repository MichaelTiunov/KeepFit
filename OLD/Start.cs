using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace ZdorovoePitanie
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }
        Raschet r;
        private void button1_Click(object sender, EventArgs e)
        {
            r = new Raschet();
            r.Show();
        }
        

        private void button4_Click(object sender, EventArgs e)
        {
            Process.Start("help.pdf");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void расчётToolStripMenuItem_Click(object sender, EventArgs e)
        {
            r = new Raschet();
            r.Show();
        }

       
        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("help.pdf");
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        Search s;
        private void button6_Click(object sender, EventArgs e)
        {
            s = new Search();
            s.Show();
        }
        Diets d;
        private void button2_Click(object sender, EventArgs e)
        {
            d = new Diets();
            d.Show();
        }

        private void диетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            d = new Diets();
            d.Show();
        }

        private void продуктыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            s = new Search();
            s.Show();
        }

        private void упражненияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Upr fUpr = new Upr();
            fUpr.ShowDialog();
            fUpr.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Upr fUpr = new Upr();
            fUpr.ShowDialog();
            fUpr.Dispose();
        }
    }
}
