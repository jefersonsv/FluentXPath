using System;
using System.Text;

namespace FluentXPath
{
    /// <summary>
    /// http://www.w3schools.com/xml/xpath_syntax.asp
    /// https://msdn.microsoft.com/en-us/library/ms256086(v=vs.110).aspx
    /// </summary>
    public class XPathBuilder
    {
        private StringBuilder sb = new StringBuilder();

        private XPathBuilder Append(string value)
        {
            sb.Append(value); return this;
        }

        /// <summary>
        /// Creates a new instance of an XPathBuilder.
        /// </summary>
        public XPathBuilder()
        {
            sb = new StringBuilder();
        }

        /// <summary>
        /// Creates a new instance of an XPathBuilder from an existing XPathBuilder.
        /// </summary>
        public XPathBuilder(XPathBuilder builder)
        {
            sb = new StringBuilder().Append(builder.sb);
        }

        /// <summary>
        /// Creates a new instance of an XPathBuilder from the specified XPath string.
        /// </summary>
        public XPathBuilder(string xpath)
        {
            sb = new StringBuilder().Append(xpath);
        }

        /// <summary>
        /// Implicit conversion to string.
        /// </summary>
        public static implicit operator string(XPathBuilder builder) => builder.ToString();

        /// <summary>
        /// Builds the XPath string.
        /// </summary>
        /// <returns>The XPath string.</returns>
        public override string ToString() => sb.ToString();

        /// <summary>
        /// Selects all immediate child elements.
        /// </summary>
        /// <returns>This XPathBuilder instance.</returns>
        public XPathBuilder AllChildElements() => Append("/*");

        /// <summary>
        /// Selects all comments.
        /// </summary>
        /// <returns>This XPathBuilder instance.</returns>
        public XPathBuilder AllComments() => Append("//comment()");

        /// <summary>
        /// Selects all descedent elements.
        /// </summary>
        /// <returns>This XPathBuilder instance.</returns>
        public XPathBuilder AllDescedentElements() => Append("//*");

        /// <summary>
        /// Selects the inner text of current node.
        /// </summary>
        /// <returns>This XPathBuilder instance.</returns>
        public XPathBuilder InnerText() => Append("/text()");

        /// <summary>
        /// Selects the parent of the current node.
        /// </summary>
        /// <returns>This XPathBuilder instance.</returns>
        public XPathBuilder Parent() => Append("/..");

        /// <summary>
        /// Adds an or condition to allow for multiple matching nodes.
        /// </summary>
        /// <returns>This XPathBuilder instance.</returns>
        public XPathBuilder Or() => Append("|");

        /// <summary>
        /// Selects immediate matching elements.
        /// </summary>
        /// <param name="element">The element to select.</param>
        /// <returns>This XPathBuilder instance.</returns>
        public XPathBuilder Elements(string element) => Append($"/{element}");

        /// <summary>
        /// Selects immediate matching elements that have an attribute of some kind.
        /// </summary>
        /// <param name="element">The element to select.</param>
        /// <returns>This XPathBuilder instance.</returns>
        public XPathBuilder ElementsAtLeastAnyAttribute(string element) => Append($"/{element}[@*]");

        /// <summary>
        /// Selects descending elements no matter where they are in the decending element tree.
        /// </summary>
        /// <param name="element">The element to select.</param>
        /// <returns>This XPathBuilder instance.</returns>
        public XPathBuilder ElementsDescend(string element) => Append("//" + element);

        /// <summary>
        /// Selects all elements that include the specified attribute name.
        /// </summary>
        /// <param name="attributeName">The attribute name that matching elments should have.</param>
        /// <returns>This XPathBuilder instance.</returns>
        public XPathBuilder Attributes(string attributeName) => WhereAttributeHasValue(attributeName);

        /// <summary>
        /// Selects all elements that include the specified attribute name.
        /// </summary>
        /// <param name="attributeName">The attribute name that matching elments should have.</param>
        /// <returns>This XPathBuilder instance.</returns>
        public XPathBuilder WhereAttributeHasValue(string attributeName) => Append($"/@{attributeName}");

        /// <summary>
        /// Selects elements where the given `attributeName` has the exact given `attributeValue`.
        /// </summary>
        /// <param name="attributeName">The attribute's name.</param>
        /// <param name="attributeValue">The attribute's value.</param>
        /// <returns>This XPathBuilder instance.</returns>
        public XPathBuilder WhereAttributeEquals(string attributeName, string attributeValue) => Append($"[@{attributeName}='{attributeValue}']");

