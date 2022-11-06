using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Weather
{
    public class weather
    {
        public int id;

        public string main;

        public string description;

        public string icon;

        public BitmapImage Icon
        {
            get
            {
                return new BitmapImage(new Uri($"icons/{icon}.png", UriKind.RelativeOrAbsolute));
            }
        }
    }
}
