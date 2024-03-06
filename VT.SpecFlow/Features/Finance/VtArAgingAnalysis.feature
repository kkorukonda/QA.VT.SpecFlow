Feature: VT AR Aging Analysis by Company

<RT490> <VT AR Aging Analysis by Company> User should be able to create "VT AR Aging Analysis by Company" for different companys and view results in table


	@Finance @IFS
Scenario Outline: View "VT AR Aging Analysis by Company" report
	Given User Visits IFS
	And I wait '5' seconds
 	When I click the 'AurenaLink' image
	And I log into IFS
	And I navigate to the 'Reporting > Order Report' Screen
	And I wait '5' seconds
	And I click the 'Search' button
	And I filter 'Report Name' by 'VT AR Aging Analysis by Company'
	And I select the 'VT AR Aging Analysis by Company' row from the table
	And I click the 'Order Report' button
	And I wait '300' seconds
	And I enter '<Company>' into the 'Company' field
	When I click the 'Execute' button
	And  I wait for page to load
	Then I verify that the table contains records
Examples:
	| Company |
	| 01      |
	| 02      |
	| 03      |
	| 04      |
	| 05      |
	| 06      |
	| 09      |
	| 16      |
	| 17      |
	| 18      |
	| 41      |
	| 42      |
