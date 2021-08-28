using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepperSearch
{
    class IocConfiguration : NinjectModule
    {
        public override void Load()
        {
            BindScrapper();

            BindPirceConvertion();

            BindViewModels();
        }

        private void BindScrapper()
        {
            Bind<IScrapper>().To<PepperScrapper>();
            Bind<ITitleScrapper>().To<PepperTitleScrapper>();
            Bind<ILinkScrapper>().To<PepperLinkScrapper>();
            Bind<IActualPriceScrapper>().To<PepperActualPriceScrapper>();
            Bind<IPreviousPriceScrapper>().To<PepperPreviousPriceScrapper>();
            Bind<IDiscountScrapper>().To<PepperDiscountScrapper>();
            Bind<IScoreScrapper>().To<PepperScoreScrapper>();
            Bind<IDescriptionScrapper>().To<PepperDescriptionScrapper>();
        }

        private void BindPirceConvertion()
        {
            Bind<IPriceConvertion>().To<PriceConverter>()
                .WithConstructorArgument("currencySymbol", ConfigurationManager.AppSettings.Get("pepperDiscountPriceCurrencySymbol"))
                .WithConstructorArgument("numberGroupSeparator", ConfigurationManager.AppSettings.Get("pepperDiscountPriceGroupSeparator"))
                .WithConstructorArgument("numberDecimalSeparator", ConfigurationManager.AppSettings.Get("pepperDiscountPriceDecimalSeparator"));
        }

        private void BindViewModels()
        {
            Bind<ScrapperViewModel>().ToSelf();
        }
    }
}
