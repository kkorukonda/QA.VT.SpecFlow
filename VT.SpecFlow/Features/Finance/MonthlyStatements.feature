Feature: MonthlyStatements

2747 <RT18> <Monthly Statements>

@Finance @IFS
Scenario: Verify Monthly Statements 
Given User Visits IFS
	And I wait '5' seconds
 	When I click the 'AurenaLink' image
	And I log into IFS
	And I navigate to the 'Financials > Accounts Receivable > AR Reports > Customer Statement of Account' Screen
	And I wait '15' seconds
	And I enter ' 01' into the 'Company'
	And I wait '15' seconds
	And I enter ' STD' into the 'Template ID'
	And I wait '15' seconds
	And I click the ' Next ' button
	And I wait '15' seconds
	And I enter '30' into the 'Period 1' 
	And I enter '30' into the 'Period 2' 
	And I enter '30' into the 'Period 3' 
	And I wait '15' seconds
	And I click the ' Finish ' button
	And I wait '15' seconds
	And I click the 'Preview' button
	Then I verify Pdf should open in another tab
	

	
