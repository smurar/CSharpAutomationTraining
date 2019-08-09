Feature: DashboardPageTests

@mytag
Scenario: BDD Check Dashboard page
	Given I am on the Dashboard page
	Then I should see the header links&image, page title and heading

Scenario: BDD Edit personal information
	Given I am on the Dashboard page
	And I edit personal information
	When I click the Save button
	Then I should see the Details saved message

Scenario: BDD Check Dashboard footer links
	Given I am on the Dashboard page
	Then I should see the footer links too.
		