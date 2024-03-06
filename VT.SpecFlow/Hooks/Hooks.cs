using BoDi;
using OpenQA.Selenium;

namespace VT.SpecFlow.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer _container;
        private static IWebDriver? _driver;
        private static AppRunConfigHelper _configHelper;

        public Hooks(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            _configHelper = new AppRunConfigHelper();
            _driver = _configHelper.GetDriver();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _driver ??= _configHelper.GetDriver();
            _container.RegisterInstanceAs(_driver);
        }


        [AfterTestRun]
        public static void TestRun()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver.Dispose();
                _driver = null;
            }
        }
    }
}
