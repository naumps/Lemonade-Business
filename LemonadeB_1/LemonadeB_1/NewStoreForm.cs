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
    public partial class NewStoreForm : Form
    {

        public Store  Store { get; set; }

        public NewStoreForm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            
            Store = new Store(tbName.Text);
            DialogResult = DialogResult.OK;
        }

        private void tbName_Validating(object sender, CancelEventArgs e)
        {
            if(tbName.Text.Trim().Length == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(tbName, "Please type name!");
            }else
            {
                errorProvider1.SetError(tbName, null);
            }
        }

        
    }
}
