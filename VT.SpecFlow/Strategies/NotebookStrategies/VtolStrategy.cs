using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Globalization;
using VT.SpecFlow.Helpers;

namespace VT.SpecFlow.Strategies.NotebookStrategies
{
    internal class VtolStrategy : NotebookStrategy, INotebookStrategy
    {
        public VtolStrategy(IWebDriver webDriver, FeatureContext notebook) : base(webDriver, notebook)
        {
        }

        private static string DetermineFieldValue(IWebElement element, string fieldTitle)
        {
            string tag = element.TagName.ToLower();
            string classAttribute = element.GetAttribute("class")?.ToLower() ?? "";

            switch (tag)
            {
                case "span":
                    if (classAttribute.Contains("badge"))
                        return element.Text;
                    break;

                case "ng-select":
                    return element.FindElement(By.XPath(".//span[contains(@class, 'ng-value-label')]")).Text;

                case "input":
                    if (classAttribute.Contains("mat-mdc-input-element"))
                        return element.GetAttribute("value");
                    break;

                case "mat-form-field":
                    return element.FindElement(By.TagName("input")).GetAttribute("value");

                case "mat-hint":
                    return element.Text;
            }

            throw new Exception($"Unable to determine the field type for title: {fieldTitle}");
        }

        public void GivenIRecordTheFieldInTheNotebookAs(string field, string name)
        {
            var matInputXpath = $"//input[@placeholder='{field}']";
            var ngSelectXpath = $"//ng-select[.//div[@class='ng-placeholder' and contains(text(), '{field}')]]";
            var matFormFieldXpath = $"//mat-label[contains(text(), '{field}')]/ancestor::mat-form-field";
            var matCardXpath = $"//mat-card-subtitle[contains(text(), '{field}')]/preceding-sibling::span | //mat-card-subtitle[contains(text(), '{field}')]/following-sibling::span";
            var matHintXpath = $"//strong[contains(text(), '{field}')]/ancestor::mat-hint";

            string fieldTypeXpathes = $"{matInputXpath} | {ngSelectXpath} | {matFormFieldXpath} | {matCardXpath} | {matHintXpath}";
            IWebElement element = _driver.FindElement(By.XPath(fieldTypeXpathes));

            string fieldValue = DetermineFieldValue(element, field);
            _notebook[name] = fieldValue;
        }

        public void GivenIFilterByTheValueRecordedInTheNotebook(string filter, string record)
        {
            IWebElement inputElement = _driver.FindElement(By.XPath($"//input[@placeholder='{filter}']"));
            inputElement.SendKeys(Keys.Control + "a");
            inputElement.SendKeys(_notebook[record].ToString());
        }

        public void GivenIRecordTheColumnInTheNotebookAs(string column, string name)
        {
            throw new PendingStepException();
        }
    }
}
