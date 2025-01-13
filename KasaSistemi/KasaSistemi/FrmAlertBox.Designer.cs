namespace KasaSistemi
{
    partial class FrmAlertBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAlertBox));
            this.PicAlertBox = new System.Windows.Forms.PictureBox();
            this.LblTitleAlertBox = new System.Windows.Forms.Label();
            this.LblTextAlertBox = new System.Windows.Forms.Label();
            this.LinAlertBox = new System.Windows.Forms.Panel();
            this.ellipse = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.timerAnimasion = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PicAlertBox)).BeginInit();
            this.SuspendLayout();
            // 
            // PicAlertBox
            // 
            this.PicAlertBox.Location = new System.Drawing.Point(33, 14);
            this.PicAlertBox.Name = "PicAlertBox";
            this.PicAlertBox.Size = new System.Drawing.Size(50, 50);
            this.PicAlertBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicAlertBox.TabIndex = 0;
            this.PicAlertBox.TabStop = false;
            // 
            // LblTitleAlertBox
            // 
            this.LblTitleAlertBox.AutoSize = true;
            this.LblTitleAlertBox.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblTitleAlertBox.Location = new System.Drawing.Point(90, 15);
            this.LblTitleAlertBox.Name = "LblTitleAlertBox";
            this.LblTitleAlertBox.Size = new System.Drawing.Size(134, 25);
            this.LblTitleAlertBox.TabIndex = 1;
            this.LblTitleAlertBox.Text = "TitleAlertBox";
            // 
            // LblTextAlertBox
            // 
            this.LblTextAlertBox.AutoSize = true;
            this.LblTextAlertBox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblTextAlertBox.Location = new System.Drawing.Point(92, 40);
            this.LblTextAlertBox.Name = "LblTextAlertBox";
            this.LblTextAlertBox.Size = new System.Drawing.Size(108, 21);
            this.LblTextAlertBox.TabIndex = 2;
            this.LblTextAlertBox.Text = "TextAlertBox";
            // 
            // LinAlertBox
            // 
            this.LinAlertBox.BackColor = System.Drawing.Color.Black;
            this.LinAlertBox.Location = new System.Drawing.Point(1, 73);
            this.LinAlertBox.Name = "LinAlertBox";
            this.LinAlertBox.Size = new System.Drawing.Size(0, 6);
            this.LinAlertBox.TabIndex = 3;
            // 
            // ellipse
            // 
            this.ellipse.BorderRadius = 15;
            this.ellipse.TargetControl = this;
            // 
            // timerAnimasion
            // 
            this.timerAnimasion.Interval = 5;
            this.timerAnimasion.Tick += new System.EventHandler(this.timerAnimasion_Tick);
            // 
            // FrmAlertBox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(521, 80);
            this.Controls.Add(this.LinAlertBox);
            this.Controls.Add(this.LblTextAlertBox);
            this.Controls.Add(this.LblTitleAlertBox);
            this.Controls.Add(this.PicAlertBox);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(843, 648);
            this.Name = "FrmAlertBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FrmAlertBox";
            ((System.ComponentModel.ISupportInitialize)(this.PicAlertBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PicAlertBox;
        private System.Windows.Forms.Label LblTitleAlertBox;
        private System.Windows.Forms.Label LblTextAlertBox;
        private System.Windows.Forms.Panel LinAlertBox;
        private Guna.UI2.WinForms.Guna2Elipse ellipse;
        private System.Windows.Forms.Timer timerAnimasion;
    }
}