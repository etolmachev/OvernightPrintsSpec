using System;
using System.Collections.Generic;
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

        [When(@"I set following parameters on LoginPopUpPage")]
        public void WhenISetFollowingParametersOnLoginPopUpPage(Table table)
        {
            foreach (var row in table.Rows)
            {
                string key = row["Field"];

                switch (key)
                {
                    case "Email":
                        _popUpPage.TypeEmail(row["Value"]);
                        break;

                    case "Password":
                        _popUpPage.TypePass(row["Value"]);
                        break;

                    default:
                        throw new NotImplementedException();
                }
            }
        }
    }
}
