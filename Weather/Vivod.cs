using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

namespace Weather
{
    class Vivod
    {
        public static ImageBrush ib = new ImageBrush();
        public static Weather.OpenWeather oW;
        public static async void VivodWeather(string cityname)
        {
            WebRequest request = WebRequest.Create($"https://api.openweathermap.org/data/2.5/weather?q={cityname}&appid=6ec4258c723eade120938ef456405434&lang=ru");

            request.Method = "POST";

            request.ContentType = "application/x-www-urlencoded";

            WebResponse response = await request.GetResponseAsync();

            string answer = string.Empty;

            using (Stream s = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(s))
                {
                    answer = await reader.ReadToEndAsync();
                }
            }
            response.Close();
            oW = JsonConvert.DeserializeObject<Weather.OpenWeather>(answer);
            ib.ImageSource = oW.weather[0].Icon;
            Ow();
            Image();
        }
        public static Weather.OpenWeather Ow() { return oW; }
        public static ImageBrush Image() { return ib; }
    }
}
