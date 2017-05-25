using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LemonadeB_1
{
    public partial class StartNewGameForm : Form
    {
        
        public StartNewGameForm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            
            
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            NewStoreForm nameOfStoreForm = new NewStoreForm();
            DialogResult result = nameOfStoreForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                LemonadeBusiness newGame = new LemonadeBusiness(nameOfStoreForm.Store);
                newGame.Show();
                this.Hide();

            }
        }

        private void btnHowToPlay_Click(object sender, EventArgs e)
        {
            HowToPlayForm howToPlay = new HowToPlayForm();
            howToPlay.Show();
        }

        private void StartNewGameForm_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterParent;

        }

        private void btnLoadGame_Click(object sender, EventArgs e)
        {
            Store store = ObjectSerialization.readFromFile();
            LemonadeBusiness newGame = new LemonadeBusiness(store);
            this.Visible = false;
            newGame.updateResurses();
            //newGame.storeName.Text = newGame.Store.NameOfStore;
            newGame.Show();
        }
    }
}
