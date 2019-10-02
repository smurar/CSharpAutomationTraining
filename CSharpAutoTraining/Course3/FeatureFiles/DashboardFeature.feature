Feature: DashboardTests
	

@dashboardtests
Scenario: Dashboard header image is displayed
	Given I am on dashboard Page
	Then The Dashboard Header image is displayed


@dashboardtests
Scenario: Home header image is displayed on Dashboard
	Given I am on dashboard Page
	Then The Home Header image is displayed


@dashboardtests
Scenario: Wiki header image is displayed on Dashboard
	Given I am on dashboard Page
	Then The Wiki Header image is displayed


@dashboardtests
Scenario: Dashboard Title is correct
	Given I am on dashboard Page
	Then The Dashboard Title is correct


@dashboardtests
Scenario: Wiki header image is displayed
	Given I am on dashboard Page
	Then The Dashboard Heading is correct


@dashboardtests
Scenario: First name is edited
	Given I am on dashboard Page
	When I fill in first name
	And I click on Save Details button
	Then First name is saved


@dashboardtests
Scenario: Last name is edited
	Given I am on dashboard Page
	When I fill in first name
	And I click on Save Details button
	Then Last name is saved


@dashboardtests
Scenario: Female radio button can be selected
	Given I am on dashboard Page
	When I click on Female button
	And I click on Save Details button
	Then Female button is selected


@dashboardtests
Scenario: Male radio button can be selected
	Given I am on dashboard Page
	When I click on Male button
	And I click on Save Details button
	Then Male button is selected


@dashboardtests
Scenario: Bike button can be selected
	Given I am on dashboard Page
	When I click on Bike button
	And I click on Save Details button
	Then Bike button is selected


@dashboardtests
Scenario: Car button can be selected
	Given I am on dashboard Page
	When I click on Car button
	And I click on Save Details button
	Then Car button is selected


@dashboardtests
Scenario: User can log out successfully
	Given I am logged in with a valid user
	When I click the Logout button
	Then I am logged out successfully


@dashboardtests
Scenario: Home footer link is displayed on Dashboard page
	Given I am on dashboard Page
	Then Home footer link is displayed on dashboard

@dashboardtests
Scenario: Wiki footer link is displayed on Dashboard page
	Given I am on dashboard Page
	Then Wiki footer link is displayed on dashboard

@dashboardtests
Scenario: Contacts footer link is displayed on Dashboard page
	Given I am on dashboard Page
	Then Contact footer link is displayed on dashboard