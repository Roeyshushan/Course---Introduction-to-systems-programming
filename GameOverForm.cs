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
    public partial class GameOverForm : Form
    {
        public GameOverForm()
        {
            InitializeComponent();

            gameOverScore_lbl.Text = "Score: " + PlayForm.score; // Set the text of "gameOverScore" label to show the player the score he achieved.
            highestScoreEver_lbl.Text = "Best: " + PlayForm.newHighScore; // Set the text of "highestScoreEver" label to show the player the best score ever achieved in the game.

            /* Set the location of the lables. */
            gameOver_lbl.Location = new Point((ClientRectangle.Width - gameOver_lbl.Width) / 2, (ClientRectangle.Height * 1/9));
            gameOverScore_lbl.Location = new Point((((ClientRectangle.Width - gameOverScore_lbl.Width) /2) - gameOverScore_lbl.Width), ClientRectangle.Height * 4/9 );
            highestScoreEver_lbl.Location = new Point((((ClientRectangle.Width - highestScoreEver_lbl.Width) / 2) + highestScoreEver_lbl.Width), ClientRectangle.Height * 4 / 9);
            goToStore_lbl.Location = new Point((ClientRectangle.Width - goToStore_lbl.Width) / 2, (ClientRectangle.Height * 6 / 9));
            playAgain_lbl.Location = new Point((ClientRectangle.Width - playAgain_lbl.Width) / 2, (ClientRectangle.Height * 7 / 9));
            return_lbl.Location = new Point((ClientRectangle.Width - return_lbl.Width) / 2, (ClientRectangle.Height * 8 / 9));
        }

        /* By clicking the "return" label - the current form will be hiden, 
         * the user will be directed to the previous form and the 
         * "PlayForm" will be closed. */
        private void return_lbl_Click(object sender, EventArgs e)
        {
            this.Hide();
            ClosePlayForm();
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

        /* By clicking the "goToStore" label - "GameOverForm" form will be
         * hiden, the "PlayForm" will be cloased, the user will be directed
         * to the "StoreForm" and the "GameOverForm" will be closed. */
        private void goToStore_lbl_Click(object sender, EventArgs e)
        {
            this.Hide();
            ClosePlayForm();
            Form StoreForm = new StoreForm();
            StoreForm.ShowDialog();
            this.Close();
        }

        /* Hooving with the mouse pointer above "goToStore" label will change
         * his color to "LimeGreen". */
        private void goToStore_lbl_MouseHover(object sender, EventArgs e)
        {
            goToStore_lbl.ForeColor = Color.LimeGreen;
        }

        /* When the mouse pointer is not hooving above "goToStore" label - his
         * color returns to "Black". */
        private void goToStore_lbl_MouseLeave(object sender, EventArgs e)
        {
            goToStore_lbl.ForeColor = Color.Black;
        }

        /* Method used to indicate that "PlayForm" form need to be close. */
        private void ClosePlayForm()
        {
            PlayForm.PlayFormClose = true;
        }

        /* By clicking the "playAgain" label the "GameOverForm" form will be 
         * hiden, the "PlayForm" will be cloased and the user will be
         * directed to a new game at the same level he played before he was
         * disqualified. */
        private void playAgain_lbl_Click(object sender, EventArgs e)
        {
            this.Hide();
            ClosePlayForm();

            switch (PlayForm.chosenLevel)
            {
                case 1:
                    PlayLevelForm.StartLevel(1);
                    break;
                case 2:
                    ClosePlayForm();
                    PlayLevelForm.StartLevel(2);
                    break;
                case 3:
                    ClosePlayForm();
                    PlayLevelForm.StartLevel(3);
                    break;
            }
        }

        /* Hooving with the mouse pointer above "playAgain" label will change
         * his color to "LimeGreen". */
        private void playAgain_lbl_MouseHover(object sender, EventArgs e)
        {
            playAgain_lbl.ForeColor = Color.LimeGreen;
        }

        /* When the mouse pointer is not hooving above "playAgain" label - his
         * color returns to "Black". */
        private void playAgain_lbl_MouseLeave(object sender, EventArgs e)
        {
            playAgain_lbl.ForeColor = Color.Black;
        }
    }
}
