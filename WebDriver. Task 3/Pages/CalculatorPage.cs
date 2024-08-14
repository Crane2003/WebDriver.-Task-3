using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Reflection.Metadata;

namespace WebDriver._Task_3.Pages
{
    public class CalculatorPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public CalculatorPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
        }

        private IWebElement AddToEstimateButton => _driver.FindElement(By.CssSelector(".UywwFc-LgbsSe.UywwFc-LgbsSe-OWXEXe-Bz112c-M1Soyc.UywwFc-LgbsSe-OWXEXe-dgl2Hf.xhASFc"));
        private IWebElement ComputeEngineLink;
        private IWebElement InstancesField;
        private IWebElement OSDropDown;
        private IWebElement ProvisioningModel;
        private IWebElement MachineFamilyDropdown;
        private IWebElement SeriesDropdown;
        private IWebElement MachineTypeDropdown;
        private IWebElement AddGPUsButton;
        private IWebElement GPUTypeDropdown;
        private IWebElement NumberOfGPUsDropdown;
        private IWebElement LocalSSDDropdown;
        private IWebElement RegionDropdown;
        private IWebElement EstimateButton;
        private IWebElement ShareButton;


        public void Open()
        {
            _driver.Navigate().GoToUrl("https://cloud.google.com/products/calculator/");
        }

        public void AddComputeEngine()
        {
            AddToEstimateButton.Click();
            ComputeEngineLink = _driver.FindElement(By.CssSelector(".aHij0b-aGsRMb"));
            _wait.Until(drv => ComputeEngineLink.Displayed && ComputeEngineLink.Enabled);
            ComputeEngineLink.Click();
        }



        
    public void FillForm()
        {
            GetFormElements();

            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].value='4';", InstancesField);

            // Select OS
            SelectOS();

            // Provisioning model
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", ProvisioningModel);

            // Machine Family
            MachineFamilyDropdown.Click();
            _driver.FindElement(By.XPath("//*[@id=\"ucj-1\"]/div/div/div/div/div/div/div/div[1]/div/div[2]/div[3]/div[11]/div/div/div[2]/div/div[1]/div[1]/div/div/div/div[2]/ul/li[1]")).Click();

            // Series
            SeriesDropdown.Click();
            _driver.FindElement(By.XPath("//*[@id=\"ucj-1\"]/div/div/div/div/div/div/div/div[1]/div/div[2]/div[3]/div[11]/div/div/div[2]/div/div[1]/div[2]/div/div/div/div[2]/ul/li[1]")).Click();

            // Machine Type
            MachineTypeDropdown.Click();
            _driver.FindElement(By.XPath("//*[@id=\"ucj-1\"]/div/div/div/div/div/div/div/div[1]/div/div[2]/div[3]/div[11]/div/div/div[2]/div/div[1]/div[3]/div/div/div/div[2]/ul/li[7]")).Click();

            // Add GPU Toggle
            AddGPUsButton.Click();

            GetGPUForm();

            // GPU Model
            GPUTypeDropdown.Click();
            _driver.FindElement(By.XPath("//*[@id=\"ucj-1\"]/div/div/div/div/div/div/div/div[1]/div/div[2]/div[3]/div[23]/div/div[1]/div/div/div/div[2]/ul/li[2]")).Click();

            // Number of GPUs
            NumberOfGPUsDropdown.Click();
            _driver.FindElement(By.XPath("//*[@id=\"ucj-1\"]/div/div/div/div/div/div/div/div[1]/div/div[2]/div[3]/div[24]/div/div[1]/div/div/div/div[2]/ul/li[1]")).Click();

            // Local SSD
            LocalSSDDropdown.Click();
            _driver.FindElement(By.XPath("//*[@id=\"ucj-1\"]/div/div/div/div/div/div/div/div[1]/div/div[2]/div[3]/div[27]/div/div[1]/div/div/div/div[2]/ul/li[3]")).Click();

            // Region
            RegionDropdown.Click();
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", _driver.FindElement(By.XPath("//*[@id=\"ucj-1\"]/div/div/div/div/div/div/div/div[1]/div/div[2]/div[3]/div[29]/div/div[1]/div/div/div/div[2]/ul/li[5]")));
            Thread.Sleep(2000);
        }

        private void SelectOS()
        {
            string textToMatch = "Free: Debian, CentOS, CoreOS, Ubuntu or BYOL (Bring Your Own License)";
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript($@"
    var items = document.querySelectorAll('li.MCs1Pd');
    for (var i = 0; i < items.length; i++) {{
        if (items[i].innerText.includes('{textToMatch}')) {{
            items[i].click();
            break;
        }}
    }}");
        }

        public void SubmitAndVerify()
        {
            
            ShareButton = _driver.FindElement(By.CssSelector("[aria-label='Open Share Estimate dialog']"));
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", ShareButton);
 
            EstimateButton = _wait.Until(drv => drv.FindElement(By.CssSelector(".tltOzc.MExMre.rP2xkc.jl2ntd")));
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", EstimateButton);
        }

        public void GetFormElements()
        {
            Thread.Sleep(2000);
            InstancesField = _driver.FindElement(By.CssSelector(".qdOxv-fmcmS-wGMbrd"));
            OSDropDown = _driver.FindElement(By.CssSelector(".VfPpkd-uusGie-fmcmS-haAclf"));
            ProvisioningModel = _driver.FindElement(By.XPath("//*[@id=\"ow5\"]/div/div/div/div/div/div/div[1]/div/div[2]/div[3]/div[9]/div/div/div[2]/div/div/div[1]/label"));
            MachineFamilyDropdown = _driver.FindElement(By.CssSelector("[jsname='Wsw6tc']"));
            SeriesDropdown = _driver.FindElement(By.CssSelector("[jsname='vGGDlb']"));
            MachineTypeDropdown = _driver.FindElement(By.CssSelector("[jsname='kgDJk']"));
            AddGPUsButton = _driver.FindElement(By.XPath("//*[@id=\"ucj-1\"]/div/div/div/div/div/div/div/div[1]/div/div[2]/div[3]/div[21]/div/div/div[1]/div/div/span/div/button"));
        }

        public void GetGPUForm()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(3));
            
            GPUTypeDropdown = wait.Until(drv => drv.FindElement(By.XPath("//*[@id=\"ucj-1\"]/div/div/div/div/div/div/div/div[1]/div/div[2]/div[3]/div[23]/div/div[1]/div/div/div/div[1]/div")));
            NumberOfGPUsDropdown = _driver.FindElement(By.XPath("//*[@id=\"ucj-1\"]/div/div/div/div/div/div/div/div[1]/div/div[2]/div[3]/div[24]/div/div[1]/div/div/div/div[1]/div"));
            LocalSSDDropdown = _driver.FindElement(By.XPath("//*[@id=\"ucj-1\"]/div/div/div/div/div/div/div/div[1]/div/div[2]/div[3]/div[27]/div/div[1]/div/div/div/div[1]/div"));
            RegionDropdown = _driver.FindElement(By.XPath("//*[@id=\"ucj-1\"]/div/div/div/div/div/div/div/div[1]/div/div[2]/div[3]/div[29]/div/div[1]/div/div/div/div[1]/div"));
        }
    }
}
