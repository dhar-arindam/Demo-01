namespace Demo01.Api.Helper
{
    using Microsoft.AspNetCore.Mvc.Formatters;
    using System;
    using System.Xml.Serialization;

    /// <summary>
    /// Custom XML Input formatter
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Formatters.XmlSerializerInputFormatter" />
    public class XmlInputFormatter : XmlSerializerInputFormatter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XmlInputFormatter"/> class.
        /// </summary>
        public XmlInputFormatter(Microsoft.AspNetCore.Mvc.MvcOptions option) : base(option) { }

        /// <summary>
        /// Called during deserialization to get the <see cref="T:System.Xml.Serialization.XmlSerializer" />.
        /// </summary>
        /// <param name="type"></param>
        /// <returns>
        /// The <see cref="T:System.Xml.Serialization.XmlSerializer" /> used during deserialization.
        /// </returns>
        protected override XmlSerializer CreateSerializer(Type type)
        {
            //init xml serializer
            XmlSerializer serializer = null;

            serializer = base.CreateSerializer(type);

            //return serializer
            return serializer;
        }
    }
}