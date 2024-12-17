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
    /// Логика взаимодействия для AddYchet.xaml
    /// </summary>
    public partial class AddYchet : Page
    {
        Ychetn ych;
        bool checknew;
        public AddYchet(Ychetn s)
        {
            InitializeComponent();
            if (s == null)
            {
                s = new Ychetn();
                checknew = true;
            }
            else
                checknew = false;
            DataContext = ych;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (checknew)
            {
                Connect.context.Ychetn.Add(ych);
            }
            try
            {
                Connect.context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Nav.MainFrame.GoBack();
        }
        public static bool CheckAccounting(AppData.Ychetn inf)
        {
            if (string.IsNullOrEmpty(inf.Mesyac) || !inf.Mesyac.Replace(" ", "").All(char.IsLetter))
                return false;
            if (inf.nomer_licevogo_Scheta < 0)
                return false;
            if (inf.nomer_zapisi < 0)
                return false;
            if (inf.kolvo_kilovatt < 0)
                return false;
            if (string.IsNullOrEmpty(inf.Tariff) || !inf.Tariff.Replace(" ", "").All(char.IsLetter))
                return false;
            return true;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }
    }
}
