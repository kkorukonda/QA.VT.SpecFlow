using OpenQA.Selenium;

namespace VT.SpecFlow.Strategies.NotebookStrategies
{
    public class NotebookStrategyFactory
    {
        private readonly IWebDriver _driver;
        private readonly FeatureContext _notebook;

        public NotebookStrategyFactory(IWebDriver driver, FeatureContext notebook)
        {
            _driver = driver;
            _notebook = notebook;
        }

        internal INotebookStrategy GetStrategy(string siteContext)
        {
            switch (siteContext)
            {
                case "VTOL":
                    return new VtolStrategy(_driver, _notebook);
                case "IFS":
                    return new IfsStrategy(_driver, _notebook);
                default:
                    throw new InvalidOperationException("Unknown site context");
            }
        }
    }
}
