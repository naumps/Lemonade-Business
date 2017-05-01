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
        public Store Store { get; set; }
        int lemons;
        int sugar;
        int ice;

        public LemonadeBusiness()
        {
            InitializeComponent();
            scene = new Scene();       
            background = new Bitmap(Resources.slika_300x300);
            backgroundLocation = new Point(360,100);
            this.DoubleBuffered = true;
            Store = new Store("Lemonade Shop");
            lemons = 0;
            sugar = 0;
            ice = 0;
            updateMyItems();
            updateTB();
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
            pbDay.Maximum = 25;// ako ja zgolemuvame dolzinata na denot togas maximum = dolzinata na denot
            pbDay.Value = Day;
        }


        private void updateTB()
        {
            tbLeemons.Text = lemons.ToString();
            tbIce.Text = ice.ToString();
            tbSugar.Text = sugar.ToString() ;
            lblTotalMoney.Text = String.Format("${0:0.0}", Store.Money.ToString());

        }
        private void updateMyItems()
        {
            lblLemons.Text = String.Format("Lemons: {0}", Store.Leemons.Count);
            lblSugar.Text = String.Format("Sugar: {0}", Store.Sugar.Count);
            lblIce.Text = String.Format("Ice: {0}", Store.Ice.Count);
            tbIce.Text = "0";
            tbLeemons.Text = "0";
            tbSugar.Text = "0";
            lblCups.Text = String.Format("Total cups:{0}",nudNumberOfCups.Value.ToString());
            nudNumberOfCups.Value = 0;
        }

        private void btnAddLemon_Click(object sender, EventArgs e)
        {
            Store.addLeemon();
            lemons++;
            updateTB();
        }

        private void btnRemoveLemon_Click(object sender, EventArgs e)
        {
            if(tbLeemons.Text != "0")
            {
                Store.removeLeemon();
                lemons--;
                updateTB();
            }
        }

        private void btnAddSugar_Click(object sender, EventArgs e)
        {
            Store.addSugar();
            sugar++;
            updateTB();
        }

        private void btnRemoveSugar_Click(object sender, EventArgs e)
        {
            if (tbSugar.Text != "0")
            {
                Store.removeSugar();
                sugar--;
                updateTB();

            }
        }

        private void btnAddIce_Click(object sender, EventArgs e)
        {
            Store.addIce();
            ice++;
            updateTB();

        }

        private void btnRemoveIce_Click(object sender, EventArgs e)
        {
            if (tbIce.Text != "0")
            {
                Store.removeIce();
                ice--;
                updateTB();
            }
        }
        private bool amIHappy()
        {
            int difference = Store.calculatePercentOfHappyPeople(calculateIdealNumberOfCups(),(int)nudNumberOfCups.Value);
            Random random = new Random();
            double randomNumber = random.NextDouble() * 100;
            if (randomNumber <= difference)
            {
                return true;
            }
            return false;
        }

       

        private void btnMakeLemonade_Click(object sender, EventArgs e)
        {
            lblPercent.Text = String.Format("Percent of happy people is: {0}", Store.calculatePercentOfHappyPeople(calculateIdealNumberOfCups(), (int)nudNumberOfCups.Value));
            updateMyItems();
            lemons = 0;
            sugar = 0;
            ice = 0;
        }

        private void lblTotalMoney_TextChanged(object sender, EventArgs e)
        {
            if (Store.Money < Store.LEEMON_PRICE)
            {
                btnAddLemon.Enabled = false;
            }else
            {
                btnAddLemon.Enabled = true;
            }

            if (Store.Money < Store.SUGAR_PRICE)
            {
                btnAddSugar.Enabled = false;
            }else
            {
                btnAddSugar.Enabled = true;
            }

            if (Store.Money < Store.ICE_PRICE)
            {
                btnAddIce.Enabled = false;
            }else
            {
                btnAddIce.Enabled = true;
            }
        }



        private void nudNumberOfCups_ValueChanged(object sender, EventArgs e)
        {
            if (nudNumberOfCups.Value != 0)
            {
                btnMakeLemonade.Enabled = true;
            }else
            {
                btnMakeLemonade.Enabled = false;
            }
        }


        private int calculateIdealNumberOfCups()
        {
            return lemons + lemons / 2 + ice / 2;
        }
    }
}
