using Conduit.Automation.Source.Drivers;
using Conduit.Automation.Source.Models;
using Conduit.Automation.Source.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Conduit.Automation.Test
{
    public class SignintTest : Driver
    {
        [Test]
        public void SigninSucess()
        {
            HomePage hp = new HomePage();
            SigninPage sip = new SigninPage();
            LogoutPage lp = new LogoutPage();
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            SigninModel sm = new SigninModel
            {
                Email = "sajina.dongol@gmail.com",
                Password = "12345678"
            };

            hp.ClicktoSigninlink();

            By emailInput = By.CssSelector("input[type='email']");
            _ = wait.Until(ExpectedConditions.ElementExists(emailInput));
            sip.Signin(sm);
            sip.Clicksignin();

            By container = By.CssSelector(".feed-toggle > ul > li.nav-item > a");
            var feed = wait.Until(ExpectedConditions.ElementExists(container));

            Assert.That(feed.Text, Is.EqualTo("Your Feed"));
            Assert.True(_driver.Title.Contains("HOME | NEXT REALWORLD"));

            lp.clickSettingsLink();
            lp.clickLogoutbtn();
            
            feed = wait.Until(ExpectedConditions.ElementExists(container));
            Assert.That(feed.Text, Is.EqualTo("Global Feed"));
        }

        [Test]
        public void SigninFail()
        {
            HomePage hp = new HomePage();
            SigninPage sip = new SigninPage();
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(2));
            SigninModel sm = new SigninModel
            {
                Email = "Sajina.dongol@g.com",
                Password = "234"
            };

            hp.ClicktoSigninlink();

            By emailInput = By.CssSelector("input[type='email']");
            _ = wait.Until(ExpectedConditions.ElementExists(emailInput));
            
            sip.Signin(sm);
            sip.Clicksignin();

            By errorMessage = By.CssSelector("ul.error-messages > li");
            var error = wait.Until(ExpectedConditions.ElementExists(errorMessage));

            Assert.That(error.Text, Is.EqualTo("email or password is invalid"));
        }
        
    }
}
