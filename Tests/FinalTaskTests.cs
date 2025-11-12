using FinalTask.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace FinalTask.Tests
{
    [TestClass]
    public sealed class IndexPageTests
    {
        private readonly IWebDriver chromeDriver = new ChromeDriver();
        private readonly IWebDriver firefoxDriver = new FirefoxDriver();
        private readonly string credentials = "Automation";
        private readonly string errorMessage = "Username is required";
        private readonly string errorPasswordMessage = "Password is required";
        private readonly string title = "Swag Labs";

        [TestMethod]
        public void Login_WithoutCredentials_ErrorMessageAppears()
        {
            try
            {
                var indexPage = new IndexPage(chromeDriver);

                indexPage.Open().InputCredentials(credentials, credentials);
                indexPage.ClearCredentials();
                indexPage.ClickLoginButton();

                var fullErrorMessage = indexPage.GetFullErrorMessage();

                Assert.Contains(fullErrorMessage, errorMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                chromeDriver.Quit();
            }
        }

        [TestMethod]
        public void Login_WithoutPassword_ErrorMessageAppears()
        {
            try
            {
                var indexPage = new IndexPage(chromeDriver);

                indexPage.Open().InputCredentials(credentials, credentials);
                indexPage.ClearPassword();
                indexPage.ClickLoginButton();

                var fullPasswordErrorMessage = indexPage.GetFullErrorMessage();

                Assert.Contains(fullPasswordErrorMessage, errorPasswordMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                chromeDriver.Quit();
            }
        }

        [DataRow("standard_user", "secret_sauce")]
        [DataRow("locked_out_user", "secret_sauce")]
        [DataRow("problem_user", "secret_sauce")]
        [DataRow("performance_glitch_user", "secret_sauce")]
        [DataRow("error_user", "secret_sauce")]
        [DataRow("visual_user", "secret_sauce")]
        [TestMethodAttribute]
        public void Login_WithValidCredentials_ErrorMessageAppears(string username, string password)
        {
            try
            {
                var indexPage = new IndexPage(firefoxDriver);

                indexPage.Open().InputCredentials(username, password);
                indexPage.ClickLoginButton();

                var inventoryPage = new InventoryPage(firefoxDriver);
                var titleInDashboard = inventoryPage.GetDashboardTitle();

                Assert.AreEqual(titleInDashboard, title);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                firefoxDriver.Quit();
            }
        }
    }
}
