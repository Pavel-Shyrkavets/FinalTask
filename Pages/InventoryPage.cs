using OpenQA.Selenium;

namespace FinalTask.Pages
{
    internal class InventoryPage
    {
        private static string Url { get; } = "https://www.saucedemo.com/inventory.html";
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
            return driver.FindElement(By.ClassName(dashboardTitleClassName)).Text;
        }
    }
}
