using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace JumpFF
{
    public partial class PlayForm : Form
    {
        internal static int score; // Field that holds the score of the specific level
        internal static int chosenLevel; // Field that indicates the level that the user chose to play.
        internal static int chosenCharacter = 0; // Field that indicates the character the user bought and about to play with.
        internal static bool keyboard = true; // Boolean field to decide if the character control button is "space".
        internal static bool mouse = false; // Boolean field to decide if the character control button is "mouse".
        internal static bool PlayFormClose = false; // Boolean field that will be changed if the form needs to be closed.

        private int gravity = 20; // Field that indicates the speed of the character gravity.
        private int obstacleSpeed = 25; // Field that indicates the speed of the moving obstacles.

        internal List<PictureBox> top_obstacle_pb_list; // Declaring of a List Type "Picture Box" that will keep the top screen obstacles picture boxes.
        internal List<PictureBox> buttom_obstacle_pb_list; // Declaring of a List Type "Picture Box" that will keep the buttom screen obstacles picture boxes.
        internal List<Bitmap> top_obstacle_img_list; // Declaring of a List Type "Bitmap" that will keep the top screen obstacles image.
        internal List<Bitmap> buttom_obstacle_img_list; // Declaring of a List Type "Bitmap" that will keep the buttom screen obstacles image.

        internal static string highestScoreTxt = "highestScore.txt"; // Field that holds the name of the TXT file which contains the best score ever reached in the game.
        internal static int newHighScore; // Field that holds the score that the highestScore.txt file contains.

        public PlayForm()
        {
            InitializeComponent();

            /* Initielizing the obstacle picture boxes lists. */
            top_obstacle_pb_list = new List<PictureBox> {topObstacle1_pb, topObstacle2_pb, topObstacle3_pb };
            buttom_obstacle_pb_list = new List<PictureBox> {buttomObstacle1_pb, buttomObstacle2_pb, buttomObstacle3_pb };

            /* Initielizing the obstacle images lists. */
            top_obstacle_img_list = new List<Bitmap> {Properties.Resources.topObstacel1,
                                                      Properties.Resources.topObstacel2,
                                                      Properties.Resources.topObstacel3};
            buttom_obstacle_img_list = new List<Bitmap> {Properties.Resources.buttomObstacel1,
                                                         Properties.Resources.buttomObstacel2,
                                                         Properties.Resources.buttomObstacel3};

            this.Bounds = Screen.PrimaryScreen.Bounds; // Set the screen size to full screen in every computer that runs this program.

            this.BackgroundImageLayout = ImageLayout.Stretch; // Set the form background image layout to be stretched.

            /* Method that set the values of the top and buttom obstacles
             * (their images), set the image layout on the picture boxes and
             * determine wheter the user buoght a character and set the game
             * character according to that exemine.*/
            switch (chosenLevel)
            {
                case 1:
                    if (chosenCharacter != 0)
                    {
                        BoughtCharacter(chosenCharacter);
                    }
                    else
                    {
                        bird_pb.Image = Properties.Resources.Bird1;
                    }
                    SetObstacleBackgroundImage(1);
                    SetObstacleBackgroundImageLayout(1);
                    break;
                case 2:
                    if (chosenCharacter != 0)
                    {
                        BoughtCharacter(chosenCharacter);
                    }
                    else
                    {
                        bird_pb.Image = Properties.Resources.Bird2;
                    }
                    SetObstacleBackgroundImage(2);
                    SetObstacleBackgroundImageLayout(2);
                    break;
                case 3:
                    if (chosenCharacter != 0)
                    {
                        BoughtCharacter(chosenCharacter);
                    }
                    else
                    {
                        bird_pb.Image = Properties.Resources.Bird3;
                    }
                    SetObstacleBackgroundImage(3);
                    SetObstacleBackgroundImageLayout(3);
                    break;
            }

            score_lbl.Text = "Score: " + score; // Set the text of "score" label along with the value of "score" integer.

            bird_pb.Location = new Point(ClientRectangle.Width / 7, (ClientRectangle.Height) * 2 / 3); // Set the character picture box (bird_pb) location.
            buttom_ground_pb.Location = new Point(buttomObstacle1_pb.Width, ClientRectangle.Bottom); // Set the gournd limit picture box (buttom_ground_pb) location.

            /* Set the size of the top obstacles picture boxes. */
            topObstacle1_pb.Size = new Size(120, (ClientRectangle.Height / 2));
            topObstacle2_pb.Size = new Size(120, (ClientRectangle.Height / 3));
            topObstacle3_pb.Size = new Size(120, (ClientRectangle.Height / 4));

            /* Set the size of the buttom obstacles picture boxes. */
            buttomObstacle1_pb.Size = new Size(120, (ClientRectangle.Height / 6));
            buttomObstacle2_pb.Size = new Size(120, (ClientRectangle.Height / 4));
            buttomObstacle3_pb.Size = new Size(120, (ClientRectangle.Height / 2));
            
            /* Set the location of the top obstacles picture boxes. */
            topObstacle1_pb.Location = new Point(ClientRectangle.Width / 3);
            topObstacle2_pb.Location = new Point(ClientRectangle.Width / 2);
            topObstacle3_pb.Location = new Point(ClientRectangle.Width * 2);

            /* Set the location of the buttom obstacles picture boxes. */
            buttomObstacle1_pb.Location = new Point(topObstacle1_pb.Location.X , buttom_ground_pb.Location.Y - buttomObstacle1_pb.Height);
            buttomObstacle2_pb.Location = new Point(topObstacle2_pb.Location.X + buttomObstacle2_pb.Width, buttom_ground_pb.Location.Y - buttomObstacle2_pb.Height);
            buttomObstacle3_pb.Location = new Point(topObstacle3_pb.Location.X + buttomObstacle3_pb.Width, buttom_ground_pb.Location.Y - buttomObstacle3_pb.Height);
            this.StartLabel.Location = new Point(ClientRectangle.Width/2-StartLabel.Width/2, ClientRectangle.Height / 2 - StartLabel.Height / 2);
            score = 0; // Set the "score" to zero the first time the game starts.
        }

        /* Each tick of the timer; the "score" value will gain 1 point,
         the "score" label text will be updated simultaneously, the character
         picture box will reflect by the gravity, the obstacles left point
         will decrease, there will be an examination if the character picture
         box interact with the obstacles nor the ground and the the obstacles
         picture boxes will react to the changes in their bounds.*/
        private void playTimer_Tick(object sender, EventArgs e)
        {
            score += 1;
            bird_pb.Top += gravity;
            score_lbl.Text = "Score: " + score;
      
            foreach (PictureBox buttom in buttom_obstacle_pb_list)
            {
                buttom.Left -= obstacleSpeed;
            }

            foreach (PictureBox top in top_obstacle_pb_list)
            {
                top.Left -= obstacleSpeed;
            }

            for (int i = 0; i < 3; i++)
            {
                if (bird_pb.Bounds.IntersectsWith(top_obstacle_pb_list[i].Bounds) ||
                    bird_pb.Bounds.IntersectsWith(buttom_obstacle_pb_list[i].Bounds) ||
                    bird_pb.Bounds.IntersectsWith(buttom_ground_pb.Bounds))
                {
                    endGame();
                }
            }

            foreach (PictureBox buttom in buttom_obstacle_pb_list)
            {
                if(buttom.Left < - buttom.Width)
                {
                    buttom.Left = ClientRectangle.Right;
                }
            }

            foreach (PictureBox top in top_obstacle_pb_list)
            {
                if (top.Left < -top.Width)
                {
                    top.Left = ClientRectangle.Right;
                }
            }
        }

        /* Once the user disqualified the method stop the timer and open
         * him the "GameOverForm" form. in addition, the HighestScore methode called
         * and set to determine which score so far is the higher so it will be shown
         * in the "GameOverForm". If the "PlayFormClose" set to true
         * (means it need to be close) the form will be closed. */
        private void endGame()
        { 
            StoreForm.score += score;
            playTimer.Stop();
            HighestScore(score);
            Form gameOver = new GameOverForm();  
            gameOver.ShowDialog();
            if (PlayFormClose)
            {
                this.Close();
            } 
        }

        /* If the keyboard space button is not clicked - the character will
         * react to the gravity (will fall). */
        private void PlayForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (keyboard)
            {
                if (e.KeyCode == Keys.Space)
                {
                    gravity = 20;
                }
            }
        }

        /* If the keyboard space button is clicked - the character will react
         * to the gravity (goes up). */
        private void PlayForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (keyboard)
            {
                if (e.KeyCode == Keys.Space)
                {
                    gravity = -20;
                }
            }

            if (e.KeyCode == Keys.Space)
            {
                playTimer.Start();
                this.Controls.Remove(StartLabel);
            }
        }

        /* If the left mouse button is clicked - the character will react to
         * the gravity (goes up). */
        private void PlayForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (mouse)
            {
                if (e.Button == MouseButtons.Left)
                {
                    gravity = -19;
                }
            }
        }

        /* If the left mouse button is not clicked - the character will react
         * to the gravity (will fall). */
        private void PlayForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (mouse)
            {
                if (e.Clicks != 0)
                {
                    gravity = 19;
                }
            }
        }

        /* Method that changes the character image based on the user purchase. */
        private void BoughtCharacter(int character)
        {
            switch (character)
            {
                case 1:
                    {
                        bird_pb.Image = Properties.Resources.FirstOptionToBuy;
                        break;
                    }
                case 2:
                    {
                        bird_pb.Image = Properties.Resources.SecondOptionToBuy;
                        break;
                    }
                case 3:
                    bird_pb.Image = Properties.Resources.ThirdOptionToBuy;
                    break;
                default:
                    break;
            }
        }

        /* Method that set each obstacle picture bob image based on the
         * chosen level. */
        private void SetObstacleBackgroundImage(int number)
        {
            switch (number)
            {
                case 1:
                    foreach (PictureBox buttom in buttom_obstacle_pb_list)
                    {
                        buttom.BackgroundImage = buttom_obstacle_img_list[0];
                    }
                    foreach (PictureBox top in top_obstacle_pb_list)
                    {
                        top.BackgroundImage = top_obstacle_img_list[0];
                    }
                    break;
                case 2:
                    foreach (PictureBox buttom in buttom_obstacle_pb_list)
                    {
                        buttom.BackgroundImage = buttom_obstacle_img_list[1];
                    }
                    foreach (PictureBox top in top_obstacle_pb_list)
                    {
                        top.BackgroundImage = top_obstacle_img_list[1];
                    }
                    break;
                case 3:
                    foreach (PictureBox buttom in buttom_obstacle_pb_list)
                    {
                        buttom.BackgroundImage = buttom_obstacle_img_list[2];
                    }
                    foreach (PictureBox top in top_obstacle_pb_list)
                    {
                        top.BackgroundImage = top_obstacle_img_list[2];
                    }
                    break;
            }
        }

        /* Method that set each obstacle background image layout
         * to be stretched. */
        private void SetObstacleBackgroundImageLayout(int number)
        {
            foreach (PictureBox buttom in buttom_obstacle_pb_list)
            {
                buttom.BackgroundImageLayout = ImageLayout.Stretch;
            }
            foreach (PictureBox top in top_obstacle_pb_list)
            {
                top.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        /* Method that check if the project folder contains txt file that holds the
         * best score ever reached in the game. If such file was not found - it creates
         * such a file and write in him the currenct score that the player reached to.
         * If such file was already in the projec folder - it checkes if the score in
         * the TXT file in lower then the score the user just reached to and if it does
         * it overwrite the TXT file with the new score. */
        private void HighestScore(int currentScore)
        {
            if (!File.Exists(highestScoreTxt))
            {
                newHighScore = currentScore;
                StreamWriter write = new StreamWriter(highestScoreTxt);
                write.WriteLine(currentScore.ToString());
                write.Close();
            }
            else
            {
                StreamReader read = new StreamReader(highestScoreTxt);
                newHighScore = int.Parse(read.ReadLine());
                read.Close();
                if (newHighScore <= currentScore)
                {
                    newHighScore = currentScore;
                    File.WriteAllText(highestScoreTxt, currentScore.ToString());
                    read.Close();
                }
                read.Close();
            }
        }
    }
}
