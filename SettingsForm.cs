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
using WMPLib;
using AxWMPLib;

namespace JumpFF
{
    public partial class SettingsForm : Form
    {
        internal static string currentPlayingMusic; // Field that will holds the name of the current playing background soundtrack.
        public SettingsForm()
        {
            InitializeComponent();

            currentPlayingMusic = MainForm.formsSound.currentMedia.name; // Initielizing that field.
            int backgroundSoundVolume = MainForm.formsSound.settings.volume; // Field that holds the volume of the current playing background soundtrack.

            this.Bounds = Screen.PrimaryScreen.Bounds; // Set the screen size to full screen in every computer that runs this program.

            choosenControl_lbl.Text = "By default the control you are playing with is: Keyboard space."; // The default text of "choosenControl" label.

            /* Marks automatically the radio button that inticates the current playing background soundtrack volume. */
            switch (backgroundSoundVolume)
            {
                case 100:
                    volume100_rb.Checked = true;
                    break;
                case 50:
                    volume50_rb.Checked = true;
                    break;
                case 25:
                    volume25_rb.Checked = true;
                    break;
                case 0:
                    volume0_rb.Checked = true;
                    break;
            }

            /* Marks automatically the name (label) of the soundtrack that currentlly playing in "DarkOrange" color. */
            switch (currentPlayingMusic)
            {
                case "VenusSoundTrack":
                    venus_lbl.ForeColor = Color.DarkOrange;
                    break;
                case "JupiterSoundTrack":
                    jupiter_lbl.ForeColor = Color.DarkOrange;
                    break;
                case "MoonSoundTrack":
                    moon_lbl.ForeColor = Color.DarkOrange;
                    break;
            }

            /* Sets the location of the label "Volume" and his friends (the radio buttons that changes the soundtrack volume). */
            volume_lbl.Location = new Point((ClientRectangle.Width - volume_lbl.Width) / 2, (ClientRectangle.Height) * 1 / 8);
            volume0_rb.Location = new Point((ClientRectangle.Width * 1/ 3) + (volume_lbl.Width / 2), (ClientRectangle.Height) * 2 / 8);
            volume25_rb.Location = new Point(volume0_rb.Location.X + volume100_rb.Width, (ClientRectangle.Height) * 2 / 8);
            volume50_rb.Location = new Point(volume25_rb.Location.X + volume100_rb.Width, (ClientRectangle.Height) * 2 / 8);
            volume100_rb.Location = new Point(volume50_rb.Location.X + volume100_rb.Width, (ClientRectangle.Height) * 2 / 8);

            /* Sets the location of the label "Music" and his friends (the labels that called in the soundtracks names). */
            music_lbl.Location = new Point((ClientRectangle.Width - music_lbl.Width) / 2, (ClientRectangle.Height) * 3 / 8);
            venus_lbl.Location = new Point(music_lbl.Location.X - moon_lbl.Width, (ClientRectangle.Height) * 4 / 8);
            moon_lbl.Location = new Point((ClientRectangle.Width - moon_lbl.Width) / 2, (ClientRectangle.Height) * 4 / 8);
            jupiter_lbl.Location = new Point(music_lbl.Location.X + (moon_lbl.Width*2), (ClientRectangle.Height) * 4 / 8);

            /* Sets the location of the label "Controls" and his friends (the picture boxes that changes the button in which the user
             * gonna play with and the lable that poing the user about his choose). */
            controls_lbl.Location = new Point((ClientRectangle.Width - controls_lbl.Width) / 2, (ClientRectangle.Height) * 5 / 8);
            spaceControl_pb.Location = new Point(controls_lbl.Bottom - (spaceControl_pb.Width / 2), (ClientRectangle.Height) * 6 / 8);
            mouseControl_pb.Location = new Point(controls_lbl.Bottom + (spaceControl_pb.Width * 2), (ClientRectangle.Height) * 6 / 8);
            choosenControl_lbl.Location = new Point(((ClientRectangle.Width - choosenControl_lbl.Width) / 2), (ClientRectangle.Height) * 7 / 8);

            return_lbl.Location = new Point((ClientRectangle.X + return_lbl.Width) / 4, (ClientRectangle.Height) - 80); // Sets the location of the label "Return".

        }

        /* Changes the soundtrack volume to 0 once the user chose this radio button. */
        private void volume0_rb_CheckedChanged(object sender, EventArgs e)
        {
            if (volume0_rb.Checked == true)
            {
                MainForm.formsSound.settings.volume = 0;
            }
        }

