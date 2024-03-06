Feature: CBillTrustFile

RT205 CBillTrustFile

@Finance @IFS
Scenario: Verify CBillTrustFile in TableView
	Given User Visits IFS
	And I wait '5' seconds
 	When I click the 'AurenaLink' image
	And I log into IFS
	And I wait '15' seconds
	And I navigate to the 'Sales > Invoicing > Customer Invoices' Screen
	And I wait '15' seconds
	And I click the 'second' 'Search' button
	And I wait '15' seconds
	And I click the 'Choose the fields to be shown in this view' button
	And I wait '15' seconds
	Then I verify 'CBillTrustFile' is displayed
	And I click the 'Add' button
	Then I verify 'CBillTrustFile' is displayed
	And I click the 'Restore default' button

@Finance @IFS
Scenario: Verify CBillTrustFile in ListView
	Given User Visits IFS
	And I wait '5' seconds
 	When I click the 'AurenaLink' image
	And I log into IFS
	And I wait '15' seconds
	And I navigate to the 'Sales > Invoicing > Customer Invoices' Screen
	And I wait '15' seconds
	And I click the 'second' 'Search' button
	And I wait '15' seconds
	When I Select the 'List View' button
	And I click on the 'Choose the fields to be shown in this view' 'button'
	And I wait '15' seconds
	And I click on the 'Configure columns manually' radio button
	And I wait '15' seconds
	Then I verify 'CBillTrustFile' is displayed
	And I click the 'Add' button
	Then I verify 'CBillTrustFile' is displayed
	And I wait '5' seconds
	And I click the 'Restore default' button
	