Feature: SampleTest
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Open Login Page and Click Sign In Button

	Given I open browser
	And I navigate to url "https://www.overnightprints.com"

	When I click Log In button
	And I write my email "afd@tr.su"
	And I write my password "12f3456"
	And I click submit button	
	Then I see displayed link MY ACCOUNT

