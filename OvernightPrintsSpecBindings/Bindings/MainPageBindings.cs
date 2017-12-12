using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OvernightPrintsSpecBindings.TestBase.Pages;
using TechTalk.SpecFlow;

namespace OvernightPrintsSpecBindings.Bindings
{   
    [Binding]
    class MainPageBindings
    {
        MainPage _mainPage = new MainPage();

        [When(@"I click Log In button")]
        public void WhenIClickLogInButton()
        {
            _mainPage.ClickLogIn();
        }
    }
}
