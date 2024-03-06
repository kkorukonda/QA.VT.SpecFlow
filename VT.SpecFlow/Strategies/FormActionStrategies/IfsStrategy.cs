using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Globalization;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text.RegularExpressions;
using VT.SpecFlow.Helpers;
using static System.Net.Mime.MediaTypeNames;

namespace VT.SpecFlow.Strategies.FormActionStrategies
{
    internal class IfsStrategy : FormActionStrategy, IFormActionStrategy
    {
        public IfsStrategy(IWebDriver webDriver) : base(webDriver)
        {
        }

        public void GivenICheckTheCheckbox(string checkbox)
        {
            throw new PendingStepException();
        }

        public void GivenIClickOnTheEllipsisMenu()
        {
            throw new PendingStepException();
        }

        public void GivenIClickTheButton(string button)
        {
            GivenIClickTheButton("first", button);
        }

        public void GivenIClickTheButton(string position, string button)
        {
            var positionMap = new Dictionary<string, int>()
            {
                { "first", 1 },
                { "second", 2 },
                { "third", 3 }
            };

            if (positionMap.TryGetValue(position, out int index))
            {
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(60));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//button[contains(., '{button}')] | //*[@title='{button}']")));

                var buttonElements = _driver.FindElements(By.XPath($"//button[contains(., '{button}')] | //*[@title='{button}']"));
                var buttonElement = buttonElements.ElementAtOrDefault(index - 1);
                buttonElement.Click();
            }
            else
            {
                throw new KeyNotFoundException($"The provided element index '{position}' is not supported.");
            }
        }

        public void GivenIClickTheElementByXpath(string strXpath)
        {
            var btnElement = _driver.FindElement(By.XPath(strXpath));
            btnElement.Click();
        }
        public void GivenIClickTheTab(string tab)
        {
            var tabElement = _driver.FindElement(By.XPath($"//fnd-tab-header[translate(normalize-space(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz') = '{tab.ToLower()}']"));
            tabElement.Click();
        }
        
        [Given(@"I click the '([^']*)' image")]
        public void GivenIClickTheImage(string imageId)
        {
            var imgElement = _driver.FindElement(By.Id(imageId));
            imgElement.Click();
        }

        public void GivenICloseThe(string target)
        {
            switch (target.ToLower())
            {
                case "navigator menu":
                    var hamburgerElement = _driver.FindElement(By.XPath("//div[contains(@class, 'hamburger')]"));
                    var classAttribute = hamburgerElement.GetAttribute("class");

                    if (classAttribute.Contains("active"))
                    {
                        hamburgerElement.Click();
                    }
                    break;
                case "record selector":
                    var chevronElement = _driver.FindElement(By.XPath("//div[@id='fndRecordSelectorToggle']/a"));
                    classAttribute = chevronElement.GetAttribute("class");

                    if (classAttribute.Contains("icon-chevron-left"))
                    {
                        var stepDefinitionsHelpers = new StepDefinitionsHelpers(_driver);
                        stepDefinitionsHelpers.PerformJavaScriptClick(chevronElement);
                    }
                    break;
                default:
                    throw new NotImplementedException($"The 'I close the {target}' has not been implemented.");
            }
        }

        public void GivenIEnterFutureDateIntoTheField(string field)
        {
            throw new PendingStepException();
        }

        public void GivenIEnterIntoTheField(string text, string field)
        {
            var inputFieldElement = _driver.FindElement(By.XPath($"//fnd-input-field-container[@data-fieldname='{field}']//input"));
            inputFieldElement.SendKeys(text);
            inputFieldElement.SendKeys(Keys.Tab);
        }

        public void GivenIEnterTodayDateReceivedField(string field)
        {
            throw new PendingStepException();
        }

        public void GivenIEnterWithCurrentTimeIntoTheField(string text, string field)
        {
            throw new PendingStepException();
        }

        public void GivenIExpandThePanel(string panel)
        {
            throw new PendingStepException();
        }

        public void GivenISelectFromTheDropdown(string item, string dropdown)
        {
            GivenISelectFromTheDropdown(item, "first", dropdown);
        }

        public void GivenISelectFromTheDropdown(string item, string position, string dropdown)
        {
            var positionMap = new Dictionary<string, int>() 
            {
                { "first", 1 },
                { "second", 2 },
                { "third", 3 }
            };

            if (positionMap.TryGetValue(position, out int index))
            {
                var dropdownElements = _driver.FindElements(By.XPath($"//button[contains(., '{dropdown}')]"));
                var dropdownElement = dropdownElements.Where(x => x.Text == $"{dropdown}").ElementAt(index - 1);
                dropdownElement.Click();

                var itemElement = _driver.FindElement(By.XPath($"//fnd-button[.//div[contains(., '{item}')]]"));
                itemElement.Click();
            }
            else
            {
                throw new KeyNotFoundException($"The provided element index '{position}' is not supported.");
            }
        }

