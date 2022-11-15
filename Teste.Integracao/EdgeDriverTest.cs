using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System.Collections.ObjectModel;
using System.Threading;

namespace Teste.Integracao
{
    [TestClass]
    public class CharactersCountWebsiteTest
    {

        private EdgeDriver _driver;
        private readonly string url = "https://www.invertexto.com/contador-caracteres";

        [TestInitialize]
        public void EdgeDriverInitialize()
        {
            var options = new EdgeOptions 
            { 
                PageLoadStrategy = PageLoadStrategy.Normal 
            };
            _driver = new EdgeDriver(options);
            _driver.Url = url;
        }

        [TestMethod]
        public void CheckTitle()
        {
            Assert.AreEqual("Contador de Caracteres, Palavras e Linhas | invertexto.com", _driver.Title);
        }

        [TestMethod]
        public void SendTextAndCountCharacters()
        {
            IWebElement textfield = _driver.FindElement(By.Id("texto"));
            textfield.SendKeys("Uma frase bem bolada hahah");
            Thread.Sleep(500);
            IWebElement charsQuantity = _driver.FindElement(By.Id("chars"));

            Assert.AreEqual("26", charsQuantity.Text);
        }

        [TestMethod]
        public void GoToAbout()
        {
            ReadOnlyCollection<IWebElement> tabOptions = _driver.FindElements(By.TagName("li"));
            tabOptions[2].Click();

            Assert.AreEqual("Sobre o Site | invertexto.com", _driver.Title);
        }


        [TestCleanup]
        public void EdgeDriverCleanup()
        {
            _driver.Quit();
        }
    }
}
