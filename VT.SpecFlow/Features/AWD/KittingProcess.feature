Feature: KittingProcess

RT#50 Kitting process for manufactured MIR's

@AWD @IFS
Scenario: Kitting process for manufactured MIR's
	Given User Visits IFS
	And I wait '5' seconds
 	When I click the 'AurenaLink' image
	And I log into IFS
	And I wait '11' seconds
	And I navigate to the 'Sales > Shipping > Shipment Delivery > Shipment Lines' Screen
	And I wait '5' seconds
	And I filter 'Site' by '1901'
	And I wait '5' seconds
	And I filter 'Source Part No' by '!~FLD'
	And I wait '5' seconds
	And I filter the date 'Planned Ship Date/Time' by '9/5/2022 - 9/9/2022'
	And I wait '5' seconds
	And I navigate to the 'Warehouse Management > Quantity in Stock > Inventory Parts In Stock' Screen
	And I wait '5' seconds
	And I filter 'Site' by '1901'
	And I wait '5' seconds
	And I filter 'Part' by '18419'
	And I wait '5' seconds
	And I filter 'Location No' by 'RECV-A-AA01'
	And I wait '5' seconds
	And I filter 'On Hand Qty' by '>0'
	And I wait '5' seconds
