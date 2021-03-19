using System.Net.Http;
using System.Threading.Tasks;

namespace PepperSearch
{
    /// <summary>
    /// Provides html from the uri.
    /// </summary>
    public class HtmlProvider
    {
        /// <summary>
        /// Returns the response body as a string in an asynchronous operation.
        /// </summary>
        /// <param name="uri">The Uri the request is sent to.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<string> GetHtmlAsync(string uri)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            return await client.GetStringAsync(uri);
        }
    }
}
