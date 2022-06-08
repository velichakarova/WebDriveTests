using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace NunitWebDriverTests
{
    public class SoftUniTests
    {
        private WebDriver driver;

        [SetUp]
        public void OpenBrowserNavigate()
        {  
            this.driver = new ChromeDriver();
            driver.Url = "http://softuni.bg";
            driver.Manage().Window.FullScreen();
        }

        [TearDown]
        public void SchutDown()
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
            var zaNasField =driver.FindElement(By.CssSelector("#header-nav > div.toggle-nav.toggle-holder > ul > li:nth-child(1) > a > span"));
            zaNasField.Click();
            
            string expectedTitile = "За нас - Софтуерен университет";

            //Assert
            Assert.That(driver.Title, Is.EqualTo(expectedTitile));

        }
    }
}