using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace VT.SpecFlow.Helpers
{
    public class StepDefinitionsHelpers
    {
        private int _staleElementReferenceExceptionCount = 0;
        private readonly IWebDriver _driver;


        public StepDefinitionsHelpers(IWebDriver driver)
        {
            _driver = driver;
        }

        public void HandleStaleElementReferenceException(Action action)
        {
            try
            {
                action();
            }
            catch (StaleElementReferenceException)
            {
                _staleElementReferenceExceptionCount++;
                if (_staleElementReferenceExceptionCount <= 3)
                {
                    _driver.SwitchTo().DefaultContent();
                    HandleStaleElementReferenceException(action);
                }
                else
                {
                    throw new InvalidOperationException("Exceeded maximum retries for StaleElementReferenceException");
                }
            }
            finally
            {
                _staleElementReferenceExceptionCount = 0;
            }
        }

        public void SwitchToIframeAndBack(string iframeXPath, Action<WebDriverWait> action)
        {
            HandleStaleElementReferenceException(() =>
            {
                var iframeElement = _driver.FindElement(By.XPath(iframeXPath));
                _driver.SwitchTo().Frame(iframeElement);

                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
                action(wait);

                _driver.SwitchTo().DefaultContent();
            });
        }

        public void PerformJavaScriptClick(IWebElement element)
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", element);
        }

        public void PerformJavaScriptScroll(IWebElement element)
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }
    }
}
