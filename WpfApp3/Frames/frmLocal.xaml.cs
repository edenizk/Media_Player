using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
using TagLib;
using System.Windows.Forms;
using WpfApp3.Classes;
using WpfApp3.Windows;

namespace WpfApp3.Frames
{
    /// <summary>
    /// Interaction logic for frmLocal.xaml
    /// </summary>
    public partial class FrmLocal : Page
    {
        MediaElement mediaPlayer;
        Playlist playlist;

        public FrmLocal(MediaElement mediaPlayer)
        {
            this.mediaPlayer = mediaPlayer;

            InitializeComponent();

            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            playlist = new Playlist("Local", mediaPlayer);

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string[] fileArrayMp3 = Directory.GetFiles(folderBrowserDialog.SelectedPath, "*.mp3");
                string[] fileArrayMp4 = Directory.GetFiles(folderBrowserDialog.SelectedPath, "*.mp4");

                CreateDtPlaylist(fileArrayMp3);
                CreateDtPlaylist(fileArrayMp4);

                AddListIntoListBox();
            }

            dtPlayList.RowBackground = Brushes.Transparent;
            dtPlayList.BorderBrush = Brushes.Transparent;
        }
        private void CreateDtPlaylist(string[] fileArray)
        {
            foreach (var item in fileArray)
            {
                TagLib.File tagFile = TagLib.File.Create(item);
                string artist = tagFile.Tag.JoinedPerformers;
                string album = tagFile.Tag.Album;
                string title = tagFile.Tag.Title;
                BitmapImage bitmapImage = GetBitmapFromIPicture(tagFile.Tag.Pictures.FirstOrDefault());

                TimeSpan duration = tagFile.Properties.Duration;
                playlist.MediaList.Add(new Local(item, title, artist, album, duration.ToString(@"mm\:ss"), bitmapImage, item.Split('\\').Last()));
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
            PlayListWindow addRemCreatePlaylistWindow = new PlayListWindow(dtPlayList.SelectedItem as Media);
            addRemCreatePlaylistWindow.Show();
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
    }
}
