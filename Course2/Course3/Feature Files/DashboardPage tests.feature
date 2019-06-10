Feature: DashboardPage tests
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: BDD Login with valid credentials and check Dashboard Page
	Given I am on homepage
	And I have typed in email and Password
	| Email           | Password |
	| admin@domain.org | 111111  |
	When I click the login button
	Then I should be redirected to Dashboard page 'Dashboard page'

Scenario: BDD Header links and image are displayed
	Given I am on homepage
	And I login successfully to dashboard page
	| Email           | Password |
	| admin@domain.org | 111111  |
	Then I should see the dashboard header links
	Then I should see the dashboard header image

Scenario: BDD Page heding title h1 is correct  
	Given I am on homepage
	And I login successfully to dashboard page
	| Email           | Password |
	| admin@domain.org | 111111  |
	Then I should see the dashboard page heading title 'Dashboard page'

Scenario: BDD Edit personal information
	Given I am on homepage
	And I login successfully to dashboard page
	| Email           | Password |
	| admin@domain.org | 111111  |
	And I update my personal information
	| FirstName | LastName | Birthday   |
	| Septimiu  | Murar    | 18/12/1992 |
	And I select a gender
	And I select Car checkbox
	And I upload an image of a car
	When I press the save button
	Then I should see the details save message "Details saved"

