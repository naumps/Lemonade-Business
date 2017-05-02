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
        int cups;
        decimal TotalMoney;
        GroupBox currentGroupBox;
        Upgrade up;

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
            TotalMoney = 50m;
            //updateMyItems();
           // updateTB();
            UpgradesSet();
            currentGroupBox = groupBoxRecipe;
            lblTotalMoney.Text = TotalMoney.ToString() + " $";
            labelResultsPrice.Text = numPrice.Value.ToString() + " $";
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
           // changeGroupBox(ResultsGroupBox);
            if (enoughResurses())
            {
                ToggleNavBarButtons();
                changeGroupBox(GroupBoxResults);
                resetResults();
                btStartDay.Enabled = false;
                gameTimer.Enabled = true;
                newHumanTimer.Enabled = true;
                dayTimer.Enabled = true;
                addNonBuyers(5);
                addBuyers(3);
            }
            else {
                MessageBox.Show("You don't have enough resourses for your recipe to start the day.\nChange your recipe or buy more suplies.","Warning",MessageBoxButtons.OK);
            }
        }

        private bool enoughResurses() {
            if (lemons * cups > int.Parse(labelLemonsCount.Text)) return false;
            if (sugar * cups > int.Parse(labelSugarCount.Text)) return false;
            if (ice * cups > int.Parse(labelIceCount.Text)) return false;

            return true;
        }

        private void resetResults() {
            labelResultsCupsSold.Text = "0";
            labelResultsEarnings.Text = "0";
            Happy.Text = "0";
            Sad.Text = "0";
            labelResults_Mad.Text = "0"; 
        }

        private void dayTimer_Tick(object sender, EventArgs e)
        {
            Day++;
            if (Day == 25) {
                ToggleNavBarButtons();
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

       
        private void btRecipe_Click(object sender, EventArgs e)
        {
            changeGroupBox(groupBoxRecipe);
        }

        private void btSupplies_Click(object sender, EventArgs e)
        {
            changeGroupBox(SuppliesGroupBox);
        }

        private void changeGroupBox(GroupBox gb) {
            if (gb != currentGroupBox)
            {
                currentGroupBox.Visible = false;
                currentGroupBox = gb;
                currentGroupBox.Visible = true;
            }
        }

        private void ToggleNavBarButtons() {
            btRecipe.Enabled = !btRecipe.Enabled;
            btSupplies.Enabled = !btSupplies.Enabled;
            btUpgrade.Enabled = !btUpgrade.Enabled;
            btUpgrade.Enabled = !btUpgrade.Enabled;
        }

        private void btResults_Click(object sender, EventArgs e)
        {
            changeGroupBox(GroupBoxResults);
        }

        private decimal totalOrderPrice() {
            decimal sum = 0;
            
            sum += numSupLemons.Value*4.5m;
            sum += numSupSugar.Value * 1.5m;
            sum += numSupIce.Value * 0.5m;
            sum += numSupCups.Value * 2m;
            
            return sum;
        }

        private void resetSupliesBoxValues() {
            numSupLemons.Value=0;
            numSupSugar.Value =0;
            numSupIce.Value =0;
            numSupCups.Value =0;
        }

            //Check if Order Price > Total Money
            private void checkifOrderisOK() {
                
                 if(totalOrderPrice() > TotalMoney)
                     btSupOrder.Enabled = false;
                 else
                     btSupOrder.Enabled = true;
        }

            private void numSupLemons_ValueChanged(object sender, EventArgs e)
            {
                checkifOrderisOK();
            }

            private void numSupSugar_ValueChanged(object sender, EventArgs e)
            {
                checkifOrderisOK();
            }

            private void numSupIce_ValueChanged(object sender, EventArgs e)
            {
                checkifOrderisOK();
            }

            private void numSupCups_ValueChanged(object sender, EventArgs e)
            {
                checkifOrderisOK();
            }

            private int OrderTotalLemons() {
                return (int)numSupLemons.Value * 12;
            }

            private int OrderTotalSugar()
            {
                return (int)numSupSugar.Value * 10;
            }

            private int OrderTotalIce()
            {
                return (int)numSupLemons.Value * 15;
            }

            private int OrderTotalCups()
            {
                return (int)numSupLemons.Value * 20;
            }

            private void btSupOrder_Click(object sender, EventArgs e)
            {
                String msg = String.Format("Order list:\n Total Lemons: {0}\n Total Sugar: {1}\n Total Ice: {2}\n Total Cups: {3}\n\n Total Price: {4}$", OrderTotalLemons(), OrderTotalSugar(), OrderTotalIce(), OrderTotalCups(), totalOrderPrice());
                DialogResult confirm = MessageBox.Show(msg,"Confirmation",MessageBoxButtons.OKCancel);

                if (confirm == DialogResult.OK) {
                    TotalMoney -= totalOrderPrice();
                    labelLemonsCount.Text = OrderTotalLemons().ToString();
                    labelSugarCount.Text = OrderTotalSugar().ToString();
                    labelIceCount.Text = OrderTotalIce().ToString();
                    labelCupsCount.Text = OrderTotalCups().ToString();
                    updateTOtalMoney();
                    resetSupliesBoxValues();

                }
            }

            private void updateTOtalMoney() {
                lblTotalMoney.Text = TotalMoney.ToString() + " $";
            }

            private void btnAddLemon_Click(object sender, EventArgs e)
            {
                lemons = int.Parse(tbLeemons.Text);

                if (lemons < 99)
                {
                    lemons += 1;
                    tbLeemons.Text = (lemons).ToString();
                }

                if (checkifRecipeisOK()) btnMakeLemonade.Enabled = true;
                else btnMakeLemonade.Enabled = false;
            }

            private void btnRemoveLemon_Click(object sender, EventArgs e)
            {
                lemons = int.Parse(tbLeemons.Text);

                if (lemons > 0)
                {
                    lemons -= 1;
                    tbLeemons.Text = (lemons).ToString();
                }

                if (checkifRecipeisOK()) btnMakeLemonade.Enabled = true;
                else btnMakeLemonade.Enabled = false;
            }

            private void btnAddSugar_Click(object sender, EventArgs e)
            {
                sugar = int.Parse(tbSugar.Text);

                if (sugar < 99)
                {
                    sugar += 1;
                    tbSugar.Text = (sugar).ToString();
                }
            }

            private void btnRemoveSugar_Click(object sender, EventArgs e)
            {
                sugar = int.Parse(tbSugar.Text);

                if (sugar > 0)
                {
                    sugar -= 1;
                    tbSugar.Text = (sugar).ToString();
                }
            }

            private void btnAddIce_Click(object sender, EventArgs e)
            {
                ice = int.Parse(tbIce.Text);

                if (ice < 99)
                {
                    ice += 1;
                    tbIce.Text = (ice).ToString();
                }
            }

            private void btnRemoveIce_Click(object sender, EventArgs e)
            {
                ice = int.Parse(tbIce.Text);

                if (ice > 0)
                {
                    ice -= 1;
                    tbIce.Text = (ice).ToString();
                }
            }

            private void nudNumberOfCups_ValueChanged(object sender, EventArgs e)
            {
                cups = (int)nudNumberOfCups.Value;
                if (checkifRecipeisOK()) btnMakeLemonade.Enabled = true;
                else btnMakeLemonade.Enabled = false;
            }

            private bool checkifRecipeisOK() {
                if (nudNumberOfCups.Value > 0 && lemons > 0) return true;
                return false;
            }

            private void btnMakeLemonade_Click(object sender, EventArgs e)
            {
                labelResultsLeemons.Text = lemons.ToString();
                labelResultsIce.Text = ice.ToString();
                labelResultSugar.Text = sugar.ToString();
                labelResultsCups.Text = cups.ToString();
                btStartDay.Enabled = true;
            }

            private void btPrice_Click(object sender, EventArgs e)
            {
                changeGroupBox(groupBoxPrice);
            }

            private void numPrice_ValueChanged(object sender, EventArgs e)
            {
                numPrice.DecimalPlaces = 2;
                labelResultsPrice.Text = numPrice.Value.ToString() + " $";
            }

            private void UpgradesSet() {
                Upgrade Juicer = new Upgrade("Juicer", 25.99m,10, "A juicer is a tool used to extract juice from fruits in a process called juicing. Buy this item and get 10% more speed in the making of the lemonade.");
                Upgrade IceMaker = new Upgrade("Ice Maker",40m,20, "A machine that automatically produces ice for use in drinks. With buying this item you will get extra 20 cubes of ice at the end of the day.");
                Upgrade Jukebox = new Upgrade("Jukebox", 33.33m,15, "A jukebox is a partially automated music-playing device, that will play a patron's selection from self-contained media. If you have this, people will love you and it's more likely that they will tip you. This item gives you 15% more profit.");
                cbUpgrades.Items.Add(Juicer);
                cbUpgrades.Items.Add(IceMaker);
                cbUpgrades.Items.Add(Jukebox);

            }

            private void cbUpgrades_SelectedIndexChanged(object sender, EventArgs e)
            {
                up = cbUpgrades.SelectedItem as Upgrade;

                if (up != null)
                {
                    listBoxUpgrades.ClearSelected();
                    tbUpgradesPrice.Text = up.price.ToString() + " $";
                    tbUpgradesInfo.Text = up.info;
                    if (TotalMoney >= up.price)
                    {
                        btUpgradesBuy.Enabled = true;
                    }
                    else { btUpgradesBuy.Enabled = false; }
                }
            }

            private void btUpgradesBuy_Click(object sender, EventArgs e)
            {
                if (up != null)
                {
                    listBoxUpgrades.Items.Add(up);
                    cbUpgrades.Items.Remove(up);    
                    TotalMoney -= up.price;
                    updateTOtalMoney();
                    tbUpgradesInfo.Text = "";
                    cbUpgrades.Text = "";
                    tbUpgradesPrice.Text = "";
                    btUpgradesBuy.Enabled = false;
                    up = null;
                }
                if (cbUpgrades.Items.Count == 0) cbUpgrades.Enabled = false;


            }

            private void listBoxUpgrades_SelectedIndexChanged(object sender, EventArgs e)
            {
                /*Upgrade upListed = listBoxUpgrades.SelectedItem as Upgrade;
                if (upListed != null)
                {
                    tbUpgradesInfo.Text = "";
                    tbUpgradesInfo.Text = up.info;
                } */
            }

            private void btUpgrade_Click(object sender, EventArgs e)
            {
                changeGroupBox(groupBoxUpgrades);
            }
    }
}
