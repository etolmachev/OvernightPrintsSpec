Feature: LogIn_Feature
	In order to access my account on the website https://www.overnightprints.com
	As a user of the website
	I want to log into the website

@mytag
Scenario Template: Failure Login With Invalid Credentials
	Given I open browser
	And I navigate to url "https://www.overnightprints.com"
	When I click Log in button on Main Page
	And I set following parameters on Login popup
		| Field         | Value      |
		| Email Address | <email>    |
		| Password      | <password> |
	And I click Log in button on Login popup

	Then I see an error message on the Login popup with
		| Field   | Value                                                                       |
		| Message | The login and/or the password does not match our records. Please try again. |
	And I see that user is not logged in

	Examples: 
		| email                       | password                    |
		|                             |                             |
		| invalid@tr.su               | invalid                     |
		| afd@tr.su                   | invalid                     |
		| afd@tr.su                   |                             |
		| <script>alert(123)</script> | 12f3456                     |
		| afd@tr.su                   | <script>alert(123)</script> |  


Scenario: Successfully Login With Valid Credentials
	Given I open browser
	And I navigate to url "https://www.overnightprints.com"
	When I click Log in button on Main Page
	And I set following parameters on Login popup
		| Field         | Value     |
		| Email Address | afd@tr.su |
		| Password      | 12f3456   |
	And I click Log in button on Login popup
	Then I see element My Account on the Main page
	And I see that user is logged in


Scenario: Successfully Login With Valid Email with spaces and Valid Password
	Given I open browser
	And I navigate to url "https://www.overnightprints.com"
	When I click Log in button on Main Page
	And I set email "   afd@tr.su" on Login popup
	And I set password "12f3456" on Login popup
	And I click Log in button on Login popup
	Then I see element My Account on the Main page
	And I see that user is logged in

Scenario: Redirect to page Reset Password
	Given I open browser
	And I navigate to url "https://www.overnightprints.com"
	When I click Log in button on Main Page
	And I click Forgot you password on Login popup 
	Then I see Reset Password popup


Scenario: Verification Return Button
	Given I open browser
	And I navigate to url "https://www.overnightprints.com"
	When I click Log in button on Main Page
	And I set following parameters on Login popup
		| Field         | Value     |
		| Email Address | afd@tr.su |
		| Password      | 12f3456   |
	And I click Return button on Login popup
	Then I see Main page

	When I click Log in button on Main Page
	Then I see following information on Login popup
		| Field         | Value |
		| Email Address |       |
		| Password      |       |
	And I see that user is not logged in