using OpenQA.Selenium;

namespace VT.SpecFlow.Strategies.FormActionStrategies
{
    internal class FormActionStrategy
    {
        internal readonly IWebDriver _driver;

        public FormActionStrategy(IWebDriver webDriver)
        {
            _driver = webDriver;
        }
    }
}
