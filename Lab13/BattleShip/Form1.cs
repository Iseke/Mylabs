using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            //timer1.Tick += new EventHandler(Timer_Tick);
            //timer1.Enabled = true;
            //timer1.Start();
            InitializeComponent();
              
        }
        int k = 0;
        GameLogic gl = new GameLogic();
        private void Random_Click(object sender, EventArgs e)
        {
            //PlayerPanel.panelPosition = PanelPosition.Left;

        }

        private void Start_Click(object sender, EventArgs e)
        {

           
            this.Controls.Add(gl.p1);
            this.Controls.Add(gl.p2);
            
           
        }
       
        private void Exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void rotateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            k++;
            if (k % 2 != 0)
            {
                MessageBox.Show("Vertical Direction");
                Ship.rotate = Rotate.Vertical;
            }
            else if (k % 2 == 0)
            {
                MessageBox.Show("Horizontal Direction");

                Ship.rotate = Rotate.Horizontal;
            }
        }
        int k1 = 0;
        int k2 = 0;
        int k3 = 0;
        int k4 = 0;
        private void Level4_Click(object sender, EventArgs e)
        {
           
            
        }

        private void Level3_Click(object sender, EventArgs e)
        {
            
        }

        private void Level2_Click(object sender, EventArgs e)
        {
            
        }

        private void Level1_Click(object sender, EventArgs e)
        {
           
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (gl.p2.brain.ShipKilledCount == 0)
            {
                MessageBox.Show("You Win!!");
                timer1.Enabled = false;
                timer1.Stop();
            }
        }
    }
}
