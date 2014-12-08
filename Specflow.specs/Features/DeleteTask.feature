Feature: DeleteTask
	In order to keep my history clean
	As a user
	I want to be delete the task


Scenario: Mark a todo as done and ensure it is persisted
	Given I have a todo database filled with
	| Done | Text			| Due Date	 |
	| NO   | Sample todo 1	| 02/01/2014 |
	| NO   | Sample todo 2	| 02/01/2014 |
	| NO   | Sample todo 3	| 02/01/2014 |
	When I delete the todo with text "Sample todo 2"
	Then I should have todos on the screen with
	| Done | Text			| Due Date	 |
	| NO   | Sample todo 1	| 02/01/2014 |
	| NO   | Sample todo 3	| 02/01/2014 |
