Feature: SampleTest
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Open Login Page and Click Sign In Button
	When I open browser
	And I navigate to url "https://www.overnightprints.com"

	When I click Log in button on Main Page
	And I set email "autestomation@gmail.com" on Login popup
	And I set password "4sep98MPcalifUSA" on Login popup
	And I click Log in button on Login popup
	Then I see element My Account on the Main page
