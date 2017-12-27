﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.42000
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace OvernightPrintsSpecTests.FFs
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Registration_Feature")]
    public partial class Registration_FeatureFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Registration.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Registration_Feature", "In order to create a new accountEmail\r\nAs a user\r\nI want to have \'Create Account\'" +
                    " feature\r\nSo that I can create acccount on the website using my credentials", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Successfully Registration With Valid Credentials")]
        [NUnit.Framework.TestCaseAttribute("4sep98MP", "4sep98MP", "::", "никнейм", null)]
        [NUnit.Framework.TestCaseAttribute("привет", "привет", "никнейм", "::", null)]
        [NUnit.Framework.TestCaseAttribute("\"      \"", "\"      \"", "Test", "Test", null)]
        public virtual void SuccessfullyRegistrationWithValidCredentials(string password, string repassword, string firstName, string lastName, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Successfully Registration With Valid Credentials", exampleTags);
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
 testRunner.When("I open browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 9
 testRunner.And("I navigate to url \"https://www.overnightprints.com\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
 testRunner.And("I click Log in button on Main Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
 testRunner.Then("I see Login popup", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 13
 testRunner.When("I click Create My Account button on Login popup", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 14
 testRunner.Then("I see Register popup", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 16
 testRunner.When("I remember \"autestoma+{{rnd::3}}tion@gmail.com\" as \"email\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table1.AddRow(new string[] {
                        "Email Address",
                        "{{context::email}}"});
            table1.AddRow(new string[] {
                        "Password",
                        string.Format("{0}", password)});
            table1.AddRow(new string[] {
                        "Repassword",
                        string.Format("{0}", repassword)});
            table1.AddRow(new string[] {
                        "First Name",
                        "Test"});
            table1.AddRow(new string[] {
                        "Last Name",
                        "Test"});
#line 17
 testRunner.And("I set following parameters on Register popup", ((string)(null)), table1, "And ");
#line 25
 testRunner.And("I click Create My Account button on Register popup", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
 testRunner.Then("I see Response to Create Account Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 28
 testRunner.When("I click Continue button on the Response to Create Account Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 29
 testRunner.Then("I see Main page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 30
 testRunner.And("I see element My Account on the Main page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
 testRunner.And("I see that user \"Test\" is logged in", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Create new account with Invalid Credentials")]
        [NUnit.Framework.TestCaseAttribute("", "", "", "", "", "Please fill out this field.", "Email", null)]
        [NUnit.Framework.TestCaseAttribute("autestoma+{{rnd::3}}tion@gmail.com", "", "", "", "", "Please fill out this field.", "Pass", null)]
        [NUnit.Framework.TestCaseAttribute("autestoma+{{rnd::3}}tion@gmail.com", "4sep98MP", "", "", "", "Please fill out this field.", "VerifyPass", null)]
        [NUnit.Framework.TestCaseAttribute("autestoma+{{rnd::3}}tion@gmail.com", "4sep98MP", "4sep98MP", "", "", "Please fill out this field.", "FirstName", null)]
        [NUnit.Framework.TestCaseAttribute("autestoma+{{rnd::3}}tion@gmail.com", "4sep98MP", "4sep98MP", "Test", "", "Please fill out this field.", "LastName", null)]
        [NUnit.Framework.TestCaseAttribute("autestomation@gmail.com", "4sep98MP", "4sep98MP", "Test", "Test", "The email is already used", "EmailHelpBlock", null)]
        [NUnit.Framework.TestCaseAttribute("autestomation@gmail.", "4sep98MP", "4sep98MP", "Test", "Test", "\'.\' is used at a wrong position in \'gmail.\'.", "Email", null)]
        [NUnit.Framework.TestCaseAttribute("autestomationgmail.com", "4sep98MP", "4sep98MP", "Test", "Test", "Please include an \'@\' in the email address. \'autestomationgmail.com\' is missing a" +
            "n \'@\'.", "Email", null)]
        [NUnit.Framework.TestCaseAttribute("autestomation@gmailcom", "4sep98MP", "4sep98MP", "Test", "Test", "The email is not valid", "EmailHelpBlock", null)]
        [NUnit.Framework.TestCaseAttribute("autestoma\"tion@gmailcom", "4sep98MP", "4sep98MP", "Test", "Test", "A part followed by \'@\' should not contain the symbol \'\"\'.", "Email", null)]
        [NUnit.Framework.TestCaseAttribute("autestomation@gma\"ilcom", "4sep98MP", "4sep98MP", "Test", "Test", "A part following \'@\' should not contain the symbol \'\"\'.", "Email", null)]
        [NUnit.Framework.TestCaseAttribute("почта@mail.ru", "4sep98MP", "4sep98MP", "Test", "Test", "A part followed by \'@\' should not contain the symbol \'п\'.", "Email", null)]
        [NUnit.Framework.TestCaseAttribute("autestoma+{{rnd::3}}tion@gmail.com", "12345", "12345", "Test", "Test", "This value is too short. It should have 6 characters or more.", "PassHelpBlock", null)]
        [NUnit.Framework.TestCaseAttribute("autestoma+{{rnd::3}}tion@gmail.com", "different", "password", "Test", "Test", "The entered passwords don\'t match.", "PassHelpBlock", null)]
        [NUnit.Framework.TestCaseAttribute("autestoma+{{rnd::3}}tion@gmail.com", "4sep98MP", "4sep98MP", "\" \"", "Test", "Please enter a First name", "FirstNameHelpBlock", null)]
        [NUnit.Framework.TestCaseAttribute("autestoma+{{rnd::3}}tion@gmail.com", "4sep98MP", "4sep98MP", "Test", "\" \"", "Please enter a Last name", "LastNameHelpBlock", null)]
        public virtual void CreateNewAccountWithInvalidCredentials(string email, string password, string repassword, string firstName, string lastName, string message, string place, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create new account with Invalid Credentials", exampleTags);
#line 39
this.ScenarioSetup(scenarioInfo);
#line 40
 testRunner.When("I open browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 41
 testRunner.And("I navigate to url \"https://www.overnightprints.com\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 42
 testRunner.And("I click Log in button on Main Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 43
 testRunner.Then("I see Login popup", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 45
 testRunner.When("I click Create My Account button on Login popup", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 46
 testRunner.Then("I see Register popup", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table2.AddRow(new string[] {
                        "Email Address",
                        string.Format("{0}", email)});
            table2.AddRow(new string[] {
                        "Password",
                        string.Format("{0}", password)});
            table2.AddRow(new string[] {
                        "Repassword",
                        string.Format("{0}", repassword)});
            table2.AddRow(new string[] {
                        "First Name",
                        string.Format("{0}", firstName)});
            table2.AddRow(new string[] {
                        "Last Name",
                        string.Format("{0}", lastName)});
#line 48
 testRunner.When("I set following parameters on Register popup", ((string)(null)), table2, "When ");
#line 55
 testRunner.And("I click Create My Account button on Register popup", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 56
 testRunner.Then(string.Format("I see notification message \"{0}\" on the Register popup on the element \"{1}\"", message, place), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 57
 testRunner.And("I wait for 10 seconds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verification of X Button on the Register popup")]
        public virtual void VerificationOfXButtonOnTheRegisterPopup()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verification of X Button on the Register popup", ((string[])(null)));
#line 78
this.ScenarioSetup(scenarioInfo);
#line 79
 testRunner.When("I open browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 80
 testRunner.And("I navigate to url \"https://www.overnightprints.com\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 81
 testRunner.And("I click Log in button on Main Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 82
 testRunner.Then("I see Login popup", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 84
 testRunner.When("I click Create My Account button on Login popup", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 85
 testRunner.Then("I see Register popup", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table3.AddRow(new string[] {
                        "Email Address",
                        "autestoma+{{rnd::3}}tion@gmail.com"});
            table3.AddRow(new string[] {
                        "Password",
                        "4sep98MP"});
            table3.AddRow(new string[] {
                        "Repassword",
                        "4sep98MP"});
            table3.AddRow(new string[] {
                        "First Name",
                        "Test"});
            table3.AddRow(new string[] {
                        "Last Name",
                        "Test"});
#line 87
 testRunner.When("I set following parameters on Register popup", ((string)(null)), table3, "When ");
#line 94
 testRunner.And("I click X button on Register popup", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 95
 testRunner.Then("I see Main page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 97
 testRunner.When("I click Log in button on Main Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 98
 testRunner.Then("I see Login popup", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 99
 testRunner.When("I click Create My Account button on Login popup", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 100
 testRunner.Then("I see Register popup", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table4.AddRow(new string[] {
                        "Email Address",
                        ""});
            table4.AddRow(new string[] {
                        "Password",
                        ""});
            table4.AddRow(new string[] {
                        "Repassword",
                        ""});
            table4.AddRow(new string[] {
                        "First Name",
                        ""});
            table4.AddRow(new string[] {
                        "Last Name",
                        ""});
#line 101
 testRunner.Then("I see following information on Register popup", ((string)(null)), table4, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
