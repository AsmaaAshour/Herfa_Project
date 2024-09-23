using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herfa.POM
{
    public class AddProducts
    {
        IWebDriver _driver;
        public AddProducts(IWebDriver driver)
        {
            _driver = driver;
        }

        By ProductIcon= By.XPath("//nav//ul//li//a[@href='/User/Categories']");
        By AddRedFlowers = By.XPath("/html/body/div[1]/div[2]/div/div/div[2]/div/div[2]/div[1]/form/button/p/i");
        By AddSimplistic = By.XPath("/html/body/div[1]/div[2]/div/div/div[3]/div/div[2]/div[1]/form/button/p/i");
      
      

        public void ClickProductIcon()
        {
            _driver.FindElement(ProductIcon).Click();
        }

        public void ClickProduct1()
        {
            _driver.FindElement(AddRedFlowers).Click();
        }

        public void ClickProduct2()
        {
            _driver.FindElement(AddSimplistic).Click();
        }
    }
}
