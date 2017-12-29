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
    [NUnit.Framework.DescriptionAttribute("Forgot_Password_Feature")]
    public partial class Forgot_Password_FeatureFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Forgot_Password_Feature.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Forgot_Password_Feature", "In order to be able to reset my password\r\nAs a user\r\nI want to have Forgot Passwo" +
                    "rd page", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("Successful Reset Password")]
        [NUnit.Framework.TestCaseAttribute("invalid@tr.su", null)]
        [NUnit.Framework.TestCaseAttribute("autestomation@gmail.com", null)]
        public virtual void SuccessfulResetPassword(string email, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Successful Reset Password", exampleTags);
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
 testRunner.When("I open browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 9
 testRunner.And("I navigate to url \"https://www.overnightprints.com\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
 testRunner.When("I click Log in button on Main Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 11
 testRunner.And("I click Forgot you password button on Login popup", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
 testRunner.Then("I see Reset Password popup", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table1.AddRow(new string[] {
                        "Email Address",
                        string.Format("{0}", email)});
#line 14
 testRunner.When("I set following parameters on Reset Password popup", ((string)(null)), table1, "When ");
#line 17
 testRunner.And("I click Reset Password button on Reset Password popup", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
 testRunner.Then("I see notification message \"An email has been sent. It contains a link you must c" +
                    "lick to reset your password.\" on the \"Reset Password\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verification of Cancel button")]
        public virtual void VerificationOfCancelButton()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verification of Cancel button", ((string[])(null)));
#line 25
this.ScenarioSetup(scenarioInfo);
#line 26
 testRunner.When("I open browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 27
 testRunner.And("I navigate to url \"https://www.overnightprints.com\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
 testRunner.When("I click Log in button on Main Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 29
 testRunner.And("I click Forgot you password button on Login popup", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
 testRunner.Then("I see Reset Password popup", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table2.AddRow(new string[] {
                        "Email Address",
                        "autestomation@gmail.com"});
#line 32
 testRunner.When("I set following parameters on Reset Password popup", ((string)(null)), table2, "When ");
#line 35
 testRunner.And("I click Cancel button on Reset Password popup", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 36
 testRunner.Then("I see Login popup", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 38
 testRunner.When("I click Forgot you password button on Login popup", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 39
 testRunner.Then("I see Reset Password popup", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 40
 testRunner.And("I see following information email - \"\" on Reset Password popup", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Try to Reset Password with Invalid Credentials")]
        [NUnit.Framework.TestCaseAttribute("", "Please fill out this field.", null)]
        [NUnit.Framework.TestCaseAttribute("gbgfgdf", "Please include an \'@\' in the email address. \'gbgfgdf\' is missing an \'@\'.", null)]
        public virtual void TryToResetPasswordWithInvalidCredentials(string email, string messageChrome, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Try to Reset Password with Invalid Credentials", exampleTags);
#line 42
this.ScenarioSetup(scenarioInfo);
#line 43
 testRunner.When("I open browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 44
 testRunner.And("I navigate to url \"https://www.overnightprints.com\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 45
 testRunner.When("I click Log in button on Main Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 46
 testRunner.And("I click Forgot you password button on Login popup", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
 testRunner.Then("I see Reset Password popup", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table3.AddRow(new string[] {
                        "Email Address",
                        string.Format("{0}", email)});
#line 49
 testRunner.When("I set following parameters on Reset Password popup", ((string)(null)), table3, "When ");
#line 52
 testRunner.And("I click Reset Password button on Reset Password popup", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 54
 testRunner.Then(string.Format("I see notification message \"{0}\" on the \"Reset Password popup\"", messageChrome), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
