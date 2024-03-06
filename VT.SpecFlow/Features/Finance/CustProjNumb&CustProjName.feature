Feature: CustProjNumb&CustProjName

<RT198 & RT199> <Cust Proj Numb & Cust Proj Name>

@Finance @IFS
Scenario: Verify CustProjNumb&CustProjName in TableView
Given User Visits IFS
	And I wait '5' seconds
 	When I click the 'AurenaLink' image
	And I log into IFS
	And I wait '60' seconds
	And I navigate to the 'Sales > Order > Customer Orders' Screen
	And I wait '15' seconds
	And I click the 'second' 'Search' button
	And I wait '15' seconds
	When I Select the 'Table View' button
	And I click on the 'Choose the fields to be shown in this view' 'button'
	And I wait '15' seconds
	Then I verify 'Cust Proj Numb' is displayed
	And I click the 'Add' button
	Then I verify 'Cust Proj Name' is displayed
	And I click the 'Add' button
	Then I verify 'Cust Proj Numb' is displayed
	Then I verify 'Cust Proj Name' is displayed
	And I click the 'Restore default' button


	@Finance @IFS
	Scenario: Verify CustProjNumb&CustProjName in ListView
	Given User Visits IFS
	And I wait '5' seconds
 	When I click the 'AurenaLink' image
	And I log into IFS
	And I wait '15' seconds
	And I navigate to the 'Sales > Order > Customer Orders' Screen
	And I wait '15' seconds
	And I click the 'second' 'Search' button
	And I wait '15' seconds
	When I Select the 'List View' button
	And I click on the 'Choose the fields to be shown in this view' 'button'
	And I wait '15' seconds
	And I click on the 'Configure columns manually' radio button
	And I wait '15' seconds
	Then I verify 'Cust Proj Numb' is displayed
	And I click the 'Add' button
	Then I verify 'Cust Proj Name' is displayed
	And I click the 'Add' button
	Then I verify 'Cust Proj Numb' is displayed
	Then I verify 'Cust Proj Name' is displayed
	And I click the 'Restore default' button
