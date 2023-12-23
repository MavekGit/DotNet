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

namespace Szachy_Projekt
{
    /// <summary>
    /// Logika interakcji dla klasy startMenu.xaml
    /// </summary>
    public partial class startMenu : Page
    {
        public startMenu()
        {
            InitializeComponent();
        }

   

        private void goToGameMenu(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new gameMenu());

        }
    }
}
