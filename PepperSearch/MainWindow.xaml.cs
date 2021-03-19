using System.Collections.Generic;
using System.Windows;

namespace PepperSearch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            PepperScrapper scrapper = new PepperScrapper(
                new PepperTitleScrapper(),
                new PepperLinkScrapper(),
                new PepperActualPriceScrapper(new PriceConverter()),
                new PepperPreviousPriceScrapper(new PriceConverter()),
                new PepperDiscountScrapper(),
                new PepperScoreScrapper(),
                new PepperDescriptionScrapper()
                );
            int numberOfPages = 10;
            scrapper.ScrapDataAsync(numberOfPages);
        }
    }
}
