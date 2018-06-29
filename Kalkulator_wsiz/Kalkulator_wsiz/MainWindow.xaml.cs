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

    /// <summary>
    /// Operacje
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
    /// <summary>
    /// Klasa menu, przechowuje wysokosc i szerokosc okna.
    /// </summary>
    class Menu
    {
        public int wysokosc;
        public int szerokosc;
    }

    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Funkcja wywolujaca okno kalkulatora prostego. 
        /// </summary>
        private void MenuItem_Standard_Click(object sender, RoutedEventArgs e)
        {
            Menu standardowe = new Menu();
            standardowe.szerokosc = 400;
            standardowe.wysokosc = 287;
            Main.Content = new Standard();
            this.Width = standardowe.wysokosc;
            this.Height = standardowe.szerokosc;

        }
        /// <summary>
        /// Funkcja wywolujaca okno kalkulatora naukowego
        /// </summary>
        private void MenuItem_Scientific_Click(object sender, RoutedEventArgs e)
        {
            Menu Naukowy = new Menu();
            Naukowy.szerokosc = 400;
            Naukowy.wysokosc = 400;
            Main.Content = new Naukowy();
            this.Width = Naukowy.szerokosc;
            this.Height = Naukowy.wysokosc;

        }
        /// <summary>
        /// Funkcje wywolujace okno funkcji kwadratowej 
        /// </summary>
        private void MenuItem_Fkwad_Click(object sender, RoutedEventArgs e)
        {

            Menu Naukowy = new Menu();
            Naukowy.szerokosc = 800;
            Naukowy.wysokosc = 550;
            Main.Content = new Funkcja();
            this.Width = Naukowy.szerokosc;
            this.Height = Naukowy.wysokosc;

        }
    }
}
