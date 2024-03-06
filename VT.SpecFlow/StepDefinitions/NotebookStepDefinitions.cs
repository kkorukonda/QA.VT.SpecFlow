using OpenQA.Selenium;
using VT.SpecFlow.Strategies.FormActionStrategies;
using VT.SpecFlow.Strategies.NotebookStrategies;

namespace VT.SpecFlow.StepDefinitions
{
    /// <summary>
    /// The "Notebook" is a logical space to note down information that 
    /// is passed between steps. 
    /// </summary>
    [Binding]
    public class NotebookStepDefinitions
    {
        readonly IWebDriver _driver;
        internal readonly FeatureContext _notebook;

        public NotebookStepDefinitions(IWebDriver webDriver, FeatureContext notebook)
        {
            _driver = webDriver;
            _notebook = notebook;
        }

        private INotebookStrategy GetStrategy()
        {
            var siteContext = _notebook["Site Context"].ToString() ?? string.Empty;
            NotebookStrategyFactory factory = new NotebookStrategyFactory(_driver, _notebook);
            return factory.GetStrategy(siteContext);
        }

        [Given(@"I record the '([^']*)' column in the Notebook as '([^']*)'")]
        public void GivenIRecordTheColumnInTheNotebookAs(string column, string name)
        {
            GetStrategy().GivenIRecordTheColumnInTheNotebookAs(column, name);
        }

        [Given(@"I record the '([^']*)' field in the Notebook as '([^']*)'")]
        public void GivenIRecordTheFieldInTheNotebookAs(string field, string name)
        {
            GetStrategy().GivenIRecordTheFieldInTheNotebookAs(field, name);
        }

        [Given(@"I filter '([^']*)' by the '([^']*)' value recorded in the Notebook")]
        public void GivenIFilterByTheValueRecordedInTheNotebook(string filter, string record)
        {
            GetStrategy().GivenIFilterByTheValueRecordedInTheNotebook(filter, record);
        }
    }
}
