using NUnit.Framework;
using OvernightPrintsSpecBindings.TestBase.Pages;
using TechTalk.SpecFlow;

namespace OvernightPrintsSpecBindings.Bindings
{	
	[Binding]
	public class ResetPasswordPageBindings
	{
		private ResetPasswordPage _page = new ResetPasswordPage();

		[Then(@"I see Reset Password Page")]
		public void ThenISeeResetPasswordPage()
		{
			Assert.IsTrue(_page.IsResetPasswordPage("Reset password"));
		}

		[When(@"I set following parameters on Reset Password Page")]
		public void WhenISetFollowingParametersOnResetPasswordPage(Table table)
		{
			foreach (var row in table.Rows)
			{
				string key = row["Field"];
				_page.SetField(key,row["Value"]);
			}
		}

		[When(@"I click Change Password Button on Reset Password Page")]
		public void WhenIClickChangePasswordButtonOnResetPasswordPage()
		{
			_page.ClickChangePasswordButton();
		}

	}
}
