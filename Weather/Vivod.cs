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
        public static OpenWeather oW;
        public static void VivodWeather(string cityname)
        {
            try
            {
                WebRequest request = WebRequest.Create($"https://api.openweathermap.org/data/2.5/weather?q={cityname}&appid=6ec4258c723eade120938ef456405434&lang=ru");

                request.Method = "POST";

                request.ContentType = "application/x-www-urlencoded";


                WebResponse response = request.GetResponse();

                string answer = string.Empty;

                using (Stream s = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(s))
                    {
                        answer = reader.ReadToEnd();
                    }
                }
                response.Close();
                oW = JsonConvert.DeserializeObject<OpenWeather>(answer);
                ib.ImageSource = oW.weather[0].Icon;
            }
            catch (Exception ex) { MessageBox.Show("Что-то пошло не так, повторите попытку позже", "Ошибка");  }
        }
        public static OpenWeather ReturnWeather() { return oW; }
        public static ImageBrush ReturnImage() { return ib; }
    }
}
