using HtmlAgilityPack;

namespace PepperSearch
{
    /// <summary>
    /// Interface of link scrapper.
    /// </summary>
    public interface ILinkScrapper
    {
        /// <summary>
        /// Scraps a html node, looking for link of the discount.
        /// </summary>
        /// <param name="node">Node to be scrapped.</param>
        /// <returns>Link of the discount.</returns>
        string GetLink(HtmlNode node);
    }
}
