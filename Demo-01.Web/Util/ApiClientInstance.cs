namespace Demo01.Web.Util
{
    using System;
    using System.Threading;

    /// <summary>
    /// ApiClientInstance class
    /// </summary>
    internal static class ApiClientInstance
    {
        /// <summary>
        /// The API URI
        /// </summary>
        private static readonly Uri apiUri;

        /// <summary>
        /// The rest client
        /// </summary>
        private static Lazy<ApiClient> restClient = new Lazy<ApiClient>(() => new ApiClient(apiUri),
          LazyThreadSafetyMode.ExecutionAndPublication);

        /// <summary>
        /// Initializes the <see cref="ApiClientInstance"/> class.
        /// </summary>
        static ApiClientInstance() => apiUri = new Uri(AppSettings.WebApiUrl);

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static ApiClient Instance => restClient.Value;
    }
}