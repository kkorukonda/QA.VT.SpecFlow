using OpenQA.Selenium;

namespace VT.SpecFlow.Strategies.VerificationStrategies
{
    internal class VerificationStrategy
    {
        internal readonly IWebDriver _driver;

        public VerificationStrategy(IWebDriver webDriver)
        {
            _driver = webDriver;
        }
    }
}
