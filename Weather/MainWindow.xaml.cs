using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Weather
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string city;
        public string someWeather = "sun";
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            //window1.SomeClass = Vivod.VivodWeather(city);
            switch (someWeather)
            {
                case "clouds":
                    window1.Background = new ImageBrush(new BitmapImage(new Uri("Resourses\\Sky\\CloudBackGround.png", UriKind.Relative)));
                    break;
                case "rain":
                    window1.Background = new ImageBrush(new BitmapImage(new Uri("Resourses\\Sky\\RainBackGround.png", UriKind.Relative)));
                    break;
                case "snow":
                    window1.Background = new ImageBrush(new BitmapImage(new Uri("Resourses\\Sky\\SnowBackGround.png", UriKind.Relative)));
                    break;
                default:
                    window1.Background = new ImageBrush(new BitmapImage(new Uri("Resourses\\Sky\\SunBackGround.png", UriKind.Relative)));
                    break;
            }
            window1.Show();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (CityNameBox.Text == String.Empty)
                SelectButton.IsEnabled = false;
            else if (!SelectButton.IsEnabled)
                SelectButton.IsEnabled = true;
            city = CityNameBox.Text;
        }
    }
}
