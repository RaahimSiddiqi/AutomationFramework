using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationFrameworkProject;
using AventStack.ExtentReports.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationFrameworkProject
{
    public class LoginPage : CorePage
    {
        By usernameTxt = By.Id("user-name");
        By passwordTxt = By.Id("password");
        By loginBtn = By.Id("login-button");

        public void Login(string url, string username, string password)
        {
            step = Test.CreateNode("LoginPage");
            openUrl(url);
            // usernameTxt.SendKeys(username);
            Write(usernameTxt, username);
            Write(passwordTxt, password);
            Click(loginBtn);

        }

    }
}