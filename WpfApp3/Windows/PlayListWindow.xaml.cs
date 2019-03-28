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

namespace WpfApp3.Windows
{
    /// <summary>
    /// Interaction logic for PlayList_Window.xaml
    /// </summary>
    public partial class PlayListWindow : Window
    {
        Playlists playLists;
        Media media;

        public PlayListWindow()
        {
            InitializeComponent();

            DeserializePlayLists();
        }
        public PlayListWindow(Media media)
        {
            this.media = media;

            InitializeComponent();

            DeserializePlayLists();
        }
        private void DeserializePlayLists()
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
        private void LbPlayLists_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("You have : " + playLists.ListOfPlaylist[lbPlayLists.SelectedIndex].MediaList.Count().ToString() + " Song(s)");
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            playLists.ListOfPlaylist[lbPlayLists.SelectedIndex].MediaList.Add(media);

            SerializeAndClose();
        }
        private void BtnCreateAndAdd_Click(object sender, RoutedEventArgs e)
        {
            if(txtPlayListName.Text != "")
            {
                playLists.ListOfPlaylist.Add(new Playlist(txtPlayListName.Text));

                playLists.ListOfPlaylist.Last().MediaList.Add(media);

                SerializeAndClose();
            }
            else
            {
                MessageBox.Show("Please give playlist a name");
            }
        }
        private void BtnRemovePlaylist_Click(object sender, RoutedEventArgs e)
        {
            playLists.ListOfPlaylist.RemoveAt(lbPlayLists.SelectedIndex);

            SerializeAndClose();
        }
        private void SerializeAndClose()
        {
            Playlists.SerializeToXml(playLists);

            Close();
        }
    }
}
