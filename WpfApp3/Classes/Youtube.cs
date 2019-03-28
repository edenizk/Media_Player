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
using YoutubeExplode;
using YoutubeExplode.Models.MediaStreams;

namespace WpfApp3.Classes
{
    public class Youtube: Media
    {
        public string Url { get; set; }

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

        public Youtube(string path, string title, string artist, string album, string time, BitmapImage bitmapImage, string fullFileName, string url)
        {
            Path = path;
            Title = title;
            Artist = artist;
            Album = album;
            Time = time;
            BitmapImage = bitmapImage;
            FullFileName = fullFileName;
            Url = url;
        }
        public Youtube(string url) { Url = url; }

        public Youtube() { }

        public async void DownloadAsyncVideo(string url)
        {
            try
            {
                var id = YoutubeClient.ParseVideoId(url);

                var client = new YoutubeClient();
                var streamInfoSet = await client.GetVideoMediaStreamInfosAsync(id);

                var video = await client.GetVideoAsync(id);
                var mp4FileTitle = video.Title;

                var streamInfo = streamInfoSet.Muxed.FirstOrDefault(quality => quality.VideoQualityLabel == "360p");
                var ext = streamInfo.Container.GetFileExtension();

                string mp4Path = Directory.GetCurrentDirectory() + "\\Download\\" + mp4FileTitle + "." + ext;

                await client.DownloadMediaStreamAsync(streamInfo, mp4Path);
                
                TagFile(url, mp4Path);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }
        public async void DownloadAsyncAudio(string url, Label labelLoadBar)
        {
            try
            {
                labelLoadBar.Content = "Starting Download";

                var id = YoutubeClient.ParseVideoId(url);

                var client = new YoutubeClient();
                var streamInfoSet = await client.GetVideoMediaStreamInfosAsync(id);

                var video = await client.GetVideoAsync(id);
                
                var mp4FileTitle = video.Title;
                
                var streamInfo = streamInfoSet.Muxed.FirstOrDefault(quality => quality.VideoQualityLabel == "360p");
                var ext = streamInfo.Container.GetFileExtension();

                string mp4Path = Directory.GetCurrentDirectory() + "\\Download\\" + mp4FileTitle + "." + ext;
                
                await client.DownloadMediaStreamAsync(streamInfo, mp4Path);

                labelLoadBar.Content = "Starting cover to mp3";

                var convert = new NReco.VideoConverter.FFMpegConverter();
                string mp3Path = Directory.GetCurrentDirectory() + "\\Download\\" + mp4FileTitle + ".mp3";

                convert.ConvertMedia(mp4Path.Trim(), mp3Path.Trim(), "mp3");

                labelLoadBar.Content = "Saving Url";

                TagFile(url, mp3Path);

                labelLoadBar.Content = "Tmp File Removing";

                System.IO.File.Delete(mp4Path);

                labelLoadBar.Content = "Audio is Ready";

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }
        private void TagFile(string url, string path)
        {
            TagLib.File tagFile = TagLib.File.Create(path);
            tagFile.Tag.Copyright = url;
            tagFile.Save();
        }
        public override string GetPath()
        {
            return Path;
        }
        public override string GetURL()
        {
            return Url;
        }
        public override string Info()
        {
            return $"File name: {FullFileName}" +
                $"\nTitle: {Title}" +
                $"\nArtist: {Artist}" +
                $"\nAlbum: {Artist}" +
                $"\nTotal Time: {Time}" +
                $"\nPath: {Path}" +
                $"\nURL: {Url}";
        }
        public override BitmapImage GetBitmapImage()
        {
            return BitmapImage;
        }
    }
}
