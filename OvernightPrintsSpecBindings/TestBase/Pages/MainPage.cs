using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace OvernightPrintsSpecBindings.TestBase.Pages
{
    public class MainPage
    {
        private By _buttonLogInLocator = By.CssSelector("a[href='/login']");
        private HtmlElement ButtonLogInElement;

        public MainPage()
        {
            ButtonLogInElement = new HtmlElement(_buttonLogInLocator);
        }

        /// <summary>
        /// Method press the button to go to the login page
        /// </summary>
        public void ClickLogIn()
        {
            ButtonLogInElement.Click();
        }
    }
}
