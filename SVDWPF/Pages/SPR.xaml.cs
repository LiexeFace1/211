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
    /// Логика взаимодействия для SPR.xaml
    /// </summary>
    public partial class SPR : Page
    {
        public SPR()
        {
            InitializeComponent();
            ClientsLV.ItemsSource = Connect.context.Spravoch.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new AddSprav(null));
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new AddSprav((sender as Button).DataContext as Spravoch));
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            var delClients = ClientsLV.SelectedItems.Cast<Spravoch>().ToList();
            foreach (var delClient in delClients)
                if (Connect.context.Ychetn.Any(x => x.nomer_licevogo_Scheta == delClient.nomer_licevogo_scheta))
                {
                    MessageBox.Show("Данные используются в таблице", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            if (MessageBox.Show($"Удалить {delClients.Count} записей", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                Connect.context.Spravoch.RemoveRange(delClients);
            try
            {
                Connect.context.SaveChanges();
                ClientsLV.ItemsSource = Connect.context.Spravoch.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RefBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ClientsLV.ItemsSource = Connect.context.Spravoch.ToList();
        }

        private void PDFBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }
    }
}
