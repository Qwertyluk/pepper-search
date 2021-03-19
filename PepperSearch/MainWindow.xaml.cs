using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;

namespace PepperSearch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// The website scrapper.
        /// </summary>
        private PepperScrapper scrapper;

        public MainWindow()
        {
            InitializeComponent();

            InitializeComponents();
        }

        /// <summary>
        /// Handles clicking on the refresh button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            int numberOfPages = 10;
            scrapper.ScrapDataAsync(numberOfPages);
        }

        /// <summary>
        /// Initializes window's components.
        /// </summary>
        private void InitializeComponents()
        {
            this.scrapper = new PepperScrapper(
                new PepperTitleScrapper(),
                new PepperLinkScrapper(),
                new PepperActualPriceScrapper(new PriceConverter()),
                new PepperPreviousPriceScrapper(new PriceConverter()),
                new PepperDiscountScrapper(),
                new PepperScoreScrapper(),
                new PepperDescriptionScrapper()
                );

            this.BtnRefresh.Content = StringResource.ButtonContentRefresh;

            Binding b = new Binding("ScrappedData")
            {
                Source = this.scrapper
            };
            this.DgData.SetBinding(DataGrid.ItemsSourceProperty, b);
        }

        /// <summary>
        /// Handles clicking on the datagrid link column.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DG_Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Hyperlink link = (Hyperlink)e.OriginalSource;
            Process.Start(link.NavigateUri.AbsoluteUri);
        }
    }
}
