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
    public partial class PlayLevelForm : Form
    {
        internal static Bitmap background; // Declaration of a field type "Bitmap" that will help us change the "PlayForm" background easely.
        public PlayLevelForm()
        {
            InitializeComponent();

            this.Bounds = Screen.PrimaryScreen.Bounds; // Set the screen size to full screen in every computer that runs this program.

            /* Set the levels labels location. */
            Level2_lbl.Location = new Point((ClientRectangle.Width - Level2_lbl.Width )/ 2, (ClientRectangle.Height) * 1 / 2);
            Level1_lbl.Location = new Point(Level2_lbl.Location.X - (Level1_lbl.Width * 2), Level2_lbl.Location.Y);
            Level3_lbl.Location = new Point(Level2_lbl.Location.X + (Level3_lbl.Width * 2), Level2_lbl.Location.Y);

            return_lbl.Location = new Point((ClientRectangle.X + return_lbl.Width) / 4, (ClientRectangle.Height) - 80); // Sets the location of the label "return".
        }

        /* Hooving with the mouse pointer above "Level1" label will change
         * his color to "LimeGreen". */
        private void Level1_lbl_MouseHover(object sender, EventArgs e)
        {
            Level1_lbl.ForeColor = Color.LimeGreen;
        }

        /* When the mouse pointer is not hooving above "Level1" label - his
         * color returns to "Black". */
        private void Level1_lbl_MouseLeave(object sender, EventArgs e)
        {
            Level1_lbl.ForeColor = Color.Black;
        }

        /* Hooving with the mouse pointer above "Level2" label will change
         * his color to "LimeGreen". */
        private void Level2_lbl_MouseHover(object sender, EventArgs e)
        {
            Level2_lbl.ForeColor = Color.LimeGreen;
        }

        /* When the mouse pointer is not hooving above "Level2" label - his
         * color returns to "Black". */
        private void Level2_lbl_MouseLeave(object sender, EventArgs e)
        {
            Level2_lbl.ForeColor = Color.Black;
        }

        /* Hooving with the mouse pointer above "Level3" label will change
         * his color to "LimeGreen". */
        private void Level3_lbl_MouseHover(object sender, EventArgs e)
        {
            Level3_lbl.ForeColor = Color.LimeGreen;
        }

        /* When the mouse pointer is not hooving above "Level3" label - his
         * color returns to "Black". */
        private void Level3_lbl_MouseLeave(object sender, EventArgs e)
        {
            Level3_lbl.ForeColor = Color.Black;
        }

        /* Hooving with the mouse pointer above "return" label will change
         * his color to "LimeGreen".*/
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

        /* By clicking the "return" label - the current form will closed and
         * the user will be directed to the previous form. */
        private void return_lbl_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /* By clicking the "level1" label - "chosenLevel" will be changed to 1,
         * the background of the level will set and the level will start.*/
        private void Level1_lbl_Click(object sender, EventArgs e)
        {
            DefineLevel(1);
            StartLevel(1);
        }

        /* By clicking the "level2" label - "chosenLevel" will be changed to 2,
         * the background of the level will set and the level will start.*/
        private void Level2_lbl_Click(object sender, EventArgs e)
        {
            DefineLevel(2);
            StartLevel(2);
        }

        /* By clicking the "level3" label - "chosenLevel" will be changed to 3,
         * the background of the level will set and the level will start.*/
        private void Level3_lbl_Click(object sender, EventArgs e)
        {
            DefineLevel(3);
            StartLevel(3);
        }

        /* Method that set the values of "chosenLevel" and "background" based
         * on the number of level that sent to it.*/
        private void DefineLevel(int level)
        {
            switch (level)
            {
                case 1:
                    PlayForm.chosenLevel = 1;
                    background = Properties.Resources.Level1_Background;
                    break;
                case 2:
                    PlayForm.chosenLevel = 2;
                    background = Properties.Resources.Level2_Background;
                    break;
                case 3:
                    PlayForm.chosenLevel = 3;
                    background = Properties.Resources.Level3_Background;
                    break;
            }
        }

        /* Method that creates a new instance of "PlayForm" form, initielized
         * the instance background and runs the form.*/
        internal static void StartLevel(int level)
        {
            Form PlayForm = new PlayForm();
            PlayForm.BackgroundImage = background;
            PlayForm.ShowDialog();
        }
    }
}
