using HtmlAgilityPack;
using System;
using System.Linq;

namespace PepperSearch
{
    /// <summary>
    /// A description scrapper.
    /// </summary>
    public class PepperDescriptionScrapper : IDescriptionScrapper
    {
        /// <summary>
        /// Returns a description of the product from the html node.
        /// </summary>
        /// <param name="node">The node to be scrapped.</param>
        /// <returns>A current product price.</returns>
        public string GetDescription(HtmlNode node)
        {
            string description = String.Empty;

            try
            {
                if (node.ChildNodes.Any(n => n.GetAttributeValue(HtmlAttributes.CLASS, String.Empty) == StringResource.DivClassNameThreadBody))
                {
                    description = node.Descendants(HtmlTags.DIV).Where(n => n.GetAttributeValue(HtmlAttributes.CLASS, String.Empty) == StringResource.DivClassNameThreadBody).First()
                        .Descendants(HtmlTags.DIV).Where(n => n.GetAttributeValue(HtmlAttributes.CLASS, String.Empty) == StringResource.DivClassNameBodySpace).First()
                        .Descendants(HtmlTags.DIV).Where(n => n.GetAttributeValue(HtmlAttributes.CLASS, String.Empty) == StringResource.DivClassNameSpaceContent).First()
                        .Descendants(HtmlTags.DIV).First().InnerHtml;
                }
                else if (node.ChildNodes.Any(n => n.GetAttributeValue(HtmlAttributes.CLASS, String.Empty) == StringResource.DivClassNameThreadBodySpace))
                {
                    description = node.Descendants(HtmlTags.DIV).Where(n => n.GetAttributeValue(HtmlAttributes.CLASS, String.Empty) == StringResource.DivClassNameThreadBodySpace).First()
                        .Descendants(HtmlTags.DIV).Where(n => n.GetAttributeValue(HtmlAttributes.CLASS, String.Empty) == StringResource.DivClassNameUserHtml).First()
                        .Descendants(HtmlTags.DIV).First().InnerHtml;
                }

                if (description.Contains("<"))
                {
                    description = description.Substring(0, description.IndexOf("<"));
                }
                description = description.Trim(new char[] { '\t', ' ', '…' });
            }
            catch (InvalidOperationException) { }

            return description;
        }
    }
}
