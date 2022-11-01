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
        public String namecity;
        public static string selectedCity;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedCity = Cities.SelectedValue.ToString();
            switch (selectedCity)
            {
                case "Москва":
                    namecity = "Moscow";
                    break;
                case "Владимир":
                    namecity = "Vladimir";
                    break;
                case "Санкт - Петербург":
                    namecity = "Saint Petersburg";
                    break;
                case "Екатеринбург":
                    namecity = "Ekaterinburg";
                    break;
                case "Иваново":
                    namecity = "Ivanovo";
                    break;
                case "Псков":
                    namecity = "Pskov";
                    break;
                case "Тверь":
                    namecity = "Tver'";
                    break;
                case "Смоленск":
                    namecity = "Smolensk";
                    break;
                case "Сочи":
                    namecity = "Sochi";
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.cityname = namecity;
            window1.Show();
        }
    }
}
