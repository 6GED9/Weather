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
        public OpenWeather weather;
        public ImageBrush image;
        public string SomeClass;
        public Window1()
        {
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            weather = Vivod.ReturnWeather();
            image = Vivod.ReturnImage();
            if (weather != null)
            {
                switch (weather.weather[0].main)
                {
                    case "Clouds":
                        Background = new ImageBrush(new BitmapImage(new Uri("Resourses\\Sky\\CloudBackGround.png", UriKind.Relative)));
                        break;
                    case "Rain":
                        Background = new ImageBrush(new BitmapImage(new Uri("Resourses\\Sky\\RainBackGround.png", UriKind.Relative)));
                        break;
                    case "Snow":
                        Background = new ImageBrush(new BitmapImage(new Uri("Resourses\\Sky\\SnowBackGround.png", UriKind.Relative)));
                        break;
                    default:
                        Background = new ImageBrush(new BitmapImage(new Uri("Resourses\\Sky\\SunBackGround.png", UriKind.Relative)));
                        break;
                }
                weatherLabel.Content = weather.weather[0].description;
                weatherLabel1.Content = weather.weather[0].main;
                speed.Content = "Скорость (м/c): " + weather.wind.speed;
                vector.Content = "Направление °: " + weather.wind.deg;
                temperature.Content = "Средняя температура (°С): " + weather.main.temp.ToString("0.00");
                humidity.Content = "Влажность (%): " + weather.main.humidity;
                pressure.Content = "Давление (мм): " + weather.main.pressure.ToString("0");
                WeatherImage.Background = image;
            }
            else win.Close();
        }
    }
}
