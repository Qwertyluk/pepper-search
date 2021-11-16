using System.Net.Http;
using System.Threading.Tasks;

namespace PepperSearch
{
    /// <summary>
    /// Provides html from the uri.
    /// </summary>
    public class HtmlProvider
    {
        private readonly HttpClient httpClient;

        public HtmlProvider(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        /// <summary>
        /// Returns the response body as a string in an asynchronous operation.
        /// </summary>
        /// <param name="uri">The Uri the request is sent to.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<string> GetHtmlAsync(string uri)
        {
            HttpResponseMessage responseMessage = await this.httpClient.GetAsync(uri);
            return await responseMessage.Content.ReadAsStringAsync();
        }
    }
}
