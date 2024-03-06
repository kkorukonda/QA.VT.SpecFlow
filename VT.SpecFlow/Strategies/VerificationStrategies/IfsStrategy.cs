using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Text.RegularExpressions;
using VT.SpecFlow.Helpers;

namespace VT.SpecFlow.Strategies.VerificationStrategies
{
    internal class IfsStrategy : VerificationStrategy, IVerificationStrategy
    {
        private int _noSuchElementExceptionCount = 0;

        public IfsStrategy(IWebDriver webDriver) : base(webDriver)
        {
        }

        public void GivenIVerifyTableContainsBelowInformation(Table table)
        {
            var headers = table.Header;
            var rows = table.Rows;

            foreach (var row in rows)
            {
                foreach (var header in headers)
                {
                    var expectedOutcome = row[header];

                    var headerElement = _driver.FindElement(By.XPath($"//fnd-header-cell[.//div[contains(@class, 'label') and text()='{header}']]"));
                    var id = Regex.Match(headerElement.GetAttribute("id"), @"[^|]*$").Value;

                    Actions actions = new Actions(_driver);
                    actions.MoveToElement(headerElement).Perform();

                    IWebElement recordElement = MoveScrollToElement($"//fnd-static-field[contains(@id, '{id}')]", "//div[contains(@class, 'scrollbar-content')]");
                    var lastDeepestNodes = recordElement.FindElements(By.XPath(".//*[not(*)]"));
                    var lastDeepestNode = lastDeepestNodes.LastOrDefault();

                    Thread.Sleep(2000);
                    actions.MoveToElement(lastDeepestNode).Perform();
                    string? actualOutcome = lastDeepestNode?.Text.Trim();

                    Assert.Equal(expectedOutcome, actualOutcome);
                }
            }
        }

        private IWebElement MoveScrollToElement(string elementXpath, string scrollbarXpath)
        {
            try
            {
                IWebElement recordElement = _driver.FindElement(By.XPath(elementXpath));
                return recordElement;
            }
            catch (NoSuchElementException)
            {
                _noSuchElementExceptionCount++;
                if(_noSuchElementExceptionCount <= 10)
                {
                    var scrollbarElement = _driver.FindElement(By.XPath(scrollbarXpath));
                    scrollbarElement.Click();

                    Actions actions = new Actions(_driver);
                    actions.SendKeys(scrollbarElement, Keys.Right)
                           .SendKeys(scrollbarElement, Keys.Right)
                           .SendKeys(scrollbarElement, Keys.Right)
                           .Perform();

                    return MoveScrollToElement(elementXpath, scrollbarXpath);
                }
                else
                {
                    throw new InvalidOperationException("Exceeded maximum retries for NoSuchElementException");
                }
            }
            finally
            {
                _noSuchElementExceptionCount = 0;
            }
        }

        public void GivenIVerifyIfTheFollowingColumnsAreBlank(Table table)
        {
            var rows = table.Rows;

            foreach (var row in rows)
            {
                bool exceptedOutcome = bool.Parse(row["IsBlank"]);

                var headerElement = _driver.FindElement(By.XPath($"//fnd-header-cell[.//div[contains(@class, 'label') and text()='{row["Column"]}']]"));
                var id = Regex.Match(headerElement.GetAttribute("id"), @"[^|]*$").Value;

                Actions actions = new Actions(_driver);
                actions.MoveToElement(headerElement).Perform();

                var recordElement = MoveScrollToElement($"//fnd-static-field[contains(@id, '{id}')]", "//div[contains(@class, 'scrollbar-content')]");
                var lastDeepestNode = recordElement.FindElements(By.XPath(".//*[not(*)]")).LastOrDefault();

                Thread.Sleep(2000);
                actions.MoveToElement(lastDeepestNode).Perform();
                string? columnElement = lastDeepestNode?.Text.Trim();

                bool isActuallyBlank = string.IsNullOrEmpty(columnElement);
                Assert.Equal(exceptedOutcome, isActuallyBlank);
            }

        }

        public void ThenIVerifyThatTheTableContainsRecords()
        {
            var rows = _driver.FindElements(By.TagName("fnd-row"));
            Assert.NotEmpty(rows);
        }

    }
}
