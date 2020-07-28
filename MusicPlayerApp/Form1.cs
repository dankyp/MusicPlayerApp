using AxWMPLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPlayerApp
{
    public partial class MusicPlayerApp : Form
    {
        public MusicPlayerApp()
        {
            InitializeComponent();
        }

        // Create global variables of String type array to save the titles or name of the tracks and path of the track
        String[] paths, files;

        private void btnSelectSongs_Click(object sender, EventArgs e)
        {
            //Code to select songs
            OpenFileDialog ofd = new OpenFileDialog();
            //Code to select multiple file
            ofd.Multiselect = true;
            if (ofd.ShowDialog()==System.Windows.Forms.DialogResult.OK)
            {
                files = ofd.SafeFileNames; //Save the names of the track in the files array
                paths = ofd.FileNames; //Save the paths of the track in the paths array
                //Display the music titles in listbox
                for(int i = 0; i < files.Length; i++)
                {
                    listBoxSongs.Items.Add(files[i]); //Display songs in listbox
                }
            }
        }

        private void listBoxSongs_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Write code to play music
            //try catch to catch any error and tell us the error rather than shutting down the music player
            try
            {
                axWindowsMediaPlayer2.URL = paths[listBoxSongs.SelectedIndex];
            }
            catch (IndexOutOfRangeException) 
            { }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //Button to minimise window completely
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            // Code to maximise the app
            this.WindowState = FormWindowState.Maximized;
        }

        private void btn_shuffle_Click(object sender, EventArgs e)
        {
            //Button to shuffle songs in the list box
            ListBox.ObjectCollection list = listBoxSongs.Items; //Refers to item in the listbox
            Random random = new Random(); //Random generator
            int w = list.Count; //States how many items there are in the listbox
            listBoxSongs.BeginUpdate();
            while (w > 1)
            {
                w--;
                int u = random.Next(w + 1);
                object value = list[u];
                list[u] = list[w];
                list[w] = value;
            }
            listBoxSongs.EndUpdate();
            listBoxSongs.Invalidate();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Code to close the app
            this.Close();
        }
    }
}
