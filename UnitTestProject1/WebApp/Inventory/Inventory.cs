﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationDemoTest;
using OpenQA.Selenium;

namespace UnitTestProject1.Inventory
{
    public class InventoryPage : CorePage
    {
        //private IWebDriver driver;



       

        public void AddToCart(string itemName)
        {
            step = Test.CreateNode("Inventory Page");
            CorePage.driver.FindElement(By.XPath($"//button[@id='add-to-cart-{itemName}']")).Click();
            //driver.FindElement(By.Id($"add-to-cart-{itemName}")).Click();
        }

        public void RemoveFromCart(string itemName)
        {
            step = Test.CreateNode("Inventory Page");
            CorePage.driver.FindElement(By.XPath($"//button[@id='remove-{itemName}']")).Click();
            //driver.FindElement(By.Id($"remove-{itemName}")).Click();
        }
    }
}

