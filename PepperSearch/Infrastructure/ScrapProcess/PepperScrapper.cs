using HtmlAgilityPack;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PepperSearch
{
    /// <summary>
    /// Represents a pepper website scrapper.
    /// </summary>
    public class PepperScrapper : IScrapper
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

        private readonly HttpClient httpClient;

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
            IDescriptionScrapper descriptionScrapper,
            HttpClient httpClient)
        {
            this.titleScrapper = titleScrapper;
            this.linkScrapper = linkScrapper;
            this.actualPriceScrapper = actualPriceScrapper;
            this.previousPriceScrapper = previousPriceScrapper;
            this.discountScrapper = discountScrapper;
            this.scoreScrapper = scoreScrapper;
            this.descriptionScrapper = descriptionScrapper;
            this.httpClient = httpClient;
        }

        /// <summary>
        /// Scraps pepper website in asynchronous way.
        /// </summary>
        /// <param name="startPage">Start page</param>
        /// <param name="endPage">End page</param>
        /// <param name="group">Group</param>
        /// <returns>Scraped data</returns>
        public async Task<List<Discount>> GetDataAsync(int startPage, int endPage, PepperGroup group)
        {
            string parameterName = "?page=";
            string baseUri = GenerateGroupUri(group) + parameterName;

            return await ScrapDataAsync(startPage, endPage, baseUri);
        }

        /// <summary>
        /// Scraps pepper website in asynchronous way.
        /// </summary>
        /// <param name="startPage">Start page</param>
        /// <param name="endPage">End page</param>
        /// <param name="group">Group</param>
        /// <returns>Scraped data</returns>
        public async Task<List<Discount>> GetDataAsync(int startPage, int endPage, string searchPhrase)
        {
            string searchParameterName = "?q=";
            string pageParameterName = "&page=";
            string baseUri = StringResource.PepperLinkSearch + searchParameterName + searchPhrase + pageParameterName;

            return await ScrapDataAsync(startPage, endPage, baseUri);
        }


        private async Task<List<Discount>>ScrapDataAsync(int startPage, int endPage, string baseUri)
        {
            List<Discount> discounts = new List<Discount>();

            for (int i = startPage; i <= endPage; i++)
            {
                HtmlProvider htmlProvider = new HtmlProvider(httpClient);
                string uri = baseUri + i;
                string html = await htmlProvider.GetHtmlAsync(uri);

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

                    discounts.Add(discount);
                }
            }

            return discounts;
        }

        /// <summary>
        /// Returns the URI according to the group of interest.
        /// </summary>
        /// <param name="group">The group of interest</param>
        /// <returns>The URI</returns>
        private string GenerateGroupUri(PepperGroup group)
        {
            switch(group){
                case PepperGroup.All:
                    return StringResource.PepperLinkBase;
                case PepperGroup.Electronics:
                    return StringResource.PepperLinkElectronics;
                case PepperGroup.Gaming:
                    return StringResource.PepperLinkGaming;
                case PepperGroup.Home:
                    return StringResource.PepperLinkHome;
                case PepperGroup.Fashion:
                    return StringResource.PepperLinkFashion;
                case PepperGroup.Garden:
                    return StringResource.PepperLinkGarden;
                case PepperGroup.Health:
                    return StringResource.PepperLinkHealth;
                case PepperGroup.Family:
                    return StringResource.PepperLinkFamily;
                case PepperGroup.Groceries:
                    return StringResource.PepperLinkGroceries;
                case PepperGroup.Motorization:
                    return StringResource.PepperLinkMotorization;
                case PepperGroup.Culture:
                    return StringResource.PepperLinkCulture;
                case PepperGroup.Sport:
                    return StringResource.PepperLinkSport;
                case PepperGroup.Internet:
                    return StringResource.PepperLinkInternet;
                case PepperGroup.Finance:
                    return StringResource.PepperLinkFinance;
                case PepperGroup.Services:
                    return StringResource.PepperLinkServices;
                case PepperGroup.Travel:
                    return StringResource.PepperLinkTravel;
                default:
                    return StringResource.PepperLinkBase;
            }
        }
    }
}
