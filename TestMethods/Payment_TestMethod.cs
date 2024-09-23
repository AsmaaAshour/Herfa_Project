using Herfa.Helpers;
using Herfa.POM;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herfa.TestMethods
{
    [TestClass]
    public class Payment_TestMethod
    {
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            ManageDriver.MaximizeDriver();
        }


        [ClassCleanup]
        public static void ClassCleanup()
        {
            ManageDriver.CloseDriver();
        }
        
        [TestMethod]
        public void Pay_by_Visa_Card_with_Correct_Details()
        {
            CommonMethods.NavigateToURL("https://localhost:44349/Auth/Login");
            Thread.Sleep(8000);
            UserLogin userLogin = new UserLogin(ManageDriver.driver);
            userLogin.EnterEmail("linaalaashqar@gmail.com");
            userLogin.EnterPassword("123456");
            userLogin.ClickLogin();
            Thread.Sleep(5000);

        
            AddProducts addProducts = new AddProducts(ManageDriver.driver);
            addProducts.ClickProductIcon();
            Thread.Sleep(5000);
            addProducts.ClickProduct1();
            Thread.Sleep(5000);
            addProducts.ClickProduct2();
            Thread.Sleep(5000);


            CommonMethods.NavigateToURL("https://localhost:44349/User/PayForTheOrder");
            Thread.Sleep(5000);
            Payment payment = new Payment(ManageDriver.driver);
            payment.name("Raghad Albetar");
            payment.number("1234123412341234");
            payment.cvv("789");
            Thread.Sleep(2000);
            payment.expire("April 2026");
            payment.pay();
            Thread.Sleep(5000);

            var expectedURL = "https://localhost:44349/User/ShoppingCart";
            var actualURL = ManageDriver.driver.Url;

            Assert.AreEqual(expectedURL, actualURL, "Actual URL not equal the expected URL_TC1");
            Console.WriteLine("TC1 Completed Successfully");
        }
        
        [TestMethod]
        public void Handle_Payment_Failure_with_Incorrect_Visa_Details()
        {
            CommonMethods.NavigateToURL("https://localhost:44349/Auth/Login");
            Thread.Sleep(8000);
            UserLogin userLogin = new UserLogin(ManageDriver.driver);
            userLogin.EnterEmail("linaalaashqar@gmail.com");
            userLogin.EnterPassword("123456");
            userLogin.ClickLogin();
            Thread.Sleep(5000);


            AddProducts addProducts = new AddProducts(ManageDriver.driver);
            addProducts.ClickProductIcon();
            Thread.Sleep(5000);
            addProducts.ClickProduct1();
            Thread.Sleep(5000);
            addProducts.ClickProduct2();
            Thread.Sleep(5000);


            CommonMethods.NavigateToURL("https://localhost:44349/User/PayForTheOrder");
            Thread.Sleep(5000);
            Payment payment = new Payment(ManageDriver.driver);
            payment.name("Raghad Albetar");
            payment.number("1234123412341234");
            payment.cvv("755");
            Thread.Sleep(2000);
            payment.expire("April 2026");
            payment.pay();

            Thread.Sleep(5000);

            var expectedURL = "https://localhost:44349/User/PayForTheOrder";
            var actualURL = ManageDriver.driver.Url;

            Assert.AreEqual(expectedURL, actualURL, "Actual URL not equal the expected URL_TC2");
            Console.WriteLine("TC2 Completed Successfully");
        }

        [TestMethod]
        public void Verify_Saving_Card_Information_with_RememberMe()
        {
            CommonMethods.NavigateToURL("https://localhost:44349/Auth/Login");
            Thread.Sleep(8000);
            UserLogin userLogin = new UserLogin(ManageDriver.driver);
            userLogin.EnterEmail("linaalaashqar@gmail.com");
            userLogin.EnterPassword("123456");
            userLogin.ClickLogin();
            Thread.Sleep(5000);


            AddProducts addProducts = new AddProducts(ManageDriver.driver);
            addProducts.ClickProductIcon();
            Thread.Sleep(5000);
            addProducts.ClickProduct1();
            Thread.Sleep(5000);
            addProducts.ClickProduct2();
            Thread.Sleep(5000);


            CommonMethods.NavigateToURL("https://localhost:44349/User/PayForTheOrder");
            Thread.Sleep(5000);
            Payment payment = new Payment(ManageDriver.driver);
            payment.name("Raghad Albetar");
            payment.number("1234123412341234");
            payment.cvv("789");
            Thread.Sleep(2000);
            payment.expire("April 2026");
            payment.rememberme();
            payment.pay();


            CommonMethods.NavigateToURL("https://localhost:44349/Auth/Login");
            Thread.Sleep(8000);
            userLogin.EnterEmail("linaalaashqar@gmail.com");
            userLogin.EnterPassword("123456");
            userLogin.ClickLogin();
            Thread.Sleep(5000);

            addProducts.ClickProductIcon();
            Thread.Sleep(5000);
            addProducts.ClickProduct1();
            Thread.Sleep(5000);
            addProducts.ClickProduct2();
            Thread.Sleep(5000);


            CommonMethods.NavigateToURL("https://localhost:44349/User/PayForTheOrder");
            Thread.Sleep(5000);
            payment.name("Raghad Albetar");
            payment.number("1234123412341234");
            payment.cvv("789");
            Thread.Sleep(2000);
            payment.expire("April 2026");
            payment.rememberme();
            payment.pay();
        }

        [TestMethod]
        public void Verify_that_Card_Informatin_is_Not_Saved_When_RememberMe_is_Unchecked()
        {
            CommonMethods.NavigateToURL("https://localhost:44349/Auth/Login");
            Thread.Sleep(8000);
            UserLogin userLogin = new UserLogin(ManageDriver.driver);
            userLogin.EnterEmail("linaalaashqar@gmail.com");
            userLogin.EnterPassword("123456");
            userLogin.ClickLogin();
            Thread.Sleep(5000);


            AddProducts addProducts = new AddProducts(ManageDriver.driver);
            addProducts.ClickProductIcon();
            Thread.Sleep(5000);
            addProducts.ClickProduct1();
            Thread.Sleep(5000);
            addProducts.ClickProduct2();
            Thread.Sleep(5000);


            CommonMethods.NavigateToURL("https://localhost:44349/User/PayForTheOrder");
            Thread.Sleep(5000);
            Payment payment = new Payment(ManageDriver.driver);
            payment.name("Raghad Albetar");
            payment.number("1234123412341234");
            payment.cvv("789");
            Thread.Sleep(2000);
            payment.expire("April 2026");
            payment.pay();
            Thread.Sleep(5000);


            CommonMethods.NavigateToURL("https://localhost:44349/Auth/Login");
            Thread.Sleep(8000);
            userLogin.EnterEmail("linaalaashqar@gmail.com");
            userLogin.EnterPassword("123456");
            userLogin.ClickLogin();
            Thread.Sleep(5000);

            addProducts.ClickProductIcon();
            Thread.Sleep(5000);
            addProducts.ClickProduct1();
            Thread.Sleep(5000);
            addProducts.ClickProduct2();
            Thread.Sleep(5000);


            CommonMethods.NavigateToURL("https://localhost:44349/User/PayForTheOrder");
            Thread.Sleep(5000);
            payment.name("Raghad Albetar");
            payment.number("1234123412341234");
            payment.cvv("789");
            Thread.Sleep(2000);
            payment.expire("April 2026");
            payment.pay();
        }

        [TestMethod]
        public void Verify_Total_Amount_Calculation()
        {
            Payment payment = new Payment(ManageDriver.driver);


            decimal totalPriceInCart = payment.GetTotalPriceInCart();
            decimal totalPriceInPayment = payment.GetTotalPriceInPayment();

            Assert.AreEqual(totalPriceInCart, totalPriceInPayment, "Total price in cart and payment are not equal.");
            Console.WriteLine($"TC5 Completed Successfully. Total Price in Cart: {totalPriceInCart}, Total Price in Payment: {totalPriceInPayment}");
        }

        [TestMethod]
        public void verify_that_all_payment_operations_are_correctly_displayed()
        {
            Payment payment = new Payment(ManageDriver.driver);
            payment.NavigateToProfile();

            bool isPurchaseArchiveVisible = payment.IsPurchaseArchiveVisible();

            Assert.IsTrue(isPurchaseArchiveVisible, "Purchase archive is not displayed correctly.");

            Console.WriteLine("Purchase archive is displayed correctly.");
        }
    }
}