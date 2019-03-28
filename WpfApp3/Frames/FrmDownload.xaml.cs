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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TagLib;
using WpfApp3.Classes;
using WpfApp3.Windows;

namespace WpfApp3.Frames
{
    /// <summary>
    /// Interaction logic for FrmDownload.xaml
    /// </summary>
    public partial class FrmDownload : Page
    {
        private MediaElement mediaPlayer;
        private Playlist playlist;

        public FrmDownload(MediaElement mediaPlayer)
        {
            this.mediaPlayer = mediaPlayer;

            InitializeComponent();

            playlist = new Playlist("Downloads", mediaPlayer);

            string[] fileArrayMp3 = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Download", "*.mp3");
            string[] fileArrayMp4 = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Download", "*.mp4");

            CreateDownloadPlaylist(fileArrayMp3);
            CreateDownloadPlaylist(fileArrayMp4);
            AddListIntoListBox();

            dtPlayList.RowBackground = Brushes.Transparent;
            dtPlayList.BorderBrush = Brushes.Transparent;
        }

        private void CreateDownloadPlaylist(string[] fileArray)
        {
            foreach (var path in fileArray)
            {
                TagLib.File tagFile = TagLib.File.Create(path);
                string artist = tagFile.Tag.JoinedPerformers;
                string album = tagFile.Tag.Album;
                string title = tagFile.Tag.Title;
                BitmapImage bitmapImage = GetBitmapFromIPicture(tagFile.Tag.Pictures.FirstOrDefault());
                string url = tagFile.Tag.Copyright;
                
                TimeSpan duration = tagFile.Properties.Duration;
                playlist.MediaList.Add(new Youtube(path, title, artist, album, duration.ToString(@"mm\:ss"), bitmapImage, path.Split('\\').Last(), url));
            }
        }
        private void AddListIntoListBox()
        {
            foreach (var item in playlist.MediaList)
            {
                dtPlayList.Items.Add(item);
            }
        }
        public BitmapImage GetBitmapFromIPicture(IPicture picture)
        {
            if (picture != null)
            {
                // Load you image data in MemoryStream
                IPicture pic = picture;
                MemoryStream ms = new MemoryStream(pic.Data.Data);
                ms.Seek(0, SeekOrigin.Begin);

                // ImageSource for System.Windows.Controls.Image
                BitmapImage bitMap = new BitmapImage();
                bitMap.BeginInit();
                bitMap.StreamSource = ms;
                bitMap.EndInit();

                return bitMap;
            }

            return null;
        }
        private void BtnPlay_Click(object sender, RoutedEventArgs e)
        {
            playlist.Play(dtPlayList.SelectedIndex);
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            PlayListWindow secondWindow = new PlayListWindow(dtPlayList.SelectedItem as Media);
            secondWindow.Show();
        }

        private void DtPlayList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (!(dtPlayList.SelectedItem is Media selectedMedia))
                return;

            System.Windows.MessageBox.Show(selectedMedia.Info());
        }
        public Playlist GetPlaylist()
        {
            return playlist;
        }
        public void ChangeSelectedIndex()
        {
            dtPlayList.SelectedIndex = playlist.GetCurrentPosition();
        }
        private void MenuItem_Delete_Click(object sender, RoutedEventArgs e)
        {
            Media media = dtPlayList.SelectedItem as Media;

            System.IO.File.Delete(media.GetPath());
            playlist.MediaList.Remove(media);

            dtPlayList.Items.Remove(dtPlayList.SelectedItem);
        }
    }
}
