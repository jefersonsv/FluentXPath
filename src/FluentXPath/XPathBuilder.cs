using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentXPath
{
    /// <summary>
    /// http://www.w3schools.com/xml/xpath_syntax.asp
    /// https://msdn.microsoft.com/en-us/library/ms256086(v=vs.110).aspx
    /// </summary>
    public class XPathBuilder
    {
        private StringBuilder sb = new StringBuilder();

        public XPathBuilder()
        {
            sb = new StringBuilder();
        }

        public static implicit operator string(XPathBuilder builder)
        {
            return builder.ToString();
        }

        public XPathBuilder AllChildElements()
        {
            sb.Append("/*");
            return this;
        }

        public XPathBuilder AllComments()
        {
            sb.Append("//comment()");
            return this;
        }

        public XPathBuilder AllDescedentElements()
        {
            sb.Append("//*");
            return this;
        }

        public XPathBuilder Attributes(string attributeName)
        {
            sb.Append("/@" + attributeName);
            return this;
        }

        public XPathBuilder Elements(string element)
        {
            sb.Append("/" + element);
            return this;
        }

        public XPathBuilder ElementsAtLeastAnyAttribute(string element)
        {
            var fmt = "/{0}[@*]";
            sb.Append(string.Format(fmt, element));
            return this;
        }

        public XPathBuilder ElementsDescend(string element)
        {
            sb.Append("//" + element);
            return this;
        }

        public XPathBuilder First()
        {
            sb.Append("[1]");
            return this;
        }

        public XPathBuilder First(int number)
        {
            if (number < 1)
                throw new Exception("The number need to be greaten 0");
            sb.Append("[position()<" + (number + 1) + "]");
            return this;
        }

        public XPathBuilder Index(int index)
        {
            sb.Append("[" + index + "]");
            return this;
        }

        public XPathBuilder InnerText()
        {
            sb.Append("/text()");
            return this;
        }

        public XPathBuilder Or()
        {
            sb.Append("|");
            return this;
        }

        /// <summary>
        /// Selects the parent of the current node
        /// </summary>
        /// <returns></returns>
        public XPathBuilder Parent()
        {
            sb.Append("/..");
            return this;
        }

        public override string ToString()
        {
            return sb.ToString();
        }

        public XPathBuilder WhereAttributeEquals(string attributeName, string attributeValue)
        {
            var fmt = "[@{0}='{1}']";
            sb.Append(string.Format(fmt, attributeName, attributeValue));
            return this;
        }

        public XPathBuilder WhereClass(string className)
        {
            var fmt = "[@class='{0}']";
            sb.Append(string.Format(fmt, className));
            return this;
        }

        public XPathBuilder WhereId(string id)
        {
            var fmt = "[@id='{0}']";
            sb.Append(string.Format(fmt, id));
            return this;
        }

        public XPathBuilder WhereIndex(int number)
        {
            if (number < 1)
                throw new Exception("The number need to be greaten 0");

            sb.Append("[" + number + "]");
            return this;
        }

        public XPathBuilder WhereInnerTextEquals(string value)
        {
            var fmt = "[@text()='{0}']";
            sb.Append(string.Format(fmt, value));
            return this;
        }

        public XPathBuilder WhereInnerTextContains(string value)
        {
            var fmt = "[contains(text(), '{0}')]";
            sb.Append(string.Format(fmt, value));
            return this;
        }

        public XPathBuilder WhereLast()
        {
            sb.Append("[last()]");
            return this;
        }

        public XPathBuilder WhereLastMinus(int number)
        {
            if (number < 1)
                throw new Exception("The number need to be greaten 0");

            sb.Append("[last()-" + number + "]");
            return this;
        }

        public XPathBuilder WhereNotInnerTextContains(string value)
        {
            var fmt = "[not(contains(text(), '{0}'))]";
            sb.Append(string.Format(fmt, value));
            return this;
        }

        public XPathBuilder WhereStartWith(string attributeName, string attributeValue)
        {
            var fmt = "[starts-with(@{0}='{1}')])";
            sb.Append(string.Format(fmt, attributeName, attributeValue));
            return this;
        }
    }
}