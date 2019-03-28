using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp3.Classes;
using WpfApp3.Windows;
using YoutubeExplode;
using YoutubeExplode.Models.MediaStreams;


namespace WpfApp3.Frames
{
    
    public partial class FrmYoutube : Page
    {

        public FrmYoutube(MediaElement mediaPlayer)
        {
            InitializeComponent();

            wbYoutube.Navigate("https://m.youtube.com");
        }

        private void WbYoutube_LoadCompleted(object sender, NavigationEventArgs e)
        {
            txtUrl.Text = wbYoutube.Source.AbsoluteUri;
            labelLoadBar.Content = "";
        }

        private void TxtUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                wbYoutube.Navigate(txtUrl.Text);
            }
        }

        private void WbYoutube_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            labelLoadBar.Content = "Loading...";
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            
            PlayListWindow secondWindow = new PlayListWindow(new Youtube(txtUrl.Text));
            secondWindow.Show();
        }

        private void BtnDownload_Click(object sender, RoutedEventArgs e)
        {
            Youtube youtube = new Youtube();
            if (cbAudioVideo.Text == "Audio")
            {
                youtube.DownloadAsyncAudio(txtUrl.Text, labelLoadBar);
            }
            if (cbAudioVideo.Text == "Video")
            {
                labelLoadBar.Content = "Starting Download";

                youtube.DownloadAsyncVideo(txtUrl.Text);

                labelLoadBar.Content = "Downloaded video";
            }

        }
        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            wbYoutube.Navigate("https://m.youtube.com");
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                wbYoutube.GoBack();
            }catch(Exception execption)
            {
                MessageBox.Show(execption.Message);
            }
        }

        private void BtnForward_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                wbYoutube.GoForward();
            }
            catch (Exception execption)
            {
                MessageBox.Show(execption.Message);
            }
        }
    }
}
