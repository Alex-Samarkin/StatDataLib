using StatDataLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            propertyGrid1.SelectedObject = C1;
            propertyGrid2.SelectedObject = D1;
        }
        public IntColumn C1 { get; set; } = new IntColumn();
        public DoubleColumn D1 { get; set;} = new DoubleColumn();

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            C1.Resize(1000);
            C1.Seq(1, 1);
            propertyGrid1.Refresh();
            //
            listBox1.DataSource = C1.Values;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            /// Random integer 
            

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            /// Sequence of double
            

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            D1.Resize(1000);
            Random random = new Random();
            D1.Random(-10, 10, random);
            propertyGrid2.Refresh();

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            var bar = new Series();
            bar.ChartType = SeriesChartType.Column;
            var i = 0;
            foreach (var item in C1.Values)
            {
                DataPoint point = new DataPoint();
                point.XValue = i;
                point.SetValueY(item) ;
                bar.Points.Add(point);
            }
            chart1.Series.Add(bar);

        }
    }
}
