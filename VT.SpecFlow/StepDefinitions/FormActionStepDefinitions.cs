using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Net;
using VT.SpecFlow.Helpers;
using VT.SpecFlow.Strategies.FormActionStrategies;
using System.Diagnostics;
using System.Xml.Linq;
using System.Runtime.Intrinsics.X86;
using OpenQA.Selenium.Interactions;


namespace VT.SpecFlow.StepDefinitions
{
    [Binding]
    public class FormActionStepDefinitions
    {
        readonly IWebDriver _driver;
        private readonly FeatureContext _notebook;
        private IWebDriver driver;

        public FormActionStepDefinitions(IWebDriver webDriver, FeatureContext notebook)
        {
            _driver = webDriver;
            _notebook = notebook;
            _notebook["VT Order Id"] = "535810";
        }

        private IFormActionStrategy GetStrategy()
        {
            var siteContext = _notebook["Site Context"].ToString() ?? string.Empty;
            FormActionStrategyFactory factory = new FormActionStrategyFactory(_driver);
            return factory.GetStrategy(siteContext);
        }

        [Given(@"I wait '([^']*)' seconds")]
        [When(@"I wait '([^']*)' seconds")]
        [Then(@"I wait '([^']*)' seconds")]
        public void GivenIWaitSeconds(int seconds)
        {
            Thread.Sleep(seconds * 1000);
        }

        [Given(@"I refresh the page")]
        public void GivenIRefreshThePage()
        {
            _driver.Navigate().Refresh();
            Thread.Sleep(5000);
        }
        [When(@"I refresh the page")]
        public void WhenIRefreshThePage()
        {
            Thread.Sleep(5000);
            _driver.Navigate().Refresh();
            Thread.Sleep(5000);
        }

        [Given(@"I click the '([^']*)' button")]
        [When(@"I click the '([^']*)' button")]
        [Then(@"I click the '([^']*)' button")]
        public void GivenIClickTheButton(string buttonText)
        {
            GetStrategy().GivenIClickTheButton(buttonText);
        }

        [Given(@"I click the '([^']*)' '([^']*)' button")]
        [When(@"I click the '([^']*)' '([^']*)' button")]
        [Then(@"I click the '([^']*)' '([^']*)' button")]
        public void GivenIClickTheButton(string second, string search)
        {
            GetStrategy().GivenIClickTheButton(second, search);
        }

        [Given(@"I wait for page to load")]
        [When(@"I wait for page to load")]
        public void WhenIWaitForPageToLoad()
        {
            GetStrategy().GivenIWaitForPageDataToLoad();
        }

        [Given(@"I click on the ellipsis menu")]
        public void GivenIClickOnTheEllipsisMenu()
        {
            GetStrategy().GivenIClickOnTheEllipsisMenu();
        }

        [Given(@"I select '([^']*)' from the ellipsis menu")]
        public void GivenISelectFromTheEllipsisMenu(string item)
        {
            GetStrategy().GivenISelectFromTheEllipsisMenu(item);
        }

        [Given(@"I close the '([^']*)'")]
        public void GivenICloseThe(string target)
        {
            GetStrategy().GivenICloseThe(target);
        }

        [Given(@"I select '([^']*)' from the '([^']*)' dropdown")]
        public void GivenISelectFromTheDropdown(string item, string dropdown)
        {
            GetStrategy().GivenISelectFromTheDropdown(item, dropdown);
        }

        [Given(@"I select '([^']*)' from the '([^']*)' '([^']*)' dropdown")]
        public void GivenISelectFromTheDropdown(string item, string elementIndex, string dropdown)
        {
            GetStrategy().GivenISelectFromTheDropdown(item, elementIndex, dropdown);
        }

        [Given(@"I select the '([^']*)' row from the table")]
        [When(@"I select the '([^']*)' row from the table")]
        public void GivenISelectRowFromTheTable(string value)
        {
            GetStrategy().GivenISelectRowFromTheTable(value);
        }

        [Given(@"I enter '([^']*)' with current time into the '([^']*)' field")]
        [When(@"I enter '([^']*)' with current time into the '([^']*)' field")]
        public void GivenIEnterWithCurrentTimeIntoTheField(string text, string field)
        {
            GetStrategy().GivenIEnterWithCurrentTimeIntoTheField(text, field);
        }

        [Given(@"I enter a future date into the '([^']*)' field")]
        public void GivenIEnterFutureDateIntoTheField(string field)
        {
            GetStrategy().GivenIEnterFutureDateIntoTheField(field);
        }

        [Given(@"I click the '([^']*)' tab")]
        public void GivenIClickTheTab(string tab)
        {
            GetStrategy().GivenIClickTheTab(tab);
        }

