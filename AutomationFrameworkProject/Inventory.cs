using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports.Model;
using OpenQA.Selenium;

namespace AutomationFrameworkProject
{
    public class InventoryPage : CorePage
    {
        public void AddToCart(string itemName)
        {
            step = Test.CreateNode("Inventory Page");
            Click(By.XPath($"//button[@id='add-to-cart-{itemName}']"));
        }

        public void RemoveFromCart(string itemName)
        {
            step = Test.CreateNode("Inventory Page");
            Click(By.XPath($"//button[@id='remove-{itemName}']"));
        }
    }
}