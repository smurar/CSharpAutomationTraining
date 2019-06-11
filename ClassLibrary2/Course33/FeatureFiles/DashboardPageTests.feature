Feature: DashboardPageTests

@dashboardtests
Scenario: BDD NavigateTo Wiki Page
	Given I am on the homepage
	When I login with success using  email 'admin@domain.org' and password '111111'
	And I click on Wikipage link
	Then landing page with title 'WikiPage' is displayed

@dashboardtests
Scenario: BDD Dashboard Logout
	Given I am on the homepage
	When I login with success using  email 'admin@domain.org' and password '111111'
	Then Dasboard page is displayed with title 'Dashboard page'
	When I click logout button
	Then password field is displayed

@dashboardtests
Scenario: BDD Dashboard Footer Links
	Given I am on the homepage
	When I login with success using  email 'admin@domain.org' and password '111111'
	Then footer home link is displayed
	And footer wikipage link is displayed
	And dashboard image is displayed

@dashboardtests
Scenario: BDD Edit User Info
	Given I am on the homepage
	When I login with success using  email 'admin@domain.org' and password '111111'
	And I update firstname with value 'Dave124'
	And I update lastname with value 'Pop234'
	And I click save button
	Then on Dashboard page message 'Details saved' is displayed