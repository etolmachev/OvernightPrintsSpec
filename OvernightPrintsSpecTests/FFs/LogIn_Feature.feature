Feature: LogIn_Feature
	In order to access my account on the website https://www.overnightprints.com
	As a user of the website
	I want to log into the website

@mytag
Scenario: Failure Login with Null Credentials
	Given User is at the Main Page
	And Navigate to LogInPopUp Page
	When User click Log in button
	Then User see an error message


Scenario Outline: Failure Login With Invalid Credentials
	Given User is at the Main Page
	And Navigate to LogInPopUp Page
	When User set <email> and <password>
	And User click Log In Button
	Then User see an error message
	Examples: 
	| email                       | password                    |
	| invalid@tr.su               | invalid                     |
	| afd@tr.su                   | invalid                     |
	| <script>alert(123)</script> | 12f3456                     |
	| afd@tr.su                   | <script>alert(123)</script> |


Scenario: Failure Login With Valid Email and Null Password
	Given User is at the Main Page
	And Navigate to LogInPopUp Page
	When User set email afd@tr.su
	And User click Log In Buttom
	Then User see an error message 


Scenario: Redirect to page Reset Password
	Given User is at the Main Page
	And Navigate to LogInPopUp Page
	When User click link "Forgot you password"
	Then User redirect to Page Reset Password
