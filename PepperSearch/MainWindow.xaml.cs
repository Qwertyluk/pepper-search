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
        public MainWindow(ScrapperViewModel viewModel)
        {
            this.DataContext = viewModel;
            InitializeComponent();
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
