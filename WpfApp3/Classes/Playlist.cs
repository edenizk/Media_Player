using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;
using TagLib;

namespace WpfApp3.Classes
{
    public class Playlist
    {
        public List<Media> MediaList { get; set; }

        public string PlayListName { get; set; }

        [XmlIgnore]
        private MediaElement mediaPlayer;

        [XmlIgnore]
        private static int currentPosition = 0;

        public Playlist(string playListName, MediaElement mediaPlayer)
        {
            MediaList = new List<Media>();

            this.mediaPlayer = mediaPlayer;

            PlayListName = playListName;
        }

        public Playlist(string playListName)
        {
            MediaList = new List<Media>();

            PlayListName = playListName;
        }

        public Playlist() { }

        public int GetCurrentPosition()
        {
            return currentPosition;
        }

        public void Play(int Index)
        {
            try
            {
                Uri path = new Uri(MediaList[Index].GetPath());

                mediaPlayer.Source = path;

                mediaPlayer.Play();

                currentPosition = Index;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            
        }
        public void Pause()
        {
            mediaPlayer.Pause();
        }
        public void Next(bool isShuffle, bool isRepeat)
        {
            if (isShuffle != true)
            {
                if (currentPosition + 1 < MediaList.Count())
                    currentPosition++;
                else if (isRepeat == true)
                    currentPosition = 0;
                else
                    return;
            }
            else
            {
                int randomNum;

                do
                {
                    Random random = new Random();

                    randomNum = random.Next(0, MediaList.Count());

                } while (currentPosition == randomNum && MediaList.Count != 1);

                currentPosition = randomNum;
            }
            SetSourceAndPlay();
        }
        public void Prev()
        {
            if (currentPosition > 0)
                currentPosition--;
            else
                currentPosition = 0;

            SetSourceAndPlay();
        }
        private void SetSourceAndPlay()
        {
            Uri path = new Uri(MediaList[currentPosition].GetPath());

            mediaPlayer.Source = path;

            mediaPlayer.Play();
        }
    }
}