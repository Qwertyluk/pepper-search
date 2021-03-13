using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PepperSearch
{
    public class HtmlProvider
    {
        public async Task<string> GetHtmlAsync(string uri)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            return await client.GetStringAsync(uri);
        }
    }
}
