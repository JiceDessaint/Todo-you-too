Feature: AddTask
	In order to remeber it for the next time I connect
	As a user
	I want to add a task with an name and an date in order to 
	

@Todo
Scenario: Click on add button
	When I click on New Todo button
	Then I should see the popup



@Todo
Scenario: Create a todo with a text
	Given I have deleted the database
	And I click on New Todo button
	And I enter "test Todo" in the textbox
	When I hit Enter
	Then I should have todos on the screen with
	| Done | Text      | Due Date   |
	| NO   | test Todo | 02/01/2014 |

@Todo
Scenario: Create a todo with a text and a date
	Given I have deleted the database
	And I click on New Todo button
	And I enter "test Todo" in the textbox
	And I enter "11/02/2014" as the date
	When I hit Enter
	Then I should have todos on the screen with
	| Done | Text      | Due Date   |
	| NO   | test Todo | 11/02/2014 |