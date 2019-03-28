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
using System.Xml.Linq;
using TagLib;
using WpfApp3.Classes;
using WpfApp3.Windows;

namespace WpfApp3.Frames
{
    /// <summary>
    /// Interaction logic for frmPlayList.xaml
    /// </summary>
    public partial class FrmPlayList : Page
    {
        Playlists playlists;
        Playlist playlist;
        MediaElement mediaPlayer;
        int playlistIndex;
        public FrmPlayList(MediaElement mediaPlayer, int playlistIndex)
        {
            this.mediaPlayer = mediaPlayer;
            this.playlistIndex = playlistIndex;

            InitializeComponent();

            playlists = Playlists.DeserializeFromXml();

            CreateDtPlaylist(playlists.ListOfPlaylist[playlistIndex]);

            dtPlayList.RowBackground = Brushes.Transparent;
            dtPlayList.BorderBrush = Brushes.Transparent;
        }
        
        private void CreateDtPlaylist(Playlist playlistPaths)
        {
            List<string> fileLists = new List<string>();
            List<string> fileTypes = new List<string>();

            playlist = new Playlist("", mediaPlayer);
            
            foreach (var item in playlistPaths.MediaList)
            {
                fileLists.Add(item.GetPath());
                fileTypes.Add(item.GetType().ToString());
            }

            for (int i = 0; i < fileLists.Count; i++)
            {
                string artist = "", 
                    album = "", 
                    title = "", 
                    url = "";
                BitmapImage bitmapImage = null;
                TimeSpan duration;

                try
                {
                    TagLib.File tagFile = TagLib.File.Create(fileLists[i]);

                    artist = tagFile.Tag.JoinedPerformers;
                    album = tagFile.Tag.Album;
                    title = tagFile.Tag.Title;
                    bitmapImage = GetBitmapFromIPicture(tagFile.Tag.Pictures.FirstOrDefault());
                    duration = tagFile.Properties.Duration;
                    url = tagFile.Tag.Copyright;

                    if (fileTypes[i].Split('.').Last() == "Local")
                        playlist.MediaList.Add(new Local(fileLists[i], title, artist, album, duration.ToString(@"mm\:ss"), bitmapImage, fileLists[i].Split('\\').Last()));
                    else
                        playlist.MediaList.Add(new Youtube(fileLists[i], title, artist, album, duration.ToString(@"mm\:ss"), bitmapImage, fileLists[i].Split('\\').Last(), url));
                }
                catch(FileNotFoundException)
                {
                    MessageBox.Show("File not Found : " + fileLists[i].Split('\\').Last());

                    playlists.ListOfPlaylist[playlistIndex].MediaList.RemoveAll(file => file.GetPath() == fileLists[i]);

                    Playlists.SerializeToXml(playlists);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.ToString());
                }
            }
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

            MessageBox.Show(selectedMedia.Info());
        }
        public Playlist GetPlaylist()
        {
            return playlist;
        }
        public void ChangeSelectedIndex()
        {
            dtPlayList.SelectedIndex = playlist.GetCurrentPosition();
        }
        private void MenuItem_Remove_Click(object sender, RoutedEventArgs e)
        {
            Media media = dtPlayList.SelectedItem as Media;

            int removeIndex = playlists.ListOfPlaylist[playlistIndex].MediaList.FindIndex(m => m.GetPath() == media.GetPath());

            playlists.ListOfPlaylist[playlistIndex].MediaList.RemoveAt(removeIndex);
            playlist.MediaList.RemoveAt(removeIndex);

            dtPlayList.Items.Remove(media);

            Playlists.SerializeToXml(playlists);
        }
    }
}
