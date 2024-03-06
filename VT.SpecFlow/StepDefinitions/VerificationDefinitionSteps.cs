using OpenQA.Selenium;
using System.Collections.ObjectModel;
using VT.SpecFlow.Strategies.VerificationStrategies;
using System.Drawing;
using Assert = NUnit.Framework.Assert;

namespace VT.SpecFlow.StepDefinitions
{
    [Binding]
    public  class VerificationDefinitionSteps
    {
        readonly IWebDriver _driver;
        internal readonly FeatureContext _notebook;

        public VerificationDefinitionSteps(IWebDriver webDriver, FeatureContext notebook)
        {
            _driver = webDriver;
            _notebook = notebook;
        }

        private IVerificationStrategy GetStrategy()
        {
            var siteContext = _notebook["Site Context"].ToString() ?? string.Empty;
            VerificationStrategyFactory factory = new VerificationStrategyFactory(_driver);
            return factory.GetStrategy(siteContext);
        }

        /// <example>
        /// And I verify table contains below information
		/// | Type  | Region   | Customer                | Project Name   | Status |
		/// | Order | VT Doors | A.G. Mauro - Pittsburgh | AutomatedTest  | Open   |
        /// </example>
        [Given(@"I verify table contains below information")]
        public void GivenIVerifyTableContainsBelowInformation(Table table)
        {
            GetStrategy().GivenIVerifyTableContainsBelowInformation(table);
        }

        /// <example>
        /// And I verify if the following columns are blank
		///       | Column       | IsBlank |
		///       | Line         | false   |
		///       | Ship Date    | true    |
		///       | Cost         | false   |
        /// </example>
        [Given(@"I verify if the following columns are blank")]
        public void GivenIVerifyIfTheFollowingColumnsAreBlank(Table table)
        {
            GetStrategy().GivenIVerifyIfTheFollowingColumnsAreBlank(table);
        }
        [Then(@"I verify '([^']*)' is displayed")]
        public void GivenIVerifyIsDisplayed(string elementText)
        {
            IWebElement element = _driver.FindElement(By.XPath("//div[text()='" + elementText + "']"));
            if (element.Size != Size.Empty)
            {
                Console.WriteLine(element.Text + "is displayed");
                element.Click();

            }
            else
            {
                Assert.Fail();
            }
        }

        [Then(@"I verify that the table contains records")]
        public void ThenIVerifyThatTheTableContainsRecords()
        {
            GetStrategy().ThenIVerifyThatTheTableContainsRecords();
        }
    }
}
