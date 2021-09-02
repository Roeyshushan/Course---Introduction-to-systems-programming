using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JumpFF
{
    public partial class GuideForm : Form
    {
        public GuideForm()
        {
            InitializeComponent();

            this.Bounds = Screen.PrimaryScreen.Bounds; // Set the screen size to full screen in every computer that runs this program.

            /* Set the location of the lables. */
            guidness_lbl.Location = new Point((ClientRectangle.Width - guidness_lbl.Width) / 2, (ClientRectangle.Height - guidness_lbl.Height) / 2);
            howToPlay_lbl.Location = new Point((ClientRectangle.Width - howToPlay_lbl.Width) / 2, guidness_lbl.Top - (howToPlay_lbl.Height * 2));
            return_lbl.Location = new Point((ClientRectangle.X + return_lbl.Width) / 4, (ClientRectangle.Height) - 80); 
        }

        /* Hooving with the mouse pointer above "return" label will change his
         * color to "LimeGreen". */
        private void return_lbl_MouseHover(object sender, EventArgs e)
        {
            return_lbl.ForeColor = Color.LimeGreen;
        }

        /* When the mouse pointer is not hooving above "return" label - his
         * color returns to "Black". */
        private void return_lbl_MouseLeave(object sender, EventArgs e)
        {
            return_lbl.ForeColor = Color.Black;
        }

        /* By clicking the "return" label - the current form will be closed and
         * the user will be directed to the previous form. */
        private void return_lbl_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
