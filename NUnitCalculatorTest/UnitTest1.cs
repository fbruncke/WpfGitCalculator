using NUnit.Framework;
using WpfGitCalculator;
using System.Windows.Input;


namespace NUnitCalculatorTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PressCalculateWithoutInput()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            mainWindowViewModel.CalcResult.Execute(null);

            Assert.AreEqual(mainWindowViewModel.Result, "0");
        }

        [Test]
        public void PressCalculateWithInput()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            mainWindowViewModel.UserInput = "11+11";
            mainWindowViewModel.CalcResult.Execute(null);

            Assert.AreEqual(mainWindowViewModel.Result, "22");
        }
    }
}