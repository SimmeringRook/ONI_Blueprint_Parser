using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ONI_Blueprint_Parser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            List<int> elements = new List<int>();
            List<int> mass = new List<int>();
            List<int> temp = new List<int>();
            List<int> loc_x = new List<int>();
            List<int> loc_y = new List<int>();


            int counter = 0;

            for (int i = 1; i < 15; i++)
            {
                elements.Add(i);
                i++;
                mass.Add(i);
                i++;
                temp.Add(i);
                i++;
                loc_x.Add(i);
                i++;
                loc_y.Add(i);

                counter++;
            }

            MessageBox.Show("counter: " + counter);
        }
    }
}
