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
    /// Логика взаимодействия для LQS.xaml
    /// </summary>
    public partial class LQS : Page
    {
        public LQS()
        {
            InitializeComponent();
            var cmFil = Connect.context.Spravoch.OrderBy(x => x.FIO).ToList();
            Update();
        }
        void Update()
        {
            var i = Connect.context.Spravoch.ToList();
            if (!string.IsNullOrEmpty(MonTbx.Text))
            {
                i = i.Where(x => x.FIO.ToString().ToLower().Contains(MonTbx.Text.ToLower())).ToList();
            }
            SLV.ItemsSource = i;
        }
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }
        private void MonTbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void NameSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }
        private void FiltBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new LQSFILT());
        }
    }
}
