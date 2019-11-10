@HomePage_Specflow

Feature: HomePageFeature
As an user
I want to make different actions on HomePage
	
Background: 
Given The user navigates to HomePage
And The user lands succesfully on HomePage

Scenario: Header Items Displayed
Then All the header items are displayed

Scenario: Page Title Ok

Scenario: Page Headling Title Ok
Then The Headling title is displayed

Scenario: Default Log In Details Displayed 
Then The corect log in credentials are displayed

Scenario: Log in fields displayed 
Then The log in fiels are displayed

Scenario: Missing Log In Details Error Message
When The user clicks on log in button
Then An empty credentisls warning message is displayed

Scenario: Invalid Email Format Error Message
When The user enters an invalid email
And The user clicks on log in button
Then An invalid email error message is displayed

Scenario: Invalid Email Or Password Error Message
When The user enters invalid log in credentials
And The user clicks on log in button
Then An invalid password or email error message is displayed

Scenario: Footer Links Are Displayed
Then All the footer items are displayed

Scenario: Succesful Navigate To Wiki Page
When The user navigates to WikiPage
Then The user lands succesfully on WikiPage

Scenario: Successful Log In
When The user logs in with success
Then The user lands succesfully on DashboardPage

