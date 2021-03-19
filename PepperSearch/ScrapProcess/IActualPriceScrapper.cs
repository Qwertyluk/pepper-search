using HtmlAgilityPack;

namespace PepperSearch
{
    /// <summary>
    /// Interface for a current price of product scrapper.
    /// </summary>
    public interface IActualPriceScrapper
    {
        /// <summary>
        /// Scraps a html node for a current price of a product.
        /// </summary>
        /// <param name="node">Node to be scrapped.</param>
        /// <returns>The current price of a product.</returns>
        decimal GetActualPrice(HtmlNode node);
    }
}