        /// <summary>
        /// Selects elements where the given `attributeName` starts with the given `attributeValue`.
        /// </summary>
        /// <param name="attributeName">The attribute's name.</param>
        /// <param name="attributeValue">The attribute's value.</param>
        /// <returns>This XPathBuilder instance.</returns>
        public XPathBuilder WhereStartWith(string attributeName, string attributeValue) => WhereAttributeStartsWith(attributeName, attributeValue);

        /// <summary>
        /// Selects elements where the given `attributeName` starts with the given `attributeValue`.
        /// </summary>
        /// <param name="attributeName">The attribute's name.</param>
        /// <param name="attributeValue">The attribute's value.</param>
        /// <returns>This XPathBuilder instance.</returns>
        public XPathBuilder WhereAttributeStartsWith(string attributeName, string attributeValue) => Append($"[starts-with(@{attributeName}='{attributeValue}')])");

        /// <summary>
        /// Selects elements where the class attribute has the exact given `className` value.
        /// </summary>
        /// <param name="className">The exact value of the class attribute.</param>
        /// <returns>This XPathBuilder instance.</returns>
        public XPathBuilder WhereClass(string className) => Append($"[@class='{className}']");

        /// <summary>
        /// Selects elements where the id attribute has the exact given `id` value.
        /// </summary>
        /// <param name="id">The exact value of the id attribute.</param>
        /// <returns>This XPathBuilder instance.</returns>
        public XPathBuilder WhereId(string id) => Append($"[@id='{id}']");

        /// <summary>
        /// Selects the element at index `i`.
        /// </summary>
        /// <param name="i">The index of the elmenet to select.</param>
        /// <returns>This XPathBuilder instance.</returns>
        public XPathBuilder Index(int i) => Append($"[{i}]");

        /// <summary>
        /// Selects the element with the given index.
        /// </summary>
        /// <param name="i">The index of the element to select.</param>
        /// <returns>This XPathBuilder instance.</returns>
        public XPathBuilder WhereIndex(int i)
        {
            if (i < 1)
            {
                throw new Exception("The index needs to be greater than 0.");
            }
            return Index(i);
        }

        /// <summary>
        /// Selects the first element.
        /// </summary>
        /// <param name="element">The element to select.</param>
        /// <returns>This XPathBuilder instance.</returns>
        public XPathBuilder First() => Append("[1]");

        /// <summary>
        /// Selects the first `n` number of elements.
        /// </summary>
        /// <param name="n">The number of elements to select.</param>
        /// <returns>This XPathBuilder instance.</returns>
        public XPathBuilder First(int n)
        {
            if (n < 1)
            {
                throw new Exception("The number needs to be greater than 0.");
            }
            return Append($"[position()<{n + 1}]");
        }

        /// <summary>
        /// Selects the last element.
        /// </summary>
        /// <returns>This XPathBuilder instance.</returns>
        public XPathBuilder WhereLast() => Append("[last()]");

        /// <summary>
        /// Selects the element `n` elements before the last element.
        /// </summary>
        /// <param name="n">The number of elements before the last element to select.</param>
        /// <returns>This XPathBuilder instance.</returns>
        public XPathBuilder WhereLastMinus(int n)
        {
            if (n < 1)
            {
                throw new Exception("The number needs to be greater than 0.");
            }
            return Append($"[last()-{n}]");
        }

        /// <summary>
        /// Selects elements where the innerText has the given value.
        /// </summary>
        /// <param name="value">The exact value of the innerText.</param>
        /// <returns>This XPathBuilder instance.</returns>
        public XPathBuilder WhereInnerTextEquals(string value) => Append($"[@text()='{value}']");

        /// <summary>
        /// Selects elements whose innerText contains the given value.
        /// </summary>
        /// <param name="value">The value that should be contained in the element's innerText.</param>
        /// <returns>This XPathBuilder instance.</returns>
        public XPathBuilder WhereInnerTextContains(string value) => Append($"[contains(text(), '{value}')]");

        /// <summary>
        /// Selects elements whose innerText does not contain the given value.
        /// </summary>
        /// <param name="value">The value that should not be contained in the element's innerText.</param>
        /// <returns>This XPathBuilder instance.</returns>
        public XPathBuilder WhereNotInnerTextContains(string value) => Append($"[not(contains(text(), '{value}'))]");
    }
}