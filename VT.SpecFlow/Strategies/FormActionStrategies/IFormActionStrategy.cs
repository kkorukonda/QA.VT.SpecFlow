
namespace VT.SpecFlow.Strategies.FormActionStrategies
{
    internal interface IFormActionStrategy
    {
        void GivenIClickTheElementByXpath(string strXpath);
        void GivenIClickTheButton(string button);
        void GivenIClickTheButton(string position, string button);
        void GivenIClickOnTheEllipsisMenu();
        void GivenISelectFromTheEllipsisMenu(string item);
        void GivenICloseThe(string target);
        void GivenISelectFromTheDropdown(string item, string dropdown);
        void GivenISelectFromTheDropdown(string item, string position, string dropdown);
        void GivenISelectRowFromTheTable(string value);
        void GivenIEnterWithCurrentTimeIntoTheField(string text, string field);
        void GivenIEnterFutureDateIntoTheField(string field);
        void GivenIClickTheTab(string tab);
        void GivenIEnterIntoTheField(string text, string field);
        void GivenIExpandThePanel(string panel);
        void GivenICheckTheCheckbox(string checkbox);
        void GivenIEnterTodayDateReceivedField(string field);
        void GivenNavigatesToScreen(string screen);
        void GivenIFilterBy(string filter, string value);
        void GivenIFilterTheDateBy(string filter, string value);
        void GivenIWaitForPageDataToLoad();
        void GivenIClickOnTheRadioButton(string button);
        void GivenIClickOnTheRadioButton(string position, string button);
    }
}
