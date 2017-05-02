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
            
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            LemonadeBusiness newGame = new LemonadeBusiness();
          //  this.Hide();
            newGame.Show();

        }
    }
}
