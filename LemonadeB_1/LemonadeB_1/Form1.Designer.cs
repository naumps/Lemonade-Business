namespace LemonadeB_1
{
    partial class LemonadeBusiness
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.newHumanTimer = new System.Windows.Forms.Timer(this.components);
            this.dayTimer = new System.Windows.Forms.Timer(this.components);
            this.btStartDay = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCups = new System.Windows.Forms.Label();
            this.lblIce = new System.Windows.Forms.Label();
            this.lblSugar = new System.Windows.Forms.Label();
            this.lblLemons = new System.Windows.Forms.Label();
            this.lblTotalMoney = new System.Windows.Forms.Label();
            this.pbDay = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddLemon = new System.Windows.Forms.Button();
            this.btnRemoveLemon = new System.Windows.Forms.Button();
            this.btnRemoveSugar = new System.Windows.Forms.Button();
            this.btnAddSugar = new System.Windows.Forms.Button();
            this.btnAddIce = new System.Windows.Forms.Button();
            this.btnRemoveIce = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tbLeemons = new System.Windows.Forms.TextBox();
            this.tbSugar = new System.Windows.Forms.TextBox();
            this.tbIce = new System.Windows.Forms.TextBox();
            this.nudNumberOfCups = new System.Windows.Forms.NumericUpDown();
            this.btnMakeLemonade = new System.Windows.Forms.Button();
            this.lblPercent = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfCups)).BeginInit();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 30;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // newHumanTimer
            // 
            this.newHumanTimer.Interval = 1500;
            this.newHumanTimer.Tick += new System.EventHandler(this.newNonBuyerTimer_Tick);
            // 
            // dayTimer
            // 
            this.dayTimer.Interval = 1000;
            this.dayTimer.Tick += new System.EventHandler(this.dayTimer_Tick);
            // 
            // btStartDay
            // 
            this.btStartDay.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btStartDay.Location = new System.Drawing.Point(486, 487);
            this.btStartDay.Name = "btStartDay";
            this.btStartDay.Size = new System.Drawing.Size(230, 23);
            this.btStartDay.TabIndex = 0;
            this.btStartDay.Text = "StartDay";
            this.btStartDay.UseVisualStyleBackColor = true;
            this.btStartDay.Click += new System.EventHandler(this.btStartDay_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblCups);
            this.panel1.Controls.Add(this.lblIce);
            this.panel1.Controls.Add(this.lblSugar);
            this.panel1.Controls.Add(this.lblLemons);
            this.panel1.Controls.Add(this.lblTotalMoney);
            this.panel1.Location = new System.Drawing.Point(14, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(759, 76);
            this.panel1.TabIndex = 1;
            // 
            // lblCups
            // 
            this.lblCups.AutoSize = true;
            this.lblCups.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCups.Location = new System.Drawing.Point(261, 33);
            this.lblCups.Name = "lblCups";
            this.lblCups.Size = new System.Drawing.Size(50, 20);
            this.lblCups.TabIndex = 1;
            this.lblCups.Text = "Cups:";
            // 
            // lblIce
            // 
            this.lblIce.AutoSize = true;
            this.lblIce.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblIce.Location = new System.Drawing.Point(196, 33);
            this.lblIce.Name = "lblIce";
            this.lblIce.Size = new System.Drawing.Size(35, 20);
            this.lblIce.TabIndex = 1;
            this.lblIce.Text = "Ice:";
            // 
            // lblSugar
            // 
            this.lblSugar.AutoSize = true;
            this.lblSugar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSugar.Location = new System.Drawing.Point(109, 33);
            this.lblSugar.Name = "lblSugar";
            this.lblSugar.Size = new System.Drawing.Size(56, 20);
            this.lblSugar.TabIndex = 1;
            this.lblSugar.Text = "Sugar:";
            // 
            // lblLemons
            // 
            this.lblLemons.AutoSize = true;
            this.lblLemons.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLemons.Location = new System.Drawing.Point(3, 33);
            this.lblLemons.Name = "lblLemons";
            this.lblLemons.Size = new System.Drawing.Size(70, 20);
            this.lblLemons.TabIndex = 1;
            this.lblLemons.Text = "Lemons:";
            // 
            // lblTotalMoney
            // 
            this.lblTotalMoney.AutoSize = true;
            this.lblTotalMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTotalMoney.Location = new System.Drawing.Point(640, 33);
            this.lblTotalMoney.Name = "lblTotalMoney";
            this.lblTotalMoney.Size = new System.Drawing.Size(95, 20);
            this.lblTotalMoney.TabIndex = 0;
            this.lblTotalMoney.Text = "Total Money";
            this.lblTotalMoney.TextChanged += new System.EventHandler(this.lblTotalMoney_TextChanged);
            // 
            // pbDay
            // 
            this.pbDay.Location = new System.Drawing.Point(486, 445);
            this.pbDay.Name = "pbDay";
            this.pbDay.Size = new System.Drawing.Size(230, 23);
            this.pbDay.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(17, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Recipe:";
            // 
            // btnAddLemon
            // 
            this.btnAddLemon.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddLemon.Location = new System.Drawing.Point(214, 224);
            this.btnAddLemon.Name = "btnAddLemon";
            this.btnAddLemon.Size = new System.Drawing.Size(137, 41);
            this.btnAddLemon.TabIndex = 4;
            this.btnAddLemon.Text = "+Lem";
            this.btnAddLemon.UseVisualStyleBackColor = true;
            this.btnAddLemon.Click += new System.EventHandler(this.btnAddLemon_Click);
            // 
            // btnRemoveLemon
            // 
            this.btnRemoveLemon.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRemoveLemon.Location = new System.Drawing.Point(12, 224);
            this.btnRemoveLemon.Name = "btnRemoveLemon";
            this.btnRemoveLemon.Size = new System.Drawing.Size(137, 41);
            this.btnRemoveLemon.TabIndex = 4;
            this.btnRemoveLemon.Text = "-\r\n";
            this.btnRemoveLemon.UseVisualStyleBackColor = true;
            this.btnRemoveLemon.Click += new System.EventHandler(this.btnRemoveLemon_Click);
            // 
            // btnRemoveSugar
            // 
            this.btnRemoveSugar.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRemoveSugar.Location = new System.Drawing.Point(12, 290);
            this.btnRemoveSugar.Name = "btnRemoveSugar";
            this.btnRemoveSugar.Size = new System.Drawing.Size(137, 41);
            this.btnRemoveSugar.TabIndex = 4;
            this.btnRemoveSugar.Text = "-";
            this.btnRemoveSugar.UseVisualStyleBackColor = true;
            this.btnRemoveSugar.Click += new System.EventHandler(this.btnRemoveSugar_Click);
            // 
            // btnAddSugar
            // 
            this.btnAddSugar.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddSugar.Location = new System.Drawing.Point(214, 290);
            this.btnAddSugar.Name = "btnAddSugar";
            this.btnAddSugar.Size = new System.Drawing.Size(137, 41);
            this.btnAddSugar.TabIndex = 4;
            this.btnAddSugar.Text = "+Sug";
            this.btnAddSugar.UseVisualStyleBackColor = true;
            this.btnAddSugar.Click += new System.EventHandler(this.btnAddSugar_Click);
            // 
            // btnAddIce
            // 
            this.btnAddIce.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddIce.Location = new System.Drawing.Point(214, 356);
            this.btnAddIce.Name = "btnAddIce";
            this.btnAddIce.Size = new System.Drawing.Size(137, 41);
            this.btnAddIce.TabIndex = 4;
            this.btnAddIce.Text = "+Ice";
            this.btnAddIce.UseVisualStyleBackColor = true;
            this.btnAddIce.Click += new System.EventHandler(this.btnAddIce_Click);
            // 
            // btnRemoveIce
            // 
            this.btnRemoveIce.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRemoveIce.Location = new System.Drawing.Point(12, 356);
            this.btnRemoveIce.Name = "btnRemoveIce";
            this.btnRemoveIce.Size = new System.Drawing.Size(137, 41);
            this.btnRemoveIce.TabIndex = 4;
            this.btnRemoveIce.Text = "-";
            this.btnRemoveIce.UseVisualStyleBackColor = true;
            this.btnRemoveIce.Click += new System.EventHandler(this.btnRemoveIce_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(14, 141);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(339, 77);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "Tweak your perfect prescription. Once you buy all the ingredients, choose in how " +
    "many cups will you mix the lemonade ...";
            // 
            // tbLeemons
            // 
            this.tbLeemons.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbLeemons.Location = new System.Drawing.Point(156, 224);
            this.tbLeemons.Multiline = true;
            this.tbLeemons.Name = "tbLeemons";
            this.tbLeemons.ReadOnly = true;
            this.tbLeemons.Size = new System.Drawing.Size(52, 41);
            this.tbLeemons.TabIndex = 6;
            this.tbLeemons.Text = "0";
            this.tbLeemons.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbSugar
            // 
            this.tbSugar.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbSugar.Location = new System.Drawing.Point(156, 290);
            this.tbSugar.Multiline = true;
            this.tbSugar.Name = "tbSugar";
            this.tbSugar.ReadOnly = true;
            this.tbSugar.Size = new System.Drawing.Size(52, 41);
            this.tbSugar.TabIndex = 6;
            this.tbSugar.Text = "0";
            this.tbSugar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbIce
            // 
            this.tbIce.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbIce.Location = new System.Drawing.Point(156, 356);
            this.tbIce.Multiline = true;
            this.tbIce.Name = "tbIce";
            this.tbIce.ReadOnly = true;
            this.tbIce.Size = new System.Drawing.Size(52, 41);
            this.tbIce.TabIndex = 6;
            this.tbIce.Text = "0";
            this.tbIce.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nudNumberOfCups
            // 
            this.nudNumberOfCups.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nudNumberOfCups.Location = new System.Drawing.Point(14, 416);
            this.nudNumberOfCups.Name = "nudNumberOfCups";
            this.nudNumberOfCups.Size = new System.Drawing.Size(135, 38);
            this.nudNumberOfCups.TabIndex = 7;
            this.nudNumberOfCups.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudNumberOfCups.ValueChanged += new System.EventHandler(this.nudNumberOfCups_ValueChanged);
            // 
            // btnMakeLemonade
            // 
            this.btnMakeLemonade.Enabled = false;
            this.btnMakeLemonade.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnMakeLemonade.Location = new System.Drawing.Point(156, 403);
            this.btnMakeLemonade.Name = "btnMakeLemonade";
            this.btnMakeLemonade.Size = new System.Drawing.Size(197, 51);
            this.btnMakeLemonade.TabIndex = 8;
            this.btnMakeLemonade.Text = "Make Lemonade";
            this.btnMakeLemonade.UseVisualStyleBackColor = true;
            this.btnMakeLemonade.Click += new System.EventHandler(this.btnMakeLemonade_Click);
            // 
            // lblPercent
            // 
            this.lblPercent.AutoSize = true;
            this.lblPercent.Location = new System.Drawing.Point(18, 497);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(35, 13);
            this.lblPercent.TabIndex = 9;
            this.lblPercent.Text = "label2";
            // 
            // LemonadeBusiness
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.lblPercent);
            this.Controls.Add(this.btnMakeLemonade);
            this.Controls.Add(this.nudNumberOfCups);
            this.Controls.Add(this.tbIce);
            this.Controls.Add(this.tbSugar);
            this.Controls.Add(this.tbLeemons);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnRemoveIce);
            this.Controls.Add(this.btnRemoveSugar);
            this.Controls.Add(this.btnRemoveLemon);
            this.Controls.Add(this.btnAddIce);
            this.Controls.Add(this.btnAddSugar);
            this.Controls.Add(this.btnAddLemon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbDay);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btStartDay);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "LemonadeBusiness";
            this.Text = "Lemonade Business";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfCups)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Timer newHumanTimer;
        private System.Windows.Forms.Timer dayTimer;
        private System.Windows.Forms.Button btStartDay;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTotalMoney;
        private System.Windows.Forms.Label lblCups;
        private System.Windows.Forms.Label lblIce;
        private System.Windows.Forms.Label lblSugar;
        private System.Windows.Forms.Label lblLemons;
        private System.Windows.Forms.ProgressBar pbDay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddLemon;
        private System.Windows.Forms.Button btnRemoveLemon;
        private System.Windows.Forms.Button btnRemoveSugar;
        private System.Windows.Forms.Button btnAddSugar;
        private System.Windows.Forms.Button btnAddIce;
        private System.Windows.Forms.Button btnRemoveIce;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox tbLeemons;
        private System.Windows.Forms.TextBox tbSugar;
        private System.Windows.Forms.TextBox tbIce;
        private System.Windows.Forms.NumericUpDown nudNumberOfCups;
        private System.Windows.Forms.Button btnMakeLemonade;
        private System.Windows.Forms.Label lblPercent;
    }
}

