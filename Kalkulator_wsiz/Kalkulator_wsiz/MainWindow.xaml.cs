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
            if (txtDisplay.Text.Contains(','))
            {
                return;
            }
            if (txtDisplay.Text.Length != 0)
            {
                txtDisplay.Text += ",";
                return;

            }
            if (0 == txtDisplay.Text.Length)
            {
                txtDisplay.Text += "0,";
            }
        }
        private void ZeroButton_Click(object oSender, RoutedEventArgs eRoutedEventArgs)
        {
            if (Operation.result == m_eLastOperationSelected)
            {
                txtDisplay.Text = string.Empty;
                m_eLastOperationSelected = Operation.none;
            }
            if ((txtDisplay.Text.Contains('0')) & (1 == txtDisplay.Text.Length))
            {
                return;
            }
            if (0 != txtDisplay.Text.Length)
            {
                txtDisplay.Text += "0";
            }
            if (0 == txtDisplay.Text.Length)
            {
                txtDisplay.Text += "0";
            }                    
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
            {
                // sprawdzenie czy poprzednia operacja jest rozna od none i od wyniku, jeśli nie to wykonać pozostałe operacje
                if ((Operation.none != m_eLastOperationSelected) || (Operation.result != m_eLastOperationSelected))
                {
                    ResultButton_Click(this, eRoutedEventArgs);
                    //txtDisplayOperation.MaxLength = 1 ;

                }
                if (txtDisplay.Text == string.Empty)
                {
                    return;
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
            this.Width = 250;
            txtDisplay.Width = 210;
        }
        private void MenuItem_Scientific_Click(object sender, RoutedEventArgs e)
        {
            this.Width = 390;
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
            if (txtDisplay.Text != string.Empty)
            {
                if ((txtDisplay.Text.Contains('-')) ||
                    (0 == txtDisplay.Text.Length))
                {
                    double a = Convert.ToDouble(txtDisplay.Text);
                    a = a * (-1);
                    txtDisplay.Text = a.ToString();
                }

                else
                {
                    double a = Convert.ToDouble(txtDisplay.Text);
                    a = a * (-1);
                    txtDisplay.Text = a.ToString();
                }

            }
            else
            {
                return;
            }

        }

        private void Log_Button_Click(object sender, RoutedEventArgs e)
        {
            bool empty = String.IsNullOrEmpty(txtDisplay.Text);
            if (empty == true)
            {
                return;

            }
            else
            {
                double ilog = Double.Parse(txtDisplay.Text);
                ilog = Math.Log10(ilog);
                txtDisplayOperation.Text = ("Log" + "(" + (txtDisplay.Text) + ")").ToString();
                txtDisplay.Text = ilog.ToString();
            }

        }


        private void Sinh_Button_Click(object sender, RoutedEventArgs e)
        {
            bool empty = String.IsNullOrEmpty(txtDisplay.Text);
            if (empty == true)
            {
                return;

            }
            else
            {
                double sinh = Double.Parse(txtDisplay.Text);
                sinh = Math.Sinh(sinh);
                txtDisplayOperation.Text = ("Sinh" + "(" + (txtDisplay.Text) + ")").ToString();
                txtDisplay.Text = sinh.ToString();
            }
        }

        private void Sin_Button_Click(object sender, RoutedEventArgs e)
        {
            bool empty = String.IsNullOrEmpty(txtDisplay.Text);
            if (empty == true)
            {
                return;

            }
            else
            {
                double sin = Double.Parse(txtDisplay.Text);
                sin = Math.Sin(sin); // w radianach
                txtDisplayOperation.Text = ("Sin" + "(" + (txtDisplay.Text) + ")").ToString();
                txtDisplayMemory.Text = "Rad.";
                txtDisplay.Text = sin.ToString();
            }
        }

        private void Cos_Button_Click(object sender, RoutedEventArgs e)
        {
            bool empty = String.IsNullOrEmpty(txtDisplay.Text);
            if (empty == true)
            {
                return;

            }
            else
            {
                double cos = Double.Parse(txtDisplay.Text);
                cos = Math.Cos(cos); // w radianach
                txtDisplayOperation.Text = ("Cos" + "(" + (txtDisplay.Text) + ")").ToString();
                txtDisplayMemory.Text = "Rad.";
                txtDisplay.Text = cos.ToString();
            }
        }

        private void Cosh_Button_Click(object sender, RoutedEventArgs e)
        {
            bool empty = String.IsNullOrEmpty(txtDisplay.Text);
            if (empty == true)
            {
                return;

            }
            else
            {
                double cosh = Double.Parse(txtDisplay.Text);
                cosh = Math.Cosh(cosh); // w radianach
                txtDisplayOperation.Text = ("Cosh" + "(" + (txtDisplay.Text) + ")").ToString();
                txtDisplay.Text = cosh.ToString();
            }
        }

        private void Tanh_Button_Click(object sender, RoutedEventArgs e)
        {
            bool empty = String.IsNullOrEmpty(txtDisplay.Text);
            if (empty == true)
            {
                return;

            }
            else
            {
                double tanh = Double.Parse(txtDisplay.Text);
                tanh = Math.Tanh(tanh); // w radianach
                txtDisplayOperation.Text = ("tanh" + "(" + (txtDisplay.Text) + ")").ToString();
                txtDisplay.Text = tanh.ToString();
            }
        }

        private void Tan_Button_Click(object sender, RoutedEventArgs e)
        {
            bool empty = String.IsNullOrEmpty(txtDisplay.Text);
            if (empty == true)
            {
                return;

            }
            else
            {
                double tan = Double.Parse(txtDisplay.Text);
                tan = Math.Tan(tan); // w radianach
                txtDisplayOperation.Text = ("tan" + "(" + (txtDisplay.Text) + ")").ToString();
                txtDisplay.Text = tan.ToString();
            }
        }
        private void Bin_Button_Click(object sender, RoutedEventArgs e)
        {
            bool empty = String.IsNullOrEmpty(txtDisplay.Text);
            if (empty == true)
            {
                return;

            }
            else
            {
                int a = int.Parse(txtDisplay.Text);
                txtDisplay.Text = System.Convert.ToString(a, 2);
            }
        }

        private void Hex_Button_Click(object sender, RoutedEventArgs e)
        {
            bool empty = String.IsNullOrEmpty(txtDisplay.Text);
            if (empty == true)
            {
                return;

            }
            else
            {
                int a = int.Parse(txtDisplay.Text);
                txtDisplay.Text = System.Convert.ToString(a, 16);
            }
        }

        private void Oct_Button_Click(object sender, RoutedEventArgs e)
        {
            bool empty = String.IsNullOrEmpty(txtDisplay.Text);
            if (empty == true)
            {
                return;

            }
            else
            {
                int a = int.Parse(txtDisplay.Text);
                txtDisplay.Text = System.Convert.ToString(a, 8);
            }
        }
        private void x2_Button_Click(object sender, RoutedEventArgs e)
        {
            bool empty = String.IsNullOrEmpty(txtDisplay.Text);
            if (empty == true)
            {
                return;

            }
            else
            {
                Double a;
                a = Convert.ToDouble(txtDisplay.Text) * Convert.ToDouble(txtDisplay.Text);
                txtDisplayOperation.Text = txtDisplay.Text + "*" + txtDisplay.Text;
                txtDisplay.Text = System.Convert.ToString(a);
            }

        }
        private void PercentButton_Click(object sender, RoutedEventArgs e)
        {
            bool empty = String.IsNullOrEmpty(txtDisplay.Text);
            if (empty == true)
            {
                return;

            }
            else
            {
                Double a;
                a = Convert.ToDouble(txtDisplay.Text) / Convert.ToDouble(100);
                txtDisplay.Text = System.Convert.ToString(a);
            }
        }

        private void PI_Button_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = Math.PI.ToString();
        }
    }
}
    