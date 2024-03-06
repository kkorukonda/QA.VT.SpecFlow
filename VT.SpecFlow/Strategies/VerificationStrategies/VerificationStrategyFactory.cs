using OpenQA.Selenium;

namespace VT.SpecFlow.Strategies.VerificationStrategies
{
    public class VerificationStrategyFactory
    {
        private readonly IWebDriver _driver;

        public VerificationStrategyFactory(IWebDriver driver)
        {
            _driver = driver;
        }

        internal IVerificationStrategy GetStrategy(string siteContext)
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
