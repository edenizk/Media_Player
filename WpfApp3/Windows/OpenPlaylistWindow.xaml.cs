using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using WpfApp3.Classes;
using WpfApp3.Frames;

namespace WpfApp3.Windows
{
    /// <summary>
    /// Interaction logic for OpenPlaylistWindow.xaml
    /// </summary>
    public partial class OpenPlaylistWindow : Window
    {
        MediaElement mediaPlayer;
        Playlist currentPlaylist;
        Frame frmMain;
        FrmPlayList frmPlayList;
        Playlists playLists;

        public OpenPlaylistWindow(MediaElement mediaPlayer, Frame frmMain)
        {
            this.mediaPlayer = mediaPlayer;
            this.frmMain = frmMain;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;

            InitializeComponent();

            DeserializeAndCreatePlayLists();
        }
        private void DeserializeAndCreatePlayLists()
        {
            playLists = Playlists.DeserializeFromXml();

            if (playLists != null)
                foreach (var item in playLists.ListOfPlaylist)
                {
                    if (item.PlayListName != null)
                        lbPlayLists.Items.Add(item.PlayListName);
                }
            else
                playLists = new Playlists();
        }

        private void BtnOpen_Click(object sender, RoutedEventArgs e)
        {
            SetFramePlaylistAndCloseWin();
        }
        private void LbPlayLists_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            SetFramePlaylistAndCloseWin();
        }
        private void SetFramePlaylistAndCloseWin()
        {
            frmPlayList = new FrmPlayList(mediaPlayer, lbPlayLists.SelectedIndex);
            frmMain.Content = frmPlayList;
            currentPlaylist = frmPlayList.GetPlaylist();
            Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        public FrmPlayList GetCurrentFramePlaylist()
        {
            return frmPlayList;
        }

        private void LbPlayLists_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                playLists.ListOfPlaylist.RemoveAt(lbPlayLists.SelectedIndex);

                Playlists.SerializeToXml(playLists);

                lbPlayLists.Items.Clear();

                DeserializeAndCreatePlayLists();

                lbPlayLists.UpdateLayout();
            }
        }
    }
}
