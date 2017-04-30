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
            this.btStartDay = new System.Windows.Forms.Button();
            this.dayTimer = new System.Windows.Forms.Timer(this.components);
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
            // btStartDay
            // 
            this.btStartDay.Location = new System.Drawing.Point(477, 66);
            this.btStartDay.Name = "btStartDay";
            this.btStartDay.Size = new System.Drawing.Size(75, 23);
            this.btStartDay.TabIndex = 0;
            this.btStartDay.Text = "StartDay";
            this.btStartDay.UseVisualStyleBackColor = true;
            this.btStartDay.Click += new System.EventHandler(this.btStartDay_Click);
            // 
            // dayTimer
            // 
            this.dayTimer.Interval = 1000;
            this.dayTimer.Tick += new System.EventHandler(this.dayTimer_Tick);
            // 
            // LemonadeBusiness
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.btStartDay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "LemonadeBusiness";
            this.Text = "LemonadeBusiness";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Timer newHumanTimer;
        private System.Windows.Forms.Button btStartDay;
        private System.Windows.Forms.Timer dayTimer;
    }
}

