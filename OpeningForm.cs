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
    public partial class OpeningForm : Form
    {
        public OpeningForm()
        {
            var openingVideoPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "OpeningVideo.avi"); // Creating a field that holds the path to the opening video which is located in the resources.
            File.WriteAllBytes(openingVideoPath, JumpFF.Properties.Resources.OpeningVideo); // Creating a string out of openingVideoPath.
            
            InitializeComponent();

            this.Bounds = Screen.PrimaryScreen.Bounds; // Set the screen size to full screen in every computer that runs this program.
            this.axWindowsMediaPlayer1.Bounds = Screen.PrimaryScreen.Bounds; // Set the windows media player screen size to full screen in every computer that runs this program.

            axWindowsMediaPlayer1.URL = openingVideoPath; // Initielizing the windows media player video path.  
            axWindowsMediaPlayer1.uiMode = "None"; // Disables the media player buttons strip.
            axWindowsMediaPlayer1.enableContextMenu = false; // Lock the windows media player from opening menu by clicking the right mouse button.
            axWindowsMediaPlayer1.Ctlenabled = false; // Lock the windows media player from changing by clicking the left mouse button.

            TimerForNextForm.Start(); // Starting the timer to count untril the opening video ends.
            StoreForm.bird1_Purchared = false;
            StoreForm.bird2_Purchared = false;
            StoreForm.bird3_Purchared = false;
        }

        /* Timer methode that responsible to stop the timer after his first
         * tick, creating a new instance of the game main form, closing the
         * windows media player and moving to the main form after closing
         * this one.*/
        private void TimerForNextForm_Tick(object sender, EventArgs e)
        {
            TimerForNextForm.Stop();
            Form mainform = new MainForm();
            axWindowsMediaPlayer1.Dispose();
            mainform.ShowDialog();
            this.Close();
        }
    }
}