        /* Changes the soundtrack volume to 25 once the user chose this radio button. */
        private void volume25_rb_CheckedChanged(object sender, EventArgs e)
        {
            if (volume25_rb.Checked == true)
            {
                MainForm.formsSound.settings.volume = 25;
            }
        }

        /* Changes the soundtrack volume to 50 once the user chose this radio button. */
        private void volume50_rb_CheckedChanged(object sender, EventArgs e)
        {
            if (volume50_rb.Checked == true)
            {
                MainForm.formsSound.settings.volume = 50;
            }
        }

        /* Changes the soundtrack volume to 100 once the user chose this radio button. */
        private void volume100_rb_CheckedChanged(object sender, EventArgs e)
        {
            if (volume100_rb.Checked == true)
            {
                MainForm.formsSound.settings.volume = 100;
            }
        }

        /* By clicking the "Venus" lable, if the current playing soundtrack is
         * not "Venus" - the instance is stopped and it URL changes to the
         * desired choose (aka "Venus") and then it starts again and plying the
         * "Venus" soundtrack. in addition, where will be indication for the
         * user on his pressing by blinking the color of this label in
         * "LimeGreen" color and the field that hoolds the current playing
         * soundtrack is being updated. */
        private void venus_lbl_Click(object sender, EventArgs e)
        {
            if(!currentPlayingMusic.Equals("VenusSoundTrack"))
            {
                MainForm.formsSound.controls.stop();
                MainForm.formsSound.URL = "VenusSoundTrack.mp3"; 
                MainForm.formsSound.controls.play();
                venus_lbl.ForeColor = Color.LimeGreen;
                currentPlayingMusic = MainForm.formsSound.currentMedia.name;
            }
        }

        /* As long as "Venus" sound track is not the current playing soundtrack -
         * hooving with the mouse above the "Venus" label - will change the label 
         * color to "DarkGray". */
        private void venus_lbl_MouseHover(object sender, EventArgs e)
        {
            if (!currentPlayingMusic.Equals("VenusSoundTrack"))
            {
                venus_lbl.ForeColor = Color.DarkGray;
            }
        }

        /* When the mouse pointer is no longer hooving abouve the "Venus" label -
         * if the current playing soundtrack is "Venus" - the label color
         * return/changes to "DarkOrange" while the other soundtrack labels
         * color changes to "Black", otherwise (if the current playing soundtrack
         * is not "Venus") - the label color changes to "Black". */
        private void venus_lbl_MouseLeave(object sender, EventArgs e)
        {
            if (currentPlayingMusic.Equals("VenusSoundTrack"))
            {
                venus_lbl.ForeColor = Color.DarkOrange;
                moon_lbl.ForeColor = Color.Black;
                jupiter_lbl.ForeColor = Color.Black;
            }
            else
            {
               venus_lbl.ForeColor = Color.Black;
            }
        }

        /* By clicking the "Moon" lable, if the current playing soundtrack is
         * not "Moon" - the instance is stopped and it URL changes to the
         * desired choose (aka "Moon") and then it starts again and plying
         * the "Moon" soundtrack. in addition, where will be indication for
         * the user on his pressing by blinking the color of this label in
         * "LimeGreen" color and the field that hoolds the current playing
         * soundtrack is being updated. */
        private void moon_lbl_Click(object sender, EventArgs e)
        {
            if (!currentPlayingMusic.Equals("MoonSoundTrack"))
            {
                MainForm.formsSound.controls.stop();
                MainForm.formsSound.URL = "MoonSoundTrack.mp3"; 
                MainForm.formsSound.controls.play(); 
                moon_lbl.ForeColor = Color.LimeGreen;
                currentPlayingMusic = MainForm.formsSound.currentMedia.name;
            }
        }

        /* As long as "Moon" sound track is not the current playing soundtrack -
         * hooving with the mouse above the "Moon" label - will change the label 
         * color to "DarkGray". */
        private void moon_lbl_MouseHover(object sender, EventArgs e)
        {
            if (!currentPlayingMusic.Equals("MoonSoundTrack"))
            {
                moon_lbl.ForeColor = Color.DarkGray;
            }
        }

