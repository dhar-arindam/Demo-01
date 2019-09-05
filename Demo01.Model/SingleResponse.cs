namespace Demo01.Model
{
    /// <summary>
    /// Single response class
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    /// <seealso cref="Demo01.Model.ISingleResponse{TModel}" />
    public class SingleResponse<TModel> : ISingleResponse<TModel>
    {
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [did error].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [did error]; otherwise, <c>false</c>.
        /// </value>
        public bool DidError { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        /// <value>
        /// The model.
        /// </value>
        public TModel Model { get; set; }
    }
}