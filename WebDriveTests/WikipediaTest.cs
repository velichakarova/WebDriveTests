

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


//Create new Chrome browser instance
var driver = new ChromeDriver();

//navigate wikepadia
driver.Url = "https://wikipedia.org";

System.Console.WriteLine("CURRENT TITLE:" + driver.Title);

//Locate Search Fild by Id
var searchField = driver.FindElement(By.Id("searchInput"));

//click on element
searchField.Click();

//fill QA and press ENTER keybord button
searchField.SendKeys("QA" + Keys.Enter);

System.Console.WriteLine("TITLE AFTER SEARCH  " + driver.Title);
//close browser
driver.Quit();
