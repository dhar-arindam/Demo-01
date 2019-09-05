namespace Demo01.Web.Util
{
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    using Demo01.Model;

    using Newtonsoft.Json;

    /// <summary>
    /// Api Client class
    /// </summary>
    public class ApiClient
    {
        /// <summary>
        /// The HTTP client
        /// </summary>
        private readonly HttpClient _httpClient;
        /// <summary>
        /// Gets or sets the base endpoint.
        /// </summary>
        /// <value>
        /// The base endpoint.
        /// </value>
        private Uri BaseEndpoint { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClient"/> class.
        /// </summary>
        /// <param name="baseEndpoint">The base endpoint.</param>
        /// <exception cref="ArgumentNullException">baseEndpoint</exception>
        public ApiClient(Uri baseEndpoint)
        {
            if (baseEndpoint == null)
            {
                throw new ArgumentNullException("baseEndpoint");
            }
            BaseEndpoint = baseEndpoint;
            _httpClient = new HttpClient();
        }

        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public async Task<T> GetAsync<T>(string url)
        {
            var acceptType = "application/xml";
            Uri requestUrl = CreateRequestUri(url);
            _httpClient.DefaultRequestHeaders.Add("Accept", acceptType);
            var response = await _httpClient.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            if (acceptType.Contains("xml"))
            {
                return data.Deserialize<T>();
            }

            return JsonConvert.DeserializeObject<T>(data);
        }

        /// <summary>
        /// Common method for making POST calls
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="content">The content.</param>
        /// <returns></returns>
        public async Task<T> PostAsync<T>(string url, T content)
        {
            var contentType = "application/xml";
            Uri requestUrl = CreateRequestUri(url);
            var payLoad = CreateHttpContent<T>(content, contentType);

            var rtresponse = default(SingleResponse<T>);

            var response = await _httpClient.PostAsync(requestUrl.ToString(), payLoad);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            if (contentType.Contains("xml"))
            {
                rtresponse = data.Deserialize<SingleResponse<T>>();
                return rtresponse.Model;
            }

            rtresponse = JsonConvert.DeserializeObject<SingleResponse<T>>(data);
            return rtresponse.Model;
        }

        /// <summary>
        /// Creates the request URI.
        /// </summary>
        /// <param name="relativePath">The relative path.</param>
        /// <param name="queryString">The query string.</param>
        /// <returns></returns>
        private Uri CreateRequestUri(string relativePath, string queryString = "")
        {
            var endpoint = new Uri(BaseEndpoint, relativePath);
            var uriBuilder = new UriBuilder(endpoint);
            uriBuilder.Query = queryString;
            return uriBuilder.Uri;
        }

        /// <summary>
        /// Creates the content of the HTTP.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="content">The content.</param>
        /// <param name="contentType">Type of the content.</param>
        /// <returns></returns>
        private HttpContent CreateHttpContent<T>(T content, string contentType = "application/xml")
        {
            StringContent result = null;
            if (contentType.Contains("xml"))
            {
                var xml = content.Serialize<T>();
                result = new StringContent(xml, Encoding.UTF8, contentType);
            }
            else
            {
                var json = JsonConvert.SerializeObject(content, MicrosoftDateFormatSettings);
                result = new StringContent(json, Encoding.UTF8, contentType);
            }

            return result;
        }

        /// <summary>
        /// Gets the microsoft date format settings.
        /// </summary>
        /// <value>
        /// The microsoft date format settings.
        /// </value>
        private static JsonSerializerSettings MicrosoftDateFormatSettings => new JsonSerializerSettings
        {
            DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
        };
    }
}