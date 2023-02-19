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
    public class HomePage : Driver
    {
        [FindsBy(How = How.XPath, Using = "//div[@id='__next']/nav[@class='navbar navbar-light']//ul[@class='nav navbar-nav pull-xs-right']//span[.='Home']")]
        private IWebElement _home;

        [FindsBy(How = How.XPath, Using = "//div[@id='__next']/nav[@class='navbar navbar-light']//ul[@class='nav navbar-nav pull-xs-right']//a[@href='/user/register']")]
        private IWebElement _signuplink;

        [FindsBy(How = How.XPath, Using = "//div[@id='__next']/nav[@class='navbar navbar-light']//ul[@class='nav navbar-nav pull-xs-right']//a[@href='/user/login']")]
        private IWebElement _signinlink;


        public HomePage()
        {
            PageFactory.InitElements(_driver, this);
        }

        public void ClicktoHomelink()
        {
            _home.Click();
        }

        public void ClickSignUplink()
        {
            _signuplink.Click();          
        }
       

        public void ClicktoSigninlink()
        {
            _signinlink.Click();
        }

        
    }
}
