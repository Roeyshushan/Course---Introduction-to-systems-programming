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

namespace JumpFF
{
    public partial class MainForm : Form
    {
        internal static WindowsMediaPlayer formsSound; // Declaration an instance type "wmp" that will play the background soundtrack.

        public MainForm()
        {
            this.DoubleBuffered = true; // Helps to prevent from images/labels to flicker and for smoother move.

            InitializeComponent();

            this.Bounds = Screen.PrimaryScreen.Bounds; // Set the screen size to full screen in every computer that runs this program.

            formsSound = new WindowsMediaPlayer(); // Creating an instance of windows media player.
            formsSound.URL = "VenusSoundTrack.mp3"; // Initializing the wmp instance "playing file location" field to the desired soundtrack.
            formsSound.settings.setMode("Loop", true); // Set the loop option on.
            formsSound.controls.play(); // Play's the background soundstrack.
            formsSound.settings.volume = 100; // Set the background soundtrack volume to full.

            /* Sets the menu lables location. */
            this.Play_lbl.Location = new Point((ClientRectangle.Width - Play_lbl.Width)/2 , (ClientRectangle.Height) * 1/7 );
            this.Store_lbl.Location = new Point((ClientRectangle.Width - Store_lbl.Width)/2 , (ClientRectangle.Height) * 2/7 );
            this.Settings_lbl.Location = new Point((ClientRectangle.Width - Settings_lbl.Width)/2, (ClientRectangle.Height) * 3/7 );
            this.Guide_lbl.Location = new Point((ClientRectangle.Width - Guide_lbl.Width)/2, (ClientRectangle.Height) * 4/7 );
            this.AboutUs_lbl.Location = new Point((ClientRectangle.Width - AboutUs_lbl.Width)/2, (ClientRectangle.Height) * 5/7 );
            this.Exit_lbl.Location = new Point((ClientRectangle.Width - Exit_lbl.Width)/2, (ClientRectangle.Height) * 6/7 );
            this.SoundOff_lbl.Location = new Point((ClientRectangle.Width - SoundOff_lbl.Width), (ClientRectangle.Height) - 80 );
            this.SoundOn_lbl.Location = new Point((ClientRectangle.Width - SoundOn_lbl.Width), (ClientRectangle.Height) - 80);

            this.SoundOn_lbl.Visible = false; // Sound On label is hidden for start (since the soundtrack is already playing).
        }

        /* By clicking the "Exit" label - the application will close itself. */
        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /* Hooving with the mouse pointer above "Play" label will change his
         * color to "LimeGreen". */
        private void Play_lbl_MouseHover(object sender, EventArgs e)
        {
            Play_lbl.ForeColor = Color.LimeGreen;
        }

        /* When the mouse pointer is not hooving above "return" label - his
         * color returns to "Black". */
        private void Play_lbl_MouseLeave(object sender, EventArgs e)
        {
            Play_lbl.ForeColor = Color.Black;
        }

        /* Hooving with the mouse pointer above "Store" label will change his
         * color to "LimeGreen". */
        private void Store_lbl_MouseHover(object sender, EventArgs e)
        {
            Store_lbl.ForeColor = Color.LimeGreen;
        }

        /* When the mouse pointer is not hooving above "Store" label - his
         * color returns to "Black". */
        private void Store_lbl_MouseLeave(object sender, EventArgs e)
        {
            Store_lbl.ForeColor = Color.Black;
        }

        /* Hooving with the mouse pointer above "Settings" label will change
         * his color to "LimeGreen". */
        private void Setting_lbl_MouseHover(object sender, EventArgs e)
        {
            Settings_lbl.ForeColor = Color.LimeGreen;
        }

        /* When the mouse pointer is not hooving above "Settings" label - his
         * color returns to "Black". */
        private void Setting_lbl_MouseLeave(object sender, EventArgs e)
        {
            Settings_lbl.ForeColor = Color.Black;
        }

        /* Hooving with the mouse pointer above "Guide" label will change his
         * color to "LimeGreen". */
        private void Guide_lbl_MouseHover(object sender, EventArgs e)
        {
            Guide_lbl.ForeColor = Color.LimeGreen;
        }

        /* When the mouse pointer is not hooving above "Guide" label - his
         * color returns to "Black". */
        private void Guide_lbl_MouseLeave(object sender, EventArgs e)
        {
            Guide_lbl.ForeColor = Color.Black;
        }

