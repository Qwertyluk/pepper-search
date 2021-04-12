using HtmlAgilityPack;

namespace PepperSearch
{
    /// <summary>
    /// Interface for a description of discount scrapper.
    /// </summary>
    public interface IDescriptionScrapper
    {
        /// <summary>
        /// Scraps a html node for description of a discount.
        /// </summary>
        /// <param name="node">Node to be scrapped.</param>
        /// <returns>Description of a discount.</returns>
        string GetDescription(HtmlNode node);
    }
}
