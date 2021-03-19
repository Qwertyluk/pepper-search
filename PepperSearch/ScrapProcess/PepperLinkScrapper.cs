using HtmlAgilityPack;
using System;
using System.Linq;

namespace PepperSearch
{
    /// <summary>
    /// A link scrapper.
    /// </summary>
    public class PepperLinkScrapper : ILinkScrapper
    {
        /// <summary>
        /// Returns a discount link from a html node.
        /// </summary>
        /// <param name="node">The node to be scrapped.</param>
        /// <returns>A link of the discount.</returns>
        public string GetLink(HtmlNode node)
        {
            string ret = String.Empty;
            try
            {
                ret = node.Descendants(HtmlTags.DIV)
                    .Where(n => n.GetAttributeValue(HtmlAttributes.CLASS, String.Empty) == StringResource.DivClassNameThreadTitle).First()
                    .Descendants(HtmlTags.A).First()
                    .GetAttributeValue(HtmlAttributes.HREF, String.Empty);
            }
            catch (InvalidOperationException)
            {

            }

            return ret;
        }
    }
}
