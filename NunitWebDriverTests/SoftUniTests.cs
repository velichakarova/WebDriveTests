using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace NunitWebDriverTests
{
    public class SoftUniTests
    {
        private WebDriver driver;

        [OneTimeSetUp]
        public void OpenBrowserNavigate()
        {  
            this.driver = new ChromeDriver();
            driver.Url = "http://softuni.bg";
            driver.Manage().Window.Maximize();
        }

        [OneTimeTearDown]
        public void ShutDown()
        {
            driver.Quit();
        }
       

        [Test]
        public void Test_AssertMainPageTitle()
        {
            
            //Act      
            string expectedTitile = "Обучение по програмиране - Софтуерен университет";
            
            //Assert
            Assert.That(driver.Title, Is.EqualTo(expectedTitile));

        }

        [Test]
        public void Test_AssertPage_AboutUs()
        {
            //Act
            var aboutUSElement = driver.FindElement(By.CssSelector("#header-nav > div.toggle-nav.toggle-holder > ul > li:nth-child(1) > a > span"));
            aboutUSElement.Click();
            
            string expectedTitile = "За нас - Софтуерен университет";

            //Assert
            Assert.That(driver.Title, Is.EqualTo(expectedTitile));

        }

        [Test]
        public void TestLogin_InvalidUsernameAndPassword()
        {
            
            driver.FindElement(By.CssSelector(".softuni-btn-primary")).Click();
            driver.FindElement(By.Id("username")).Click();
            driver.FindElement(By.Id("username")).SendKeys("user1");
            driver.FindElement(By.Id("password-input")).Click();
            driver.FindElement(By.Id("password-input")).SendKeys("123");
            driver.FindElement(By.CssSelector(".softuni-btn")).Click();
            Assert.That(driver.FindElement(By.CssSelector("li")).Text, Is.EqualTo("Невалидно потребителско име или парола"));
            driver.Close();
        }
    }
}