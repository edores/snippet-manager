using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq; 

namespace Snippet
{
    class XmlHelpers
    {
        public static XDocument CreateNewDoc()
        {
            XDocument doc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("collection")
            );
            return doc;
        }

        public static XElement GetFileItem(string filePath, string tags)
        {
            XElement e = new XElement("file",
                new XAttribute("path", filePath),
                new XAttribute("tags", tags)
                );
            return e;
        }

        // Convert Tag List to comma-separated string
        public static string GetTags(List<string> list)
        {
            if (list.Count == 0)
            {
                return "";
            }

            var sbTags = new StringBuilder();
            foreach (var listItem in list)
            {
                sbTags.Append(",");
                sbTags.Append(listItem);
            }
            return sbTags.ToString().Substring(1);
        }

        // Substitute "dangerous" XML symbols if they were found in input string
        public static string XmlEscaped(string listItem)
        {
            // No need to escape -- XML.Linq does it
            return System.Security.SecurityElement.Escape(listItem);
        }

    }
}
