using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace MortgageCalculatorWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void AddConfChecked(object sender, RoutedEventArgs e)
        {
                add.Visibility = Visibility.Visible;
        }
        private void AddConfUnchecked(object sender, RoutedEventArgs e)
        {
            add.Visibility = Visibility.Hidden;
        }
        private void computeMortgage(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44322/");
        }
    }
}
