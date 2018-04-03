Feature: Login
	To Test Login feature

@mytag
Scenario: Login With valid values
	Given I have navigated to Login page
	And I have entered username as user@phptravels.com
	And I have entered password as demouser
	When I have pressed Login button
	Then I should see MyAccountPage

@mytag
Scenario: Login With invalid values
	Given I have navigated to Login page
	And I have entered username as user@phptravels.com
	And I have entered password as demousera
	When I have pressed Login button
	Then I should see error login failed message
