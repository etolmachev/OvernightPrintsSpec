Feature: Registration_Feature
	In order to create a new account
	As a user
	I want to have 'Create Account' feature
	So that I can create acccount on the website using my credentials

Scenario Template: Successful Registration With Valid Credentials
	When I open browser
	And I navigate to url "https://www.overnightprints.com"
	And I click Log in button on Main Page
	Then I see Login popup

	When I click Create My Account button on Login popup
	Then I see Register popup

	When I remember "autestoma+{{rnd::3}}tion@gmail.com" as "email"
	And I set following parameters on Register popup
		| Field         | Value              |
		| Email Address | {{context::email}} |
		| Password      | <password>         |
		| Repassword    | <repassword>       |
		| First Name    | <firstName>        |
		| Last Name     | <lastName>         |

	And I click Create My Account button on Register popup
	Then I see Response to Create Account Page

	When I click Continue button on the Response to Create Account Page
	Then I see Main page
	And I see element My Account on the Main page
	And I see that user "<firstName>" is logged in

	Examples:
		| password | repassword | firstName | lastName |
		| 4sep98MP | 4sep98MP   | ::        | никнейм  |
		| привет   | привет     | никнейм   | ::       |
		| "      " | "      "   | Test      | Test     |

Scenario Template: Create new account with Invalid Credentials
	When I open browser
	And I navigate to url "https://www.overnightprints.com"
	And I click Log in button on Main Page
	Then I see Login popup

	When I click Create My Account button on Login popup
	Then I see Register popup

	When I set following parameters on Register popup
		| Field         | Value        |
		| Email Address | <email>      |
		| Password      | <password>   |
		| Repassword    | <repassword> |
		| First Name    | <firstName>  |
		| Last Name     | <lastName>   |
	And I click Create My Account button on Register popup
	Then I see notification message "<message>" on the Register popup on the element "<place>"
	And I wait for 10 seconds

	Examples:
		| email                              | password  | repassword | firstName | lastName | message                                                                                 | place              |
		|                                    |           |            |           |          | Please fill out this field.                                                             | Email              |
		| autestoma+{{rnd::3}}tion@gmail.com |           |            |           |          | Please fill out this field.                                                             | Pass               |
		| autestoma+{{rnd::3}}tion@gmail.com | 4sep98MP  |            |           |          | Please fill out this field.                                                             | VerifyPass         |
		| autestoma+{{rnd::3}}tion@gmail.com | 4sep98MP  | 4sep98MP   |           |          | Please fill out this field.                                                             | FirstName          |
		| autestoma+{{rnd::3}}tion@gmail.com | 4sep98MP  | 4sep98MP   | Test      |          | Please fill out this field.                                                             | LastName           |
		| autestomation@gmail.com            | 4sep98MP  | 4sep98MP   | Test      | Test     | The email is already used                                                               | EmailHelpBlock     |
		| autestomation@gmail.               | 4sep98MP  | 4sep98MP   | Test      | Test     | '.' is used at a wrong position in 'gmail.'.                                            | Email              |
		| autestomationgmail.com             | 4sep98MP  | 4sep98MP   | Test      | Test     | Please include an '@' in the email address. 'autestomationgmail.com' is missing an '@'. | Email              |
		| autestomation@gmailcom             | 4sep98MP  | 4sep98MP   | Test      | Test     | The email is not valid                                                                  | EmailHelpBlock     |
		| autestoma"tion@gmailcom            | 4sep98MP  | 4sep98MP   | Test      | Test     | A part followed by '@' should not contain the symbol '"'.                               | Email              |
		| autestomation@gma"ilcom            | 4sep98MP  | 4sep98MP   | Test      | Test     | A part following '@' should not contain the symbol '"'.                                 | Email              |
		| почта@mail.ru                      | 4sep98MP  | 4sep98MP   | Test      | Test     | A part followed by '@' should not contain the symbol 'п'.                               | Email              |
		| autestoma+{{rnd::3}}tion@gmail.com | 12345     | 12345      | Test      | Test     | This value is too short. It should have 6 characters or more.                           | PassHelpBlock      |
		| autestoma+{{rnd::3}}tion@gmail.com | different | password   | Test      | Test     | The entered passwords don't match.                                                      | PassHelpBlock      |
		| autestoma+{{rnd::3}}tion@gmail.com | 4sep98MP  | 4sep98MP   | " "       | Test     | Please enter a First name                                                               | FirstNameHelpBlock |
		| autestoma+{{rnd::3}}tion@gmail.com | 4sep98MP  | 4sep98MP   | Test      | " "      | Please enter a Last name                                                                | LastNameHelpBlock  |

Scenario: Verification of X Button on the Register popup
	When I open browser
	And I navigate to url "https://www.overnightprints.com"
	And I click Log in button on Main Page
	Then I see Login popup

	When I click Create My Account button on Login popup
	Then I see Register popup

	When I set following parameters on Register popup
		| Field         | Value                              |
		| Email Address | autestoma+{{rnd::3}}tion@gmail.com |
		| Password      | 4sep98MP                           |
		| Repassword    | 4sep98MP                           |
		| First Name    | Test                               |
		| Last Name     | Test                               |
	And I click X button on Register popup
	Then I see Main page

	When I click Log in button on Main Page
	Then I see Login popup
	When I click Create My Account button on Login popup
	Then I see Register popup
	Then I see following information on Register popup
		| Field         | Value |
		| Email Address |       |
		| Password      |       |
		| Repassword    |       |
		| First Name    |       |
		| Last Name     |       |