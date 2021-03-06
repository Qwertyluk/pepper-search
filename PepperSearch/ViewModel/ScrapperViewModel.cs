using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PepperSearch
{
    public class ScrapperViewModel
    {
        private IScrapper scrapper;

        private ObservableCollection<Discount> discounts;

        private ICommand scrapCommand;

        public IScrapper Scrapper
        {
            get
            {
                if(this.scrapper == null)
                {
                    HttpClient httpClient = new HttpClient();
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Add("user-agent",
                        "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)");

                    this.scrapper = new PepperScrapper(
                        new PepperTitleScrapper(),
                        new PepperLinkScrapper(),
                        new PepperActualPriceScrapper(new PriceConverter()),
                        new PepperPreviousPriceScrapper(new PriceConverter()),
                        new PepperDiscountScrapper(),
                        new PepperScoreScrapper(),
                        new PepperDescriptionScrapper(),
                        httpClient
                        );
                }
                return this.scrapper;
            }
        } 

        public ObservableCollection<Discount> Discounts
        {
            get
            {
                if(this.discounts == null)
                {
                    this.discounts = new ObservableCollection<Discount>();
                }
                return this.discounts;
            }
        }

        public ICommand ScrapCommand
        {
            get
            {
                if (this.scrapCommand == null)
                {
                    this.scrapCommand = new RelayCommand(this.ExecuteMethodScrapData, this.CanExecuteMethodScrapData);
                }
                return this.scrapCommand;
            }
        }

        public int StartPage
        {
            get;
            set;
        } = 1;

        public int EndPage
        {
            get;
            set;
        } = 10;

        public PepperGroup PepperGroup
        {
            get;
            set;
        } = PepperGroup.All;

        public string PepperSearchPhrase
        {
            get;
            set;
        } = String.Empty;

        private bool CanExecuteMethodScrapData(object parameter)
        {
            return true;
        }

        private async void ExecuteMethodScrapData(object parameter)
        {
            List<Discount> discounts;

            if(!String.IsNullOrEmpty(this.PepperSearchPhrase))
            {
                discounts = await this.Scrapper.GetDataAsync(this.StartPage, this.EndPage, this.PepperSearchPhrase);
            }
            else
            {
                discounts = await this.Scrapper.GetDataAsync(this.StartPage, this.EndPage, this.PepperGroup);
            }
            
            this.Discounts.Clear();
            discounts.ForEach(d => this.discounts.Add(d));
        }
    }
}
