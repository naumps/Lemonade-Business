using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LemonadeB_1.Properties;
using System.IO;
using System.Media;

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
        public Label storeName { get; set; }
        int lemons;
        int sugar;
        int ice;
        int cups;
        GroupBox currentGroupBox;
        Upgrade up;
        Store store;
        decimal moneyTODAY;
        int cupsSOLD;
        Label weather;
        bool hasMusic;
        SoundPlayer player;
        Bitmap ratingFaceHappy;
        Bitmap ratingFaceSad;
        Bitmap ratingFaceMad;

        public LemonadeBusiness(Store s)
        {
            InitializeComponent();
            
            loadScene();
            this.DoubleBuffered = true;
            random = new Random();
            store = s;
            loadStoreItems();
            UpgradesSet();
            currentGroupBox = groupBoxRecipe;
            updateMoney();
            labelResultsPrice.Text = numPrice.Value.ToString() + " $";
            CreateManuelLabel();
            loadMusic();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            
        }

        private void updateMoney() {
            lblTotalMoney.Text = store.Money.ToString() + " $";
            labelResultsEarnings.Text = moneyTODAY.ToString() + " $";
            labelResultsCupsSold.Text = cupsSOLD.ToString();
        }

        public void CreateManuelLabel()
        {
            storeName = new Label();
            storeName.Location = new Point(515, 85);
            storeName.Text = store.NameOfStore;
            this.Controls.Add(storeName);
            storeName.AutoSize = true;
            weather = new Label();
            weather.Location = new Point(515, 405);

            updateWeather();

            this.Controls.Add(weather);
            weather.AutoSize = true;
            loadUpgrades();
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
                isitPaid(nb);
            }
            Invalidate();
        }

        private void newNonBuyerTimer_Tick(object sender, EventArgs e)
        {
            if(random.Next(2)==1) scene.addNewNonByer();
            if (random.Next(2)==1) scene.addNewByer();

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
                DayStart();
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
            int check = store.people*7; 
            check = scene.buyers.Count * 7;
            if (check < 14) check = 25;
            if (Day >= check && !scene.buyersNow[scene.buyersNow.Count - 1].Alive && !scene.nonbuyersNow[scene.nonbuyersNow.Count - 1].Alive)
            {
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
                pbDay.Value = 0;
                store.Upgrades();
                updateResurses();
            }
            pbDay.Maximum = check;// ako ja zgolemuvame dolzinata na denot togas maximum = dolzinata na denot
            if (pbDay.Value >= pbDay.Maximum - 1) pbDay.Value = pbDay.Maximum;
            else pbDay.Value = Day;
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
            btnSave.Enabled = !btnSave.Enabled;
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
                DialogResult confirm = DialogResult.Cancel;

                if (totalLemons != 0 || totalSugar != 0 || totalCups != 0 || totalIce != 0)
                {
                    String msg = String.Format("Order list:\n Total Lemons: {0}\n Total Sugar: {1}\n Total Ice: {2}\n Total Cups: {3}\n\n Total Price: {4}$", totalLemons, totalSugar, totalIce, totalCups, totalOrderPrice());
                     confirm = MessageBox.Show(msg, "Confirmation", MessageBoxButtons.OKCancel);
                }
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

            public void updateResurses() {
                labelLemonsCount.Text = store.Leemons.ToString();
                labelSugarCount.Text = store.Sugar.ToString();
                labelIceCount.Text = store.Ice.ToString();
                labelCupsCount.Text = store.Cups.ToString();
            }

            private void updateTOtalMoney() {
                lblTotalMoney.Text = store.Money.ToString() + " $";               
            }

            private void increseRecipeItem(out int item, TextBox tb) {
                item = int.Parse(tb.Text);

                if (item < 99)
                {
                    item += 1;
                    tb.Text = (item).ToString();
                }
            }

            private void decreseRecipeItem(out int item, TextBox tb)
            {
                item = int.Parse(tb.Text);

                if (item > 0)
                {
                    item -= 1;
                    tb.Text = (item).ToString();
                }
            }

            private void btnAddLemon_Click(object sender, EventArgs e)
            {
               /* lemons = int.Parse(tbLeemons.Text);

                if (lemons < 99)
                {
                    lemons += 1;
                    tbLeemons.Text = (lemons).ToString();
                }*/

                increseRecipeItem(out lemons, tbLeemons);

                if (checkifRecipeisOK()) btnMakeLemonade.Enabled = true;
                else btnMakeLemonade.Enabled = false;
            }

            private void btnRemoveLemon_Click(object sender, EventArgs e)
            {
                /*lemons = int.Parse(tbLeemons.Text);

                if (lemons > 0)
                {
                    lemons -= 1;
                    tbLeemons.Text = (lemons).ToString();
                }*/

                decreseRecipeItem(out lemons, tbLeemons);
                if (checkifRecipeisOK()) btnMakeLemonade.Enabled = true;
                else btnMakeLemonade.Enabled = false;
            }

            private void btnAddSugar_Click(object sender, EventArgs e)
            {
               /* sugar = int.Parse(tbSugar.Text);

                if (sugar < 99)
                {
                    sugar += 1;
                    tbSugar.Text = (sugar).ToString();
                } */

                increseRecipeItem(out sugar, tbSugar);
            }

            private void btnRemoveSugar_Click(object sender, EventArgs e)
            {
                /*sugar = int.Parse(tbSugar.Text);

                if (sugar > 0)
                {
                    sugar -= 1;
                    tbSugar.Text = (sugar).ToString();
                }*/
                decreseRecipeItem(out sugar, tbSugar);
            }

            private void btnAddIce_Click(object sender, EventArgs e)
            {
                /*
                ice = int.Parse(tbIce.Text);

                if (ice < 99)
                {
                    ice += 1;
                    tbIce.Text = (ice).ToString();
                }*/
                increseRecipeItem(out ice, tbIce);
            }

            private void btnRemoveIce_Click(object sender, EventArgs e)
            {
               /* ice = int.Parse(tbIce.Text);

                if (ice > 0)
                {
                    ice -= 1;
                    tbIce.Text = (ice).ToString();
                }*/
                decreseRecipeItem(out ice, tbIce);
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
                Upgrade Juicer = new Upgrade("Juicer","Speed", 45.59m,10, "A juicer is a tool used to extract juice from fruits in a process called juicing. Buy this item and get 10% more speed in the making of the lemonade.");
                Upgrade IceMaker = new Upgrade("Ice Maker","Ice",30m,20, "A machine that automatically produces ice for use in drinks. With buying this item you will get extra 20 cubes of ice at the end of the day.");
                Upgrade Jukebox = new Upgrade("Jukebox","Jukebox", 63.33m,15, "A jukebox is a partially automated music-playing device, that will play a patron's selection from self-contained media. If you have this, people will love you and it's more likely that it will increse your popularity. This item gives you 10% more popularity per day.");
                Upgrade Television = new Upgrade("Television", "TV", 100.99m, 99, "People usually watch TV to escape from the real world or to pass the time. But after watching TV enough and doing little else to keep it busy, the brain will enter a recessive state, usually leading to big tip (+1.5$ per day) and more popularity (+10%).");
                cbUpgrades.Items.Add(Television);
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
                    store.Money -= up.price;
                    updateTOtalMoney();
                    btUpgradesBuy.Enabled = false;
                }
                if (cbUpgrades.Items.Count == 0) cbUpgrades.Enabled = false;
            }

            private void loadUpgrades() {
                foreach (Upgrade up in store.upgrades) {
                    listBoxUpgrades.Items.Add(up);
                    //cbUpgrades.Items.Remove(up);
                }
            }
           

            private void btUpgrade_Click(object sender, EventArgs e)
            {
                changeGroupBox(groupBoxUpgrades);
                cbUpgrades.Items.Remove(up);
            }

        private void btnSave_Click(object sender, EventArgs e)
        {
            LemonadeBusiness activeForm = (LemonadeBusiness)LemonadeBusiness.ActiveForm;
            if(MessageBox.Show("Do you really want to close?","Save && Quit",MessageBoxButtons.YesNo)== DialogResult.Yes)
            {
                ObjectSerialization.saveToFile(activeForm.store);
                this.Close();
                Program.form.Close();
               // Environment.Exit(0);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (hasMusic)
            {
                pictureBox1.Image = Resources.mute;
                player.Stop();
                hasMusic = false;
            }else
            {
                pictureBox1.Image = Resources.unmute2;
                player.PlayLooping();
                hasMusic = true;
            }
        }

        private void LemonadeBusiness_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.form.Close();
        }

        private void loadScene()
        {
            scene = new Scene();
            background = new Bitmap(Resources.slika_300x300);
            backgroundLocation = new Point(360, 100);
            ratingFaceHappy = new Bitmap(Resources.happy, 30, 30);
            ratingFaceSad = new Bitmap(Resources.face, 30, 30);
            ratingFaceMad = new Bitmap(Resources.mad, 30, 30);
        }

        private void loadStoreItems()
        {
            lemons = store.Leemons;
            moneyTODAY = 0;
            cupsSOLD = 0;
            sugar = store.Sugar;
            ice = store.Ice;
            cups = store.Cups;
            numPrice.Value = store.price;
            showRecipe();
        }

        private void loadMusic()
        {
            hasMusic = true;
            if (store.lastRecipeCups > 0 && store.lastRecipeLeamons > 0) btStartDay.Enabled = true;
            player = new SoundPlayer(Properties.Resources.Ambient_piano_loop_105_bpm); // here WindowsFormsApplication1 is the namespace and Connect is the audio file name
            player.PlayLooping();
        }

        private void isitPaid(Buyer nb)
        {
            if (nb.PAID == true)
            {
                nb.PAID = false;

                cupsSOLD += 1;
                moneyTODAY += numPrice.Value;
                store.Money += numPrice.Value;
                updateMoney();

                if (store.Rating() == 0)
                {
                    labelResults_Mad.Text = (int.Parse(labelResults_Mad.Text) + 1).ToString();
                    store.Popularity -= 1;
                    nb.Picture = ratingFaceMad;
                }
                else if (store.Rating() == 1)
                {
                    store.Popularity -= 1;
                    labelResults_Sad.Text = (int.Parse(labelResults_Sad.Text) + 1).ToString();
                    nb.Picture = ratingFaceSad;
                }
                else
                {
                    store.Popularity += 1;
                    labelResults_Happy.Text = (int.Parse(labelResults_Happy.Text) + 1).ToString();
                    nb.Picture = ratingFaceHappy;
                }
            }
        }

        private void DayStart()
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
    }
}
