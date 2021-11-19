using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WpfGitCalculator;

namespace UnitMSTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]        
        public void PressCalculateWithoutInput()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            mainWindowViewModel.CalcResult.Execute(null);

            Assert.AreEqual(mainWindowViewModel.Result, "0");
        }

        [TestMethod]
        public void PressCalculateWithInput()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            mainWindowViewModel.UserInput = "11+11";
            mainWindowViewModel.CalcResult.Execute(null);

            Assert.AreEqual(mainWindowViewModel.Result, "22");
        }
    }
}
