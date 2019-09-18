Feature: DashboardTests
	
@mytag
Scenario: Check if header links and image are displayed
	Given I am on dashboard page
	Then the header links are displayed
	And the image in the header is displayed

Scenario: Dashboard page title is correct
	Given I am on dashboard page
	Then the page title is correct
	