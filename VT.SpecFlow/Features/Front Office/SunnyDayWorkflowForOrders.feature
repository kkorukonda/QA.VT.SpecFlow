Feature: SunnyDayWorflowForOrders

Creates an order in vtonline and submits a case that creates a case in IFS

@FrontOffice @VTOL @IFS
Scenario: Creates an order in vtonline
	Given User Visits VTOnline
	And I wait '11' seconds
	And I log into VTOL
	And I navigate to the 'Quotes & Orders' Screen
	And I click the 'New Order' button
	And I wait '11' seconds
	And I select '2036431 A.G. Mauro - Pittsburgh' from the 'Customer' dropdown
	And I select 'AutomatedTest' from the 'Project' dropdown
	And I enter 'AutoTest' with current time into the 'Purchase Order' field	
	And I record the 'Order' field in the Notebook as 'VT Order Id'
	And I select 'NONE' from the 'Special Packaging Options' dropdown
	And I select 'AutomatedTest' from the 'Contact' dropdown
	And I enter a future date into the 'Customer Desired Ship Date' field
	And I click the 'Detail' tab
	And I wait '11' seconds
	And I click the 'New' button
	And I wait '11' seconds
	And I enter 'test' into the 'Opening' field
	And I select 'RH' from the 'Swing' dropdown
	And I click the 'Save' button
	And I expand the 'Configuration' panel
	And I select 'AMWELD' from the 'Frame Mfg' configurator dropdown
	And I select 'PARTICLEBOARD' from the 'Core Type' configurator dropdown
	And I click the 'Continue' configurator button
	And I enter '3' and '0' into the 'Opening Width (ft - in)' configurator fields
	And I enter '7' and '0' into the 'Opening Height (ft - in)' configurator fields
	And I select 'MDO -MDO' from the 'HF Material' configurator dropdown
	And I select 'UNFINISHED' from the 'Factory Finish' configurator dropdown
	And I click the 'Continue' configurator button
	And I click the 'Finish' configurator button
	And I wait '5' seconds
	#And I verify table contains below information
	#	| Line | Openings | Qty   | Product | Description       | Ship To/Desired Date    |
	#	| 1    | test     | 1     | Flush   | SINGLE (1 leaves) | A.G. Mauro - Pittsburgh |

##Part 2 starts here : Internal user can submit a case in vtonline
    And I wait '5' seconds
	And I click the 'Create Case' button
	And I wait '5' seconds
	And I check the 'Heritage' checkbox
	And I enter current date at 08:30:00 in the 'Date Received' Field
	And I click the 'Finish' button
	And I wait '5' seconds
	And I filter 'ID' by the 'VT Order Id' value recorded in the Notebook
	And I wait '5' seconds
	#And I verify table contains below information
	#	| Type  | Region   | Customer                | Project Name   | Status |
	#	| Order | VT Doors | A.G. Mauro - Pittsburgh | AutomatedTest  | Open   |


##Part 3 starts here: A case submitted in vtonline is created in IFS
	And I open IFS in a new browser tab
	And I wait '15' seconds
 	And I log into IFS
	And I navigate to the 'Relationship Management > Call Center > Cases > Cases' Screen
	And I wait '5' seconds
	And I filter 'Quote/Order' by the 'VT Order Id' value recorded in the Notebook
	And I wait '5' seconds
	And I record the 'Case ID' column in the Notebook as 'Case ID'
	And I verify table contains below information
		| Case Type           | Title         | Category                   | Case Severity | Status | Focus            | Organization |
		| STANDARD - Standard | AutomatedTest | HERITAGE - Holstein/Neenah | HC ORDER      | Open   | ORDER TO PROCESS | 10 - DOORS   |


##Part 4 starts here: Case tasks are added to a case when it's created in IFS
    And I wait '5' seconds
	And I navigate to the 'Relationship Management > Call Center > Tasks > Case Tasks' Screen
	And I wait '5' seconds
	And I filter 'Case ID' by the 'Case ID' value recorded in the Notebook
