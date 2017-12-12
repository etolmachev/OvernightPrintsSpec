using System;
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
        LoginPopUpPage _popUpPage = new LoginPopUpPage();

        [When(@"I write my email ""(.*)""")]
        public void WhenIWriteMyEmail(string email)
        {
            _popUpPage.TypeEmail(email);
        }

        [When(@"I write my password ""(.*)""")]
        public void WhenIWriteMyPassword(String pass)
        {
            _popUpPage.TypePass(pass);
        }

        [When(@"I click submit button")]
        public void WhenIClickSubmitButton()
        {
            _popUpPage.ClickSubmit();
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
