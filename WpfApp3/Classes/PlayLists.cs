using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace WpfApp3.Classes
{
    public class Playlists
    {
        public List<Playlist> ListOfPlaylist { get; set; }

        public Playlists() { ListOfPlaylist = new List<Playlist>(); }

        public static void SerializeToXml(Playlists playLists)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Playlists));
            TextWriter writer = new StreamWriter($"PlayLists.xml");

            serializer.Serialize(writer, playLists);
            writer.Close();
        }

        public static Playlists DeserializeFromXml()
        {
            Playlists playLists;

            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(Playlists));
                FileStream fs = new FileStream("PlayLists.xml", FileMode.Open);

                playLists = (Playlists)deserializer.Deserialize(fs);
                fs.Close();
            }
            catch (FileNotFoundException e)
            {
                return null;
            }
            return playLists;
        }
    }
}
