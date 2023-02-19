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
    public class ArticlePage : Driver
    {
        [FindsBy(How = How.CssSelector, Using = "form > fieldset > :nth-child(1) input")]
        private IWebElement _articleTitle;

        [FindsBy(How = How.CssSelector, Using = "form > fieldset > :nth-child(2) input")]
        private IWebElement _articleAbout;

        [FindsBy(How = How.CssSelector, Using = "form > fieldset > :nth-child(3) textarea")]
        private IWebElement _articleDescrption;

        [FindsBy(How = How.CssSelector, Using = "form > fieldset > :nth-child(4) input")]
        private IWebElement _articleTags;

        [FindsBy(How = How.CssSelector, Using = "button[type='button']")]
        private IWebElement _publishBtn;

        [FindsBy(How = How.CssSelector, Using = ".article-meta > span> a")]
        private IWebElement _editBtn;

        [FindsBy(How = How.CssSelector, Using = "button[type='button']")]
        private IWebElement _updateBtn;

        [FindsBy(How = How.CssSelector, Using = ".article-meta > span > button")]
        private IWebElement _deleteBtn;

        public ArticlePage()
        {
            PageFactory.InitElements(_driver, this);
        }

        public void FillForm(ArticleModel model)
        {
            _articleTitle.SendKeys(model.ArticleTitle);
            _articleAbout.SendKeys(model.ArticleAbout);
            _articleDescrption.SendKeys(model.ArticleDescription);
            _articleTags.SendKeys(model.ArticleTag);
        }

        public void UpdateTitle(string newTitle)
        {
            _articleTitle.Clear();
            _articleTitle.SendKeys(newTitle);
        }

        public void ClickPublishBtn()
        {
            _publishBtn.SendKeys(Keys.Return);
        }

        public void ClickeditArticlebtn()
        {
            _editBtn.Click();
        }

        public void ClickUpdateArticlebtn()
        {       
            _updateBtn.Click(); 
        }

        public void ClickDelbtn()
        {
            _deleteBtn.Click();
            _driver.SwitchTo().Alert().Accept();
        }
    }
}
