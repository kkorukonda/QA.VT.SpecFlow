Feature: EDICustomer

2762 <RT208 & RT209> <custom Fields on Customer Master – EDI Customer>

@Finance @IFS
Scenario: Verify Customer 1534209 EDI Customer should be No
Given User Visits IFS
	And I wait '5' seconds
 	When I click the 'AurenaLink' image
	And I log into IFS
	#And I refresh the page
	#And I wait '60' seconds
	And I navigate to the 'Application Base Setup > Enterprise > Customer > Customer' Screen
	And I wait '15' seconds
	And I select Customer 'Doors, Inc. - Des Moines' '1534209'
	Then I verify EDI Customer 'No'

	@Finance @IFS
Scenario: Verify Customer 10911000 EDI Customer should be Yes
Given User Visits IFS
	And I wait '5' seconds
 	When I click the 'AurenaLink' image
	And I log into IFS
	And I wait '60' seconds
	And I navigate to the 'Application Base Setup > Enterprise > Customer > Customer' Screen
	And I wait '15' seconds
	And I select Customer 'The Home Depot- Corporate' '10911000'
	And I wait '15' seconds
	Then I verify EDI Customer 'Yes'
	 
