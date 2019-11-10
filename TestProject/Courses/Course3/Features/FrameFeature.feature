Feature: FrameFeature
As an user 
I would like to do different actions
Using two different frames

Background: 
Given The user navigates to HomePage
And The user lands succesfully on HomePage
When The user clicks the frames page link
And The user land succesfully on FramesPage

Scenario: Write inside the text area of Frame A
When The user is focusing on the first frame
Then The user types inside the textbox 

Scenario: Write inside the text area of Frame B
When The user is focusing on the second frame
Then The user types inside the textbox

	