using FinalTask.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

[assembly: Parallelize]
namespace FinalTask.Tests
{   
    [TestClass]
    public sealed class IndexPageTests
    {
        private readonly IWebDriver chromeDriver = new ChromeDriver();
        private readonly IWebDriver firefoxDriver = new FirefoxDriver();
        private readonly string errorMessage = "Username and password do not match any user in this service";
        private readonly string title = "Swag Labs";
        private readonly string credentials = Config.GetConfigValue("credentials");

        [TestCleanup]
        [TestMethod]
        public void Login_WithoutCredentials_ErrorMessageAppears()
        {
            var indexPage = new IndexPage(chromeDriver);

            indexPage.Open().InputCredentials(credentials, credentials);
            indexPage.ClearCredentials();
            indexPage.ClickLoginButton();

            var fullErrorMessage = indexPage.GetFullErrorMessage();

            Assert.Contains(errorMessage, fullErrorMessage);      
        }

        [TestMethod]
        public void Login_WithoutPassword_ErrorMessageAppears()
        {
            var indexPage = new IndexPage(chromeDriver);

            indexPage.Open().InputCredentials(credentials, credentials);
            indexPage.ClearPassword();
            indexPage.ClickLoginButton();

            var fullErrorMessage = indexPage.GetFullErrorMessage();

            Assert.Contains(errorMessage, fullErrorMessage); 
        }

        [DataRow(Constants.FIRST_USERNAME, Constants.PASSWORD)]
        [DataRow(Constants.SECOND_USERNAME, Constants.PASSWORD)]
        [DataRow(Constants.THIRD_USERNAME, Constants.PASSWORD)]
        [DataRow(Constants.FOURTH_USERNAME, Constants.PASSWORD)]
        [DataRow(Constants.FIFTH_USERNAME, Constants.PASSWORD)]
        [TestMethod]
        public void Login_WithValidCredentials_ErrorMessageAppears(string username, string password)
        {
            var indexPage = new IndexPage(firefoxDriver);

            indexPage.Open().InputCredentials(username, password);
            indexPage.ClickLoginButton();

            var inventoryPage = new InventoryPage(firefoxDriver);
            var titleInDashboard = inventoryPage.GetDashboardTitle();

            Assert.AreEqual(title, titleInDashboard);
        }
    }
}
