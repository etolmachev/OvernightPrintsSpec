using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OvernightPrintsSpecBindings.TestBase;
using OvernightPrintsSpecBindings.TestBase.Pages;
using TechTalk.SpecFlow;

namespace OvernightPrintsSpecBindings.Bindings
{   
    [Binding]
    class LoginPageBindings
    {
        LoginPage Page = new LoginPage();

        [When(@"I click Log In button")]
        public void WhenIClickLogInButton()
        {
            Page.ClickLogIn();
        }

        [When(@"I write my email ""(.*)""")]
        public void WhenIWriteMyEmail(string email)
        {
            Page.TypeEmail(email);
        }

        [When(@"I write my password ""(.*)""")]
        public void WhenIWriteMyPassword(String pass)
        {
            Page.TypePass(pass);
        }

        [When(@"I click submit button")]
        public void WhenIClickSubmitButton()
        {
            Page.ClickSubmit();
        }

        [Then(@"I see displayed link MY ACCOUNT")]
        public void WhenISeeDisplayedLinkMyAccount()
        {
            HtmlElement linkElement = new HtmlElement(By.CssSelector("#my-account > span"));
            linkElement.WaitElementAppears(5);
            String textLink = linkElement.Text;
            Assert.AreEqual(textLink, "MY ACCOUNT");
        }


    }
}
