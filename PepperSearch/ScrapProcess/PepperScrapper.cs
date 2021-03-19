using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;

namespace PepperSearch
{
    /// <summary>
    /// Represents a pepper website scrapper.
    /// </summary>
    public class PepperScrapper
    {
        /// <summary>
        /// A title scrapper.
        /// </summary>
        private readonly ITitleScrapper titleScrapper;
        /// <summary>
        /// A link scrapper.
        /// </summary>
        private readonly ILinkScrapper linkScrapper;
        /// <summary>
        /// A current price scrapper.
        /// </summary>
        private readonly IActualPriceScrapper actualPriceScrapper;
        /// <summary>
        /// A previous price scrapper.
        /// </summary>
        private readonly IPreviousPriceScrapper previousPriceScrapper;
        /// <summary>
        /// A discount value scrapper.
        /// </summary>
        private readonly IDiscountScrapper discountScrapper;
        /// <summary>
        /// A score scrapper.
        /// </summary>
        private readonly IScoreScrapper scoreScrapper;
        /// <summary>
        /// A description scrapper.
        /// </summary>
        private readonly IDescriptionScrapper descriptionScrapper;
        /// <summary>
        /// Scrapped data.
        /// </summary>
        public List<Discount> ScrappedData { get; private set; }

        /// <summary>
        /// Creates an instance of the class.
        /// </summary>
        /// <param name="titleScrapper">A title scrapper.</param>
        /// <param name="linkScrapper">A link scrapper.</param>
        /// <param name="actualPriceScrapper">A current price scrapper.</param>
        /// <param name="previousPriceScrapper">A previous price scrapper.</param>
        /// <param name="discountScrapper">A discount value scrapper.</param>
        /// <param name="scoreScrapper">A score scrapper.</param>
        /// <param name="descriptionScrapper">A description scrapper.</param>
        public PepperScrapper(
            ITitleScrapper titleScrapper,
            ILinkScrapper linkScrapper,
            IActualPriceScrapper actualPriceScrapper,
            IPreviousPriceScrapper previousPriceScrapper,
            IDiscountScrapper discountScrapper,
            IScoreScrapper scoreScrapper,
            IDescriptionScrapper descriptionScrapper)
        {
            this.titleScrapper = titleScrapper;
            this.linkScrapper = linkScrapper;
            this.actualPriceScrapper = actualPriceScrapper;
            this.previousPriceScrapper = previousPriceScrapper;
            this.discountScrapper = discountScrapper;
            this.scoreScrapper = scoreScrapper;
            this.descriptionScrapper = descriptionScrapper;

            this.ScrappedData = new List<Discount>();
        }

        /// <summary>
        /// Scraps pepper website in asynchronous way.
        /// </summary>
        /// <param name="number">Number of pages to scrap.</param>
        public async void ScrapDataAsync(int number)
        {
            for (int i = 1; i <= number; i++)
            {
                HtmlProvider htmlProvider = new HtmlProvider();
                string uri = StringResource.PepperHomePageLink + i;
                string html = await htmlProvider.GetHtmlAsync(StringResource.PepperHomePageLink);

                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);

                List<HtmlNode> nodes = htmlDoc.DocumentNode.Descendants(HtmlTags.DIV).Where(n => n.GetAttributeValue(HtmlAttributes.CLASS, "") == StringResource.DivClassNameThread).ToList();

                foreach (var node in nodes)
                {
                    Discount discount = new Discount()
                    {
                        Title = this.titleScrapper.GetTitle(node),
                        Link = this.linkScrapper.GetLink(node),
                        ActualPrice = this.actualPriceScrapper.GetActualPrice(node),
                        PreviousPrice = this.previousPriceScrapper.GetPreviousPrice(node),
                        Value = this.discountScrapper.GetDiscount(node),
                        Score = this.scoreScrapper.GetScore(node),
                        Description = this.descriptionScrapper.GetDescription(node),
                    };

                    this.ScrappedData.Add(discount);
                }
            }
        }
    }
}
