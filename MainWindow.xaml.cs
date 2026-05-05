using System.Security.Policy;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MoneyCalculator
{
    public partial class MainWindow : Window
    {
        private Money _currentMoney;

        public MainWindow()
        {
            InitializeComponent();
            this.Width = 800;
            this.Height = 600;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.ResizeMode = ResizeMode.CanResize; 
            _currentMoney = new Money(0, 0);
            UpdateDisplay();
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            _currentMoney = new Money(txtRubles.Text, txtKopeks.Text);
            UpdateDisplay();
        }

        private void BtnIncrement_Click(object sender, RoutedEventArgs e)
        {
            _currentMoney = _currentMoney.Add(1);
            UpdateDisplay();
        }

        private void BtnDecrement_Click(object sender, RoutedEventArgs e)
        {
            _currentMoney = _currentMoney.Subtract(1);
            UpdateDisplay();
        }

        private void BtnAddRubles_Click(object sender, RoutedEventArgs e)
        {
            if (uint.TryParse(txtRublesAmount.Text, out uint rubles))
            {
                _currentMoney = _currentMoney + rubles;
                UpdateDisplay();
            }
        }

        private void BtnSubtractRubles_Click(object sender, RoutedEventArgs e)
        {
            if (uint.TryParse(txtRublesAmount.Text, out uint rubles))
            {
                _currentMoney = _currentMoney - rubles;
                UpdateDisplay();
            }
        }

        private void BtnAddKopeks_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtKopeksAmount.Text, out int kopeks))
            {
                _currentMoney = _currentMoney.Add(kopeks);
                UpdateDisplay();
            }
        }

        private void BtnSubtractKopeks_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtKopeksAmount.Text, out int kopeks))
            {
                _currentMoney = _currentMoney.Subtract(kopeks);
                UpdateDisplay();
            }
        }

        private void BtnToDouble_Click(object sender, RoutedEventArgs e)
        {
            double value = _currentMoney;
            MessageBox.Show($"Значение в double: {value:F2}", "Конвертация");
        }

        private void BtnToUint_Click(object sender, RoutedEventArgs e)
        {
            uint value = (uint)_currentMoney;
            MessageBox.Show($"Значение в uint: {value}", "Конвертация");
        }

        private void UpdateDisplay()
        {
            txtCurrentMoney.Text = _currentMoney.ToString();
        }
    } 
}