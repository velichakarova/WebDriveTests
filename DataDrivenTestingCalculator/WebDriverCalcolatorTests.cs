using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace DataDrivenTestingCalculator
{
    
    public class WebDriverCalcolatorTests
    {
        private WebDriver driver;
        IWebElement numFild1;
        IWebElement numFild2;
        IWebElement operation;
        IWebElement calculate;
        IWebElement resultFild;
        IWebElement clearFild;

        [OneTimeSetUp]
        public void OpenAndNavigate()
        {
            this.driver = new ChromeDriver();
            driver.Url = "https://number-calculator.nakov.repl.co";
            driver.Manage().Window.Maximize();
            //Arrange
            numFild1 = driver.FindElement(By.Id("number1"));
            numFild2 = driver.FindElement(By.Id("number2"));
            operation = driver.FindElement(By.Id("operation"));
            calculate = driver.FindElement(By.Id("calcButton"));
            resultFild = driver.FindElement(By.Id("result"));
            clearFild = driver.FindElement(By.Id("result"));
        }
        [OneTimeTearDown]
        public void ShutDown() 
        {
            driver.Quit();
        }
        
        [TestCase("5","2","+", "Result: 7")]
        [TestCase("0", "0", "+", "Result: 0")]
        [TestCase("15", "6", "-", "Result: 9")]
        [TestCase("2", "3", "*", "Result: 6")]
        [TestCase("36", "6", "/", "Result: 6")]
        [TestCase("dxbvcs", "sds", "+", "Result: invalid input")]
        public void Test_Calculator(string num1, string num2, string operato,string result)
        {
            
            //Act
            numFild1.SendKeys(num1);
            operation.SendKeys(operato);
            numFild2.SendKeys(num2);

            calculate.Click();

            //string expectedValue = "Result: 7";
            Assert.That((result), Is.EqualTo(resultFild.Text));

            clearFild.Click();  
        }
    }
}