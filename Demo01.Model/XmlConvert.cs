
namespace Demo01.Model
{
    using System;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// Xml serialiser/ deserializer
    /// </summary>
    public static class XmlConvert
    {
        /// <summary>
        /// Serializes the specified value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        /// <exception cref="Exception">An error occurred</exception>
        public static string Serialize<T>(this T value)
        {
            if (value == null)
            {
                return string.Empty;
            }
            try
            {
                var xmlserializer = new XmlSerializer(typeof(T));
                var stringWriter = new StringWriter();
                using (var writer = XmlWriter.Create(stringWriter))
                {
                    xmlserializer.Serialize(writer, value);
                    var xDoc = new XmlDocument();
                    xDoc.LoadXml(stringWriter.ToString());
                    return xDoc.DocumentElement.OuterXml;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred", ex);
            }
        }

        /// <summary>
        /// Deserializes the specified XML string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xmlString">The XML string.</param>
        /// <returns></returns>
        /// <exception cref="Exception">An error occurred</exception>
        public static T Deserialize<T>(this string xmlString)
        {
            var data = default(T);
            try
            {
                var xDoc = new XmlDocument();
                xDoc.LoadXml(xmlString);
                var xNodeReader = new XmlNodeReader(xDoc.DocumentElement);
                var xmlSerializer = new XmlSerializer(typeof(T));

                data = (T)xmlSerializer.Deserialize(xNodeReader);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred", ex);
            }
            return data;
        }
    }
}