        [Given(@"I enter '([^']*)' into the '([^']*)' field")]
        [When(@"I enter '([^']*)' into the '([^']*)' field")]
        public void GivenIEnterIntoTheField(string text, string field)
        {
            GetStrategy().GivenIEnterIntoTheField(text, field);
        }

        [Given(@"I expand the '([^']*)' panel")]
        public void GivenIExpandThePanel(string panel)
        {
            GetStrategy().GivenIExpandThePanel(panel);
        }

        [Given(@"I check the '([^']*)' checkbox")]
        public void GivenICheckTheCheckbox(string checkbox)
        {
            GetStrategy().GivenICheckTheCheckbox(checkbox);
        }

        [Given(@"I enter current date at 08:30:00 in the '([^']*)' Field")]
        public void GivenIEnterTodayDateReceivedField(string field)
        {
            GetStrategy().GivenIEnterTodayDateReceivedField(field);
        }

        [Given(@"I navigate to the '([^']*)' Screen")]
        [When(@"I navigate to the '([^']*)' Screen")]
        public void GivenNavigatesToScreen(string screen)
        {
            GetStrategy().GivenNavigatesToScreen(screen);
        }

        [When(@"I filter '([^']*)' by '([^']*)'")]
        [Given(@"I filter '([^']*)' by '([^']*)'")]
        public void GivenIFilterBy(string filter, string value)
        {
            GetStrategy().GivenIFilterBy(filter, value);
        }

        [When(@"I filter the date '([^']*)' by '([^']*)'")]
        [Given(@"I filter the date '([^']*)' by '([^']*)'")]
        public void GivenIFilterTheDateBy(string filter, string value)
        {
            GetStrategy().GivenIFilterTheDateBy(filter, value);
        }

        [When(@"I click on the '([^']*)' radio button")]
        [Given(@"I click on the '([^']*)' radio button")]
        public void GivenIClickOnTheRadioButton(string button)
        {
            GetStrategy().GivenIClickOnTheRadioButton(button);
        }

        [When(@"I click on the '([^']*)' '([^']*)' radio button")]
        [Given(@"I click on the '([^']*)' '([^']*)' radio button")]
        public void GivenIClickOnTheRadioButton(string position, string button)
        {
            GetStrategy().GivenIClickOnTheRadioButton(position, button);
        }
        [Given(@"I click on the '([^']*)' checkbox")]
        public void GivenIClickOnTheCheckbox(string ValidRateChkBoX)
        {
            IWebElement ValidRate = _driver.FindElement(By.XPath("//input[@id='"+ ValidRateChkBoX + "']"));
            ValidRate.Click();
        }

        [When(@"I click on hamburger view menu")]
        public void WhenIClickOnHamburgerViewMenu()
        {
            IWebElement gridToolBar = _driver.FindElement(By.XPath("//button[@title='Choose the fields to be shown in this view']"));
            gridToolBar.Click();
        }

        [When(@"I click on the '([^']*)' '([^']*)'")]

        public void WhenIClickOnThe(string strTitle, string tagname)
        {
            IWebElement gridToolBar = _driver.FindElement(By.XPath("//"+tagname+"[@title='"+strTitle+"']"));
            gridToolBar.Click();
        }
        
        
        [When(@"I enter '([^']*)' into the '([^']*)'")]
        public void WhenIEnterIntoThe(string compNo, string company)
        {
            IWebElement comp = _driver.FindElement(By.XPath("//label[text()='" + company + "']/following::input[1]"));

            comp.Click();
            Thread.Sleep(10000);
            comp.Clear();
            Thread.Sleep(10000);
            comp.SendKeys(compNo);
            Thread.Sleep(30000);
            comp.SendKeys(Keys.Insert);
            Thread.Sleep(10000);
            comp.SendKeys(Keys.Tab);
            Thread.Sleep(1000);            
        }

        [Then(@"I verify Pdf should open in another tab")]
        public void ThenIVerifyPdfShouldOpenInAnotherTab()
        {
            Thread.Sleep(10000);
            System.Collections.ObjectModel.ReadOnlyCollection<string> listHandles = _driver.WindowHandles;
            _driver.SwitchTo().Window(listHandles[1]); //switch to 2nd tab
            var url = _driver.Url;
            Thread.Sleep(30000);
            Assert.True(url.Contains("/Pdf"), "Not navigated to PDF");
           
        }



