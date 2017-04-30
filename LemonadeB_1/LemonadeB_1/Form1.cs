using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LemonadeB_1.Properties;

namespace LemonadeB_1
{
    public partial class LemonadeBusiness : Form
    {
        Scene scene;
        Bitmap background;
        Point backgroundLocation;
        int Day;

        public LemonadeBusiness()
        {
            InitializeComponent();
            scene = new Scene();       
            background = new Bitmap(Resources.background);
            backgroundLocation = new Point(0,0);
            this.DoubleBuffered = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            foreach (NonBuyer nb in scene.nonbuyersNow) {
                nb.Move();
            }
            foreach (Buyer nb in scene.buyersNow)
            {
                nb.Move();
            }
            Invalidate();
        }

        private void newNonBuyerTimer_Tick(object sender, EventArgs e)
        {
            scene.addNewNonByer();
            scene.addNewByer();
            foreach (Buyer b in scene.buyersNow)
            {
                b.waitingToBuy();
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(background,backgroundLocation);
            scene.DrawNonByers(e.Graphics);
            scene.DrawByers(e.Graphics);
        }

        private void addNonBuyers(int n) {
            scene.addNonByers(n);
            scene.addNewNonByer();
        }

        private void addBuyers(int n)
        {
            scene.addByers(n);
            scene.addNewByer();
        }

        private void btStartDay_Click(object sender, EventArgs e)
        {
            btStartDay.Enabled = false;
            gameTimer.Enabled = true;
            newHumanTimer.Enabled = true;
            dayTimer.Enabled = true;
            addNonBuyers(5);
            addBuyers(3);
        }

        private void dayTimer_Tick(object sender, EventArgs e)
        {
            Day++;
            if (Day == 25) {
                dayTimer.Enabled = false;
                btStartDay.Enabled = true;
                gameTimer.Enabled = false;
                newHumanTimer.Enabled = false;
                scene = new Scene();
                Day = 0;
            }
        }
    }
}
