using SVDWPF.AppData;
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

namespace SVDWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new SPR());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new YCH());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new NavLQS());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new exPDF());
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }
    }
}
