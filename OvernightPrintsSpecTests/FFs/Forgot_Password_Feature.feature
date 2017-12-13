Feature: Forgot_Password_Feature
	In order to access page Forgot Password
	As a user of the website
	I want to reset my password

@mytag
Scenario Template: Failure Reset Password With Invalid Credentials
	Given I open browser
	And I navigate to url "https://www.overnightprints.com"
	When I click Log in button on Main Page
	And I click Link Name on Login popup 
		| Field     | Value               |
		| Link Name | Forgot you password |
	Then I see Reset Password page

	When I set following parameters on Reset password page
		| Field         | Value   |
		| Email Address | <email> |
	And I click Reset Password button
	Then I see an error message with
		| Field   | Value |
		| message |

	Examples: 
		| Email Address   |
		|                 |
		| invalid@mail.ru | 
