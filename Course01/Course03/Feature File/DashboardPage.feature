Feature: DashboardPage

@Dashboardtests
	Scenario: BDD Login with valid credentials
	Given I am on homepage
	And I have typed in email and the password
	|Email            |Password |
    |admin@domain.org |111111  |
	When I click login button to Dashboard Page
	Then I should be on DashboardPage 'Dashboard page'
