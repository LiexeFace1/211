using SVDWPF.AppData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для LQSFILT.xaml
    /// </summary>
    public partial class LQSFILT : Page
    {
        private ObservableCollection<Spravoch> spravoch;
        public LQSFILT()
        {
            InitializeComponent();
            spravoch = new ObservableCollection<Spravoch>(Connect.context.Spravoch.ToList());
            SLV.ItemsSource = spravoch;
            var fioList = Connect.context.Spravoch.OrderBy(x => x.FIO).ToList();
            fioList.Insert(0, new Spravoch { FIO = "По умолчанию" });
            NameSort.ItemsSource = fioList;
            NameSort.DisplayMemberPath = "FIO";
            NameSort.SelectedValuePath = "FIO";
            NameSort.SelectedIndex = 0;
        }
        void Update()
        {
            var selectedFIO = (NameSort.SelectedItem as Spravoch)?.FIO ?? "";
            SLV.ItemsSource = new ObservableCollection<Spravoch>(spravoch.Where(x =>
                string.IsNullOrEmpty(selectedFIO) || x.FIO.ToLower().Contains(selectedFIO.ToLower())
            ));
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }
        private void NameSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }
    }
}
