Feature: LogIn
	Check if the Login functionality is working
	as expected with different permutations and 
	combinations of data

Background: 
	Given I Delete employee 'AutoUser' before I start running test
	
@smoke @positive
Scenario: Check LogIn with currect username and password
	Given I have navigated to the application
	And I see application opened
	Then I click login link
	When I enter UserName and Password and click login
	| UserName | Pasword |
	| admin    |password |
	Then I click login button
	Then I should see the username with hello