namespace Demo01.Model
{
    /// <summary>
    /// IPagedResponse interface
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    /// <seealso cref="Demo01.Model.IListResponse{TModel}" />
    public interface IPagedResponse<TModel> : IListResponse<TModel>
    {
        /// <summary>
        /// Gets or sets the items count.
        /// </summary>
        /// <value>
        /// The items count.
        /// </value>
        int ItemsCount { get; set; }

        /// <summary>
        /// Gets the page count.
        /// </summary>
        /// <value>
        /// The page count.
        /// </value>
        double PageCount { get; }
    }
}