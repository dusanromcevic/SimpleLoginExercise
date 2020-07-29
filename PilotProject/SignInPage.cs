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
        // ovo je dobro za pocetak ali ako imas 10 Page Objects vidi da ne instanciras drajver svaki put nego ga izvuci u posebnu klasu koju bi nasledjivao mozda preko BasePage
        private IWebDriver driver;

        public SignInPage(IWebDriver _driver)
        {
           this.driver = _driver;
        }

        // lista elemenata sa drajverom uzetim iz driver klase koju sam video kao predlog da se pravi posebno kao odvojena klasa
        // oive elemente vidis na ovoj i na svim drugim stranicama. Mislim da je to lose. Ti ovim elementima pristupas samo preko SignInPage. I to cak ne radis sa elementima u testu nego metodama. 
        // Vidi kako bi ih sakrio.
        public IWebElement Authentication => Driver.driver.FindElement(By.Id("content"));
        public IWebElement UsernameField => Driver.driver.FindElement(By.Id("username"));
        public IWebElement Password => driver.FindElement(By.Id("password"));
        public IWebElement Login => driver.FindElement(By.CssSelector("input[name='SubmitCreate']"));

        // ispd se nalaze parametri koji bi kao moguci test scenariji bili ubacivani u polja
        // Ovi kredencijali i sl. su deo testa a ne PageObject. I kao takvi bi trebalo da idu u test.
        // ja bih recimo napravio akcije a ne samo stringove. Npr InputValidCredentials(string username, string password) i onda uradio { UsernameField.SendKyes(username); ...};
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
