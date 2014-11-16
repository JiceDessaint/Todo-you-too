Feature: Data should be persisted
	In order keep states of my todos
	As a user
	I want my todos to be saved and reloaded in the same state when restarting the app

Scenario: Create a todo and ensure it is persisted
	Given I have deleted the database
	And I click on New Todo button
	And I enter "test Todo" in the textbox
	And I hit Enter
	When I restart the application
	Then I should have todos on the screen with
	| Done | Text      | Due Date   |
	| NO   | test Todo | 02/01/2014 |

Scenario: Mark a todo as done and ensure it is persisted
	Given I have a todo database filled with
	| Done | Text			| Due Date	 |
	| NO   | Sample todo 1	| 02/01/2014 |
	| NO   | Sample todo 2	| 02/01/2014 |
	| NO   | Sample todo 3	| 02/01/2014 |
	And I check the todo with text "Sample todo 2"
	When I restart the application
	Then I should have todos on the screen with
	| Done | Text			| Due Date	 |
	| NO   | Sample todo 1	| 02/01/2014 |
	| YES  | Sample todo 2	| 02/01/2014 |
	| NO   | Sample todo 3	| 02/01/2014 |
