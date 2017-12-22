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

	When I click Log in button on Main Page
	And I set following parameters on Login popup
		| Field         | Value     |
		| Email Address | autestomation@gmail.com |
		| Password      | 4sep98MPcalifUSA   |
	And I click Log in button on Login popup
	Then I see element My Account on the Main page
	And I see that user "Test" is logged in

	Examples: 
		| email         |
		| invalid@tr.su |
		| autestomation@gmail.com     |


Scenario: Verification of Cancel button
	When I open browser
	And I navigate to url "https://www.overnightprints.com"
	When I click Log in button on Main Page
	And I click Forgot you password button on Login popup
	Then I see Reset Password popup

	When I set following parameters on Reset Password popup
		| Field         | Value                   |
		| Email Address | autestomation@gmail.com |
	And I click Replace password button on Reset Password popup
	Then I see Login popup 
	And I see following information on Login popup
		| Field         | Value |
		| Email Address |       |
		| Password      |       |

	When I set following parameters on Login popup
		| Field         | Value                   |
		| Email Address | autestomation@gmail.com |
		| Password      | 4sep98MPcalifUSA        |
	And I click Log in button on Login popup
	Then I see element My Account on the Main page
	And I see that user "Test" is logged in


Scenario Template: Try to Reset Password with Invalid Credentials
	When I open browser
	And I navigate to url "https://www.overnightprints.com"
	When I click Log in button on Main Page
	And I click Forgot you password button on Login popup
	Then I see Reset Password popup

	When I set following parameters on Reset Password popup
	| Field         | Value   |
	| Email Address | <email> |
	And I click Replace password button on Reset Password popup
	
	Then I see notification message "<messageChrome>" on the "Reset Password popup"

	Examples:
		| email   | messageChrome                               |
		|         | Please fill out this field.                 |
		| gbgfgdf | Please include an '@' in the email address. |