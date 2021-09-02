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
    public partial class StoreForm : Form
    {
        internal static int score;
        internal static bool bird1_Purchared;
        internal static bool bird2_Purchared;
        internal static bool bird3_Purchared;
        public StoreForm()
        {
            InitializeComponent();

            this.Bounds = Screen.PrimaryScreen.Bounds; // Set the screen size to full screen in every computer that runs this program.

            yourCurrentScoreis_lbl.Text = "Your current score is: " + score; // Set the text of "YourCurrentScoreis" label to show the player the score he achieved.

            /* Set the text of the labels that gives the user indication about how much score each character requires. */
            scoreNeededForFirst.Text = "Score needed: 100";
            scoreNeededForSecond.Text = "Score needed: 200";
            scoreNeededForThird.Text = "Score needed: 300";

            /* Set the location of the title and score labels. */
            chooseYourFavoriteCharacter_lbl.Location = new Point((ClientRectangle.Width - chooseYourFavoriteCharacter_lbl.Width) / 2, (ClientRectangle.Height) * 1 / 6);
            yourCurrentScoreis_lbl.Location = new Point((ClientRectangle.Width - yourCurrentScoreis_lbl.Width) / 2, (ClientRectangle.Height) * 2 / 6);

            /* Set the location of the characters picture boxes. */
            secondOptionToBuy_pb.Location = new Point((ClientRectangle.Width - secondOptionToBuy_pb.Width) / 2, (ClientRectangle.Height) * 3 / 6);
            firstOptionToBuy_pb.Location = new Point(secondOptionToBuy_pb.Location.X - (firstOptionToBuy_pb.Width) * 3, (ClientRectangle.Height) * 3 / 6);
            thirdOptionToBuy_pb.Location = new Point(secondOptionToBuy_pb.Location.X + (thirdOptionToBuy_pb.Width) * 3, (ClientRectangle.Height) * 3 / 6);

            /* Set the location of the labels that gives the user indication about how much score each character requires. */
            scoreNeededForFirst.Location = new Point(firstOptionToBuy_pb.Location.X - scoreNeededForFirst.Width / 5, firstOptionToBuy_pb.Location.Y + (scoreNeededForFirst.Height * 5));
            scoreNeededForSecond.Location = new Point(secondOptionToBuy_pb.Location.X - scoreNeededForSecond.Width / 5, firstOptionToBuy_pb.Location.Y + (scoreNeededForSecond.Height * 5));
            scoreNeededForThird.Location = new Point(thirdOptionToBuy_pb.Location.X - scoreNeededForThird.Width / 5, firstOptionToBuy_pb.Location.Y + (scoreNeededForThird.Height * 5));

            return_lbl.Location = new Point((ClientRectangle.X + return_lbl.Width) / 4, (ClientRectangle.Height) - 80); // Sets the location of the label "return".

            /* Condition statement to check if the user achieve enough points and
             * changes the indications label color accordingly.*/
            if (score < 100)
            {
                scoreNeededForFirst.ForeColor = Color.DarkRed;
                scoreNeededForSecond.ForeColor = Color.DarkRed;
                scoreNeededForThird.ForeColor = Color.DarkRed;
            }
            if(score >= 100 && score < 200)
            {
                scoreNeededForFirst.ForeColor = Color.DarkGreen;
                scoreNeededForSecond.ForeColor = Color.DarkRed;
                scoreNeededForThird.ForeColor = Color.DarkRed;
            }
            if(score >= 200 &&score < 300)
            {
                scoreNeededForFirst.ForeColor = Color.DarkGreen;
                scoreNeededForSecond.ForeColor = Color.DarkGreen;
                scoreNeededForThird.ForeColor = Color.DarkRed;
            }
            else if(score >= 300)
            {
                scoreNeededForFirst.ForeColor = Color.DarkGreen;
                scoreNeededForSecond.ForeColor = Color.DarkGreen;
                scoreNeededForThird.ForeColor = Color.DarkGreen;
            }
        }

        /* Hooving with the mouse pointer above "return" label will change his
         * color to "LimeGreen".*/
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

        /* By clicking the "return" label - the current form will close and
         * the user will be directed to the previous form. */
        private void return_lbl_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /* By clicking the "firstOptionToBut" picture box it will be checked
         * if the user achieve enough points to purchase this item, in case
         * he did not achieve enough - "LowScoreForm" form will be shown,
         * in case he achieve enough - "PurchaseSuccessfullyForm" will be shown
         * and his character will be changed. */
        private void firstOptionToBuy_pb_Click(object sender, EventArgs e)
        {
            if (StoreForm.score < 100&& !bird1_Purchared)
            {
                NeedHigherScore();
            }
            else if (!bird1_Purchared)
            {
                    Congratulation();
                    score -= 100;
                    yourCurrentScoreis_lbl.Text = "Your current score is: " + score;
                    bird1_Purchared = true;
                    PlayForm.chosenCharacter = 1;
            }
            if(bird1_Purchared)
            {
                PlayForm.chosenCharacter = 1;
            }
        }

        /* By clicking the "secondOptionToBut" picture box it will be checked
         * if the user achieve enough points to purchase this item, in case
         * he did not achieve enough - "LowScoreForm" form will be shown,
         * in case he achieve enough - "PurchaseSuccessfullyForm" will be shown
         * and his character will be changed. */
        private void secondOptionToBuy_pb_Click(object sender, EventArgs e)
        {
            if (StoreForm.score<200&& !bird2_Purchared)
            {
                NeedHigherScore();
            }
            else if (!bird2_Purchared)
            {
                Congratulation();
                score -= 200;
                yourCurrentScoreis_lbl.Text = "Your current score is: " + score;
                bird2_Purchared = true;
                PlayForm.chosenCharacter = 2;
            }
            if(bird2_Purchared)
            {
                PlayForm.chosenCharacter = 2;
            }
        }

        /* By clicking the "thirdOptionToBut" picture box it will be checked
         * if the user achieve enough points to purchase this item, in case
         * he did not achieve enough - "LowScoreForm" form will be shown,
         * in case he achieve enough - "PurchaseSuccessfullyForm" will be shown
         * and his character will be changed. */
        private void thirdOptionToBuy_pb_Click(object sender, EventArgs e)
        {
            if (StoreForm.score<300 && !bird3_Purchared)
            {
                NeedHigherScore();
            }
            else  if(!bird3_Purchared)
            {
                Congratulation();
                score -= 300;
                yourCurrentScoreis_lbl.Text = "Your current score is: " + score;
                bird3_Purchared = true;
                PlayForm.chosenCharacter = 3;
            }
            if(bird3_Purchared)
            {
                PlayForm.chosenCharacter = 3;
            }
        }

        /* Method to creat a new instance of "LowScoreForm" and open it. */
        private void NeedHigherScore()
        {
            Form LowScoreForm = new LowScoreForm();
            LowScoreForm.Show();
        }

        /* Method to creat a new instance of "PurchaseSuccessfully" and 
         * open it. */
        private void Congratulation()
        {
            Form PurchaseSuccessfullyForm = new PurchaseSuccessfullyForm();
            PurchaseSuccessfullyForm.Show();
        }
    }
}
