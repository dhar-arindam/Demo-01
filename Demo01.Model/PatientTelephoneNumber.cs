namespace Demo01.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    /// <summary>
    /// Patient Telephone Number class
    /// </summary>
    [DataContract]
    [Serializable, XmlRoot("PatientTelephoneNumber")]
    public class PatientTelephoneNumber
    {
        public PatientTelephoneNumber()
        {
        }

        /// <summary>
        /// Gets or sets the mobile number.
        /// </summary>
        /// <value>
        /// The number.
        /// </value>
        [DataMember(Name = "MobileNumber")]
        [DataType(DataType.PhoneNumber)]
        public string MobileNumber { get; set; }

        /// <summary>
        /// Gets or sets the work number.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        [DataMember(Name = "WorkNumber")]
        [DataType(DataType.PhoneNumber)]
        public string WorkNumber { get; set; }

        /// <summary>
        /// Gets or sets the home number.
        /// </summary>
        /// <value>
        /// The home number.
        /// </value>
        [DataMember(Name = "HomeNumber")]
        [DataType(DataType.PhoneNumber)]
        public string HomeNumber { get; set; }
    }
}