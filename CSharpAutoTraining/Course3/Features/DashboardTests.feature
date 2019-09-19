Feature: DashboardTests
	
@mytag
Scenario: Check if header links and image are displayed
	Given I am on dashboard page
	Then the dashboard header links and image are displayed

Scenario: Dashboard page title is correct
	Given I am on dashboard page
	Then the dashboard page title is correct

Scenario: Dashboard page heading title is correct
	Given I am on dashboard page
	Then the dashboard page heading title is correct

Scenario: "Details Saved" message is displayed 
	Given I am on dashboard page
	When I fill in the firstName and lastName
	| FirstName        | LastName |
	| Gill			   | Toy      |
	And I select male gender
	And I check the 'I have a bike' checkbox
	And I chose my birthday
	And I upload a file from my PC
	And I click on the 'Save' button
	Then the 'Details Saved' message should be displayed

Scenario: When I click on the Logout button I am redirected to homepage