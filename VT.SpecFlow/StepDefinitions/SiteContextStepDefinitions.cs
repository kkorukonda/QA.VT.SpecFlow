using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using NUnit.Framework;

using Assert = NUnit.Framework.Assert;
using AngleSharp.Dom;
using AngleSharp.Io;
namespace VT.SpecFlow.StepDefinitions
{
    /// <summary>
    /// Steps that modify site context
    /// </summary>
    [Binding]
    public class SiteContextStepDefinitions
    {
        readonly IWebDriver _driver;
        readonly FeatureContext _notebook;
        readonly AppRunConfigHelper _appRunConfigHelper;

        public SiteContextStepDefinitions(IWebDriver webDriver, FeatureContext notebook)
        {
            _driver = webDriver;
            _notebook = notebook;
            _appRunConfigHelper = new AppRunConfigHelper();
        }

        [Given(@"User Visits VTOnline")]
        public void GivenUserVisitsVTOnline()
        {
            _driver.Url = _appRunConfigHelper.GetApplUrl(AppName.Vtol);
            _notebook["Site Context"] = "VTOL";
        }

        [Given(@"User Visits IFS")]

        public void GivenUserVisitsIFS()
        {
            _driver.Url = _appRunConfigHelper.GetApplUrl(AppName.Ifs);
            _notebook["Site Context"] = "IFS";
        }
        [Given(@"I click the '([^']*)' image")]
        [When(@"I click the '([^']*)' image")]
        public void GivenIClickTheImage(string imageId)
        {

            var imgElement = _driver.FindElement(By.Id(imageId));
            imgElement.Click();
            _driver.Manage().Window.Maximize();

        }

        [Given(@"I log into VTOL")]
        public void GivenUserIsLoggedinOnVTOnline()
        {
            _notebook["Site Context"] = "VTOL";

            string email = "SQAssurance@vtindustries.com";
            string password = "sh!nyBrain34";

            try
            {
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(60));

                var emailTextbox = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("Username")));
                emailTextbox.SendKeys(email);

                var passwordTextbox = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("Password")));
                passwordTextbox.SendKeys(password);

                var loginButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@type='submit' and @value='login']")));
                loginButton.Click();
            }
            catch (NoSuchElementException)
            {
                // continue
            }
        }

        [Given(@"I log into IFS")]
        [When(@"I log into IFS")]
        public void WhenILogIntoIFS()
        {
            _notebook["Site Context"] = "IFS";

            string email = "kkorukonda@vtindustries.com";
            string password = "H0lste1n!";

            try
            {
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(60));
                var emailTextbox = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("loginfmt")));
                emailTextbox.SendKeys(email);

                Thread.Sleep(1000);
                IWebElement srchIcon = _driver.FindElement(By.XPath("//input[@id='idSIButton9']"));
                srchIcon.Click();
                var passwordTextbox = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("credentials.passcode")));
                passwordTextbox.SendKeys(password);

                var loginButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@type='submit' and @value='Sign in']")));
                loginButton.Click();
               
                Thread.Sleep(50000);
                
            }
            catch (NoSuchElementException) { /* continue */ }
            catch (WebDriverTimeoutException) { /* continue */ }
        }

        [When(@"I click the ""([^""]*)"" button")]
        [Then(@"I click the ""([^""]*)"" button")]
        public void GivenIClickTheButton(string btnName)
        {

            IWebElement srchIcon = _driver.FindElement(By.XPath("//div[@title='" + btnName + "']"));
            srchIcon.Click();
        }

        [Given(@"I open IFS in a new browser tab")]
        public void GivenIOpenIFSInANewBrowserTab()
        {
            var siteTab = $"{_notebook["Site Context"]} Browser Tab";
            _notebook[siteTab] = _driver.CurrentWindowHandle;

            ((IJavaScriptExecutor)_driver).ExecuteScript("window.open();");

            _notebook["IFS Browser Tab"] = _driver.WindowHandles.LastOrDefault();
            _driver.SwitchTo().Window(_notebook["IFS Browser Tab"].ToString());

            _driver.Navigate().GoToUrl("https://ifs-dev.vtindustries.com/main/ifsapplications/web/start");

            _notebook["Site Context"] = "IFS";
        }

        [Given(@"I switch back to the '([^']*)' browser tab")]
        public void GivenISwitchBackToTheBrowserTab(string site)
        {
            _driver.SwitchTo().Window(_notebook[$"{site} Browser Tab"].ToString());
            _notebook["Site Context"] = site;
        }
    }
}


