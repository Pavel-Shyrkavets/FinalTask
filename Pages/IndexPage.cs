using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace FinalTask.Pages
{
    public class IndexPage
    {
        private static string Url { get; } = "https://www.saucedemo.com/";
        private readonly IWebDriver driver;
        private readonly int timeSpanInSeconds = 1;
        private readonly string usernameId = "user-name";
        private readonly string passwordId = "password";
        private readonly string loginButtonId = "login-button";
        private readonly string errorMessageClassName = "error-message-container";

        public IndexPage(IWebDriver driver) => this.driver = driver ?? throw new ArgumentException(nameof(driver));

        public IndexPage Open()
        {
            driver.Url = Url;

            return this;
        }

        public void InputCredentials(string username, string password)
        {
            var usernameInputField = driver.FindElement(By.Id(usernameId));
            var passwordInputField = driver.FindElement(By.Id(passwordId));
            var clickAndSendKeysActions = new Actions(driver);

            clickAndSendKeysActions
                .Click(usernameInputField)
                .Pause(TimeSpan.FromSeconds(timeSpanInSeconds))
                .SendKeys(username)
                .Click(passwordInputField)
                .Pause(TimeSpan.FromSeconds(timeSpanInSeconds))
                .SendKeys(password)
                .Perform();
        }

        public void ClearCredentials()
        {
            driver.FindElement(By.Id(usernameId)).Clear();
            driver.FindElement(By.Id(passwordId)).Clear();
        }

        public void ClearPassword()
        {
            driver.FindElement(By.Id(passwordId)).Clear();
        }

        public void ClickLoginButton()
        {
            var loginButton = driver.FindElement(By.Id(loginButtonId));

            loginButton.Click();
        }

        public string GetFullErrorMessage()
        {
            var fullErrorMessage = driver.FindElement(By.ClassName(errorMessageClassName)).Text;

            return fullErrorMessage;
        }
    }
}
