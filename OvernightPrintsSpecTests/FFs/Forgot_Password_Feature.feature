Feature: Forgot_Password_Feature
	In order to access page Forgot Password
	As a user of the website
	I want to reset my password

@mytag
Scenario Template: Successfully Reset Password 
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


Scenario: Verification Cancel Button
	Given I open browser
	And I navigate to url "https://www.overnightprints.com"
	When I click Log in button on Main Page
	And I click Forgot you password on Login popup
	Then I see Reset Password popup

	When I set following parameters on Reset Password popup
		| Field         | Value     |
		| Email Address | afd@tr.su |
	And I click Cancel Button on Reset Password popup
	Then I see Login popup 
	And I see following information on Login popup
		| Field         | Value |
		| Email Address |       |
		| Password      |       |

	When I set following parameters on Login popup
		| Field         | Value     |
		| Email Address | afd@tr.su |
		| Password      | 12f3456   |
	And I click Log in button on Login popup
	Then I see element My Account on the Main page
	And I see that user is logged in


Scenario Template: Failure Reset Password with Invalid Credentials
	Given I open browser
	And I navigate to url "https://www.overnightprints.com"
	When I click Log in button on Main Page
	And I click Forgot you password on Login popup
	Then I see Reset Password popup

	When I set following parameters on Reset Password popup
	| Field         | Value   |
	| Email Address | <email> |
	And I click Cancel Button on Reset Password popup
	Then I see an error message on Reset Password popup with
		| Field   | Value           |
		| Message | <messageChrome> |

	Examples:
		| email   | messageChrome                               |
		|         | Please fill out this field.                 |
		| gbgfgdf | Please include an '@' in the email address. |