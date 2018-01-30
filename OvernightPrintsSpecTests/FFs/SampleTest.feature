Feature: SampleTest
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Open Login Page and Click Sign In Button
	When I open browser
	And I navigate to url "https://www.overnightprints.com"

	When I click Log in button on Main Page
	And I set following parameters on Login popup
		| Field         | Value                |
		| Email Address | {{config::email}}    |
		| Password      | {{config::password}} |
	And I click Log in button on Login popup
	Then I see element My Account on the Main page


Scenario: Successful Reset Password
	When I open browser
	And I navigate to url "https://www.overnightprints.com"
	When I click Log in button on Main Page
	And I click Forgot you password button on Login popup
	Then I see Reset Password popup

	When I set following parameters on Reset Password popup
		| Field         | Value             |
		| Email Address | {{config::email}} |
	And I click Reset Password button on Reset Password popup
	Then I see notification message "An email has been sent. It contains a link you must click to reset your password." on the "Reset Password" 
	And I wait for 5 seconds

	When I check the mail and remember the link to restore the password
	And I navigate to url "{{context::resetPasswordLink}}"
	Then I see Reset Password Page

	When I set following parameters on Reset Password Page
         | Field      | Value            |
         | Password   | 4sep98MPcalifUSA |
         | Validation | 4sep98MPcalifUSA |
	And I click Change Password Button on Reset Password Page
	Then I see that user "{{config::username}}" is logged in
