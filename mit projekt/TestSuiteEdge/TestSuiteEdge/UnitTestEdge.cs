using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System.Text;

namespace SeleniumTests
{
    [TestFixture]
    public class SuiteTestEdge
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new EdgeDriver();
            baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheChangeLanguageTest()
        {
            driver.Navigate().GoToUrl("http://www.bagatshop.hr/en/");
            driver.FindElement(By.XPath("//div[@id='region']/div/a")).Click();
            driver.Navigate().GoToUrl("http://www.bagatshop.hr/hr/");
            driver.FindElement(By.XPath("//div[@id='region']/div[2]/a/img")).Click();
            driver.Navigate().GoToUrl("http://www.bagatshop.hr/en/");
            driver.FindElement(By.XPath("//div[@id='region']/div[3]/a/img")).Click();
            driver.Navigate().GoToUrl("http://www.bagatshop.hr/de/");
        }
        [Test]
        public void TheSearchForTheWebsiteTest()
        {
            driver.Navigate().GoToUrl("https://www.google.com/");
            driver.FindElement(By.XPath("//button[@id='L2AGLb']/div")).Click();
            driver.FindElement(By.Name("q")).Click();
            driver.FindElement(By.Name("q")).Clear();
            driver.FindElement(By.Name("q")).SendKeys("bagat");
            driver.FindElement(By.XPath("//div[4]/center/input")).Click();
            driver.FindElement(By.XPath("//div[@id='rso']/div/div/div/div/div/div/div/div/div/a/h3")).Click();
        }
        [Test]
        public void TheAddProductTest()
        {
            driver.Navigate().GoToUrl("http://www.bagatshop.hr/hr/");
            driver.FindElement(By.Name("query")).Click();
            driver.FindElement(By.Name("query")).Clear();
            driver.FindElement(By.Name("query")).SendKeys("čutura");
            driver.FindElement(By.Name("search_form")).Submit();
            driver.FindElement(By.XPath("//img[@alt='Boca ČUTURA']")).Click();
            driver.FindElement(By.Name("quantity")).Clear();
            driver.FindElement(By.Name("quantity")).SendKeys("2");
            driver.FindElement(By.Name("quantity")).Click();
            driver.FindElement(By.Name("quantity")).Clear();
            driver.FindElement(By.Name("quantity")).SendKeys("2.50");
            driver.FindElement(By.Name("add_cart_product")).Click();
            driver.FindElement(By.LinkText("Blagajna »")).Click();
        }
        [Test]
        public void TheSearchForAProductTest()
        {
            driver.Navigate().GoToUrl("http://www.bagatshop.hr/hr/");
            driver.FindElement(By.Name("query")).Click();
            driver.FindElement(By.Name("query")).Clear();
            driver.FindElement(By.Name("query")).SendKeys("dukat");
            driver.FindElement(By.Name("search_form")).Submit();
            driver.FindElement(By.XPath("//img[@alt='Dukat mali s rupicomØ2,0cm']")).Click();
            driver.FindElement(By.Name("query")).Click();
            driver.FindElement(By.Name("query")).Clear();
            driver.FindElement(By.Name("query")).SendKeys("kutija");
            driver.FindElement(By.Name("search_form")).Submit();
            driver.FindElement(By.LinkText("Slijedeće")).Click();
        }
        [Test]
        public void TheLogInAndAccountSettingsTest()
        {
            driver.Navigate().GoToUrl("http://www.bagatshop.hr/hr/");
            driver.FindElement(By.Name("email")).Click();
            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("email")).SendKeys("fides.mides@gmail.com");
            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys("lozinka ");
            driver.FindElement(By.Name("remember_me")).Click();
            driver.FindElement(By.Name("login")).Click();
            driver.FindElement(By.LinkText("Korisnički servis")).Click();
            driver.FindElement(By.XPath("//img[@alt='BAGAT SHOP']")).Click();
            driver.FindElement(By.LinkText("Povijest narudžbe")).Click();
            driver.FindElement(By.XPath("//img[@alt='BAGAT SHOP']")).Click();
            driver.FindElement(By.Id("main-wrapper")).Click();
            driver.FindElement(By.LinkText("Izmjeni račun")).Click();
            driver.FindElement(By.XPath("//img[@alt='BAGAT SHOP']")).Click();
            driver.FindElement(By.LinkText("Odjava")).Click();
            driver.Navigate().GoToUrl("http://www.bagatshop.hr/hr/");
        }


        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
