@DashboardPage_Specflow

Feature: DashboardPageFeature
 As an user
 I want to make different actions on DashboardPage

 Background: 
Given The user navigates to HomePage
When The user logs in with success 
Then The user lands succesfully on DashboardPage 

Scenario: Check Page Header Elements
Then All the DashboarPage header items are displayed

Scenario: Page title ok

Scenario: Page Headling Title Ok
Then The DashboardPage headling title is displayed

Scenario: Footer Links Are Displayed
Then All the DashboardPage footer items are displayed

Scenario: Successful Log Out
When The user clicks on log out button 
Then The user lands succesfully on HomePage

Scenario: Edit Personal Information Succesful
Given The user completes all fields
When The user click the save button
Then A confirmation message is displayed


