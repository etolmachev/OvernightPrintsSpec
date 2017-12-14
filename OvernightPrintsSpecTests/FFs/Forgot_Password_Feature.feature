Feature: Forgot_Password_Feature
	In order to access page Forgot Password
	As a user of the website
	I want to reset my password

@mytag
Scenario Template: Name 
	Given I open browser
	And I navigate to url "https://www.overnightprints.com"
	When I click Log in button on Main Page
	And I click Forgot you password on Login popup
	Then I see Reset Password popup

	When I set following parameters on Reset Password popup
		| Field         | Value      |
		| Email Address | <email>    |
	And I click Reset Password Button on Reset Password popup
	Then I see notification message about successful reset password

	When I click Log in button on Main Page
	And I set following parameters on Login popup
		| Field         | Value     |
		| Email Address | afd@tr.su |
		| Password      | 12f3456   |
	And I click Log in button on Login popup
	Then I see element My Account on the Main page
	And I see that user is logged in

	Examples: 
		| email         |
		| invalid@tr.su |
		| afd@tr.su     |