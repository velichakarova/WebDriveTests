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
            driver.Manage().Window.FullScreen();
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
    }
}