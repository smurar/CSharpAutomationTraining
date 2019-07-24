Feature: HomePageTests

@mytag
Scenario: BDD Login with wrong password
	Given I am on homepage
	And I have typed in email
	| Email            | Password |
	| admin@domain.org | invalid  |
	When I click login button
	Then I should remain on homepage 'Home page'
