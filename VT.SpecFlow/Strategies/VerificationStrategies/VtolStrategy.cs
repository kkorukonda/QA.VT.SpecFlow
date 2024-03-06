using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using VT.SpecFlow.Helpers;

namespace VT.SpecFlow.Strategies.VerificationStrategies
{
    internal class VtolStrategy : VerificationStrategy, IVerificationStrategy
    {
        public VtolStrategy(IWebDriver webDriver) : base(webDriver)
        {
        }

        public void GivenIVerifyTableContainsBelowInformation(Table table)
        {
            var headers = table.Header;
            var rows = table.Rows;

            var StepDefinitionsHelpers = new StepDefinitionsHelpers(_driver);

            foreach (var row in rows)
            {
                foreach (var header in headers)
                {
                    var filterElement = _driver.FindElement(By.XPath($"//input[@placeholder='{header}']"));

                    StepDefinitionsHelpers.PerformJavaScriptScroll(filterElement);
                    filterElement.SendKeys(row[header].ToString());
                }

                var recordExist = 0 == _driver.FindElements(By.XPath("//div[@class='empty-row ng-star-inserted' and text()='No data to display']")).Count;
                Assert.True(recordExist, "Table does not contain the expected information.");

                foreach (var header in headers)
                {
                    IWebElement filterElement = _driver.FindElement(By.XPath($"//input[@placeholder='{header}']"));
                    Actions actions = new Actions(_driver);
                    actions.MoveToElement(filterElement);
                    actions.Perform();

                    filterElement.Clear();
                }
            }
        }

        public void GivenIVerifyIfTheFollowingColumnsAreBlank(Table table)
        {
            var rows = table.Rows;

            foreach (var row in rows)
            {
                string columnName = row["Column"];
                bool exceptedOutcome = bool.Parse(row["IsBlank"]);

                bool isActuallyBlank = string.IsNullOrEmpty(GetColumnValue(columnName));

                Assert.Equal(exceptedOutcome, isActuallyBlank);
            }
        }
        private string GetColumnValue(string columnName)
        {
            var table = _driver.FindElement(By.XPath("//ngx-datatable"));
            var headers = GetHeaders(table);
            var columns = table.FindElements(By.XPath("//datatable-body-cell//div[span]/span"));
            return columns[headers.IndexOf(columnName)].Text;
        }

        private static List<string> GetHeaders(IWebElement table)
        {
            var inputs = table.FindElements(By.XPath("//datatable-header-cell/div/mat-form-field/div[1]/div[2]/div/input"));
            var headers = new List<string>();

            foreach (var item in inputs)
            {
                headers.Add(item.GetAttribute("placeholder"));
            }

            return headers;
        }

        public void ThenIVerifyThatTheTableContainsRecords()
        {
            throw new PendingStepException();
        }
    }
}
