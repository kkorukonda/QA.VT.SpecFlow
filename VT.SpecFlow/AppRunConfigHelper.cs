using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace VT.SpecFlow
{
    public enum AppName
    {
        Vtol,
        Ifs
    }
    public class AppRunConfigHelper
    {
        private IConfiguration _configuration;

        public AppRunConfigHelper()
        {
            SetConfiguration();
        }

        private void SetConfiguration()
        {
            _configuration = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                                        .AddJsonFile("appsettings.json", false, true).Build();
        }

        public IWebDriver GetDriver()
        {
            switch (_configuration["Browser"].ToLower().Trim())
            {
                case "chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
                    var service = ChromeDriverService.CreateDefaultService();
                    return new ChromeDriver(service, new ChromeOptions(), TimeSpan.FromSeconds(60));
                case "firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig(), VersionResolveStrategy.MatchingBrowser);
                    return new FirefoxDriver();
                default:
                    throw new ArgumentException($"Cannot recognize browser '{_configuration["Browser"]}'");
            }

        }

        public string GetApplUrl(AppName app)
        {

            string env = _configuration["Environment"].ToLower().Trim();
            if (env == "qa")
            {
                return _configuration[$"{app.ToString()}:QA_Env"];
            }
            else if (env == "dev")
            {
                return _configuration[$"{app.ToString()}:DEV_Env"];
            }

            throw new InvalidOperationException($"Environment '{env}' is not recognized!");
        }
    }
}
