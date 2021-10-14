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

        [Test]
        public void GroupOrStatement()
        {
            string xpath = new XPathBuilder()
                .Elements("a")
                .Or()
                .StartGroup()
                .Elements("span")
                .Or()
                .Elements("div")
                .EndGroup();

            Assert.AreEqual("/a|(/span|/div)", xpath);
        }

        [Test]
        public void ContainAttributeOrStatement()
        {
            string xpath = new XPathBuilder()
                .AllChildElements()
                .Elements("div")
                .ContainsAttribute("class");

            Assert.AreEqual("/*/div[@class]", xpath);
        }

        [Test]
        public void WhereAttributeValueOrStatement()
        {
            string xpath = new XPathBuilder()
                .AllChildElements()
                .Elements("div")
                .WhereAttributeEquals("class", "button");

            Assert.AreEqual("/*/div[@class='button']", xpath);
        }
    }
}