using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace EngageSmart
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            IWebDriver driver = new ChromeDriver();


            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/");

            IWebElement linkAddRemoveElement = driver.FindElement(By.CssSelector("a[href='/add_remove_elements/']"));

            linkAddRemoveElement.Click();

            IWebElement buttonAddElement = driver.FindElement(By.CssSelector("button[onclick='addElement()']"));

            int numberOfElementsToBeAdded = 10;
            for (int i = 0; i < numberOfElementsToBeAdded; i++)
            {
                buttonAddElement.Click();
            }
            ReadOnlyCollection<IWebElement> deleteButtons = driver.FindElements(By.CssSelector("button.added-manually[onclick='deleteElement()']"));

            int numberOfElementsOnThePage = deleteButtons.Count;
            Assert.That(numberOfElementsOnThePage, Is.EqualTo(numberOfElementsToBeAdded));

            driver.Quit();
        }
    }
}