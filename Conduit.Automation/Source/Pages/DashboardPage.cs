using Conduit.Automation.Source.Drivers;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Conduit.Automation.Source.Pages
{
    public class DashboardPage : Driver
    {
        [FindsBy(How = How.XPath, Using = "//div[@id='__next']/nav[@class='navbar navbar-light']//ul[@class='nav navbar-nav pull-xs-right']//a[@href='/user/settings']")]
        private IWebElement _settings;

        [FindsBy(How = How.XPath, Using = "//div[@id='__next']/nav[@class='navbar navbar-light']//ul[@class='nav navbar-nav pull-xs-right']//a[@href='/editor/new']")]
        private IWebElement _newpost;

        [FindsBy(How = How.XPath, Using = "//div[@id='__next']/nav[@class='navbar navbar-light']//ul[@class='nav navbar-nav pull-xs-right']//span[.='sajina']")]
        private IWebElement _profile;

        [FindsBy(How = How.XPath, Using = "/html//div[@id='__next']//div[@class='col-md-9']/div[2]/a[@href='/article/Demo-Test-139916']/span[.='Read more...']")]
        private IWebElement _readMore;

        public DashboardPage()
        {
            PageFactory.InitElements(_driver, this);
        }
        public void ClickSettingslink()
        {
            _settings.Click();
        }
        public void ClickNewPostlink()
        {
            _newpost.Click();
        }
        public void ClickProfilelink()
        {
            _profile.Click();
        }
        public void ClickReadmore()
        {
            _readMore.Click();
        }
    }

}
