using Conduit.Automation.Source.Drivers;
using Conduit.Automation.Source.Models;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduit.Automation.Source.Pages
{
    public class SigninPage : Driver
    {
        [FindsBy(How = How.CssSelector, Using = "input[type='email']")] 
        private IWebElement _email;

        [FindsBy(How = How.CssSelector, Using = "input[type='password']")]
        private IWebElement _password;

        [FindsBy(How = How.CssSelector, Using = "button[type='submit']")]
        private IWebElement _signinbtn;

        public SigninPage()
        {
            PageFactory.InitElements(_driver, this);
        }

        public void Signin(SigninModel model)
        {
            _email.SendKeys(model.Email);
            _password.SendKeys(model.Password);
        }
        public void Clicksignin()
        {       
            _signinbtn.Click();
        }
    }
}
