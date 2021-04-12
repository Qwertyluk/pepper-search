using HtmlAgilityPack;
using System;
using System.Linq;

namespace PepperSearch
{
    /// <summary>
    /// A previous price scrapper.
    /// </summary>
    class PepperPreviousPriceScrapper : IPreviousPriceScrapper
    {
        /// <summary>
        /// A price converter.
        /// </summary>
        private IPriceConvertion priceConverter;

        /// <summary>
        /// Creates an instance of the class.
        /// </summary>
        /// <param name="priceConverter">A price converter.</param>
        public PepperPreviousPriceScrapper(IPriceConvertion priceConverter)
        {
            this.priceConverter = priceConverter;
        }

        /// <summary>
        /// Returns a previous price of the product.
        /// </summary>
        /// <param name="node">A node to be scrapped.</param>
        /// <returns>The previous price of the product.</returns>
        public decimal GetPreviousPrice(HtmlNode node)
        {
            decimal ret = 0;
            try
            {
                string strPreviousPrice = node.Descendants(HtmlTags.DIV).Where(n => n.GetAttributeValue(HtmlAttributes.CLASS, String.Empty) == StringResource.DivClassNameThreadTitle).First()
                    .Descendants(HtmlTags.SPAN).Where(n => n.GetAttributeValue(HtmlAttributes.CLASS, String.Empty) == StringResource.SpanClassNameDiscount).First()
                    .Descendants(HtmlTags.SPAN).Where(n => n.GetAttributeValue(HtmlAttributes.CLASS, String.Empty) == StringResource.SpanClassNamePreviousAndDiscount).First()
                    .Descendants(HtmlTags.SPAN).Where(n => n.GetAttributeValue(HtmlAttributes.CLASS, String.Empty) == StringResource.SpanClassNamePrevioudPrice).First().InnerText;
                try
                {
                    ret = this.priceConverter.ConvertPrice(strPreviousPrice);
                }
                catch (FormatException) { }

            }
            catch (InvalidOperationException) { }

            return ret;
        }
    }
}
