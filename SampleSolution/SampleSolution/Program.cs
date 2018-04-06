using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Linq;

namespace SampleSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver(@"C:\tools\selenium");
            string indexUrl = "file:///D:/projects/SeleniumTutorial/index.html";
            driver.Url = indexUrl;

            //ID Form
            IWebElement nameField = driver.FindElement(By.Id("name"));
            nameField.SendKeys("Matthew Hansen");

            IWebElement dogBreed = driver.FindElement(By.Id("chopper"));
            dogBreed.Click();

            IWebElement blizzardDropdown = driver.FindElement(By.Id("dropdown"));
            blizzardDropdown.Click();

            IWebElement gameOption = driver.FindElement(By.Id("overwatch"));
            gameOption.Click();

            IWebElement submitButton = driver.FindElement(By.Id("submit"));
            submitButton.Click();

            driver.Url = indexUrl;


            //XPath Form
            IWebElement xNameField = driver.FindElement(By.XPath(".//p[contains(text(), 'Name')]/input"));
            xNameField.SendKeys("Matthew Hansen ;)");

            IWebElement xDogBreed = driver.FindElement(By.XPath(".//p[contains(text(), 'Pom')]/input"));
            xDogBreed.Click();

            IWebElement xBlizzardOption = driver.FindElement(By.XPath(".//select"));
            xBlizzardOption.Click();

            IWebElement xBlizzardGame = driver.FindElement(By.XPath(".//option[text() = 'HOTS']"));
            xBlizzardGame.Click();

            IWebElement xSubmitButton = driver.FindElement(By.XPath(".//*[@value = 'Submit Now!!!']"));
            xSubmitButton.Click();

            IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor) driver;
            string script = $"window.location.href = '{indexUrl}'";
            javaScriptExecutor.ExecuteScript(script);

            //One more time by Xpath, but a little bit more complicated and not well thought out, but realistic of what you might see.
            IWebElement x2NameField = driver.FindElement(By.XPath(".//p[contains(text(), 'Name')]/input"));
            x2NameField.SendKeys("Matthew Hansen ;)");

            
            //Could've been done as a list and a foreach to appear simpler, but it was more messy and functional programming is da wae.
            IEnumerable<IWebElement> dogBreeds = driver.FindElements(By.XPath(".//input[@name = 'dog']/parent::*"));
            IWebElement preferredBreed = dogBreeds.FirstOrDefault(db => db.Text.Contains("Wins")).FindElement(By.XPath(".//input"));
            preferredBreed.Click();


            IWebElement x2BlizzardOption = driver.FindElement(By.XPath(".//select"));
            x2BlizzardOption.Click();

            IEnumerable<IWebElement> x2BlizzardGames = driver.FindElements(By.XPath(".//option"));
            IWebElement x2BlizzardGame = x2BlizzardGames.FirstOrDefault(bg => bg.Text.Equals("DOTA 2"));
            x2BlizzardGame.Click();

            IWebElement x2SubmitButton = driver.FindElement(By.XPath(".//*[@value = 'Submit Now!!!']"));
            x2SubmitButton.Click();

            driver.Close();
        }
    }
}