        public void GivenISelectFromTheEllipsisMenu(string item)
        {
            throw new PendingStepException();
        }

        public void GivenISelectRowFromTheTable(string value)
        {
            var row = _driver.FindElement(By.XPath($"//fnd-static-field[.//span[@title='{value}']]"));

            var stepDefinitionsHelpers = new StepDefinitionsHelpers(_driver);
            stepDefinitionsHelpers.PerformJavaScriptClick(row);
        }

        public void GivenIClickOnTheRadioButton(string button)
        {
            var buttonElement = _driver.FindElement(By.XPath($"//li[.//div[text()='{button}']]"));
            buttonElement.Click();
        }

        public void GivenIClickOnTheRadioButton(string position, string button)
        {
            throw new PendingStepException();
        }

        public void GivenNavigatesToScreen(string screen)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(120));
            string[] items = screen.Split('>', StringSplitOptions.TrimEntries);

            var hamburgerElement = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[contains(@class, 'hamburger')]")));   

            var classAttribute = hamburgerElement.GetAttribute("class");
            if (!classAttribute.Contains("active"))
            {
                var stepDefinitionsHelpers = new StepDefinitionsHelpers(_driver);
                stepDefinitionsHelpers.PerformJavaScriptClick(hamburgerElement);
            }
   
            if (items.Length > 0)
            {
                IWebElement searchElement = _driver.FindElement(By.XPath("//input[@id='searchInputInsideNavigationMenu']"));
                searchElement.SendKeys(items[0]);

                
                var firstMenuItemElement = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//span[text()='{items[0]}']")));
                Actions actions = new Actions(_driver);
                actions.MoveToElement(firstMenuItemElement);
                actions.Perform();

                firstMenuItemElement.Click();
            }

            for (int i = 1; i < items.Length; i++)
            {   
                try
                {
                    var menuItemElement = _driver.FindElement(By.XPath($"//span[text()='{items[i]}']"));
                    menuItemElement.Click();
                }
                catch (NoSuchElementException ex)
                {
                    throw new ArgumentException($"The menu item '{items[i]}' does not exist. Check your spelling.",ex);
                }
            }
        }

        public void GivenIFilterBy(string filter, string value)
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
            searchInputElement = wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[contains(@class, 'options-pane')]//input")));
            searchInputElement.SendKeys(value.ToString());
            searchInputElement.SendKeys(Keys.Enter);
        }

        public void GivenIFilterTheDateBy(string filter, string value)
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

            switch (GetDateFilterType(value))
            {
                case IfsDateFilterType.Single:
                    value.ToString();
                    // Select the correct option button
                    // Select date
                    break;
                case IfsDateFilterType.DateRange:
                    value.ToString();
                    var optionElement = _driver.FindElement(By.XPath("//label[normalize-space()='Between two dates']"));
                    optionElement.Click();
                    optionElement.ToString();

                    var dates = value.Split("-", StringSplitOptions.TrimEntries);
                    var startDate = Convert.ToDateTime(dates[0]);
                    var endDate = Convert.ToDateTime(dates[1]);
                    endDate.ToString();

                    if (startDate.Year == DateTime.Now.Year)
                    {
                        startDate.ToString();
                        var formattedDate = startDate.ToString("dddd, MMMM dd, yyyy", CultureInfo.InvariantCulture);
                        // $"//td[@title='{formattedDate}']"
                    }

                    if (endDate.Year == DateTime.Now.Year)
                    {
                        endDate.ToString();
                    }

                    break;
                case IfsDateFilterType.During:
                    value.ToString();
                    break;
                case IfsDateFilterType.InRange:
                    value.ToString();
                    break;
                case IfsDateFilterType.Invalid:
                    throw new ArgumentException($"{value} does not match a know date filter pattern.");
            }
        }

        public void GivenIWaitForPageDataToLoad()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));

            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("spinner")));
                wait.Timeout = TimeSpan.FromMinutes(5);
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.ClassName("spinner")));
            }
            catch { }
            Thread.Sleep(1000);
        }

        private static IfsDateFilterType GetDateFilterType(string input)
        {
            Func<string, bool> isSingleDate = (input) => Regex.IsMatch(input, @"^\d{1,2}/\d{1,2}/\d{4}$");
            Func<string, bool> isDateRange = (input) => Regex.IsMatch(input, @"^\d{1,2}/\d{1,2}/\d{4} - \d{1,2}/\d{1,2}/\d{4}$");
            Func<string, bool> isDuring = (input) => Regex.IsMatch(input, @"^#.*#$");
            Func<string, bool> isInRange = (input) => Regex.IsMatch(input, @"^#.*# : #.*#$");

            return input switch
            {
                var i when isSingleDate(i) => IfsDateFilterType.Single,
                var i when isDateRange(i) => IfsDateFilterType.DateRange,
                var i when isDuring(i) => IfsDateFilterType.During,
                var i when isInRange(i) => IfsDateFilterType.InRange,
                _ => IfsDateFilterType.Invalid
            };
        }
    }
}
