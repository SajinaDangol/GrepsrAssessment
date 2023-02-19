using Conduit.Automation.Source.Drivers;
using Conduit.Automation.Source.Models;
using Conduit.Automation.Source.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduit.Automation.Test
{
    public class CrudArticleTest : Driver
    {
        [Test, Order(1)]
        public void CreateArticle()
        {
            HomePage hp = new HomePage();
            SigninPage sip = new SigninPage();
            DashboardPage dp = new DashboardPage();
            ArticlePage ap = new ArticlePage();
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            SigninModel sm = new SigninModel
            {
                Email = "sajina.dongol@gmail.com",
                Password = "12345678"
            };

            ArticleModel am = new ArticleModel
            {
                ArticleTitle = "Test Title",
                ArticleAbout = "Test About",
                ArticleDescription = "Test Desc",
                ArticleTag = "TestTag",

            };

            hp.ClicktoSigninlink();

            By emailInput = By.CssSelector("input[type='email']");
            _ = wait.Until(ExpectedConditions.ElementExists(emailInput));

            sip.Signin(sm);
            sip.Clicksignin();

            By container = By.CssSelector(".feed-toggle > ul > li.nav-item > a");
            _ = wait.Until(ExpectedConditions.ElementExists(container));

            dp.ClickNewPostlink();

            By btn = By.CssSelector("form > fieldset > button");
            _ = wait.Until(ExpectedConditions.ElementExists(btn));

            ap.FillForm(am);
            ap.ClickPublishBtn();

            By titleSelector = By.CssSelector(".article-preview > .preview-link > h1");
            var title = wait.Until(ExpectedConditions.TextToBePresentInElementLocated(titleSelector, "Test Title"));

            Assert.True(title);
        }

        [Test, Order(2)]
        public void ReadArticle()
        {
            HomePage hp = new HomePage();
            SigninPage sip = new SigninPage();
            DashboardPage dp = new DashboardPage();
            ArticlePage ap = new ArticlePage();
            ProfilePage pp = new ProfilePage();
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
            _ = wait.Until(ExpectedConditions.ElementExists(container));

            dp.ClickProfilelink();

            By titleSelector = By.CssSelector(".article-preview > .preview-link > h1");
            var title = wait.Until(ExpectedConditions.TextToBePresentInElementLocated(titleSelector, "Test Title"));

            Assert.True(title);
        }

        [Test, Order(3)]
        public void UpdateArticle()
        {
            HomePage hp = new HomePage();
            SigninPage sip = new SigninPage();
            DashboardPage dp = new DashboardPage();
            ArticlePage ap = new ArticlePage();
            ProfilePage pp = new ProfilePage();
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
            _ = wait.Until(ExpectedConditions.ElementExists(container));

            dp.ClickProfilelink();

            By myArticle = By.CssSelector("a.preview-link");
            _ = wait.Until(ExpectedConditions.ElementExists(myArticle));

            pp.ClickArticlePreviewlink();

            By editArticle = By.CssSelector(".article-meta > span > a");
            _ = wait.Until(ExpectedConditions.ElementExists(editArticle));

            ap.ClickeditArticlebtn();

            By titlefield = By.CssSelector("form > fieldset > :nth-child(1) input");
            _ = wait.Until(ExpectedConditions.ElementExists(titlefield));
            
            ap.UpdateTitle("Updated Test Title");
            ap.ClickUpdateArticlebtn();

            By titleSelector = By.CssSelector(".article-preview > .preview-link > h1");
            var title = wait.Until(ExpectedConditions.TextToBePresentInElementLocated(titleSelector, "Updated Test Title"));

            Assert.True(title);

        }

        [Test, Order(4)]
        public void DeleteArticle()
        {
            HomePage hp = new HomePage();
            SigninPage sip= new SigninPage();
            DashboardPage dp = new DashboardPage();
            ArticlePage ap = new ArticlePage();
            ProfilePage pp = new ProfilePage();
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
            _ = wait.Until(ExpectedConditions.ElementExists(container));

            dp.ClickProfilelink();

            By myArticle = By.CssSelector("a.preview-link");
            _ = wait.Until(ExpectedConditions.ElementExists(myArticle));

            pp.ClickArticlePreviewlink();

            By editArticle = By.CssSelector(".article-meta > span > a");
            _ = wait.Until(ExpectedConditions.ElementExists(editArticle));

            ap.ClickDelbtn();

            By titleSelector = By.CssSelector(".article-preview > .preview-link > h1");
            var title = wait.Until(ExpectedConditions.ElementExists(titleSelector));

            Assert.That(title.Text, Is.Not.EqualTo("Updated Test Title"));
        }
    }
}
