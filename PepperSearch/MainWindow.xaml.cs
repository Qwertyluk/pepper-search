using System;
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
            scrapper.ScrapDataAsync(Convert.ToInt32(this.TxtFrom.Text), Convert.ToInt32(this.TxtTo.Text));
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

            this.LblFrom.Content = StringResource.FROM;
            this.LblTo.Content = StringResource.TO;
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

        /// <summary>
        /// Prevents non-numeric input in the textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtFrom_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = !Int32.TryParse(e.Text, out _);
        }

        /// <summary>
        /// Prevents non-numeric input in the textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtTo_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = !Int32.TryParse(e.Text, out _);
        }
    }
}
