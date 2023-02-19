using Conduit.Automation.Source.Drivers;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduit.Automation.Source.Pages
{
    public class LogoutPage : Driver
    {
        [FindsBy(How = How.CssSelector, Using = ".container > ul.nav > :nth-child(3) > a")]
        private IWebElement _settingsLink;

        [FindsBy(How = How.CssSelector, Using = "button.btn.btn-outline-danger")]
        private IWebElement _logoutbtn;

        public LogoutPage()
        {
            PageFactory.InitElements(_driver, this);
        }

        public void clickLogoutbtn()
        {
            _logoutbtn.Click();
        }

        public void clickSettingsLink()
        {
            _settingsLink.Click();
        }
    }
}

