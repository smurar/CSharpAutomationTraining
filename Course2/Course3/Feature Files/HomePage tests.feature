Feature: HomePage tests
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: BDD Login with wrong password
	Given I am on homepage
	And I have typed in email
	| Email            | Password |
	| admin@domain.org | invalid  |
	When I click the login button
	Then I should remain on homepage 'Home page'


Scenario: BDD Header links and image are displayed
	Given I am on homepage
	Then I should see the header links
	Then I should see the header image


Scenario: BDD Page heding title h1 is correct  
	Given I am on homepage
	Then I should see the page heading title 'HTML'

Scenario: BDD Default email and password text are displayed
	Given I am on homepage
	Then I should see the default email text 'Default email: admin@domain.org'
	Then I should see the default password text 'Default password: 111111'

Scenario: BDD Login fields are displayed
	Given I am on homepage
	Then I should see the email and password fields 

Scenario: BDD Empty email validation
	Given I am on homepage
	When I click the login button
	Then I should see the validation message "Email address can't be null"

Scenario: BDD Email format validation
	Given I am on homepage
	And I have typed in email
	| Email           |
	| admindomain.org | 
	When I click the login button
	Then I should see the validation message "Email address format is not valid"
	
Scenario: BDD Password validation message
	Given I am on homepage
	And I have typed in email and Password 
	| Email           | Password |
	| admindomain.org | Invalid  |
	When I click the login button
	Then I should see the password validation message "Invalid password/email"

Scenario: BDD Login with valid credentials and check Dashboard Page
	Given I am on homepage
	And I have typed in email and Password
	| Email           | Password |
	| admin@domain.org | 111111  |
	When I click the login button
	Then I should be redirected to Dashboard page 'Dashboard page'

Scenario: BDD Logout
	Given I am on homepage
	And I login successfully to dashboard page
	| Email           | Password |
	| admin@domain.org | 111111  |
	When I press logout button
	Then I should be redirected to HomePage'Home page'