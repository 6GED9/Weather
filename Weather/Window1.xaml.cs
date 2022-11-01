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
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public String cityname;
        public Window1()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            label8.Content = MainWindow.selectedCity;
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

            Weather.OpenWeather oW = JsonConvert.DeserializeObject<Weather.OpenWeather>(answer);

            ImageBrush ib = new ImageBrush();
            ib.ImageSource = oW.weather[0].Icon;
            panel1.Background = ib;

            label1.Content = oW.weather[0].main;
            label2.Content = oW.weather[0].description;
            label3.Content = "Средняя температура (°С): " + oW.main.temp.ToString("0.##");
            label6.Content = "Скорость (м/c): " + oW.wind.speed.ToString();
            label7.Content = "Направление °: " + oW.wind.deg.ToString();
            label4.Content = "Влажность (%): " + oW.main.humidity.ToString();
            label5.Content = "Давление (мм): " + ((int)oW.main.pressure).ToString();
        }
    }
}
