using HtmlAgilityPack;

namespace PepperSearch
{
    /// <summary>
    /// Interface of discount value scrapper.
    /// </summary>
    public interface IDiscountScrapper
    {
        /// <summary>
        /// Scraps a html node for a discount value.
        /// </summary>
        /// <param name="node">Node to be scrapped.</param>
        /// <returns>Discount value.</returns>
        decimal GetDiscount(HtmlNode node);
    }
}
