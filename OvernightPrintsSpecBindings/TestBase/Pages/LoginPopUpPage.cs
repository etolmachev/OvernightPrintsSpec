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
        /// Метод заполняет поле email, переданным значением
        /// </summary>
        /// <param name="email">Значение email для заполнения</param> 
        public void TypeEmail(String email)
        {
            EmailElement.SendKeys(email);
        }

        /// <summary>
        /// Метод заполняет поле пароля, переданным значением
        /// </summary>
        /// <param name="pass">Значение pass для заполнения</param>
        public void TypePass(String pass)
        {
            PassElement.SendKeys(pass);
        }

        /// <summary>
        /// Метод, нажимает кнопку подтвреждения входа
        /// </summary>
        public void ClickSubmit()
        {
            ButtonLogInSubmitElement.Click();
        }

        /// <summary>
        /// Метод, нажимает кнопку, которая переводит на страницу регистрации пользователя
        /// </summary>
        public void ClickCreateMyAccount()
        {
            ButtonCreateMyAccount.Click();
        }
    }
}
