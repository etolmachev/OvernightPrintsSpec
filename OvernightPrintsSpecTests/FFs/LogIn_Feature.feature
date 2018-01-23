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
		| {{config::email}}           | invalid                     |
		| {{config::email}}           |                             |
		| <script>alert(123)</script> | {{config::password}}        |
		| {{config::email}}           | <script>alert(123)</script> |

Scenario Template: Successful Login With Valid Credentials
	When I open browser
	And I navigate to url "https://www.overnightprints.com"
	When I click Log in button on Main Page
	And I set following parameters on Login popup
		| Field         | Value      |
		| Email Address | <email>    |
		| Password      | <password> |
	And I click Log in button on Login popup
	Then I see element My Account on the Main page
	And I see that user "Test" is logged in

	Examples: 
		| email                        | password             |
		| {{config::email}}            | {{config::password}} |
		| "   autestomation@gmail.com" | {{config::password}} |

Scenario: Verification of X Button
	When I open browser
	And I navigate to url "https://www.overnightprints.com"
	When I click Log in button on Main Page
	And I set following parameters on Login popup
		| Field         | Value                |
		| Email Address | {{config::email}}    |
		| Password      | {{config::password}} |
	And I click X button on Login popup
	Then I see Main page

	When I click Log in button on Main Page
	Then I see following information on Login popup
		| Field         | Value |
		| Email Address |       |
		| Password      |       |
	And I see that user is not logged in