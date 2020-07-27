using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;

namespace PilotProject
{
    public class SignInPage
    {

        // pravljenje instance drajvera ispod sam nasao kao jedno od mogucih resenja sa stackowerflowa
        private IWebDriver driver;

        public SignInPage(IWebDriver _driver)
        {
           this.driver = _driver;
        }

        // lista elemenata sa drajverom uzetim iz driver klase koju sam video kao predlog da se pravi posebno kao odvojena klasa
        public IWebElement Authentication = Driver.driver.FindElement(By.Id("content"));
        public IWebElement Username => Driver.driver.FindElement(By.Id("username"));
        public IWebElement Password => driver.FindElement(By.Id("password"));
        public IWebElement Login => driver.FindElement(By.CssSelector("input[name='SubmitCreate']"));

        // ispd se nalaze parametri koji bi kao moguci test scenariji bili ubacivani u polja
        public static class ValidCredentials
        {
            public static string Username = "tomsmith";
            public static string Password = "SuperSecretPassword!";
        }

        public static class InvalidCredentials
        {
            public static class Username
            {
                public static string RandomCharacters = "blablaBlalbla";
                public static string RandomNumbers = "45965465465";
            }
            public static class Password
            {
                public static string OnlyCharacters = "blablaBLaaa";
                public static string OnlyNumbers = "4654651232";
                public static string Combination = "154fds564fsd$^/";
            }
        }
        // ovde bi pravio akcije nad elementima i poljima
        public static void FillInForm()
        {
            Driver.driver.Navigate().GoToUrl(BasePage.BaseUrl);

        }
    }

}
