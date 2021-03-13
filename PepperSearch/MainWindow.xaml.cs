using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

        private async void Btn_Click(object sender, RoutedEventArgs e)
        {
            /*string url = "https://www.pepper.pl/";
            string response = await CallUrl(url);
            ParseHtml(response);*/
        }

        private static async Task<string> CallUrl(string fullUrl)
        {
            /*HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            return await client.GetStringAsync(fullUrl);*/
        }

        private void ParseHtml(string html)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            List<HtmlNode> nodes = htmlDoc.DocumentNode.Descendants("div").Where(n => n.GetAttributeValue("class", "") == "threadGrid").ToList();

            foreach (var node in nodes)
            {
                HtmlNode temp = node.Descendants("div").Where(n => n.GetAttributeValue("class", "") == "threadGrid-title js-contextual-message-placeholder").First();
                HtmlNode temp2 = temp.Descendants("strong").Where(n => n.GetAttributeValue("class", "") == "thread-title ").First();
                string title = temp2.Descendants("a").First().GetAttributeValue("title", "");
            }

            return;
        }
    }
}
