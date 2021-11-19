using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfGitCalculator
{
    public class MainWindowViewModel : Bindable
    {
        //public List<String> CalculatorInput { get; set; } = new List<string>();

        private String userInput ="";

        public String UserInput
        {
            get { return userInput; }
            set { userInput = value;
                propertyIsChanged();
            }
        }

        private String result = "";

        public String Result
        {
            get { return result; }
            set { result = value;
                propertyIsChanged();
            }
        }


        public ICommand CalcResult => new Command(() => {

            List<Char> charInput = UserInput.ToList<Char>();
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
            this.Result = result.ToString();

        });


        public ICommand AddNo => new Command((Object obj) => {
            Button btn = obj as Button;
            if (btn != null)
            {
                UserInput += (btn.Content as String);
            }
        });

        public ICommand Clear => new Command(() => {
            this.UserInput = "";
        });


    }
}
