Feature: WikiPage


@WikiPageTests
Scenario: BDD Navigate to WikiPage
Given I am on homepage
When I click on WikiPage link
Then I should be redirected to WikiPage 'Wiki page'
