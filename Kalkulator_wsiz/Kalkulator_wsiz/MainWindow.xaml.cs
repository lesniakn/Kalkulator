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

        private void CommaButton_Click(object oSender, RoutedEventArgs eRoutedEventArgs)
        {
            if (Operation.result == m_eLastOperationSelected)
            {
                txtDisplay.Text = string.Empty;
                m_eLastOperationSelected = Operation.none;
            }
            if ((txtDisplay.Text.Contains(',')) ||
                (0 == txtDisplay.Text.Length))
            {
                return;
            }
            txtDisplay.Text += ",";
        }

        private void EraseButton_Click(object oSender, RoutedEventArgs eRoutedEventArgs)
        {
            txtDisplay.Text = string.Empty;
            txtDisplayMemory.Text = string.Empty;
            txtDisplayOperation.Text = string.Empty;
            m_eLastOperationSelected = Operation.none;
        }

        private void OperationButton_Click(object oSender, RoutedEventArgs eRoutedEventArgs)
        {
            // sprawdzenie czy poprzednia operacja czy jest rozna od none i od wyniku, jeśli nie to wykonać pozostałe operacje
            if ((Operation.none != m_eLastOperationSelected) || (Operation.result != m_eLastOperationSelected))
            {
                ResultButton_Click(this, eRoutedEventArgs);
            }
            Button oButton = (Button)oSender;
            switch (oButton.Content.ToString())
            {
                case "+":
                    m_eLastOperationSelected = Operation.addition;
                    break;
                case "-":
                    m_eLastOperationSelected = Operation.subtraction;
                    break;
                case "*":
                    m_eLastOperationSelected = Operation.multiplication;
                    break;
                case "/":
                    m_eLastOperationSelected = Operation.division;
                    break;
                case "Mod":
                    m_eLastOperationSelected = Operation.mod;
                    break;
                case "Exp":
                    m_eLastOperationSelected = Operation.exp;
                    break;


                default:
                    MessageBox.Show("Nieznana operacja!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
            }
            txtDisplayMemory.Text = txtDisplay.Text;
            txtDisplayOperation.Text = oButton.Content.ToString();
            txtDisplay.Text = string.Empty;
        }

        private void ResultButton_Click(object oSender, RoutedEventArgs eRoutedEventArgs)
        {
            // Nie wykonywano żadnych operacji, nie można wyliczyć wyniku
            if ((Operation.result == m_eLastOperationSelected) ||
                (Operation.none == m_eLastOperationSelected))
            {
                return;
            }
            if (string.IsNullOrEmpty(txtDisplay.Text))
            {
                txtDisplay.Text = "0";
            }
            switch (m_eLastOperationSelected)
            {
                case Operation.addition:
                    txtDisplay.Text = (double.Parse(txtDisplayMemory.Text) +
                        double.Parse(txtDisplay.Text)).ToString();
                    break;
                case Operation.subtraction:
                    txtDisplay.Text = (double.Parse(txtDisplayMemory.Text) -
                        double.Parse(txtDisplay.Text)).ToString();
                    break;
                case Operation.multiplication:
                    txtDisplay.Text = (double.Parse(txtDisplayMemory.Text) *
                        double.Parse(txtDisplay.Text)).ToString();
                    break;
                case Operation.division:
                    txtDisplay.Text = (double.Parse(txtDisplayMemory.Text) /
                        double.Parse(txtDisplay.Text)).ToString();
                    break;
                case Operation.mod:
                    txtDisplay.Text = (double.Parse(txtDisplayMemory.Text) % double.Parse(txtDisplay.Text)).ToString();
                    break;
                case Operation.exp:
                    double i = Double.Parse(txtDisplay.Text);
                    double q;
                    q = double.Parse(txtDisplayMemory.Text);
                    txtDisplay.Text = Math.Exp(i * Math.Log(q * 4)).ToString();
                    break;


            }
            m_eLastOperationSelected = Operation.result;
            txtDisplayOperation.Text = string.Empty;
            txtDisplayMemory.Text = string.Empty;
        }

        private void BackspaceButton_Click(object sender, RoutedEventArgs e)
        {
            if (txtDisplay.Text.Length > 0)
            {
                txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.Text.Length - 1, 1);
            }
        }

        private void MenuItem_Standard_Click(object sender, RoutedEventArgs e)
        {
            this.Width = 240;
            txtDisplay.Width = 210;
        }

        private void OneX_Button_Click(object sender, RoutedEventArgs e)
        {
            bool empty = String.IsNullOrEmpty(txtDisplay.Text);
            if (empty == true)
            {
                return;

            }
            else
            {
                Double a;
                a = Convert.ToDouble(1.0 / Convert.ToDouble(txtDisplay.Text));
                txtDisplayOperation.Text = "reciproc" + "(" + txtDisplay.Text + ")";
                txtDisplay.Text = System.Convert.ToString(a);
            }
        }

        private void CleartxtDisplay_Button_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = string.Empty;
        }
        private void Sqrt_Button_Click(object sender, RoutedEventArgs e)
        {
            bool empty = String.IsNullOrEmpty(txtDisplay.Text);
            if (empty == true)
            {
                return;

            }
            else
            {
                double sqrt = Double.Parse(txtDisplay.Text);
                sqrt = Math.Sqrt(sqrt);
                txtDisplayOperation.Text = ("Sqrt" + "(" + (txtDisplay.Text) + ")").ToString();
                txtDisplay.Text = sqrt.ToString();

            }

        }

        private void Pos_Neg_Button_Click(object sender, RoutedEventArgs e)
        {


            if ((txtDisplay.Text.Contains('-')) ||
                (0 == txtDisplay.Text.Length))
            {
                return;
            }
            else
            {

                txtDisplay.Text = "-" + txtDisplay.Text;
            }



        }

    } }

