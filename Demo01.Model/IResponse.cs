namespace Demo01.Model
{
    /// <summary>
    /// IResponse interface
    /// </summary>
    public interface IResponse
    {
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        string Message { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [did error].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [did error]; otherwise, <c>false</c>.
        /// </value>
        bool DidError { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        string ErrorMessage { get; set; }
    }
}