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
    public partial class PurchaseSuccessfullyForm : Form
    {
        public PurchaseSuccessfullyForm()
        {
            InitializeComponent();

            /* Set the location of the lables. */
            blessing1_lbl.Location = new Point((ClientRectangle.Width - blessing1_lbl.Width) / 2, (ClientRectangle.Height - blessing1_lbl.Height) * 1/3);
            blessing2_lbl.Location = new Point((ClientRectangle.Width - blessing2_lbl.Width) / 2, blessing1_lbl.Bottom + (blessing2_lbl.Height / 2));
            thankYou_lbl.Location = new Point((ClientRectangle.Width - thankYou_lbl.Width) / 2, blessing2_lbl.Bottom + (thankYou_lbl.Height * 2));
        }

        /* By clicking the "thankYou" label - the "PurchaseSuccessfyllyForm"
         * form will be closed. */
        private void thankYou_lbl_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /* Hooving with the mouse pointer above "thankYou" label will change
         * his color to "LimeGreen". */
        private void thankYou_lbl_MouseHover(object sender, EventArgs e)
        {
            thankYou_lbl.ForeColor = Color.LimeGreen;
        }

        /* When the mouse pointer is not hooving above "thankYou" label - his
         * color returns to "Black". */
        private void thankYou_lbl_MouseLeave(object sender, EventArgs e)
        {
            thankYou_lbl.ForeColor = Color.Black;
        }
    }
}
