using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Text.RegularExpressions;

namespace VT.SpecFlow.Strategies.NotebookStrategies
{
    internal class IfsStrategy : NotebookStrategy, INotebookStrategy
    {
        public IfsStrategy(IWebDriver webDriver, FeatureContext notebook) : base(webDriver, notebook)
        {
        }

        public void GivenIRecordTheFieldInTheNotebookAs(string field, string name)
        {
            throw new PendingStepException();
        }

        public void GivenIFilterByTheValueRecordedInTheNotebook(string filter, string record)
        {
            IWebElement moreSpanElement = _driver.FindElement(By.XPath("//fnd-more-fields-button//span[text()='More']"));
            moreSpanElement.Click();

            IWebElement searchInputElement = _driver.FindElement(By.XPath("//input[@type='search' and @placeholder='Filter fields']"));
            searchInputElement.SendKeys(filter);

            IWebElement checkboxIconElement = _driver.FindElement(By.XPath($"//div[contains(@class, 'more-fields')]//label[contains(., '{filter}')]/i"));
            var isChecked = checkboxIconElement.GetAttribute("class").Contains("icon-check");

            if (!isChecked)
            {
                checkboxIconElement.Click();
            }
            else
            {
                IWebElement filterElement = _driver.FindElement(By.XPath($"//div[contains(@class, 'header-label') and @title='{filter}']"));
                filterElement.Click();
            }

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(60));
            searchInputElement = wait.Until(ExpectedConditions.ElementExists(By.XPath("div[contains(@class, 'options-pane')]//input")));
            searchInputElement.SendKeys(_notebook[record].ToString());
            searchInputElement.SendKeys(Keys.Enter);
        }

        public void GivenIRecordTheColumnInTheNotebookAs(string column, string name)
        {
            var headerElement = _driver.FindElement(By.XPath($"//fnd-header-cell[.//div[contains(@class, 'label') and text()='{column}']]"));
            var id = Regex.Match(headerElement.GetAttribute("id"), @"[^|]*$").Value;
            var recordElement = _driver.FindElement(By.XPath($"//fnd-static-field[contains(@id, '{id}')]"));
            var lastDeepestNode = recordElement.FindElements(By.XPath(".//*[not(*)]")).LastOrDefault();

            Actions actions = new Actions(_driver);
            actions.MoveToElement(lastDeepestNode).Perform();
            _notebook[column] = lastDeepestNode?.Text ?? "";
        }
    }
}
