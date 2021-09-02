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
    public partial class LowScoreForm : Form
    {
        public LowScoreForm()
        {
            InitializeComponent();

            /* Set the location of the lables. */
            yourScoreisLow_lbl.Location = new Point((ClientRectangle.Width - yourScoreisLow_lbl.Width) / 2, (ClientRectangle.Height - yourScoreisLow_lbl.Height) * 1/3);
            yourScoreisLow2_lbl.Location = new Point((ClientRectangle.Width - yourScoreisLow2_lbl.Width) / 2, yourScoreisLow_lbl.Bottom + (yourScoreisLow2_lbl.Height / 2));
            iUnderstand_lbl.Location = new Point((ClientRectangle.Width - iUnderstand_lbl.Width) / 2, yourScoreisLow2_lbl.Bottom + (iUnderstand_lbl.Height * 2));
        }

        /* By clicking the "iUnderstand" label - the "LowScoreForm" form will
         * be closed. */
        private void iUnderstand_lbl_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /* Hooving with the mouse pointer above "iUnderstand" label will
         * change his color to "LimeGreen". */
        private void iUnderstand_lbl_MouseHover(object sender, EventArgs e)
        {
            iUnderstand_lbl.ForeColor = Color.LimeGreen;
        }

        /* When the mouse pointer is not hooving above "iUnderstand" label
         * - his color returns to "Black". */
        private void iUnderstand_lbl_MouseLeave(object sender, EventArgs e)
        {
            iUnderstand_lbl.ForeColor = Color.Black;
        }
    }
}
