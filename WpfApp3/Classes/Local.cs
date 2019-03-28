using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;
using TagLib;

namespace WpfApp3.Classes
{
    public class Local: Media
    {

        public string Path { get; set; }
        [XmlIgnore]
        public string Title { get; private set; }
        [XmlIgnore]
        public string Artist { get; private set; }
        [XmlIgnore]
        public string Album { get; private set; }
        [XmlIgnore]
        public string Time { get; private set; }
        [XmlIgnore]
        public string FullFileName { get; private set; }
        [XmlIgnore]
        public BitmapImage BitmapImage { get; private set; }

        public Local(string path, string title, string artist, string album, string time, BitmapImage bitmapImage, string fullFileName)
        {
            Path = path;
            Title = title;
            Artist = artist;
            Album = album;
            Time = time;
            BitmapImage = bitmapImage;
            FullFileName = fullFileName;
        }

        public Local() { }

        public override string Info()
        {
            return $"File name: {FullFileName}" +
                $"\nTitle: {Title}" +
                $"\nArtist: {Artist}" +
                $"\nAlbum: {Artist}" +
                $"\nTotal Time: {Time}" +
                $"\nPath: {Path}";
        }

        public override string GetURL()
        {
            return null;
        }

        public override string GetPath()
        {
            return Path;
        }

        public override BitmapImage GetBitmapImage()
        {
            return BitmapImage;
        }
    }
}
