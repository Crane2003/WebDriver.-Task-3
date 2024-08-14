using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.ComponentModel;

namespace WebDriver._Task_3.Pages
{
    public class EstimateSummaryPage
    {
        private readonly IWebDriver _driver;

        public EstimateSummaryPage(IWebDriver driver)
        {
            _driver = driver;
        }


        public bool GetSummary()
        {
            var expectedValues = new Dictionary<string, string>
{
    { "Number of instances", "4" },
    { "Operating System / Software", "Free: Debian, CentOS, CoreOS, Ubuntu or BYOL (Bring Your Own License)" },
    { "Provisioning model", "Regular" },
    { "Machine type", "n1-standard-8, vCPUs: 8, RAM: 30 GB" },
    { "GPU type", "NVIDIA V100" },
    { "Number of GPUs", "1" },
    { "Local SSD", "2x375 GB" },
    { "Region", "Netherlands (europe-west4)" }
};
            // Get the actual values from the page
            var actualValues = new Dictionary<string, string>();

            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(2));
            // Number of instances
            actualValues["Number of instances"] = wait.Until(drv => drv.FindElement(By.CssSelector("#yDmH0d > c-wiz.SSPGKf > div > div > div > div > div.qBohdf.AlLELb > div.oijjFb > div:nth-child(1) > div > div:nth-child(2) > div > div:nth-child(7) > span > span.Z7Pe2d.g5Ano > span.Kfvdz"))).Text;

            // Operating System / Software
            actualValues["Operating System / Software"] = _driver.FindElement(By.XPath("//*[@id=\"yDmH0d\"]/c-wiz[1]/div/div/div/div/div[2]/div[2]/div[1]/div/div[2]/div/div[8]/span/span[1]/span[2]")).Text;

            // Provisioning model
            actualValues["Provisioning model"] = _driver.FindElement(By.XPath("//*[@id=\"yDmH0d\"]/c-wiz[1]/div/div/div/div/div[2]/div[2]/div[1]/div/div[2]/div/div[9]/span/span[1]/span[2]")).Text;

            // Machine type
            actualValues["Machine type"] = _driver.FindElement(By.XPath("//*[@id=\"yDmH0d\"]/c-wiz[1]/div/div/div/div/div[2]/div[2]/div[1]/div/div[2]/div/div[3]/span[2]/span[1]/span[2]")).Text;

            // GPU type
            actualValues["GPU type"] = _driver.FindElement(By.XPath("//*[@id=\"yDmH0d\"]/c-wiz[1]/div/div/div/div/div[2]/div[2]/div[1]/div/div[2]/div/div[4]/span[2]/span[1]/span[2]")).Text;

            // Number of GPUs
            actualValues["Number of GPUs"] = _driver.FindElement(By.XPath("//*[@id=\"yDmH0d\"]/c-wiz[1]/div/div/div/div/div[2]/div[2]/div[1]/div/div[2]/div/div[4]/span[3]/span[1]/span[2]")).Text;

            // Local SSD
            actualValues["Local SSD"] = _driver.FindElement(By.XPath("//*[@id=\"yDmH0d\"]/c-wiz[1]/div/div/div/div/div[2]/div[2]/div[1]/div/div[2]/div/div[5]/span/span[1]/span[2]")).Text;

            // Region
            actualValues["Region"] = _driver.FindElement(By.XPath("//*[@id=\"yDmH0d\"]/c-wiz[1]/div/div/div/div/div[2]/div[2]/div[1]/div/div[2]/div/div[15]/span/span[1]/span[2]")).Text;

            // Compare actual values with expected values
            foreach (var key in expectedValues.Keys)
            {
                if (expectedValues[key].Trim() != actualValues[key].Trim())
                {
                    return false;
                }
            }

            return true;
        }
    }
}
