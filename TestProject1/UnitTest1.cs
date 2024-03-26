using OpenQA.Selenium;

namespace TestProject1
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
            Assert.Pass();
        }
    }

    internal class ExpectedConditions
    {
        internal static Func<IWebDriver, IWebElement> ElementExists(By by)
        {
            throw new NotImplementedException();
        }
    }
}