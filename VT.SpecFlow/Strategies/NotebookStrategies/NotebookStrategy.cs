using OpenQA.Selenium;

namespace VT.SpecFlow.Strategies.NotebookStrategies
{
    internal class NotebookStrategy
    {
        internal readonly IWebDriver _driver;
        internal readonly FeatureContext _notebook;

        public NotebookStrategy(IWebDriver webDriver, FeatureContext notebook)
        {
            _driver = webDriver;
            _notebook = notebook;
        }
    }
}
