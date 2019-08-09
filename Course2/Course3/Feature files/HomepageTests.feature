Feature: HomePage tests

@mytag
Scenario: BDD Login with wrong password
	Given I am on homepage
	And I have typed in email
	| Email            | Password |  
	| admin@domain.org | invalid  |
	When I click the login button
	Then I should remain on homepage 'Home page'


Scenario: BDD Check header links & image
	Given I am on homepage
	Then I should see the header links and image

Scenario: BDD Check heading title
	Given I am on homepage
	Then I should see the heading title 'Heading title'

Scenario: BDD Check default email and password text
	Given I am on homepage
	Then I should see the default email and password texts 'Email', 'Password'

Scenario: BDD Check login fields are displayed
	Given I am on homepage
	Then I should see the Login fields

Scenario: BDD Check null email address error
	Given I am on homepage
	And I have not typed in email
	When I click the login button
	Then Email address cannot be null error should be displayed 'Email address null'

Scenario: BDD Check email format error
	Given I am on homepage
	And I have typed in email with wrong format
	When I click the login button
	Then I should see the Email format error 'Email format not valid'

Scenario: BDD Invalid login data
	Given I am on homepage
	And I have typed in email
	| Email            | Password |  
	| admin@domain.org | invalid  |
	And I have typed in incorrect password
	When I click the login button
	Then I should the Invalid email/password error 'Invalid email/password'

Scenario: BDD Login
	Given I am on homepage
	And I have typed in email
	| Email            | Password |  
	| admin@domain.org | invalid  |
	And I have typed in password
	When I click the login button
	Then I should land on the Dashboard page

Scenario: BBD Check Home footer links
	Given I am on homepage
	Then I should see the footer links

Scenario: BDD Navigate to Wiki page
	Given I am on homepage
	And I click the Wiki link
	Then I should be redirected to WikiPage 'Wiki page'