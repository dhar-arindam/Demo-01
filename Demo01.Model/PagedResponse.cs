namespace Demo01.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    /// <summary>
    /// Paged response class
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    /// <seealso cref="Demo01.Model.IPagedResponse{TModel}" />
    [DataContract]
    [Serializable]
    [XmlRoot("PagedResponse")]
    public class PagedResponse<TModel> : IPagedResponse<TModel>
    {
        public PagedResponse()
        {
        }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        [DataMember(Name = "Message")]
        [XmlElement(ElementName = "Message")]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [did error].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [did error]; otherwise, <c>false</c>.
        /// </value>
        [XmlIgnore]
        public bool DidError { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        [DataMember(Name = "ErrorMessage")]
        [XmlElement(ElementName = "ErrorMessage")]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        /// <value>
        /// The model.
        /// </value>
        [DataMember(Name = "Data")]
        [XmlElement, Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public List<TModel> Model { get; set; }

        /// <summary>
        /// Gets or sets the size of the page.
        /// </summary>
        /// <value>
        /// The size of the page.
        /// </value>
        [DataMember(Name = "PageSize")]
        [XmlElement(ElementName = "PageSize")]
        public int PageSize { get; set; }

        /// <summary>
        /// Gets or sets the page number.
        /// </summary>
        /// <value>
        /// The page number.
        /// </value>
        [DataMember(Name = "PageNumber")]
        [XmlElement(ElementName = "PageNumber")]
        public int PageNumber { get; set; }

        /// <summary>
        /// Gets or sets the items count.
        /// </summary>
        /// <value>
        /// The items count.
        /// </value>
        [DataMember(Name = "ItemCount")]
        [XmlElement(ElementName = "ItemCount")]
        public int ItemsCount { get; set; }

        /// <summary>
        /// Gets the page count.
        /// </summary>
        /// <value>
        /// The page count.
        /// </value>
        [DataMember(Name = "PageCount")]
        [XmlElement(ElementName = "PageCount")]
        public double PageCount
            => ItemsCount < PageSize ? 1 : (int)(((double)ItemsCount / PageSize) + 1);
    }
}