﻿using AutomationDemoTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Configuration;
using UnitTestProject1.Inventory;
using UnitTestProject1.WebApp.LoginPage;
//TestExecution.cs
namespace AutomationFrameworkProject
{
    [TestClass]
    public class UnitTest1:CorePage
    {
        #region Setups and Cleanups
        public TestContext instance;
        public TestContext TestContext
        {
            set { instance = value; }
            get { return instance; }
        }

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
           
        }
        [AssemblyInitialize()]
        public static void AssemblyInit(TestContext context)
        {
            string ResultFile = @"C:/UnitTestProject1/UnitTestProject1" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".html";
            CreateReport(ResultFile);
        }
        [AssemblyCleanup()]
        public static void AssemblyCleanup()
        {
            extentreports.Flush();
        }

        [TestInitialize()]
        public void TestInit()
        {
            CorePage.SeleniumInit(ConfigurationManager.AppSettings["Browser"].ToString());
            Test = extentreports.CreateTest(TestContext.TestName);
            //CorePage.SeleniumInit("Chrome");


        }
        [TestCleanup()]
        public void TestCleanup()
        {
            CorePage.driver.Quit();
        }
        #endregion

        LoginPage loginPage = new LoginPage();
        InventoryPage inventoryPage = new InventoryPage();
        [TestMethod]
        [TestCategory("Login")][TestCategory("Positive")]
        public void LoginWith_ValidUser_ValidPassword_TC001()
        {
            loginPage.Login("https://www.saucedemo.com/", "standard_user", "secret_sauce");
            Test = extentreports.CreateTest(TestContext.TestName);

            string title = CorePage.driver.FindElement(By.XPath("//div[@class='header_secondary_container']/span[@class='title']")).Text;
            Assert.AreEqual(title, "Products");

        }

        [TestMethod]
        [TestCategory("Login")]
        [TestCategory("Negative")]
        public void LoginWith_InvalidUser_ValidPassword_TC002()
        {
            loginPage.Login("https://www.saucedemo.com/", "incorrect_user", "secret_sauce");
            string error = CorePage.driver.FindElement(By.XPath("//div[contains(@class, 'error-message-container')]/h3")).Text;
            Assert.AreEqual(error, "Epic sadface: Username and password do not match any user in this service");
            
        }

        [TestMethod]
        [TestCategory("Login")]
        [TestCategory("Negative")]
        public void LoginWith_InvalidUser_InvalidPassword_TC003()
        {
            loginPage.Login("https://www.saucedemo.com/", "incorrect_user", "incorrect_sauce");
            string error = CorePage.driver.FindElement(By.XPath("//div[contains(@class, 'error-message-container')]/h3")).Text;
            Assert.AreEqual(error, "Epic sadface: Username and password do not match any user in this service");
        }



        [TestMethod]
        [TestCategory("Login")]
        [TestCategory("Positive")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "LoginWith_AllValidUser_ValidPassword_TC004", DataAccessMethod.Sequential)]
        public void LoginWith_AllValidUser_ValidPassword_TC004()
        {
            string url = TestContext.DataRow["url"].ToString();
            string username = TestContext.DataRow["username"].ToString();
            string pass = TestContext.DataRow["password"].ToString();

            loginPage.Login(url, username, pass);
            string title = CorePage.driver.FindElement(By.XPath("//div[@class='header_secondary_container']/span[@class='title']")).Text;
            Assert.AreEqual(title, "Products");

        }
        [TestMethod]
        [TestCategory("AddtoCart")]
        public void AddToCartSingleItem_TC005()
        {
            loginPage.Login("https://www.saucedemo.com/", "standard_user", "secret_sauce");
            string title = CorePage.driver.FindElement(By.XPath("//div[@class='header_secondary_container']/span[@class='title']")).Text;
            Assert.AreEqual(title, "Products");
            System.Threading.Thread.Sleep(3000);

            inventoryPage.AddToCart("sauce-labs-backpack");

            // Wait for a few seconds (you should consider using explicit waits instead of Thread.Sleep)
            System.Threading.Thread.Sleep(3000);

            // Remove the item from the cart
            inventoryPage.RemoveFromCart("sauce-labs-backpack");

            // Wait for a few seconds
            System.Threading.Thread.Sleep(3000);
        }
        [TestMethod]
        [TestCategory("AddtoCart")]
        public void AddToCartMultipleItem_TC005()
        {

            loginPage.Login("https://www.saucedemo.com/", "standard_user", "secret_sauce");
            string title = CorePage.driver.FindElement(By.XPath("//div[@class='header_secondary_container']/span[@class='title']")).Text;
            Assert.AreEqual(title, "Products");
            System.Threading.Thread.Sleep(3000);

            inventoryPage.AddToCart("sauce-labs-backpack");

            // Wait for a few seconds (you should consider using explicit waits instead of Thread.Sleep)
            CorePage.ScrollDownByPercentage(50);
            System.Threading.Thread.Sleep(3000);
            inventoryPage.AddToCart("test.allthethings()-t-shirt-(red)");


            // Wait for a few seconds
            System.Threading.Thread.Sleep(3000);
        }


    }
}
