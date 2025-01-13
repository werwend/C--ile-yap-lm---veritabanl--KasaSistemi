using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KasaSistemi
{
    public partial class FrmAlertBox : Form
    {
        public FrmAlertBox()
        {
            InitializeComponent();
            timerAnimasion.Start();
        }


        public Color BackColorAlertBox
        {
            get { return this.BackColor; }
            set { this.BackColor = value; }
        }

        public Color ColorAlertBox
        {
            get { return LinAlertBox.BackColor; }
            set { LinAlertBox.BackColor = LblTitleAlertBox.ForeColor = LblTextAlertBox.ForeColor = value; }
        }

        public Image IconeAlertBox
        {
            get { return PicAlertBox.Image; }
            set { PicAlertBox.Image  = value; }
        }

        public string TitleAlertBox
        {
            get { return LblTitleAlertBox.Text; }
            set { LblTitleAlertBox.Text = value; }
        }

        public string TextAlertBox
        {
            get { return LblTextAlertBox.Text; }
            set { LblTextAlertBox.Text = value; }
        }

        private void PositionAlertBox()
        {
            
        }

        private void timerAnimasion_Tick(object sender, EventArgs e)
        {
            LinAlertBox.Width += 2; 
            if (LinAlertBox.Width >= 521) 
            {
                timerAnimasion.Stop(); 
                this.Close(); 
            }
        }

        private void FrmAlertBox_Load(object sender, EventArgs e)
        {
            
        }

        
    }
}
