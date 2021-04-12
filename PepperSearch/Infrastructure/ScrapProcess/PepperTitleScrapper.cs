using HtmlAgilityPack;
using System;
using System.Linq;

namespace PepperSearch
{
    /// <summary>
    /// Represents a title scrapper.
    /// </summary>
    class PepperTitleScrapper : ITitleScrapper
    {
        /// <summary>
        /// Returns a discount title.
        /// </summary>
        /// <param name="node">Node to be scrapped.</param>
        /// <returns>A discount title</returns>
        public string GetTitle(HtmlNode node)
        {
            string ret = String.Empty;
            try
            {
                ret = node.Descendants(HtmlTags.DIV)
                    .Where(n => n.GetAttributeValue(HtmlAttributes.CLASS, String.Empty) == StringResource.DivClassNameThreadTitle).First()
                    .Descendants(HtmlTags.A).First()
                    .GetAttributeValue(HtmlAttributes.TITLE, String.Empty);
            }
            catch (InvalidOperationException)
            {

            }

            return ret;
        }
    }
}