        [When(@"I select Customer '([^']*)' '([^']*)'")]
        public void WhenISelectCustomer(string custName, string custNum)
        {
            Thread.Sleep(3000);
            IWebElement CustSelect = _driver.FindElement(By.XPath("//span[normalize-space()='"+custName+"']['"+custNum+"'] "));
            Console.WriteLine(CustSelect.Text);

            Thread.Sleep(5000);
            Actions action = new Actions(_driver);
            action.MoveToElement(CustSelect).Build().Perform();
            CustSelect.Click();
        }

        [Then(@"I verify EDI Customer '([^']*)'")]
        public void ThenIVerifyEDICustomer(string option)
        {


            //twoversion
            var inputElement = _driver.FindElement(By.XPath("//label[text()='EDI Customer']/following::input[1]"));
            var value = inputElement.GetAttribute("value");
            if (value == "No")
            {
                Assert.True(value == "No", value);
                Console.WriteLine($"Input Value: {value}");
            }
            if (value == "Yes")
            {
                Assert.True(value == "Yes", value);
                Console.WriteLine($"Input Value: {value}");
            }

        }

        private object SelectElement(IWebElement webElement)
        {
            throw new NotImplementedException();
        }

        public void ClickonViewSelectionArrow()
        {
            IWebElement viewArrow = _driver.FindElement(By.XPath("//div[@class='button-group switch-view ng-star-inserted']//button[@id='button']"));
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", viewArrow);

        }
        [When(@"I click the view selection icon")]
        public void WhenIClickTheViewSelectionIcon()
        {
            ClickonViewSelectionArrow();
        }

        [When(@"I Select the '([^']*)' button")]
        public void WhenISelectTheButton(string viewType)
        {
            Thread.Sleep(5000);
            ClickonViewSelectionArrow();
            IList<IWebElement> listListView = _driver.FindElements(By.XPath("//div[contains(text(),'List View')]"));
            IList<IWebElement> tableViewList = _driver.FindElements(By.XPath("//div[contains(text(),'Table View')]"));

            switch (viewType)
            {
                case "Table View":
                    if (tableViewList.Count > 0)
                    {
                        tableViewList[0].Displayed.Should().BeTrue();
                        tableViewList[0].Click(); //Click on TableView
                    }
                    else
                    {
                        ClickonViewSelectionArrow();
                        Thread.Sleep(2000);
                        ClickonViewSelectionArrow();
                        listListView = _driver.FindElements(By.XPath("//div[contains(text(),'List View')]"));
                        listListView[0].Click();
                        ClickonViewSelectionArrow();

                        Thread.Sleep(2000);
                        tableViewList = _driver.FindElements(By.XPath("//div[contains(text(),'Table View')]"));


                        tableViewList[0].Displayed.Should().BeTrue();
                        tableViewList[0].Click(); //Click on Table View
                    }
                    break;

                case "List View":
                    if (tableViewList.Count > 0)
                    {
                        //ClickonViewSelectionArrow();
                        tableViewList[0].Click();
                        ClickonViewSelectionArrow();
                        listListView = _driver.FindElements(By.XPath("//div[contains(text(),'List View')]"));
                        listListView[0].Click();

                    }
                    else
                    {
                        listListView[0].Click();
                    }
                    break;

            }

        }


        [When(@"I Select the ""([^""]*)""")]
        
        public void WhenISelectThe(string viewType)
        {
            Thread.Sleep(5000);
            ClickonViewSelectionArrow();
            IList<IWebElement> listListView = _driver.FindElements(By.XPath("//div[contains(text(),'List View')]"));
            IList<IWebElement> tableViewList = _driver.FindElements(By.XPath("//div[contains(text(),'Table View')]"));

            switch (viewType)
            {
                case "Table View":
                    if (tableViewList.Count > 0)
                    {
                        tableViewList[0].Displayed.Should().BeTrue();
                        tableViewList[0].Click(); //Click on TableView
                    }
                    else
                    {
                        ClickonViewSelectionArrow();
                        listListView = _driver.FindElements(By.XPath("//div[contains(text(),'List View')]"));
                        listListView[0].Click();
                        ClickonViewSelectionArrow();

                        Thread.Sleep(2000);
                        tableViewList = _driver.FindElements(By.XPath("//div[contains(text(),'Table View')]"));


                        tableViewList[0].Displayed.Should().BeTrue();
                        tableViewList[0].Click(); //Click on ListView
                    }
                    break;

                case "List View":
                    if (tableViewList.Count > 0)
                    {
                        //ClickonViewSelectionArrow();
                        tableViewList[0].Click();
                        ClickonViewSelectionArrow();
                        listListView = _driver.FindElements(By.XPath("//div[contains(text(),'List View')]"));
                        listListView[0].Click();

                    }
                    else
                    {
                        listListView[0].Click();
                    }
                    break;

            }

        }

    }
}
