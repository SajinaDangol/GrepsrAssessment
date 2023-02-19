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
    public class ProfilePage : Driver
    {
        [FindsBy(How = How.CssSelector, Using = ".articles-toggle> ul > li.nav-item > a")]
        private IWebElement _myArticles;

        [FindsBy(How = How.XPath, Using = "/html//div[@id='__next']/div[@class='profile-page']//div[@class='articles-toggle']/ul//a[@href='/profile/sajina?favorite=true']/span[.='Favorited Articles']")]
        private IWebElement _favArticles;

        [FindsBy(How = How.CssSelector, Using = "a.preview-link")]
        private IWebElement _articlePreview;



        public ProfilePage() 
        {
            PageFactory.InitElements(_driver, this);
        }

        public void ClickMyArticlelink()
        {
            _myArticles.Click();    
        }

        public void ClickArticlePreviewlink()
        {
            _articlePreview.Click();    
        }


    }
}
