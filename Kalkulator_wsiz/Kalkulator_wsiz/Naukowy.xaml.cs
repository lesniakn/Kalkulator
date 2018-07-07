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
    /**
* <p>
* Klasa NaukowyKalkulator - przechowujaca zmienne
* </p>
* <param name="a">Zmienna a przechowujaca wpis z klawiatury</param>
* <param name="ilog">Zmienna b przechowujaca logarytm </param>
* <param name="sqrt">Zmienna c przechowujaca pierwiastek</param>
* <param name="sin">Zmienna przechowujaca sin</param>
*/
    class NaukowyKalkulator
    {
        private Operation m_eLastOperationSelected = Operation.none;
        public double a;
        public double ilog;
        public double sqrt;
        public double sin;

    }
    /**
* <p>
* Klasa Naukowy
* </p>
*/
    public partial class Naukowy : Page
    {

        private Operation m_eLastOperationSelected = Operation.none;
        public Naukowy()
        {
            InitializeComponent();
        }
        /**
    * <p>
    * Funkcja NumberButton_Clic 
    * Obslugujaca przyciski numeryczne
    * </p>
@return Zwraca wcisnieta cyfre
*/
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

        /**
    * <p>
    * Funkcja CommaButton_Clic - obsluguje przycisk przecinka
    * </p>
    * <param name="txtDisplay">Pole wyswietlajace wpisywane cyfry</param>
     @return przecinek
*/
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
        /**
    * <p>
    * Funkcja ZeroButton_Clic obsluguje przycisk do wpisywania zera 
    * </p>
    * <param name="txtDisplay">Pole wyswietlajace wpisywane cyfry</param>
    @return Cyfra zero
*/
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

        /**
    * <p>
    * Funkcja EraseButton_Clic
    * </p>
    * <param name="txtDisplay">Pole wyswietlajace wpisywana cyfre</param>
    * <param name="txtDisplayMemory">Pole przechowujace ostatnio zaakceptowana cyfre </param>
    * <param name="txtDisplayOperation">Pole przechowujace znak funkcyjny</param>
@return Wyczyszczenie wszystkich pol 
*/
        private void EraseButton_Click(object oSender, RoutedEventArgs eRoutedEventArgs)
        {
            txtDisplay.Text = string.Empty;
            txtDisplayMemory.Text = string.Empty;
            txtDisplayOperation.Text = string.Empty;
            m_eLastOperationSelected = Operation.none;
        }
        /**
* <p>
* Funkcja obslugujaca przyciski funkcyjne "+", "-", "*", "/", "mod", "exp"
* </p>
* <param name="ResultButton_Click">funkcja przycisku "wynik"</param>
* <param name="addition">Funkcja dodawania</param>
* <param name="subtraction">Funkcja odejmowania </param>
* <param name="multiplication">Funkcja mnozenia </param>
* <param name="division">Funkcja dzielenia </param>
* <param name="mod">Funkcja dzielenia modulo</param>
* <param name="exp">Potegowanie</param>
@return Wpisany klawisz funkcyjny
*/
        private void OperationButton_Click(object oSender, RoutedEventArgs eRoutedEventArgs)
        {
            {
                /// sprawdzenie czy poprzednia operacja jest rozna od none i od wyniku, jeśli nie to wykonać pozostałe operacje
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

                        ///wypisywanie bledu
                    default:
                        MessageBox.Show("Nieznana operacja!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                }
                txtDisplayMemory.Text = txtDisplay.Text;
                txtDisplayOperation.Text = oButton.Content.ToString();
                txtDisplay.Text = string.Empty;
            }
        }
        /**
* <p>
* Funkcja obslugujaca przycisk
* </p>
* <param name="txtDisplay">Pole wyswietlajace wpisywane cyfry</param>
@return wynik
*/
        private void ResultButton_Click(object oSender, RoutedEventArgs eRoutedEventArgs)
        {
            /// Nie wykonywano żadnych operacji, nie można wyliczyć wyniku
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
        /**
* <p>
* Funkcja obslugujaca przycisk cofania
* </p>
* <param name="txtDisplay">Pole wyswietlajace wpisywane cyfry</param>
@return Usuniecie ostatniej wpisanej cyfry
*/
        private void BackspaceButton_Click(object sender, RoutedEventArgs e)
        {
            if (txtDisplay.Text.Length > 0)
            {
                txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.Text.Length - 1, 1);
            }
        }
        /**
* <p>
* Funkcja obslugujaca przycisk zamiany liczby na odwrotna
* </p>
* <param name="obiekt.a">Zmienna a</param>
* <param name="txtDisplay">Pole wyswietlajace wpisywane cyfry</param>
@return Liczba odwrotna
*/
        private void OneX_Button_Click(object sender, RoutedEventArgs e)
        {

            /// tworzenie onowego obiektu kalkulator
            NaukowyKalkulator obiekt = new NaukowyKalkulator();
            bool empty = String.IsNullOrEmpty(txtDisplay.Text);
            if (empty == true)
            {
                return;

            }
            else
            {
                Double a;
                obiekt.a = Convert.ToDouble(1.0 / Convert.ToDouble(txtDisplay.Text));
                txtDisplayOperation.Text = "reciproc" + "(" + txtDisplay.Text + ")";
                txtDisplay.Text = System.Convert.ToString(obiekt.a);
            }
        }
        /**
* <p>
* Funkcja obslugujaca przycisk wyczyszczenia textboxow
* </p>
* <param name="txtDisplay">Pole wyswietlajace wpisywane cyfry</param>
@return Puste textboxy
*/
        private void CleartxtDisplay_Button_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = string.Empty;
        }
        /**
* <p>
* Funkcja obslugujaca przycisk pierwsiatkowania
* </p>
* <param name="obiekt.sqrt">Zmienna sqrt</param>
* <param name="txtDisplay">Pole wyswietlajace wpisywane cyfry</param>
@return Pierwiastek wpisanej liczby
*/
        private void Sqrt_Button_Click(object sender, RoutedEventArgs e)
        {
            NaukowyKalkulator obiekt = new NaukowyKalkulator();
            bool empty = String.IsNullOrEmpty(txtDisplay.Text);
            if (empty == true)
            {
                return;

            }
            else
            {
                obiekt.sqrt = Double.Parse(txtDisplay.Text);
                obiekt.sqrt = Math.Sqrt(obiekt.sqrt);
                txtDisplayOperation.Text = ("Sqrt" + "(" + (txtDisplay.Text) + ")").ToString();
                txtDisplay.Text = obiekt.sqrt.ToString();

            }

        }
        /**
  * <p>
  * Funkcja obslugujaca zmiane znaku liczby
  * </p>
  * <param name="txtDisplay">Pole wyswietlajace wpisywane cyfry</param>
  * <param name="obiekt.a ">Zmienna a ( wpisana liczba )</param>
@return Liczba z zmienionym znakiem
*/
        private void Pos_Neg_Button_Click(object sender, RoutedEventArgs e)
        {
            NaukowyKalkulator obiekt = new NaukowyKalkulator();
            if (txtDisplay.Text != string.Empty)
            {
                if ((txtDisplay.Text.Contains('-')) ||
                    (0 == txtDisplay.Text.Length))
                {
                    obiekt.a = Convert.ToDouble(txtDisplay.Text);
                    obiekt.a = obiekt.a * (-1);
                    txtDisplay.Text = obiekt.a.ToString();
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
        /**
       * <p>
       * Funkcja obslugujaca przycisk logarytmowania
       * </p>
       * <param name="txtDisplay">Pole wyswietlajace wpisywane cyfry</param>
       * <param name="obiekt.ilog ">Zmienna ilog</param>
@return Logarytm liczby
*/
        private void Log_Button_Click(object sender, RoutedEventArgs e)
        {
            NaukowyKalkulator obiekt = new NaukowyKalkulator();
            bool empty = String.IsNullOrEmpty(txtDisplay.Text);
            if (empty == true)
            {
                return;

            }
            else
            {
                obiekt.ilog = Double.Parse(txtDisplay.Text);
                obiekt.ilog = Math.Log10(obiekt.ilog);
                txtDisplayOperation.Text = ("Log" + "(" + (txtDisplay.Text) + ")").ToString();
                txtDisplay.Text = obiekt.ilog.ToString();
            }

        }

        /**
            * <p>
            * Funkcja obslugujaca przyciski funkcji trygonometrycznych
            * </p>
            * <param name="txtDisplay">Pole wyswietlajace wpisywane cyfry</param>
            * <param name="sinh ">Zmienna singh</param>
@return Funkcja trygonometryczna sinus
*/

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
        /// <summary>
        /// Obliczanie sinusa
        /// </summary>
        private void Sin_Button_Click(object sender, RoutedEventArgs e)
        {
            NaukowyKalkulator obiekt = new NaukowyKalkulator();
            bool empty = String.IsNullOrEmpty(txtDisplay.Text);
            if (empty == true)
            {
                return;

            }
            else
            {
                obiekt.sin = Double.Parse(txtDisplay.Text);
                obiekt.sin = Math.Sin(obiekt.sin); // w radianach
                txtDisplayOperation.Text = ("Sin" + "(" + (txtDisplay.Text) + ")").ToString();
                txtDisplayMemory.Text = "Rad.";
                txtDisplay.Text = obiekt.sin.ToString();
            }
        }
        /// <summary>
        /// Obliczanie cosinusa
        /// </summary>
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
        /// <summary>
        /// Obliczanie tangensa
        /// </summary>
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
        /// <summary>
        /// Zamiana liczby w system binarny
        /// </summary>
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
        /// <summary>
        /// Zamiana liczby na system szesnastkowy
        /// </summary>
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

        /**
             * <p>
             * Funkcja obslugujaca przyciski potegowania
             * </p>
             * <param name="a">Zmienna a - liczba do potegowana</param>
@return wynik potegowania liczby
*/
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
        /**
                 * <p>
                 * Funkcja obslugujaca przyciski zmiany liczby na procent
                 * </p>
                 * <param name="a">Zmienna a - liczba do zamiany na procent</param>
@return procent wpisanej liczby
*/
        private void PercentButton_Click(object sender, RoutedEventArgs e)
        {
            NaukowyKalkulator obiekt = new NaukowyKalkulator();
            bool empty = String.IsNullOrEmpty(txtDisplay.Text);
            if (empty == true)
            {
                return;

            }
            else
            {

                obiekt.a = Convert.ToDouble(txtDisplay.Text) / Convert.ToDouble(100);
                txtDisplay.Text = System.Convert.ToString(obiekt.a);
            }
        }
        /**
                 * <p>
                 * Funkcja obslugujaca przyciski dodawania liczby pi
                 * </p>
@return Liczba pi
*/
        private void PI_Button_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = Math.PI.ToString();
        }
    }
}