        /* Hooving with the mouse pointer above "About us" label will change
         * his color to "LimeGreen". */
        private void AboutUs_lbl_MouseHover(object sender, EventArgs e)
        {
            AboutUs_lbl.ForeColor = Color.LimeGreen;
        }

        /* When the mouse pointer is not hooving above "About us" label - his
         * color returns to "Black". */
        private void AboutUs_lbl_MouseLeave(object sender, EventArgs e)
        {
            AboutUs_lbl.ForeColor = Color.Black;
        }

        /* Hooving with the mouse pointer above "Exit" label will change his
         * color to "LimeGreen". */
        private void Exit_lbl_MouseHover(object sender, EventArgs e)
        {
            Exit_lbl.ForeColor = Color.LimeGreen;
        }

        /* When the mouse pointer is not hooving above "Exit" label - his
         * color returns to "Black". */
        private void Exit_lbl_MouseLeave(object sender, EventArgs e)
        {
            Exit_lbl.ForeColor = Color.Black;
        }

        /* Hooving with the mouse pointer above "Sound off" label will change
         * his color to "LimeGreen". */
        private void Mute_lbl_MouseHover(object sender, EventArgs e)
        {
            SoundOff_lbl.ForeColor = Color.LimeGreen;
        }

        /* When the mouse pointer is not hooving above "Sound off" label - his
         * color returns to "Black". */
        private void Mute_lbl_MouseLeave(object sender, EventArgs e)
        {
            SoundOff_lbl.ForeColor = Color.Black;
        }

        /* Hooving with the mouse pointer above "Sound on" label will change
         * his color to "LimeGreen". */
        private void SoundOn_lbl_MouseHover(object sender, EventArgs e)
        {
            SoundOn_lbl.ForeColor = Color.LimeGreen;
        }

        /* When the mouse pointer is not hooving above "Sound on" label - his
         * color returns to "Black". */
        private void SoundOn_lbl_MouseLeave(object sender, EventArgs e)
        {
            SoundOn_lbl.ForeColor = Color.Black;
        }

        /* By clicking on "Sound off" label - the background soundtrack will
         * pause, the "Sound off" label will be hidding and the "Sound on"
         * label will show instead.*/
        private void SoundOff_lbl_Click(object sender, EventArgs e)
        {
            formsSound.settings.mute = true;
            SoundOff_lbl.Visible = false;
            SoundOn_lbl.Visible = true;
        }

        /* By clicking on "Sound on" label - the background soundtrack will
         * resume, the "Sound on" label will be hidding and the "Sound off"
         * label will show instead. */
        private void SoundOn_lbl_Click(object sender, EventArgs e)
        {
            formsSound.settings.mute = false;

            SoundOff_lbl.Visible = true;
            SoundOn_lbl.Visible = false;
        }

        /* By clicking on "About us" label - the user will be transfered to
         * the "AboutUsForm" while this form will be hidden". */
        private void AboutUs_lbl_Click(object sender, EventArgs e)
        {
            Form aboutUs = new AboutUsForm();
            aboutUs.ShowDialog();
        }

        /* By clicking on "Guide" label - the user will be transfered to the
         "GuideForm" while this form will be hidden". */
        private void Guide_lbl_Click(object sender, EventArgs e)
        {
            Form guide = new GuideForm();
            guide.ShowDialog();
        }

        /* By clicking on "Settings" label - the user will be transfered to the
         "SettingsForm" while this form will be hidden". */
        private void Settings_lbl_Click(object sender, EventArgs e)
        {
            Form settings = new SettingsForm();
            settings.ShowDialog();
        }

        /* By clicking on "Play" label - the user will be transfered to the
         "PlayLevelForm" while this form will be hidden". */
        private void Play_lbl_Click(object sender, EventArgs e)
        {
            Form PlayLevelForm = new PlayLevelForm();
            PlayLevelForm.ShowDialog();
        }

        /* By clicking on "Store" label - the user will be transfered to the
         * "StoreForm" while this form will be hidden". */
        private void Store_lbl_Click(object sender, EventArgs e)
        {
            Form StoreForm = new StoreForm();
            StoreForm.ShowDialog();
        }
    }
}
