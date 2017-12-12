using System;
using OpenQA.Selenium;

namespace OvernightPrintsSpecBindings.TestBase.Pages
{
    public class LoginPopUpPage
    {
        private By _emailLocator = By.Id("username");
        private By _passLocator = By.Id("password");
        private By _buttonLogInSubmitLocator = By.CssSelector("#ui-id-3 > div > div.myonp.myonp-login > div.myonp-login-pane.log-in > form > div.control-group > div > button");
        private By _buttonCreateMyAccountLocator = By.CssSelector("#ui-id-3 > div > div.myonp.myonp-login > div.myonp-login-pane.create-account > a > span");

        private HtmlElement EmailElement;
        private HtmlElement PassElement;
        private HtmlElement ButtonLogInSubmitElement;
        private HtmlElement ButtonCreateMyAccount;

        public LoginPopUpPage()
        {
            EmailElement = new HtmlElement(_emailLocator);
            PassElement = new HtmlElement(_passLocator);
            ButtonLogInSubmitElement = new HtmlElement(_buttonLogInSubmitLocator);
            ButtonCreateMyAccount = new HtmlElement(_buttonCreateMyAccountLocator);
        }


        /// <summary>
        /// The method fills the email field passed by the value
        /// </summary>
        /// <param name="email">Email value for filling</param> 
        public void TypeEmail(String email)
        {
            EmailElement.SendKeys(email);
        }

        /// <summary>
        /// The method fills the password field passed by the value
        /// </summary>
        /// <param name="pass">The pass value to fill</param>
        public void TypePass(String pass)
        {
            PassElement.SendKeys(pass);
        }

        /// <summary>
        /// Method press submit Login button
        /// </summary>
        public void ClickSubmit()
        {
            ButtonLogInSubmitElement.Click();
        }

        /// <summary>
        /// Method, press a button that redirect the user to registration page
        /// </summary>
        public void ClickCreateMyAccount()
        {
            ButtonCreateMyAccount.Click();
        }
    }
}
