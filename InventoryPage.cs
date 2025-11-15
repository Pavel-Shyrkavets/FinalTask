using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FinalTask.Pages
{
    public class InventoryPage
    {
        private static string Url { get; } = Config.GetConfigValue("inventory_page_url");
        private readonly IWebDriver driver;
        private readonly string dashboardTitleClassName = "app_logo";

        public InventoryPage(IWebDriver driver) => this.driver = driver ?? throw new ArgumentException(nameof(driver));

        public InventoryPage Open()
        {
            driver.Url = Url;

            return this;
        }

        public string GetDashboardTitle()
        {
            IWebElement dashboardTitle = driver.FindElement(By.ClassName(dashboardTitleClassName));
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));

            wait.Until(d => dashboardTitle.Displayed);

            return dashboardTitle.Text;
        }
    }
}