#	And I verify table contains below information
#		| Title         | Activity   | Task Type | Task Status | Queue  | VTOL User | Task Organization |
#		| AutomatedTest | OP2Process | ORDER     | Queued      | 10/OP/ |           |                   | 

##Part 5 starts here: User can accept OP2Process case tasks
	And I wait '5' seconds
	And I navigate to the 'Relationship Management > Call Center > Cases > Case Details' Screen
	And I wait '11' seconds
	And I close the 'Navigator Menu'
	And I close the 'Record Selector'
	And I filter 'Case ID' by the 'Case ID' value recorded in the Notebook
	And I wait '5' seconds
	And I click the 'Tasks' tab
	And I wait '5' seconds
	And I select the 'OP2PROCESS' row from the table
	And I wait '5' seconds
	And I select 'Accept Task' from the 'second' 'Status' dropdown
	And I wait '5' seconds
	And I click the 'OK' button
	And I wait '5' seconds
	#And I verify table contains below information
	#| Activity   | Status | Queue | VTOL User | Task Organization               |
	#| OP2Process | Open   |       |           | <name of use who accepted task> |  

##Part 6 starts here: User can Accept & Send ORA on Order
	And I switch back to the 'VTOL' browser tab
	And I navigate to the 'Quotes & Orders' Screen
    And I wait '5' seconds
	And I filter 'ID' by the 'VT Order Id' value recorded in the Notebook
	And I wait '5' seconds
	And I select the 'Order' row from the table
	And I wait '5' seconds
	And I click on the ellipsis menu
	And I select 'Calculate ATP' from the ellipsis menu
	And I wait '15' seconds
	And I refresh the page
	And I wait '5' seconds
	And I click the 'Accept & Send ORA' button
	And I wait '5' seconds
	And I click the 'Submit' button
	And I wait '5' seconds

##Part 7 starts here: User can accept HC DTL2ALLOCATE case tasks
	And I switch back to the 'IFS' browser tab
	And I refresh the page
	And I close the 'Record Selector'
	And I click the 'Tasks' tab
	And I wait '5' seconds
	And I select the 'HC DTL2ALLOCATE' row from the table
	And I wait '5' seconds
	And I select 'Accept Task' from the 'second' 'Status' dropdown
	And I wait '5' seconds
	And I click the 'OK' button
	And I wait '5' seconds
	#And I verify table contains below information
	#| Activity        | Status   | Queue | VTOL User      | Owning Organization               |
	#| OP2Process      | Closed   |       | %VTOL User%    | 10 - DOORS                        |
	#| HC DTL2ALLOCATE | Open     |       |                | 10 - DOORS                        |
	#| HC DTL2COMPLETE | New      |       |                | 10 - DOORS                        | 

##Part 8 starts here: User can Allocate an Order
	And I switch back to the 'VTOL' browser tab
	And I navigate to the 'Quotes & Orders' Screen
    And I wait '5' seconds
	And I filter 'ID' by the 'VT Order Id' value recorded in the Notebook
	And I wait '5' seconds
	And I select the 'Order' row from the table
	And I wait '5' seconds
	And I click the 'Allocate' button
	And I click the 'Submit' button
	And I wait '5' seconds

##Part 9 starts here: Case is updated after a user Allocates an Order
	And I switch back to the 'IFS' browser tab
	And I refresh the page
	And I close the 'Record Selector'
	And I click the 'Tasks' tab
	And I wait '5' seconds
	#And I verify table contains below information
	#| Activity        | Status   | Queue | VTOL User      | Owning Organization               |
	#| OP2Process      | Closed   |       | %VTOL User%    | 10 - DOORS                        |
	#| HC DTL2ALLOCATE | Closed   |       | %VTOL User%    | 10 - DOORS                        |
	#| HC DTL2COMPLETE | Open     |       | %VTOL User%    | 10 - DOORS       

