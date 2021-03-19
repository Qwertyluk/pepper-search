using HtmlAgilityPack;

namespace PepperSearch
{
    /// <summary>
    /// Represents a previous price scrapper
    /// </summary>
    public interface IPreviousPriceScrapper
    {
        /// <summary>
        /// Scraps a html node, looking for a previous price of product
        /// </summary>
        /// <param name="node">Node to be scrapped.</param>
        /// <returns>Previous price of product.</returns>
        decimal GetPreviousPrice(HtmlNode node);
    }
}
