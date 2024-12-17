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
    /// Логика взаимодействия для AddSprav.xaml
    /// </summary>
    public partial class AddSprav : Page
    {
        Spravoch spr;
        bool checknew;
        public AddSprav(Spravoch s)
        {
            InitializeComponent();
            if (s == null)
            {
                spr = new Spravoch();
                checknew = true;
            }
            else
                checknew = false;
            DataContext = spr;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (checknew)
            {
                Connect.context.Spravoch.Add(spr);
            }
            try
            {
                Connect.context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(),"Ошибка",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            Nav.MainFrame.GoBack();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }
        
    }
}
