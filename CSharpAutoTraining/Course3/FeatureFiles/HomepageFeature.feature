Feature: HomepageTests
	

@homepagetests
Scenario: Header Image Displayed BDD
	Given I am on Homepage
	Then The Header image is displayed


@homepagetests
Scenario: Home Header Link is Displayed BDD
	Given I am on Homepage
	Then Home Header Link is Displayed


@homepagetests
Scenario: Wiki Header Link is Displayed BDD
	Given I am on Homepage
	Then Wiki Header Link is Displayed


@homepagetests
Scenario: Homepage Title is correct
	Given I am on Homepage
	Then Homepage Title is correct


@homepagetests
Scenario: Homepage Heading is correct
	Given I am on Homepage
	Then Homepage Heading is correct


@homepagetests
Scenario: Default Email is displayed on Homepage
	Given I am on Homepage
	Then Default email is displayed


@homepagetests
Scenario: Default Password is displayed on Homepage
	Given I am on Homepage
	Then Default password is displayed


@homepagetests
Scenario: Login fields are displayed on Homepage
	Given I am on Homepage
	Then Login fields are displayed


@homepagetests
Scenario: Email cannot be null when attempting to log in
	Given I am on Homepage
	When Login with no email entered
	Then Email can't be null error is displayed


@homepagetests
Scenario: Email format invalid error appears when attempting to log
	Given I am on Homepage
	When I Login with invalid email format
	| invalid email | asdfasdf |
	Then Email format error is displayed


@homepagetests
Scenario: Invalid email and valid password entered when logging in
	Given I am on Homepage
	When I enter an invalid email and a valid password
	Then Invalid email/password error is displayed


@homepagetests
Scenario: Valid email and invalid password entered when logging in
	Given I am on Homepage
	When I enter a valid email and an invalid password
	Then Invalid email/password error is displayed


@homepagetests
Scenario: Login with valid credentials
	Given I am on Homepage
	When I Login with valid email and password
	Then Login is successful


@homepagetests
Scenario: Clicking on Wiki link redirects to WikiPage
	Given I am on Homepage
	When I click on Wiki page title link
	Then I am redirected to the Wiki page


@homepagetests
Scenario: Home footer link is displayed
	Given I am on Homepage
	Then Home footer link is displayed


@homepagetests
Scenario: Wiki footer link is displayed
	Given I am on Homepage
	Then Wiki footer link is displayed


@homepagetests
Scenario: Contacts footer link is displayed
	Given I am on Homepage
	Then Contacts footer link is displayed