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
    public partial class AboutUsForm : Form
    {
        public AboutUsForm()
        {
            InitializeComponent();

            this.Bounds = Screen.PrimaryScreen.Bounds; // Set the screen size to full screen in every computer that runs this program.

            /* Set the location of the about us information lables and picture box. */
            tetaLogo.Location = new Point((ClientRectangle.Width - tetaLogo.Width) / 2, (ClientRectangle.Height - tetaLogo.Height) / 2);
            developedBy_lbl.Location = new Point((ClientRectangle.Width - developedBy_lbl.Width)  / 2, tetaLogo.Top - (developedBy_lbl.Height * 2));
            supervisedBy_lbl.Location = new Point((ClientRectangle.Width - supervisedBy_lbl.Width) / 2, tetaLogo.Bottom + supervisedBy_lbl.Height);

            return_lbl.Location = new Point((ClientRectangle.X + return_lbl.Width) / 4, (ClientRectangle.Height) - 80); // Sets the location of the label "return".
        }

        /* Hooving with the mouse pointer above "return" label will change
         * his color to "LimeGreen". */
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
