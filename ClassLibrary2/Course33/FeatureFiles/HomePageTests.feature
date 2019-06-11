Feature: HomePageTests

@homepagetests
Scenario:  BDD Header links and image are displayed
	Given I am on the homepage
	Then the homepage link is displayed
	And the wikipedia link is displayed
	And the image is displayed

@homepagetests
Scenario: BDD Home Page Heading Title Is Correct
	Given I am on the homepage
	Then the expected title is 'HTML'

@homepagetests
Scenario: BDD Default Email And Password Label Checks
	Given I am on the homepage
	Then the default email label text is 'Email'
	And default password label text is 'Password'

@homepagetests
Scenario: BDD Login Fields Are Displayed
	Given I am on the homepage
	Then email field is displayed
	And password field is displayed

@homepagetests
Scenario: BDD Empty Email Address Error Message
	Given I am on the homepage
	And I click login button leaving email field empty
	Then 'Email address can't be null' message is displayed above the email field

@homepagetests
Scenario: BDD Email Address Not Valid
	Given I am on the homepage
	When I type 'admin.domain.org' in the email textbox
	And I click login button
	Then 'Email address format is not valid' is displayed above the email textbox

@homepagetests
Scenario: BDD Email Address Or Password Not Valid
	Given I am on the homepage
	When I type 'admin@domain.org' in the email textbox
	And I type '234' in the password textbox
	And I click login button
	Then 'Invalid password/email' message is displayed above the password textbox

@homepagetests
Scenario: : BDD Login Successful
	Given I am on the homepage
	When I type 'admin@domain.org' in the email textbox
	And I type '111111' in the password textbox
	And I click login button successfully
	Then Dasboard page is displayed with title 'Dashboard page'