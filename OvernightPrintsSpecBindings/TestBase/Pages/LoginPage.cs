
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace OvernightPrintsSpecBindings.TestBase.Pages
{
    public class LoginPage
    {
        private By _buttonLogInLocator = By.CssSelector("a[href='/login']");
        private By _emailLocator = By.Id("username");
        private By _passLocator = By.Id("password");
        private By _buttonLogInSubmitLocator = By.CssSelector("#ui-id-3 > div > div.myonp.myonp-login > div.myonp-login-pane.log-in > form > div.control-group > div > button");

        private HtmlElement ButtonLogInElement;
        private HtmlElement EmailElement;
        private HtmlElement PassElement;
        private HtmlElement ButtonLogInSubmitElement;

        public LoginPage()
        {   
            ButtonLogInElement = new HtmlElement(_buttonLogInLocator);
            EmailElement = new HtmlElement(_emailLocator);
            PassElement = new HtmlElement(_passLocator);
            ButtonLogInSubmitElement = new HtmlElement(_buttonLogInSubmitLocator);
        }

        /// <summary>
        /// Метод, нажимает кнопку для перехода на страницу входа
        /// </summary>
        public void ClickLogIn()
        {
            ButtonLogInElement.Click();
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
    }
}
