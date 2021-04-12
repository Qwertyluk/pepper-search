using HtmlAgilityPack;

namespace PepperSearch
{
    /// <summary>
    /// Represents a title scrapper.
    /// </summary>
    public interface ITitleScrapper
    {
        /// <summary>
        /// Scraps a html node looking for a discount title.
        /// </summary>
        /// <param name="node">The node to be scrapped.</param>
        /// <returns>The title of discount.</returns>
        string GetTitle(HtmlNode node);
    }
}
