using NUnit.Framework;

namespace FluentXPath.Test
{
    public class Tests
    {
        [Test]
        public void TestOrStatement()
        {
            string xpath = new XPathBuilder()
                .Elements("a")
                .Or()
                .Elements("span");

            Assert.AreEqual("/a|/span", xpath);
        }
    }
}