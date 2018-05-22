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

namespace Kalkulator_wsiz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    enum Operation
    {
        none = 0, // brak operacji
        addition, // dodawanie
        subtraction, // odejmowanie
        multiplication, // mnożenie
        division, // dzielenie
        result, // wynik
        mod, //modulo
        exp //funkcja eksponencjalna


    }
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();
        }
        private void MenuItem_Standard_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Standard();
            this.Width = 287;
            this.Height = 400;

        }
        private void MenuItem_Scientific_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Naukowy();
            this.Width = 400;
            this.Height = 400;

        }

        private void MenuItem_Fkwad_Click(object sender, RoutedEventArgs e)
        {

            Main.Content = new Funkcja();
            this.Width = 800;
            this.Height = 550;

        }
    }
}
