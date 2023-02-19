using Conduit.Automation.Source.Drivers;
using Conduit.Automation.Source.Models;
using Conduit.Automation.Source.Pages;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NUnit.Framework.Constraints.Tolerance;

namespace Conduit.Automation.Test
{
    public class SignupTest : Driver
    {
        [Test]
        public void SignupSucess()
        {
            HomePage hp = new HomePage();
            SignupPage su = new SignupPage();
            LogoutPage lp = new LogoutPage();
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            RegistrationModel reg = new RegistrationModel
            {
                UserName = "Kri2m",
                Email = "J01@tmail.com",
                Password = "Jane@1$#"
            };

            hp.ClickSignUplink();

            By usernameInput = By.CssSelector("input[type='text']");
            _ = wait.Until(ExpectedConditions.ElementExists(usernameInput));
            su.signup(reg);
            su.ClickSignupbtn();

            By profilelocator = By.CssSelector(".container > ul.nav > :nth-child(4) > a");
            var profileLink = wait.Until(ExpectedConditions.ElementExists(profilelocator));

            Assert.That(profileLink.Text, Is.EqualTo(reg.UserName));
            Assert.True(_driver.Title.Contains("HOME | NEXT REALWORLD"));
            lp.clickSettingsLink();

            By Logoutbtn = By.CssSelector("button.btn.btn-outline-danger");
            _ = wait.Until(ExpectedConditions.ElementExists(Logoutbtn));

            lp.clickLogoutbtn();

            By container = By.CssSelector(".feed-toggle > ul > li.nav-item > a");
            var yourFeed = wait.Until(ExpectedConditions.ElementExists(container));

            Assert.That(yourFeed.Text, Is.EqualTo("Global Feed"));
        }

        [Test]
        public void SignUpFail()
        {
            HomePage hp = new HomePage();
            SignupPage su = new SignupPage();
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            RegistrationModel reg = new RegistrationModel
            {
                UserName = "Kri30m",
                Email = "J3@tmail.com",
                Password = "Jane@1$#"
            };

            hp.ClickSignUplink();

            By usernameInput = By.CssSelector("input[type='text']");
            _ = wait.Until(ExpectedConditions.ElementExists(usernameInput));
            su.signup(reg);
            su.ClickSignupbtn();

            By errorMessage = By.CssSelector("ul.error-messages > li");
            var error = wait.Until(ExpectedConditions.ElementExists(errorMessage));

            Assert.That(error.Text, Is.EqualTo("email has already been taken"));
        }
       
    }
}
