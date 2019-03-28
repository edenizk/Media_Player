using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;
using TagLib;

namespace WpfApp3.Classes
{
    [XmlInclude(typeof(Local))]
    [XmlInclude(typeof(Youtube))]
    [Serializable]
    public abstract class Media
    {
        public Media() { }

        public abstract string GetPath();

        public abstract string GetURL();

        public abstract string Info();

        public abstract BitmapImage GetBitmapImage();
    }
}
