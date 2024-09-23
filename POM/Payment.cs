using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herfa.POM
{
    public class Payment
    {
        IWebDriver _driver;
        public Payment(IWebDriver driver)
        {
            _driver = driver;
        }

        By Cardholdername= By.XPath("//div/input[@name='cardholderame']");
        By Cardnumber = By.XPath("//div/input[@name='cardNumber']");
        By Cvv = By.XPath("//div/input[@name='cvv']");
        By Expire = By.XPath("//div/input[@name='expire']");
        By Pay=By.XPath("//button[@type='submit']");

        By RememberMe=By.XPath("//div/input[@name='rememberMe']");

        By Profile = By.XPath("//div/a[@href='/User/EditProfile/886']");
        By PurchaseArchaive = By.XPath("/html/body/div[1]/section/div/div/div[3]/div/div/a[2]/u");

        By TotalPriceInCart = By.XPath("//*[@id=\"ShoppingCarttt\"]/div/div[2]/div[2]/div[2]/div[2]/div/strong");
        By TotalPriceInPayment = By.XPath("/html/body/div[1]/section[2]/div/div/div/div/form/div[3]/div[2]/span/b");


        public void name (string value)
        {
            _driver.FindElement(Cardholdername).SendKeys(value);
        }

        public void number(String value)
        {
            _driver.FindElement(Cardnumber).SendKeys(value);
        }

        public void cvv(String value)
        {
            _driver.FindElement(Cvv).SendKeys(value);
        }

        public void expire(String value)
        {
            var parts = value.Split(' ');
            string month = parts[0];
            string year = parts[1];

            int monthNumber = DateTime.ParseExact(month, "MMMM", System.Globalization.CultureInfo.InvariantCulture).Month;

            string formattedValue = $"{year}-{monthNumber:D2}";

            var expireField = _driver.FindElement(By.Name("expire"));

            string script = $"arguments[0].value = '{formattedValue}';";
            ((IJavaScriptExecutor)_driver).ExecuteScript(script, expireField);

            Console.WriteLine($"Set expiration date to: {formattedValue}");

        }

        public void pay()
        {
            _driver.FindElement(Pay).Click();
        }

        public void rememberme()
        {
            _driver.FindElement(RememberMe).Click();
        }

       

       
     
        public decimal GetTotalPriceInCart()
        {
            var totalPriceElement = _driver.FindElement(By.XPath("TotalPriceInCart"));

            string totalPriceText = totalPriceElement.Text.Replace("$", "").Trim();
            decimal totalPriceInCart = decimal.Parse(totalPriceText);

            return totalPriceInCart;
        }

        public decimal GetTotalPriceInPayment()
        {
            var totalPriceElement = _driver.FindElement(By.XPath("TotalPriceInPayment"));

            string totalPriceText = totalPriceElement.Text.Replace("$", "").Trim();
            decimal totalPriceInPayment = decimal.Parse(totalPriceText);

            return totalPriceInPayment;
        }

        public void NavigateToProfile()
        {
            _driver.FindElement(Profile).Click();
            
        }

        public bool IsPurchaseArchiveVisible()
        {
            try
            {
                var purchaseArchiveElement = _driver.FindElement(PurchaseArchaive);
                return purchaseArchiveElement.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
