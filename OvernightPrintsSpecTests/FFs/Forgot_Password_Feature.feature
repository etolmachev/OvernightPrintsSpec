Feature: Forgot_Password_Feature
	In order to be able to reset my password
	As a user
	I want to have Forgot Password page


Scenario Template: Successfully Reset Password 
	When I open browser
	And I navigate to url "https://www.overnightprints.com"
	When I click Log in button on Main Page
	And I click Forgot you password button on Login popup
	Then I see Reset Password popup

	When I set following parameters on Reset Password popup
		| Field         | Value      |
		| Email Address | <email>    |
	And I click Reset Password button on Reset Password popup
	Then I see notification message "An email has been sent. It contains a link you must click to reset your password." on the "Reset Password"

	Examples: 
		| email                   |
		| invalid@tr.su           |
		| autestomation@gmail.com |

Scenario: Verification of Cancel button
	When I open browser
	And I navigate to url "https://www.overnightprints.com"
	When I click Log in button on Main Page
	And I click Forgot you password button on Login popup
	Then I see Reset Password popup

	When I set following parameters on Reset Password popup
		| Field         | Value                   |
		| Email Address | autestomation@gmail.com |
	And I click Cancel button on Reset Password popup
	Then I see Login popup 

	When I click Forgot you password button on Login popup
	Then I see Reset Password popup
	And I see following information email - "" on Reset Password popup

Scenario Template: Try to Reset Password with Invalid Credentials
	When I open browser
	And I navigate to url "https://www.overnightprints.com"
	When I click Log in button on Main Page
	And I click Forgot you password button on Login popup
	Then I see Reset Password popup

	When I set following parameters on Reset Password popup
	| Field         | Value   |
	| Email Address | <email> |
	And I click Reset Password button on Reset Password popup
	
	Then I see notification message "<messageChrome>" on the "Reset Password popup"

	Examples:
		| email   | messageChrome                                                            |
		|         | Please fill out this field.                                              |
		| gbgfgdf | Please include an '@' in the email address. 'gbgfgdf' is missing an '@'. |