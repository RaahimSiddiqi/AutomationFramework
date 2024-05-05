using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace AutomationFrameworkProject
{
    [TestClass]
    public class UnitTest1
    {
        IWebDriver driver = new ChromeDriver();

        [TestMethod]
        public void LoginWith_ValidUser_ValidPassword_TC001()
        {
            Login("https://www.saucedemo.com/", "standard_user", "secret_sauce");
            string title = driver.FindElement(By.XPath("//div[@class='header_secondary_container']/span[@class='title']")).Text;
            Assert.AreEqual(title, "Products");
            driver.Close();
        }

        [TestMethod]
        public void LoginWith_InvalidUser_ValidPassword_TC002()
        {
            Login("https://www.saucedemo.com/", "incorrect_user", "secret_sauce");
            string error = driver.FindElement(By.XPath("//div[contains(@class, 'error-message-container')]/h3")).Text;
            Assert.AreEqual(error, "Epic sadface: Username and password do not match any user in this service");
            driver.Close();
        }

        [TestMethod]
        public void LoginWith_InvalidUser_InvalidPassword_TC003()
        {
            Login("https://www.saucedemo.com/", "incorrect_user", "incorrect_sauce");
            string error = driver.FindElement(By.XPath("//div[contains(@class, 'error-message-container')]/h3")).Text;
            Assert.AreEqual(error, "Epic sadface: Username and password do not match any user in this service");
            driver.Close();
        }

        public void Login(string url, string username, string password)
        {
            driver.Url = url;
            driver.FindElement(By.Id("user-name")).SendKeys(username);
            driver.FindElement(By.Id("password")).SendKeys(password);
            driver.FindElement(By.Id("login-button")).Click();
        }
    }
}
