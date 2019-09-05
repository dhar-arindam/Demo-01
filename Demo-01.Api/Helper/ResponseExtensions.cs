namespace Demo01.Api.Helper
{
    using System.Net;

    using Demo01.Model;

    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// ResponseExtensions class
    /// </summary>
    public static class ResponseExtensions
    {
        /// <summary>
        /// Converts to httpresponse.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns></returns>
        public static IActionResult ToHttpResponse(this IResponse response)
        {
            var status = response.DidError ? HttpStatusCode.InternalServerError : HttpStatusCode.OK;

            return new ObjectResult(response)
            {
                StatusCode = (int)status
            };
        }

        /// <summary>
        /// Converts to httpresponse.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="response">The response.</param>
        /// <returns></returns>
        public static IActionResult ToHttpResponse<TModel>(this ISingleResponse<TModel> response)
        {
            var status = HttpStatusCode.OK;

            if (response.DidError)
            {
                status = HttpStatusCode.InternalServerError;
            }
            else if (response.Model == null)
            {
                status = HttpStatusCode.NotFound;
            }

            return new ObjectResult(response)
            {
                StatusCode = (int)status
            };
        }

        /// <summary>
        /// Converts to httpresponse.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="response">The response.</param>
        /// <returns></returns>
        public static IActionResult ToHttpResponse<TModel>(this IListResponse<TModel> response)
        {
            var status = HttpStatusCode.OK;

            if (response.DidError)
            {
                status = HttpStatusCode.InternalServerError;
            }
            else if (response.Model == null)
            {
                status = HttpStatusCode.NoContent;
            }

            return new ObjectResult(response)
            {
                StatusCode = (int)status
            };
        }
    }
}