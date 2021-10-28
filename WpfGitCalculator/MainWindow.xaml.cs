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

namespace WpfGitCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public List<String> CalculatorInput { get; set; } = new List<string>();


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                lInput.Content += (btn.Content as String);
            }
        }

      
        


        private void Button_Click_Result(object sender, RoutedEventArgs e)
        {
            List<Char> charInput = lInput.Content.ToString().ToList<Char>();
            int no = 0;
            int no1 = 0;
            int no2 = 0;
            int result = 0;
            Char lastOperator = '!';

            foreach (var item in charInput)
            {
                if (item.Equals('+'))
                {
                    lastOperator = '+';
                    no2 = no1;
                    no1 = 0;
                }
                else if (item.Equals('-'))
                {
                    lastOperator = '-';
                    no2 = no1;
                    no1 = 0;
                }
                else if (int.TryParse(item.ToString(), out no))
                {
                    no1 = no1 * 10 + no;
                }
            }

            if (lastOperator.Equals('+'))
            {
                result = no2 + no1;
            }
            else if (lastOperator.Equals('-'))
            {
                result = no2 - no1;
            }


            this.lResult.Content = result;
        }
        private void Button_Clear(object sender, RoutedEventArgs e)
        {
            this.lInput.Content = "";
            
        }

        
    }
}
