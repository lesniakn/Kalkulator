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
        private Operation m_eLastOperationSelected = Operation.none;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberButton_Click(object oSender, RoutedEventArgs eRoutedEventArgs)
        {
            if (Operation.result == m_eLastOperationSelected)
            {
                txtDisplay.Text = string.Empty;
                m_eLastOperationSelected = Operation.none;
            }
            Button oButton = (Button)oSender;
            txtDisplay.Text += oButton.Content;
        }

        private void MenuItem_Standard_Click(object sender, RoutedEventArgs e)
        {
            this.Width = 240;
            txtDisplay.Width = 210;
        }

    }
}
