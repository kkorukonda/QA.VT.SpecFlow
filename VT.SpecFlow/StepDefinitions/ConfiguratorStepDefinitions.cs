using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using VT.SpecFlow.Helpers;

namespace VT.SpecFlow.StepDefinitions
{
    /// <summary>
    /// The "Configurator" refers to the system embedded in VTOL use to 
    /// enter product specifications.  
    /// </summary>
    [Binding]
    public class ConfiguratorStepDefinitions
    {
        readonly IWebDriver _driver;
        readonly string _iframeXPath;

        public ConfiguratorStepDefinitions(IWebDriver webDriver)
        {
            _driver = webDriver;
            _iframeXPath = "//iframe[contains(@src,'vtindustries.com')]";
        }

        [Given(@"I select '([^']*)' from the '([^']*)' configurator dropdown")]
        public void GivenISelectFromTheConfiguratorDropdown(string text, string dropdown)
        {
            var stepDefinitionsHelpers = new StepDefinitionsHelpers(_driver);

            stepDefinitionsHelpers.SwitchToIframeAndBack(_iframeXPath, wait =>
            {
                var dropdownElement = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//span[@class='question-text' and contains(text(),'{dropdown}')]/following::input[@type='text']")));

                dropdownElement.SendKeys(text);
                dropdownElement.SendKeys(Keys.Tab);
            });
        }

        [Given(@"I click the '([^']*)' configurator button")]
        public void GivenIClickTheConfiguratorButton(string button)
        {
            var stepDefinitionsHelpers = new StepDefinitionsHelpers(_driver);

            stepDefinitionsHelpers.SwitchToIframeAndBack(_iframeXPath, wait =>
            {
                var buttonElement = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//button[text()='{button}']")));

                stepDefinitionsHelpers.PerformJavaScriptClick(buttonElement);
            });
        }

        [Given(@"I enter '([^']*)' into the '([^']*)' configurator field")]
        public void GivenIEnterIntoTheConfiguratorField(string text, string field)
        {
            var stepDefinitionsHelpers = new StepDefinitionsHelpers(_driver);

            stepDefinitionsHelpers.SwitchToIframeAndBack(_iframeXPath, wait =>
            {
                var dropdownElement = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//span[@class='question-text' and contains(text(),'{field}')]/following::input[@type='text']")));

                dropdownElement.SendKeys(text);
                dropdownElement.SendKeys(Keys.Tab);
            });
        }

        [Given(@"I enter '([^']*)' and '([^']*)' into the '([^']*)' configurator fields")]
        public void GivenIEnterAndIntoTheConfiguratorFields(string firstValue, string secondValue, string label)
        {
            var stepDefinitionsHelpers = new StepDefinitionsHelpers(_driver);

            stepDefinitionsHelpers.SwitchToIframeAndBack(_iframeXPath, wait =>
            {
                var fieldElement = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//span[@class='question-text' and contains(text(),'{label}')]/following::input[@type='text']")));

                fieldElement.SendKeys(firstValue);
                fieldElement.SendKeys(Keys.Tab);

                fieldElement = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//span[@class='question-text' and contains(text(),'{label}')]/following::input[@type='text'][2]")));

                fieldElement.SendKeys(secondValue);
                fieldElement.SendKeys(Keys.Tab);
            });
        }
    }
}