        /* When the mouse pointer is no longer hooving abouve the "Moon" label -
         * if the current playing soundtrack is "Moon" - the label color
         * return/changesto "DarkOrange" while the other soundtrack labels
         * color changes to "Black",otherwise (if the current playing soundtrack
         * is not "Moon") - the label color changes to "Black". */
        private void moon_lbl_MouseLeave(object sender, EventArgs e)
        {
            if (currentPlayingMusic.Equals("MoonSoundTrack"))
            {
                moon_lbl.ForeColor = Color.DarkOrange;
                jupiter_lbl.ForeColor = Color.Black;
                venus_lbl.ForeColor = Color.Black;
            }
            else
            {
                moon_lbl.ForeColor = Color.Black;
            }
        }

        /* By clicking the "Jupiter" lable, if the current playing soundtrack
         * is not "Jupiter" - the instance is stopped and it URL changes to the
         * desired choose (aka "Jupiter") and then it starts again and plying
         * the "Jupiter" soundtrack. in addition, where will be indication for
         * the user on his pressing by blinking the color of this label in 
         * "LimeGreen" color and the field that hoolds the current playing
         * soundtrack is being updated. */
        private void Jupiter_lbl_Click(object sender, EventArgs e)
        {
            if (!currentPlayingMusic.Equals("JupiterSoundTrack"))
            {
                MainForm.formsSound.controls.stop();
                MainForm.formsSound.URL = "JupiterSoundTrack.mp3"; 
                MainForm.formsSound.controls.play(); 
                jupiter_lbl.ForeColor = Color.LimeGreen;
                currentPlayingMusic = MainForm.formsSound.currentMedia.name;
            }
        }

        /* As long as "Jupiter" sound track is not the current playing
         * soundtrack - hooving with the mouse above the "Jupiter" label
         * - will change the label color to "DarkGray". */
        private void Jupiter_lbl_MouseHover(object sender, EventArgs e)
        {
            if (!currentPlayingMusic.Equals("JupiterSoundTrack"))
            {
                jupiter_lbl.ForeColor = Color.DarkGray;
            }
        }

        /* When the mouse pointer is no longer hooving abouve the "Jupiter"
         * label - if the current playing soundtrack is "Jupiter" - the label
         * color return/changes to "DarkOrange" while the other soundtrack
         * labels color changes to "Black", otherwise
         * (if the current playing soundtrack is not "Jupiter") - the label color
         * changes to "Black". */
        private void Jupiter_lbl_MouseLeave(object sender, EventArgs e)
        {
            if (currentPlayingMusic.Equals("JupiterSoundTrack"))
            {
                jupiter_lbl.ForeColor = Color.DarkOrange;
                moon_lbl.ForeColor = Color.Black;
                venus_lbl.ForeColor = Color.Black;
            }
            else
            {
                jupiter_lbl.ForeColor = Color.Black;
            }
        }

        /* Hooving with the mouse pointer above "return" label will change
         * his color to "LimeGreen".*/
        private void return_lbl_MouseHover(object sender, EventArgs e)
        {
            return_lbl.ForeColor = Color.LimeGreen;
        }

        /* When the mouse pointer is not hooving above "return" label
         * - his color returns to "Black". */
        private void return_lbl_MouseLeave(object sender, EventArgs e)
        {
            return_lbl.ForeColor = Color.Black;
        }

        /* By clicking the "Return" label - the current form will close and the
         * user will be directed to the previous form. */
        private void return_lbl_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        /* By clicking on "SpaceControl" picture box - the text of
         * "choosenControl" label will be changed and inform the user about
         * the control he chose to play with. In addition, the location of that
         * label will fixed to center once she changed. */
        private void spaceControl_pb_Click(object sender, EventArgs e)
        {
            if (!PlayForm.keyboard)
            {
                PlayForm.mouse = false;
                PlayForm.keyboard = true;
                choosenControl_lbl.Text = "The control you are playing with is: Keyboard space.";
                this.choosenControl_lbl.Location = new Point(((ClientRectangle.Width - choosenControl_lbl.Width) / 2), (ClientRectangle.Height) * 7 / 8);
            }
        }

        /* By clicking on "MouseControl" picture box - the text of
         * "choosenControl" label will be changed and inform the user about
         * the control he chose to play with. In addition, the location of
         * that label will fixed to center once she changed. */
        private void mouseControl_pb_Click(object sender, EventArgs e)
        {
            if (!PlayForm.mouse)
            {
                PlayForm.mouse = true;
                PlayForm.keyboard = false;
                choosenControl_lbl.Text = "The control you are playing with is: Mouse left button.";
                this.choosenControl_lbl.Location = new Point(((ClientRectangle.Width - choosenControl_lbl.Width) / 2), (ClientRectangle.Height) * 7 / 8);
            }
        }
    }
}
