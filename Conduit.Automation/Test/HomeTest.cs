using Conduit.Automation.Source.Drivers;
using Conduit.Automation.Source.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduit.Automation.Test
{
    public class HomeTest :Driver
    {

        [Test]
        public void LoadHomepage()
        {
            _driver.Navigate().GoToUrl("https://next-realworld.vercel.app/");
            Assert.True(_driver.Title.Contains("HOME | NEXT REALWORLD"));
        } 
    }
}
