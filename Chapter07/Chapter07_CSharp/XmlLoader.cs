namespace Chapter07_CSharp
{
    using System;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using System.Xml.Linq;

    using FunctionalCSharp;

    static class XmlLoader
    {
        public static string Attribute(this XElement node, string name, string def)
        {
            var attr = node.Attribute(name);
            return attr != null ? attr.Value : def;
        }

        public static DocumentPart LoadDocument(string url)
        {
            return LoadPart(XDocument.Load(url).Root);
        }

        static DocumentPart LoadPart(XElement node)
        {
            switch (node.Name.LocalName)
            {
                case "titled":
                    return new TitledPart(
                        new TextContent(node.Attribute("title", string.Empty), ParseFont(node)),
                        LoadPart(node.Elements().First()));
                case "split":
                    var nodes = node.Elements().Select((el) => LoadPart(el)).ToFuncList();
                    return new SplitPart(ParseOrientation(node.Attribute("orientation", string.Empty)), nodes);
                case "text":
                    return new TextPart(new TextContent(node.Value, ParseFont(node)));
                case "image":
                    return new ImagePart(node.Attribute("filename", string.Empty));
            }
            throw new Exception("Unknown element!");
        }

        static Font ParseFont(XElement node)
        {
            var styleStr = node.Attribute("style", string.Empty);
            var style = styleStr.Contains("bold") ? FontStyle.Bold : FontStyle.Regular;
            style = styleStr.Contains("italic") ? (style | FontStyle.Italic) : style;
            return new Font(node.Attribute("font", "Calibri"), float.Parse(node.Attribute("size", "12")), style);
        }

        static Orientation ParseOrientation(string orient)
        {
            return (orient == "horizontal") ? Orientation.Horizontal : Orientation.Vertical;
        }
    }
}