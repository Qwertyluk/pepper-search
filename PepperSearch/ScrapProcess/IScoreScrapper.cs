using HtmlAgilityPack;

namespace PepperSearch
{
    /// <summary>
    /// Represents a score scrapper
    /// </summary>
    public interface IScoreScrapper
    {
        /// <summary>
        /// Scraps a html node looking for score of discunt.
        /// </summary>
        /// <param name="node">Node to be scrapped.</param>
        /// <returns>The discount score.</returns>
        int GetScore(HtmlNode node);
    }
}
