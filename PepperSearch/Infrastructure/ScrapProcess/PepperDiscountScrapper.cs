using HtmlAgilityPack;
using System;
using System.Linq;

namespace PepperSearch
{
    /// <summary>
    /// A discount value scrapper.
    /// </summary>
    public class PepperDiscountScrapper : IDiscountScrapper
    {
        /// <summary>
        /// Returns a value of discount from the html node.
        /// </summary>
        /// <param name="node">The node to be scrapped.</param>
        /// <returns>A discount value.</returns>
        public decimal GetDiscount(HtmlNode node)
        {
            string strDiscount;
            decimal discount = 0;

            try
            {
                strDiscount = node.Descendants(HtmlTags.DIV).Where(n => n.GetAttributeValue(HtmlAttributes.CLASS, String.Empty) == StringResource.DivClassNameThreadTitle).First()
                    .Descendants(HtmlTags.SPAN).Where(n => n.GetAttributeValue(HtmlAttributes.CLASS, String.Empty) == StringResource.SpanClassNameDiscount).First()
                    .Descendants(HtmlTags.SPAN).Where(n => n.GetAttributeValue(HtmlAttributes.CLASS, String.Empty) == StringResource.SpanClassNamePreviousAndDiscount).First()
                    .Descendants(HtmlTags.SPAN).Where(n => n.GetAttributeValue(HtmlAttributes.CLASS, String.Empty) == StringResource.SpanClassNameDiscountPercentage).First().InnerText;

                discount = ConvertPercentage(strDiscount);
                discount = Math.Abs(discount);
            }
            catch (InvalidOperationException) { }

            return discount;
        }

        private decimal ConvertPercentage(string input)
        {
            return Decimal.Parse(input.TrimEnd(new char[] { '%', ' ' })) / 100M;
        }
    }
}
