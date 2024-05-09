using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationFrameworkProject
{
    internal class Checkout : CorePage
    {
        public void GoToCheckout()
        {
            step = Test.CreateNode("CheckoutPage");
            Click(By.XPath("//a[@class='shopping_cart_link']"));
            Thread.Sleep(500);
            Click(By.Id("checkout"));
        }

        public void FillCheckoutInformation(string firstname, string lastname, string postalcode)
        {
            Write(By.Id("first-name"), firstname);
            Write(By.Id("last-name"), lastname);
            Write(By.Id("postal-code"), postalcode);
            Click(By.Id("continue"));
        }

        public void CompleteCheckout()
        {
            Click(By.Id("finish"));
        }
    }
}
