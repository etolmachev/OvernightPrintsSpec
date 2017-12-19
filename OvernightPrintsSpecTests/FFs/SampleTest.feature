Feature: SampleTest
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Open Login Page and Click Sign In Button

	Given I open browser
	And I navigate to url "https://www.overnightprints.com"

	When I click Log in button on Main Page
	And I set email "afd@tr.su" on Login popup
	And I set password "12f3456" on Login popup
	And I click Log in button on Login popup
	Then I see displayed link MY ACCOUNT
