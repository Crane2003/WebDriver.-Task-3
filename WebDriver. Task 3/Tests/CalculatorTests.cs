using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriver._Task_3.Pages;

namespace WebDriver._Task_3.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        private IWebDriver _driver;
        private CalculatorPage _calculatorPage;
        private EstimateSummaryPage _estimateSummaryPage;

        [TestInitialize]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _calculatorPage = new CalculatorPage(_driver);
            _estimateSummaryPage = new EstimateSummaryPage(_driver);
        }

        [TestCleanup]
        public void Teardown()
        {
            _driver.Quit();
        }

        [TestMethod]
        public void VerifyCostEstimate()
        {
            _calculatorPage.Open();
            _calculatorPage.AddComputeEngine();
            _calculatorPage.FillForm();
            _calculatorPage.SubmitAndVerify();

            // Switch to the new tab
            var windows = _driver.WindowHandles;
            _driver.SwitchTo().Window(windows[1]);

            // Verify the estimate summary
            bool summary = _estimateSummaryPage.GetSummary();
            Assert.IsTrue(summary);
        }
    }
}
