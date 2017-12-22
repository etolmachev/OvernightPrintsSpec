Feature: LogIn_Feature
	In order to have a secure access to my account
	As a user
	I want to have 'Log In' feature
	So that I can log into the website using my credentials

Scenario Template: Log In with Invalid Credentials
	When I open browser
	And I navigate to url "https://www.overnightprints.com"
	When I click Log in button on Main Page
	And I set following parameters on Login popup
		| Field         | Value      |
		| Email Address | <email>    |
		| Password      | <password> |
	And I click Log in button on Login popup

	Then I see notification message "The login and/or the password does not match our records. Please try again." on the "Login popup"
	And I see that user is not logged in

	Examples: 
		| email                       | password                    |
		|                             |                             |
		| invalid@tr.su               | invalid                     |
		| autestomation@gmail.com     | invalid                     |
		| autestomation@gmail.com     |                             |
		| <script>alert(123)</script> | 4sep98MPcalifUSA            |
		| autestomation@gmail.com     | <script>alert(123)</script> |


Scenario: Successfully Login With Valid Credentials
	When I open browser
	And I navigate to url "https://www.overnightprints.com"
	When I click Log in button on Main Page
	And I set following parameters on Login popup
		| Field         | Value                   |
		| Email Address | autestomation@gmail.com |
		| Password      | 4sep98MPcalifUSA        |
	And I click Log in button on Login popup
	Then I see element My Account on the Main page
	And I see that user "Test" is logged in


Scenario: Successfully Login With Valid Email with spaces and Valid Password
	When I open browser
	And I navigate to url "https://www.overnightprints.com"
	When I click Log in button on Main Page
	And I set email "   autestomation@gmail.com" on Login popup
	And I set password "4sep98MPcalifUSA" on Login popup
	And I click Log in button on Login popup
	Then I see element My Account on the Main page
	And I see that user "Test" is logged in

Scenario: Verification of X Button
	When I open browser
	And I navigate to url "https://www.overnightprints.com"
	When I click Log in button on Main Page
	And I set following parameters on Login popup
		| Field         | Value                   |
		| Email Address | autestomation@gmail.com |
		| Password      | 4sep98MPcalifUSA        |
	And I click X button on Login popup
	Then I see Main page

	When I click Log in button on Main Page
	Then I see following information on Login popup
		| Field         | Value |
		| Email Address |       |
		| Password      |       |
	And I see that user is not logged in