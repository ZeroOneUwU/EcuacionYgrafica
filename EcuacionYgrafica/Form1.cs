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

namespace EcuacionYgrafica
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cad= textBoxform.Text;
            string[] tokens = cad.Split(' ');
            //tokens[0] -> X
            //tokens[1] -> *
            //tokens[2] -> n

            double rinix = -10.0;
            //double rfinx = 10.0;
            double y = 0.0;
            if(tokens.Length == 3 )
            {
                double pot = Convert.ToDouble(tokens[2]);
                int i;
                inicializaDatos();
                textBoxDatos.Text = "";
                for (i = 1; i <= 20; i++)
                {
                    y = Math.Pow(rinix, pot);
                    textBoxDatos.Text = textBoxDatos.Text + "    " + rinix.ToString()
                     + "     " + y.ToString() + Environment.NewLine;
                    rinix += 1.0;
                    this.chart1.Series["ValorY"].Points.AddXY(rinix, y);
                }
            }
            else
            {
                MessageBox.Show("Hay un error en la formula pelotudo", "Error");
            }

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            inicializaDatos();
        }
        void inicializaDatos()
        {
            //limpiar en char
            this.chart1.Series.Clear();

            //Crear la serie
            //declarar un objeto que estara dentro
            var serieAY = chart1.Series.Add("ValorY");
            serieAY.ChartType = SeriesChartType.Spline;
            serieAY.XValueType = ChartValueType.Single;
            //asigna datos simples
            //color
            chart1.Series["ValorY"].Color = Color.Aqua;
        }
    }
}
