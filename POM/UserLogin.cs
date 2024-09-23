﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herfa.POM
{
    public class UserLogin
    {
        IWebDriver _driver;
        public UserLogin(IWebDriver driver)
        {
            _driver = driver;
        }

        By Email= By.XPath("//div/input[@id='Email']");
        By Password = By.XPath("//div/input[@id='myPass1']");
        By Login = By.XPath("//div/button[@type='submit']");


        public void EnterEmail(string value)
        {
            _driver.FindElement(Email).SendKeys(value);
        }

        public void EnterPassword(string value)
        {
            _driver.FindElement(Password).SendKeys(value);
        }

        public void ClickLogin()
        {
            _driver.FindElement(Login).Click();
        }
    }
}
