using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Brutus
{
    public partial class EnterForm : Form
    {
        public EnterForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        Point lastP;
    
        private void panel6_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastP.X;
                this.Top += e.Y - lastP.Y;
            }
        }

        private void panel6_MouseDown_1(object sender, MouseEventArgs e)
        {
            lastP = new Point(e.X, e.Y);
        }

   
    }
}
