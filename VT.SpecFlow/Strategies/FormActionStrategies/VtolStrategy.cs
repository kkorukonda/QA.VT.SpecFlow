using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Globalization;
using VT.SpecFlow.Helpers;

namespace VT.SpecFlow.Strategies.FormActionStrategies
{
    internal class VtolStrategy : FormActionStrategy, IFormActionStrategy
    {
        public VtolStrategy(IWebDriver webDriver) : base(webDriver)
        {
        }

        public void GivenICheckTheCheckbox(string checkbox)
        {
            var checkboxElement = _driver.FindElement(By.XPath($"//label[text() = '{checkbox}']//preceding-sibling::div/input"));
            checkboxElement.Click();
        }
        public void GivenIClickTheElementByXpath(string strXpath)
        {
            var dropdownElement = _driver.FindElement(By.XPath($"+ strXpath+"));
            dropdownElement.Click();
        }
        public void GivenIClickOnTheEllipsisMenu()
        {
            var ellipsisElement = _driver.FindElement(By.XPath("//button[.//mat-icon[text()='more_vert']]"));
            var stepDefinitionsHelpers = new StepDefinitionsHelpers(_driver);
            stepDefinitionsHelpers.PerformJavaScriptClick(ellipsisElement);
        }

        public void GivenIClickTheButton(string button)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(60));
            var buttonElement = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//span[contains(.,'{button}')]")));

            var stepDefinitionHelpers = new StepDefinitionsHelpers(_driver);
            stepDefinitionHelpers.PerformJavaScriptClick(buttonElement);
        }

        public void GivenIClickTheButton(string position, string button)
        {
            throw new PendingStepException();
        }

        public void GivenIClickTheTab(string tab)
        {
            var tabElement = _driver.FindElement(By.XPath($"//a[@class='nav-link' and ./strong[text()='{tab}']]"));

            var stepDefinitionHelpers = new StepDefinitionsHelpers(_driver);
            stepDefinitionHelpers.PerformJavaScriptClick(tabElement);
        }

        public void GivenICloseThe(string target)
        {
            throw new PendingStepException();
        }

        public void GivenIEnterFutureDateIntoTheField(string field)
        {
            var stepDefinitionsHelpers = new StepDefinitionsHelpers(_driver);

            stepDefinitionsHelpers.HandleStaleElementReferenceException(() =>
            {
                var fieldElement = _driver.FindElement(By.XPath($"//mat-label[contains(text(), '{field}')]/ancestor::div[contains(@class, 'mat-mdc-form-field-infix')]/input"));

                fieldElement.SendKeys(Keys.Control + "a");
                fieldElement.SendKeys($"{DateTime.Now.AddDays(6).ToLocalTime().ToString("M/d/yyyy")}");
                fieldElement.SendKeys(Keys.Tab);
            });
        }

        public void GivenIEnterIntoTheField(string text, string field)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(60));
            var fieldElement = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//mat-label[contains(text(), '{field}')]/ancestor::div[contains(@class, 'mat-mdc-form-field-infix')]/input")));

            fieldElement.SendKeys(text);
            fieldElement.SendKeys(Keys.Tab);
        }

        public void GivenIEnterTodayDateReceivedField(string field)
        {
            var fieldElement = _driver.FindElement(By.XPath($"//input[@placeholder='{field}']"));

            DateTime currentDate = DateTime.Now;
            DateTime desiredDateTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 8, 30, 0, DateTimeKind.Local);
            fieldElement.SendKeys(desiredDateTime.ToString("M/d/yyyy, HH:mm:ss", CultureInfo.InvariantCulture));
        }

        public void GivenIEnterWithCurrentTimeIntoTheField(string text, string field)
        {
            var fieldElement = _driver.FindElement(By.XPath($"//mat-label[contains(text(), '{field}')]/ancestor::div[contains(@class, 'mat-mdc-form-field-infix')]/input"));
            fieldElement.SendKeys($"{text} {DateTime.Now.ToLocalTime().ToString("yyMMddHHmmss")}");
            fieldElement.SendKeys(Keys.Tab);
        }

        public void GivenIExpandThePanel(string panel)
        {
            var panelElement = _driver.FindElement(By.XPath($"//mat-panel-title[contains(normalize-space(), '{panel}')]/ancestor::mat-expansion-panel-header"));

            var stepDefinitionsHelpers = new StepDefinitionsHelpers(_driver);
            stepDefinitionsHelpers.PerformJavaScriptClick(panelElement);
        }

        public void GivenISelectFromTheDropdown(string item, string dropdown)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(60));
            var dropdownElement = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//div[contains(@class, 'ng-placeholder') and contains(text(), '{dropdown}')]/following-sibling::div//input")));

            dropdownElement.SendKeys(item);
            string xPath = $"//div[contains(@class, 'ng-option') and .//span[contains(@class, 'ng-option-label') and text()='{item}']]";
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xPath)));
            dropdownElement.SendKeys(Keys.Tab);
        }

        public void GivenISelectFromTheDropdown(string item, string position, string dropdown)
        {
            throw new PendingStepException();
        }

        public void GivenISelectFromTheEllipsisMenu(string item)
        {
            var itemElement = _driver.FindElement(By.XPath($"//button[.//span[text()='{item}']]"));
            itemElement.Click();
        }

        public void GivenISelectRowFromTheTable(string value)
        {
            var cellElement = _driver.FindElement(By.XPath($"//datatable-body-cell[.//span[normalize-space(text())='{value}']]"));
            var stepDefinitionsHelpers = new StepDefinitionsHelpers(_driver);

            stepDefinitionsHelpers.PerformJavaScriptClick(cellElement);
        }

        public void GivenNavigatesToScreen(string screen)
        {
            var menuItem = _driver.FindElement(By.XPath($"//a[contains(@class, 'nav-link') and @title='{screen}']"));
            menuItem.Click();
        }
        
        public void GivenIClickOnTheRadioButton(string button)
        {
            throw new PendingStepException();
        }

        public void GivenIClickOnTheRadioButton(string position, string button)
        {
            throw new PendingStepException();
        }

        public void GivenIFilterBy(string filter, string value)
        {
            IWebElement inputElement = _driver.FindElement(By.XPath($"//input[@placeholder='{filter}']"));
            inputElement.SendKeys(value.ToString());
        }

        public void GivenIFilterTheDateBy(string filter, string value)
        {
            throw new PendingStepException();
        }

        public void GivenIWaitForPageDataToLoad()
        {
            throw new PendingStepException();
        }
    }
}