##Part 10 starts here: User can Detailer Finish an Order
    And I switch back to the 'VTOL' browser tab
	And I navigate to the 'Quotes & Orders' Screen
    And I wait '5' seconds
	And I filter 'ID' by the 'VT Order Id' value recorded in the Notebook
	And I wait '5' seconds
	And I select the 'Order' row from the table
	And I wait '5' seconds
	And I click the 'Detailer Finish' button
	And I click the 'Submit' button
	And I wait '5' seconds

##Part 11 starts here: Case is updated after a user Detailer Finished an Order
	And I switch back to the 'IFS' browser tab
	And I refresh the page
	And I close the 'Record Selector'
	And I click the 'Tasks' tab
	And I wait '5' seconds
	#And I verify table contains below information
	#| Activity        | Status   | Queue   | VTOL User      | Owning Organization               |
	#| OP2Process      | Closed   |         | %VTOL User%    | 10 - DOORS                        |
	#| HC DTL2ALLOCATE | Closed   |         | %VTOL User%    | 10 - DOORS                        |
	#| HC DTL2COMPLETE | Closed   |         | %VTOL User%    | 10 - DOORS                        |
	#| ORD2PRICE       | Queued   | 10/ISR/ |                | 10 - DOORS                        |

##Part 12 starts here: User can Detailer Finish an Order
    And I switch back to the 'VTOL' browser tab
	And I navigate to the 'Quotes & Orders' Screen
    And I wait '5' seconds
	And I filter 'ID' by the 'VT Order Id' value recorded in the Notebook
	And I wait '5' seconds
	And I select the 'Order' row from the table
	And I wait '5' seconds
	And I click the 'Finish and Send FOA' button
	And I click the 'Submit' button
	#And I wait '5' seconds

##Part 13 starts here: Case is updated after a user Finish and Send FOA on Order
	And I switch back to the 'IFS' browser tab
	And I refresh the page
	And I close the 'Record Selector'
	And I click the 'Tasks' tab
    And I wait '5' seconds
	#And I verify table contains below information
	#| Activity        | Status   | Queue   | VTOL User      | Owning Organization               |
	#| OP2Process      | Closed   |         | %VTOL User%    | 10 - DOORS                        |
	#| HC DTL2ALLOCATE | Closed   |         | %VTOL User%    | 10 - DOORS                        |
	#| HC DTL2COMPLETE | Closed   |         | %VTOL User%    | 10 - DOORS                        |
	#| ORD2PRICE       | Closed   |         | %VTOL User%    | 10 - DOORS                        |
	#| AWAIT ACCEPT    | Open     |         | %VTOL User%    | 10 - DOORS                        |

##Part 14 starts here: User can Accept an Order
	And I switch back to the 'VTOL' browser tab
	And I navigate to the 'Quotes & Orders' Screen
    And I wait '5' seconds
	And I filter 'ID' by the 'VT Order Id' value recorded in the Notebook
	And I wait '5' seconds
	And I select the 'Order' row from the table
	And I wait '5' seconds
	And I click the 'Accept' button
	And I click the 'Submit' button
	And I wait '5' seconds

##Part 15 starts here: Case is Accepts Order
	And I switch back to the 'IFS' browser tab
	And I refresh the page
	And I close the 'Record Selector'
	And I click the 'Tasks' tab
    And I wait '5' seconds
	#And I verify table contains below information
	#| Activity        | Status   | Queue   | VTOL User      | Owning Organization               |
	#| OP2Process      | Closed   |         | %VTOL User%    | 10 - DOORS                        |
	#| HC DTL2ALLOCATE | Closed   |         | %VTOL User%    | 10 - DOORS                        |
	#| HC DTL2COMPLETE | Closed   |         | %VTOL User%    | 10 - DOORS                        |
	#| ORD2PRICE       | Closed   |         | %VTOL User%    | 10 - DOORS                        |
	#| AWAIT ACCEPT    | Closed   |         | %VTOL User%    | 10 - DOORS                        |