using OpenQA.Selenium;

namespace VT.SpecFlow.Strategies.FormActionStrategies
{
    public class FormActionStrategyFactory
    {
        private readonly IWebDriver _driver;

        public FormActionStrategyFactory(IWebDriver driver)
        {
            _driver = driver;
        }

        internal IFormActionStrategy GetStrategy(string siteContext)
        {
            switch (siteContext)
            {
                case "VTOL":
                    return new VtolStrategy(_driver);
                case "IFS":
                    return new IfsStrategy(_driver);
                default:
                    throw new InvalidOperationException("Unknown site context");
            }
        }
    }
}
