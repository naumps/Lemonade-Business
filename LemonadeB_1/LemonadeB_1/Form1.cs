﻿using System;
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
        private Random random;
        public Store Store { get; set; }
        int lemons;
        int sugar;
        int ice;
        int cups;
       // decimal TotalMoney;
        GroupBox currentGroupBox;
        Upgrade up;
        Label l1;
        Store store;
        decimal moneyTODAY;
        int cupsSOLD;
        Label weather;

        public LemonadeBusiness()
        {
            InitializeComponent();
            scene = new Scene();       
            background = new Bitmap(Resources.slika_300x300);
            backgroundLocation = new Point(360,100);
            this.DoubleBuffered = true;
            random = new Random();
            store = new Store("Jonny's Lemonade Shop");
            lemons = 0;
            moneyTODAY = 0;
            sugar = 0;
            ice = 0;
            cupsSOLD = 0;
           // TotalMoney = 50m;
            UpgradesSet();
            currentGroupBox = groupBoxRecipe;
            updateMoney();
            labelResultsPrice.Text = numPrice.Value.ToString() + " $";
            CreateManuelLabel();
        }

        private void updateMoney() {
            lblTotalMoney.Text = store.Money.ToString() + " $";
            labelResultsEarnings.Text = moneyTODAY.ToString() + " $";
            labelResultsCupsSold.Text = cupsSOLD.ToString();
        }

        private void CreateManuelLabel()
        {
            l1 = new Label();
            l1.Location = new Point(515, 85);
            l1.Text = store.NameOfStore;
            this.Controls.Add(l1);
            l1.AutoSize = true;
            weather = new Label();
            weather.Location = new Point(515, 405);

            updateWeather();

            this.Controls.Add(weather);
            weather.AutoSize = true;
        }

        private void updateWeather() {
            if (store.sunny)
                weather.Text = "Weather: Sunny";
            else
                weather.Text = "Weather: Rainy";
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
                if (nb.PAID == true) {
                    nb.PAID = false;
                    cupsSOLD += 1;
                    moneyTODAY += numPrice.Value;
                    store.Money += numPrice.Value;
                    updateMoney();

                    if (store.Rating() == 0) {
                        labelResults_Mad.Text = (int.Parse(labelResults_Mad.Text)+1).ToString();
                        store.Popularity -= 1;
                    }
                    else if (store.Rating() == 1)
                    {
                        store.Popularity -= 1;
                        labelResults_Sad.Text = (int.Parse(labelResults_Sad.Text) + 1).ToString();
                    }
                    else {
                        store.Popularity += 1;
                        labelResults_Happy.Text = (int.Parse(labelResults_Happy.Text) + 1).ToString();
                    }
                }
                
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

        private void addNonBuyers() {
            int n;
            if (store.sunny) n =random.Next(5, 10);
            else n =random.Next(2, 5);
            scene.addNonByers(n);
            scene.addNewNonByer();
        }

        private void addBuyers()
        {
            scene.addByers(store.generatePopularityPeople());
            scene.addNewByer();
        }

        private void showRecipe() {
            labelResultsLeemons.Text = store.lastRecipeLeamons.ToString();
            labelResultsIce.Text = store.lastRecipeIce.ToString();
            labelResultSugar.Text = store.lastRecipeSugar.ToString();
            labelResultsCups.Text = store.lastRecipeCups.ToString();
        }

        private void takeResursi() {
            store.removeSuplies();
            updateResurses();
        }

        private void btStartDay_Click(object sender, EventArgs e)
        {
           
            if (store.enoughResurses())
            {
                ToggleNavBarButtons();
                changeGroupBox(GroupBoxResults);
                resetResults();
                showRecipe();
                store.startDay();
                takeResursi();
                labelLemonadesTotal.Text = store.lastRecipeCups.ToString();
                btStartDay.Enabled = false;
                gameTimer.Enabled = true;
                newHumanTimer.Enabled = true;
                dayTimer.Enabled = true;
                moneyTODAY = 0;
                cupsSOLD = 0;
                addNonBuyers();
                addBuyers();
            }
            else {
                MessageBox.Show("You don't have enough resourses for your recipe to start the day.\nChange your recipe or buy more suplies.","Warning",MessageBoxButtons.OK);
            }
        }  

        private void resetResults() {
            labelResultsCupsSold.Text = "0";
            labelResultsEarnings.Text = "0";
            labelResults_Happy.Text = "0";
            labelResults_Sad.Text = "0";
            labelResults_Mad.Text = "0"; 
        }

        private void dayTimer_Tick(object sender, EventArgs e)
        {
            Day++;
            if (Day == store.people*9) {
                ToggleNavBarButtons();
                dayTimer.Enabled = false;
                btStartDay.Enabled = true;
                gameTimer.Enabled = false;
                newHumanTimer.Enabled = false;

                if (random.Next(2) == 1)
                {
                    store.sunny = true;
                }
                else
                {
                    store.sunny = false;
                }

                updateWeather();
                scene = new Scene();
                Day = 0;
                store.Upgrades();
            }
            pbDay.Maximum = store.people * 9;// ako ja zgolemuvame dolzinata na denot togas maximum = dolzinata na denot
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
            btPrice.Enabled = !btPrice.Enabled;   
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

                if (totalOrderPrice() > store.Money)
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
       
            private void btSupOrder_Click(object sender, EventArgs e)
            {
                int totalLemons = store.OrderTotalLemons((int)numSupLemons.Value);
                int totalSugar = store.OrderTotalSugar((int)numSupSugar.Value);
                int totalCups = store.OrderTotalCups((int)numSupCups.Value);
                int totalIce = store.OrderTotalIce((int)numSupIce.Value);

                String msg = String.Format("Order list:\n Total Lemons: {0}\n Total Sugar: {1}\n Total Ice: {2}\n Total Cups: {3}\n\n Total Price: {4}$", totalLemons, totalSugar, totalIce, totalCups, totalOrderPrice());
                DialogResult confirm = MessageBox.Show(msg,"Confirmation",MessageBoxButtons.OKCancel);
               
                if (confirm == DialogResult.OK) {
                    store.Money -= totalOrderPrice();
                  
                    store.Leemons += totalLemons;
                    store.Ice += totalIce;
                    store.Sugar += totalSugar;
                    store.Cups += totalCups;

                    updateResurses();
                    updateTOtalMoney();
                    resetSupliesBoxValues();

                }
            }

            private void updateResurses() {
                labelLemonsCount.Text = store.Leemons.ToString();
                labelSugarCount.Text = store.Sugar.ToString();
                labelIceCount.Text = store.Ice.ToString();
                labelCupsCount.Text = store.Cups.ToString();
            }

            private void updateTOtalMoney() {
                lblTotalMoney.Text = store.Money.ToString() + " $";               
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
                store.lastRecipeLeamons = lemons;
                store.lastRecipeIce = ice;
                store.lastRecipeSugar = sugar;
                store.lastRecipeCups = cups;   

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

                store.price = numPrice.Value;
            }

            private void UpgradesSet() {
                Upgrade Juicer = new Upgrade("Juicer","Speed", 25.99m,10, "A juicer is a tool used to extract juice from fruits in a process called juicing. Buy this item and get 10% more speed in the making of the lemonade.");
                Upgrade IceMaker = new Upgrade("Ice Maker","Ice",40m,20, "A machine that automatically produces ice for use in drinks. With buying this item you will get extra 20 cubes of ice at the start of the day.");
                Upgrade Jukebox = new Upgrade("Jukebox","Jukebox", 33.33m,15, "A jukebox is a partially automated music-playing device, that will play a patron's selection from self-contained media. If you have this, people will love you and it's more likely that it will increse your popularity. This item gives you 10% more popularity per day.");
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
                    if (store.Money >= up.price)
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
                    store.upgrades.Add(up);
                    cbUpgrades.Items.Remove(up);
                    store.Money -= up.price;
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
                
            }

            private void btUpgrade_Click(object sender, EventArgs e)
            {
                changeGroupBox(groupBoxUpgrades);
            }
    }
}
