using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using ZedGraph;


namespace ZdorovoePitanie
{
    public partial class DVesa : Form
    {
        public DVesa()
        {
            InitializeComponent();
        }
        public double ves;
        public double vesn;
        public double vesv;
        
        

        private void Form5_Load(object sender, EventArgs e)
        {
            // Setup the graph
            CreateGraph(zedGraphControl1);
            // Size the control to fill the form with a margin
            SetSize();


        }
        private void SetSize()
        {
            zedGraphControl1.Location = new Point(10, 10);
            // Leave a small margin around the outside of the control
            zedGraphControl1.Size = new Size(ClientRectangle.Width - 20,
                                    ClientRectangle.Height - 20);
        }

        private void Form5_Resize(object sender, EventArgs e)
        {
            SetSize();
        }
        private void CreateGraph(ZedGraphControl zg1)
        {
            // get a reference to the GraphPane
            GraphPane myPane = zg1.GraphPane;

            // Set the Titles
            myPane.Title.Text = "Диаграмма границы веса";
            myPane.XAxis.Title.Text = "";
            myPane.YAxis.Title.Text = "Вес в кг.";

            // Make up some random data points
            string[] labels = { "Нижняя граница", "Ваш вес", "Верхняя граница" };
            double[] y = { vesn };
            double[] y2 = {0, ves };
            double[] y3 = {0,0, vesv };
           

            // Generate a red bar with "Curve 1" in the legend
            BarItem myBar = myPane.AddBar("Нижняя граница", null, y,
                                                        Color.Red);
            myBar.Bar.Fill = new Fill(Color.Coral, Color.White,
                                                        Color.Coral);

            // Generate a blue bar with "Curve 2" in the legend
            myBar = myPane.AddBar("Ваш вес", null, y2, Color.Blue);
            myBar.Bar.Fill = new Fill(Color.Lime, Color.White,
                                                        Color.Lime);

            // Generate a green bar with "Curve 3" in the legend
            myBar = myPane.AddBar("Верхняя граница", null, y3, Color.Green);
            myBar.Bar.Fill = new Fill(Color.DarkRed, Color.White,
                                                        Color.DarkRed);

            // Generate a black line with "Curve 4" in the legend
          

            // Draw the X tics between the labels instead of 
            // at the labels
            myPane.XAxis.MajorTic.IsBetweenLabels = true;

            // Set the XAxis labels
            myPane.XAxis.Scale.TextLabels = labels;
            // Set the XAxis to Text type
            myPane.XAxis.Type = AxisType.Text;

            // Fill the Axis and Pane backgrounds
            myPane.Chart.Fill = new Fill(Color.White,
                  Color.FromArgb(255, 255, 166), 90F);
            myPane.Fill = new Fill(Color.FromArgb(250, 250, 255));

            // Tell ZedGraph to refigure the
            // axes since the data have changed
            zg1.AxisChange();
        }
       
    }
}
