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
    /// Логика взаимодействия для LQY.xaml
    /// </summary>
    public partial class LQY : Page
    {
            public LQY()
            {
                InitializeComponent();
                FioFlit.ItemsSource = new[] { "По умолчанию", "По возврастанию", "По убыванию" };
                FioFlit.SelectedIndex = 0;
            }

            void Update()
            {
            var ac = Connect.context.Ychetn.ToList();

            if (FioFlit.SelectedItem != null && FioFlit.SelectedItem is ComboBoxItem selectedItem)
            {
                string selectedTariff = selectedItem.Content.ToString();
                ac = ac.Where(x => x.Tariff.Contains(selectedTariff)).ToList();
            }

            if (!string.IsNullOrEmpty(FiOTbx.Text))
            {
                ac = ac.Where(x => x.Tariff.Contains(FiOTbx.Text)).ToList();
            }

            switch (FioFlit.SelectedIndex)
            {
                case 1:
                    ac = ac.OrderBy(x => x.Tariff).ToList(); 
                    break;
                case 2:
                    ac = ac.OrderByDescending(x => x.Tariff).ToList();
                    break;
            }

                    YLV.ItemsSource = ac;
            }

            private void FioFlit_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                Update();
            }

            private void FiOTbx_TextChanged(object sender, TextChangedEventArgs e)
            {
                Update();
            }

            private void Tarif_TextChanged(object sender, TextChangedEventArgs e)
            {
                Update();
            }

            private void Name_TextChanged(object sender, TextChangedEventArgs e)
            {
                Update();
            }

            private void BackBtn_Click(object sender, RoutedEventArgs e)
            {
                Nav.MainFrame.GoBack();
            }
        }    
}