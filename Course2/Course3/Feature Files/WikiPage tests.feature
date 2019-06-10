Feature: WikiPage tests
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario: BDD Navigate to WikiPage
Given I am on homepage
When I click on WikiPagelink
Then I should be redirected to WikiPage'Wiki page'
