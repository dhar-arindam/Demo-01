namespace Demo01.Model
{
    /// <summary>
    /// Single response interface
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    /// <seealso cref="Demo01.Model.IResponse" />
    public interface ISingleResponse<TModel> : IResponse
    {
        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        /// <value>
        /// The model.
        /// </value>
        TModel Model { get; set; }
    }
}