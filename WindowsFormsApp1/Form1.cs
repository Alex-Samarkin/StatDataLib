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
            listBox1.DataSource = null;
            listBox1.DataSource = C1.Values;
            
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            /// Random integer 
            D1.Resize(1000);
            Random random = new Random();
            D1.Seq(0, 0.1);
            propertyGrid2.Refresh();
            listBox2.DataSource = null;
            listBox2.DataSource = D1.Values;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            /// Sequence of double
            C1.Resize(1000);
            C1.Random(-10, 10);
            propertyGrid1.Refresh();
            //
            listBox1.DataSource = null;
            listBox1.DataSource = C1.Values;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            D1.Resize(1000);
            Random random = new Random();
            D1.Random(-10, 10, random);
            propertyGrid2.Refresh();
            listBox2.DataSource = null;
            listBox2.DataSource = D1.Values;
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

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            var ss = new Series();
            ss.ChartType = SeriesChartType.FastLine;
            for (int i = 0; i < C1.Values.Count; i++)
            {
                var point = new DataPoint();
                ///
                point.XValue = C1.Values[i];
                point.SetValueY(D1[i]);
                point.Label = i.ToString();
                ss.Points.Add(point);
                ///
                ss.Points.Add(point);
            }
            chart1.Series.Add(ss);
            chart1.ChartAreas[0].RecalculateAxesScale();

        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            // Sort data in D1 values
            var data = D1.Values.OrderBy(x=>x).ToList();
            var c = data.Count();
            // Find median and LQ and HQ
            var median = data[c / 2];
            var LQ = data[c / 4];
            var HQ = data[c / 4 * 3];
            var IQR = HQ - LQ;
            // Find count of bins according one of the stats rules
            // Sturgess rule is
            // var KBins = (int)(Math.Round(Math.Log(c, 2))) + 1;
            var KBins = (int)Math.Round(3.322 * Math.Log10(c)) + 1;
            // find a borders of bins
            var min = data.Min();
            var max = data.Max();
            var h = (max- min)/KBins;
            // calculate count of data in every bin
            // Clear C1 before calculating

            for (var i = 0; i < KBins; i++)
            {
                var low = min+ i*h - h/2.0;
                var high = low + h;
                // lambda function
                // понятие замыкания
                var c1 = data.Count(x=> (x > low && x <= high ));
                
                // Add data to C1
            }
            //
            listBox1.DataSource = null;
            listBox1.DataSource = C1.Values;

            // Show bar graph
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            if( C1.Count > 0 )
            {
                D1.Clear();
                for (int i = 0;i < C1.Count;i++)
                {
                    var phi = C1.Values[i]/10.0;
                    D1.Add(Math.Sin(phi));
                }
                listBox2.DataSource = null;
                listBox2.DataSource = D1.Values;
                toolStripButton6_Click(sender, e);
            }
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            if (C1.Count > 0)
            {
                D1.Clear();
                for (int i = 0; i < C1.Count; i++)
                {
                    var phi = C1.Values[i] / 10.0;
                    D1.Add(Math.Sin(phi));
                }
                listBox2.DataSource = null;
                listBox2.DataSource = D1.Values;
                toolStripButton6_Click(sender, e);
            }
        }
    }
}
