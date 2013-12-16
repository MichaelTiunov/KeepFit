using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.PieChart;

namespace ZdorovoePitanie
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class DSootn : System.Windows.Forms.Form
    {

        #region Controls

        private System.Drawing.PieChart.PieChartControl m_panelDrawing;

        private System.Windows.Forms.PrintDialog m_printDialog;
        private System.Windows.Forms.ColorDialog m_colorDialog;
        #endregion
        public decimal kkal, jir, bel, ugl;

        private System.ComponentModel.Container components = null;
        private PieChartControl pieChartControl1;
        private Label label1;
        private Label label2;

        private Menu _mainForm;
        public DSootn(Menu mainform)
        {
            _mainForm = mainform;
            InitializeComponent();
            FillEdgeColorTypeListBox();
            InitializeChart();
        }
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DSootn));
            this.m_panelDrawing = new System.Drawing.PieChart.PieChartControl();
            this.m_colorDialog = new System.Windows.Forms.ColorDialog();
            this.m_printDialog = new System.Windows.Forms.PrintDialog();
            this.pieChartControl1 = new System.Drawing.PieChart.PieChartControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // m_panelDrawing
            // 
            this.m_panelDrawing.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelDrawing.BackColor = System.Drawing.SystemColors.Window;
            this.m_panelDrawing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_panelDrawing.Location = new System.Drawing.Point(23, 322);
            this.m_panelDrawing.Name = "m_panelDrawing";
            this.m_panelDrawing.Size = new System.Drawing.Size(809, 269);
            this.m_panelDrawing.TabIndex = 16;
            this.m_panelDrawing.ToolTips = null;
            // 
            // pieChartControl1
            // 
            this.pieChartControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pieChartControl1.BackColor = System.Drawing.SystemColors.Window;
            this.pieChartControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pieChartControl1.Location = new System.Drawing.Point(23, 29);
            this.pieChartControl1.Name = "pieChartControl1";
            this.pieChartControl1.Size = new System.Drawing.Size(809, 259);
            this.pieChartControl1.TabIndex = 17;
            this.pieChartControl1.ToolTips = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(326, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Оптимальное процентное соотношение";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(308, 297);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(251, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Процентное соотношение в Вашем меню";
            // 
            // DSootn
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(860, 603);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_panelDrawing);
            this.Controls.Add(this.pieChartControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 380);
            this.Name = "DSootn";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Диаграмма потребления";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region Get properties

        private Color[] Colors
        {
            get
            {
                ArrayList colors = new ArrayList();

                colors.Add(Color.FromArgb(120, Color.Yellow));
                colors.Add(Color.FromArgb(120, Color.Lavender));
                colors.Add(Color.FromArgb(120, Color.PaleTurquoise));
                return (Color[])colors.ToArray(typeof(Color));
            }
        }
        public decimal[] Values = new decimal[3];
        
        private float[] Displacements
        {
            get
            {
                ArrayList displacements = new ArrayList();
                displacements.Add((float)0.20);
                displacements.Add((float)0.05);
                displacements.Add((float)0.05);

                return (float[])displacements.ToArray(typeof(float));
            }
        }

        private string[] Texts
        {
            get
            {
                ArrayList texts = new ArrayList();
                texts.Add("Белки");
                texts.Add("Жиры");
                texts.Add("Углеводы");

                return (string[])texts.ToArray(typeof(string));
            }
        }
        public string[] ToolTips = new string[3];
       //данные для идеального соотношения!!!
        public string[] ToolTips1 = new string[3] {"30%","15%","55%"};
        public decimal[] Values1 = new decimal[3] {30,15,55 };
        
        
        #endregion // Get properties

        private void InitializeChart()
        {
            SetValues();
            SetPieDisplacements();
            SetColors();
            SetTexts();
            SetToolTips();
            m_panelDrawing.LeftMargin = (float)100;
            m_panelDrawing.RightMargin = (float)100;
            m_panelDrawing.TopMargin = (float)50;
            m_panelDrawing.BottomMargin = (float)50;
            m_panelDrawing.FitChart = true;
            m_panelDrawing.SliceRelativeHeight = (float)0.25;
            m_panelDrawing.InitialAngle = (float)-30;
            m_panelDrawing.EdgeLineWidth = (float)1.0;
            m_panelDrawing.SliceRelativeHeight = (float)0.10;

            //идеальное процентное соотношение
            SetValues1();
            SetPieDisplacements1();
            SetColors1();
            SetTexts1();
            SetToolTips1();

            pieChartControl1.LeftMargin = (float)100;
            pieChartControl1.RightMargin = (float)100;
            pieChartControl1.TopMargin = (float)50;
            pieChartControl1.BottomMargin = (float)50;
            pieChartControl1.FitChart = true;
            pieChartControl1.SliceRelativeHeight = (float)0.25;
            pieChartControl1.InitialAngle = (float)-30;
            pieChartControl1.EdgeLineWidth = (float)1.0;
            pieChartControl1.SliceRelativeHeight = (float)0.10;

        }

        private void FillEdgeColorTypeListBox()
        {
            string[] types = Enum.GetNames(typeof(EdgeColorType));
            m_panelDrawing.EdgeColorType = EdgeColorType.DarkerThanSurface;
            pieChartControl1.EdgeColorType = EdgeColorType.DarkerThanSurface;
        }

        private void UpdateChart()
        {
            SetValues();
            SetPieDisplacements();
            SetColors();
            SetTexts();
            SetToolTips();
        }
        private void SetValues1()
        {
            pieChartControl1.Values = Values1;
        }

        private void SetPieDisplacements1()
        {
            pieChartControl1.SliceRelativeDisplacements = Displacements;
        }

        private void SetColors1()
        {
            pieChartControl1.Colors = Colors;
        }

        private void SetTexts1()
        {
            pieChartControl1.Texts = Texts;
        }

        private void SetToolTips1()
        {
            pieChartControl1.ToolTips = ToolTips1;
        }

        private void SetValues()
        {
            m_panelDrawing.Values = Values;
        }

        private void SetPieDisplacements()
        {
            m_panelDrawing.SliceRelativeDisplacements = Displacements;
        }

        private void SetColors()
        {
            m_panelDrawing.Colors = Colors;
        }

        private void SetTexts()
        {
            m_panelDrawing.Texts = Texts;
        }

        private void SetToolTips()
        {
            m_panelDrawing.ToolTips = ToolTips;
        }

       
       

       
        
    }
}