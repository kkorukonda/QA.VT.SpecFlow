
namespace VT.SpecFlow.Strategies.NotebookStrategies
{
    internal interface INotebookStrategy
    {
        void GivenIRecordTheColumnInTheNotebookAs(string column, string name);
        void GivenIRecordTheFieldInTheNotebookAs(string field, string name);
        void GivenIFilterByTheValueRecordedInTheNotebook(string filter, string record);
    }
}
