Feature: ExchangeRateUpdate

<RT17> <Exchange Rate Update>

@Finance @IFS
Scenario: Verify ExchangeRateUpdate record for the previous business day
Given User Visits IFS
	And I wait '5' seconds
 	When I click the 'AurenaLink' image
	And I log into IFS
	And I wait '15' seconds
	And I navigate to the 'Accounting Rules > Currency > currency Rates' Screen
	And I wait '15' seconds
	Given I click the 'VT Industries, Inc.' button
	Given I click on the 'Show Only Valid Rates' checkbox
	Given I filter the date 'During' by '#YESTERDAY#'

