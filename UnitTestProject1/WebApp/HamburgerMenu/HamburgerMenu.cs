using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationDemoTest;
using OpenQA.Selenium;

namespace UnitTestProject1.WebApp.HamburgerMenu
{
    class HamburgerMenu:CorePage
    {
        By HamburegerMenu = By.XPath("//button[@id='react-burger-menu-btn']");
        By LogoutBtn= By.Id("logout_sidebar_link");
        
        public void ClickHamburgerMenu()
        {
            Click(HamburegerMenu);
        }
        public void ClickLogout()
        {
            Click(LogoutBtn);
        }   
    }
}
