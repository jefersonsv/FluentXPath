[![NuGet](https://img.shields.io/nuget/v/FluentXpath.svg)](https://www.nuget.org/packages/FluentXpath/)
[![MIT Licence](https://badges.frapsoft.com/os/mit/mit.svg?v=103)](https://opensource.org/licenses/mit-license.php)
# Fluent XPath
Build query XPath with fluent style code
# Usage
``` C#
string xpath = new XPathBuilder()
	.AllDescedentElements()
	.Elements("div").WhereAttributeEquals("class", "line")
	.Elements("a")
	.Or()
	.AllDescedentElements()
	.Elements("div").WhereAttributeEquals("class", "line odd")
	.Elements("a")
	.Or()
	.AllDescedentElements()
	.Elements("blockquote")
	.Elements("font")
	.Elements("a");
```
## Thanks to
- [Microsoft](https://msdn.microsoft.com/en-us/library/ms256086.aspx)
- [Rawgit](https://rawgit.com/)
- [w3schools](http://www.w3schools.com/xml/xpath_syntax.asp)
- [Jeferson Tenorio](https://br.linkedin.com/in/jefersontenorio) :smile: