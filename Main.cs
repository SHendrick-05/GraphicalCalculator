using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicalCalculator
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void graphButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(functionBox.Text)
                && double.TryParse(minXBox.Text, out double xMin)
                && double.TryParse(maxXBox.Text, out double xMax)
                && double.TryParse(minYBox.Text, out double yMin)
                && double.TryParse(maxYBox.Text, out double yMax))
            {
                initStart(functionBox.Text, xMin, xMax, yMin, yMax);
            }
        }

        private void initStart(string funcText, double xMin, double xMax, double yMin, double yMax)
        {
            Thread graphThread = new Thread(() => startGraph(funcText, xMin, xMax, yMin, yMax));
            graphThread.Start();
        }

        private void startGraph(string func, double xMin, double xMax, double yMin, double yMax)
        {
            using var game = new Game1(func, xMin, xMax, yMin, yMax);
            game.Run();
        }
    }
}
