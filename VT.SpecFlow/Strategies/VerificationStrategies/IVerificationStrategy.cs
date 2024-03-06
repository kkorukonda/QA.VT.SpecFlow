
namespace VT.SpecFlow.Strategies.VerificationStrategies
{
    internal interface IVerificationStrategy
    {
        void GivenIVerifyTableContainsBelowInformation(Table table);
        void GivenIVerifyIfTheFollowingColumnsAreBlank(Table table);
        void ThenIVerifyThatTheTableContainsRecords();
    }
}
