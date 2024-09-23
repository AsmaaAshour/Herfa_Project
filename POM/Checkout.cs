using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herfa.POM
{
    public class Checkout
    {
        IWebDriver _driver;
        public Checkout(IWebDriver driver)
        {
            _driver = driver;
        }

        By Cart = By.XPath("//div[3]/ul/li/a/span");
        By Checkoutt = By.XPath("//div/a[@href='/User/PayForTheOrder']");


        public void ClickCart()
        {
            _driver.FindElement(Cart).Click();
        }

        public void ClickCheckout()
        {
            _driver.FindElement(Checkoutt).Click();
        }
    }
}
