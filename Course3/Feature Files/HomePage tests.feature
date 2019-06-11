Feature: HomePage tests

@mytag
Scenario: BDD Login with wrong password
	Given I am on homepage
	And I have typed in emaail
	| Email            | Password |
	| admin@domain.org | invalid  |
	When I click login button
	Then I should reamin on homepage 'Home page'
