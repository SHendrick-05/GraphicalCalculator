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
            Thread graphThread = new Thread(() => startGraph(functionBox.Text));
            graphThread.Start();
        }

        private void startGraph(string func)
        {
            using var game = new GraphicalCalculator.Game1(func);
            game.Run();
        }
    }
}
