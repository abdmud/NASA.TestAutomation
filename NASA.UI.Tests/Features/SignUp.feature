Feature: Sign Up
User successfully signs up via form

@smoke
Scenario: Successful sign up
	Given I navigate to the sign up page
	When I fill in the sign up form with valid data
	And I click the submit button
	Then I should see a success message

@validation
Scenario: Validation error on sign up
	Given I navigate to the sign up page
	When I click the submit button
	Then I should see a validation error message for the required fields