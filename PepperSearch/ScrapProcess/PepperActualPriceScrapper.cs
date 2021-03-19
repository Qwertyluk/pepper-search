using HtmlAgilityPack;
using System;
using System.Linq;

namespace PepperSearch
{
    /// <summary>
    /// A scrapper of current product price.
    /// </summary>
    public class PepperActualPriceScrapper : IActualPriceScrapper
    {
        /// <summary>
        /// A price converter.
        /// </summary>
        private readonly IPriceConvertion priceConverter;

        /// <summary>
        /// Creates an instance of the class.
        /// </summary>
        /// <param name="priceConverter">A price converter</param>
        public PepperActualPriceScrapper(IPriceConvertion priceConverter)
        {
            this.priceConverter = priceConverter;
        }

        /// <summary>
        /// Returns a current price of the product from the html node.
        /// </summary>
        /// <param name="node">The node to be scrapped.</param>
        /// <returns>A current product price.</returns>
        public decimal GetActualPrice(HtmlNode node)
        {
            decimal ret = 0;
            try
            {
                string strActualPrice = node.Descendants(HtmlTags.DIV).Where(n => n.GetAttributeValue(HtmlAttributes.CLASS, String.Empty) == StringResource.DivClassNameThreadTitle).First()
                    .Descendants(HtmlTags.SPAN).Where(n => n.GetAttributeValue(HtmlAttributes.CLASS, String.Empty) == StringResource.SpanClassNameDiscount).First()
                    .Descendants(HtmlTags.SPAN).Where(n => n.GetAttributeValue(HtmlAttributes.CLASS, String.Empty) == StringResource.SpanClassNameActualPrice).First()
                    .Descendants(HtmlTags.SPAN).First()
                    .InnerText;
                try
                {
                    ret = this.priceConverter.ConvertPrice(strActualPrice);
                }
                catch (FormatException) { }

            }
            catch (InvalidOperationException) { }

            return ret;
        }
    }
}
