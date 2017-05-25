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
    public partial class HowToPlayForm : Form
    {
        public HowToPlayForm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
