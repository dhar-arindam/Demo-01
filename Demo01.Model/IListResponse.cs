using System.Collections.Generic;

namespace Demo01.Model
{
    /// <summary>
    /// IListResponse interface
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    /// <seealso cref="Demo01.Model.IResponse" />
    public interface IListResponse<TModel> : IResponse
    {
        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        /// <value>
        /// The model.
        /// </value>
        List<TModel> Model { get; set; }
    }
}