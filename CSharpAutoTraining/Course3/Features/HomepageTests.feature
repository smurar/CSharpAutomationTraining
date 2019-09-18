Feature: HomePage Tests

Scenario: Check if header links and image are displayed
	Given I am on homepage
	Then the header links are displayed
	And the image in the header is displayed

Scenario: Test that the page title is correct
	Given I am on homepage
	Then the page title is correct

Scenario: Test that the page heading title is correct
	Given I am on homepage
	Then the page heading title is correct

Scenario: Test that the default e-mail is correct
	Given I am on homepage
	Then the default e-mail is correct

Scenario: Test that the default password is correct
	Given I am on homepage
	Then the default password is correct

Scenario: Test that the user can authenticate
	Given I am on homepage
	When I type in the credentials and click the login button
	| E-mail           | Password |
	| admin@domain.org | 111111   |
	Then I am redirected to 'Dashboard page'

Scenario: Login with missing email
	Given I am on homepage
	When I type in the credentials and click the login button
	| E-mail           | Password |
	|                  | 111111   |
	Then I should remain on 'Homepage'
	And a null email error should be displayed

Scenario: Login with wrong email
	Given I am on homepage
	When I type in the credentials and click the login button
	| E-mail    | Password |
	| invalid   | 111111   |
	Then I should remain on 'Homepage'
	And an invalid email error should be displayed

Scenario: Login with missing password
	Given I am on homepage
	When I type in the credentials and click the login button
	| E-mail           | Password |
	| admin@domain.org |          |
	Then I should remain on 'Homepage'
	And a null password error should be displayed

Scenario: Login with wrong password
	Given I am on homepage
	When I type in the credentials and click the login button
	| E-mail           | Password |
	| admin@domain.org | invalid  |
	Then I should remain on 'Homepage'
	And an invalid password error should be displayed

Scenario: Login without credentials
	Given I am on homepage
	When I type in the credentials and click the login button
	| E-mail           | Password |
	|				   |		  |
	Then I should remain on 'Homepage'
	And a null email error should be displayed
	And a null password error should be displayed

Scenario: Login with wrong credentials
	Given I am on homepage
	When I type in the credentials and click the login button
	| E-mail           | Password |
	| invalid		   | invalid  |
	Then I should remain on 'Homepage'
	And an invalid email error should be displayed
	And an invalid password error should be displayed

Scenario: Test that footer links are displayed
	Given I am on homepage
	Then the footer links are displayed