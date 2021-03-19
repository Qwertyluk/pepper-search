using HtmlAgilityPack;
using System;
using System.Linq;

namespace PepperSearch
{
    /// <summary>
    /// Represents a score scrapper.
    /// </summary>
    public class PepperScoreScrapper : IScoreScrapper
    {
        /// <summary>
        /// Returns a discount score.
        /// </summary>
        /// <param name="node">A node to be scrappe.d</param>
        /// <returns>The discount score.</returns>
        public int GetScore(HtmlNode node)
        {
            int score = 0;

            try
            {
                string strScore = node.Descendants(HtmlTags.DIV).Where(n => n.GetAttributeValue(HtmlAttributes.CLASS, String.Empty) == StringResource.DivClassNameHeaderMeta).First()
                    .Descendants(HtmlTags.DIV).First()
                    .Descendants(HtmlTags.DIV).Where(n => n.GetAttributeValue(HtmlAttributes.CLASS, String.Empty) == StringResource.DivClassNameVoteBox).First()
                    .Descendants(HtmlTags.SPAN).Where(n => n.GetAttributeValue(HtmlAttributes.CLASS, String.Empty) == StringResource.SpanClassNameVoteScore).First().InnerText;
                strScore = new string(strScore.Where(c => !Char.IsWhiteSpace(c)).ToArray()).RemoveWhitespace();
                strScore = strScore.Remove(strScore.Length - 1);
                score = Convert.ToInt32(strScore);
            }
            catch (InvalidOperationException) { }

            return score;
        }
    }
}
