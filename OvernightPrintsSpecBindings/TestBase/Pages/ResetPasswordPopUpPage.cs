    using System;
using OpenQA.Selenium;

namespace OvernightPrintsSpecBindings.TestBase.Pages
{
    public class ResetPasswordPopUpPage
    {
        private By _emailLocator = By.Id("username");
        private By _buttonResetPasswordLocator = By.CssSelector("[value=\"Reset Password\"]");
        private By _linkCancelLocator = By.CssSelector("#myonp-reset-pwd > form > div:nth-child(2) > div > a");
        private By _labelLocator = By.CssSelector("#ui-id-3 > div > div > h1");

        private HtmlElement EmailElement;
        private HtmlElement ButtonResetPasswordElement;
        private HtmlElement LinkCancelElement;
        private HtmlElement LabelElement;

        public ResetPasswordPopUpPage()
        {
            EmailElement = new HtmlElement(_emailLocator);
            ButtonResetPasswordElement = new HtmlElement(_buttonResetPasswordLocator);
            LinkCancelElement = new HtmlElement(_linkCancelLocator);
            LabelElement = new HtmlElement(_labelLocator);
        }

        public void TypeEmail(String email)
		{
			EmailElement.SendKeys(email);
			Console.WriteLine(EmailElement.GetAttribute("validity"));
		}

        public void ClickResetPassword()
        {
            ButtonResetPasswordElement.Click();
        }

        public void ClickCancel()
        {
            LinkCancelElement.Click();
        }

        public string GetLabelText()
        {
            return LabelElement.Text;
        }
    }
}
