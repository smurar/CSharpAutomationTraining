Feature: WikiPageTests
	

@wikipagetests
Scenario: Clicking on Wiki link redirects to WikiPage
	Given I am on Homepage
	When I click on Wiki page title link
	Then I am redirected to the Wiki page
