namespace Demo01.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    /// <summary>
    /// Patient model class
    /// </summary>
    /// <seealso cref="Demo01.Model.BaseModel" />
    [DataContract]
    [XmlRoot("PatientModel")]
    [Serializable]
    public class PatientModel : BaseModel
    {
        /// <summary>Initializes a new instance of the <see cref="Patient"/> class.</summary>
        public PatientModel()
        {
            TelephoneNumber = new PatientTelephoneNumber();
        }

        /// <summary>
        /// Gets or sets the patient identifier.
        /// </summary>
        /// <value>
        /// The patient identifier.
        /// </value>
        [Key]
        [DataMember(Name = "PatientId")]
        [XmlElement(ElementName = "PatientId")]
        public int? PatientId { get; set; }

        /// <summary>
        /// Gets or sets the forename.
        /// </summary>
        /// <value>
        /// The forename.
        /// </value>
        [Required(ErrorMessage = "Please enter the Forename")]
        [MinLength(3, ErrorMessage = "Enter minimum 3 characters")]
        [MaxLength(50, ErrorMessage = "Forename cannot be more than 50 characters")]
        [StringLength(50, MinimumLength = 3)]
        [DataMember(Name = "Forename")]
        [XmlElement(ElementName = "Forename")]
        public string Forename { get; set; }

        /// <summary>
        /// Gets or sets the surname.
        /// </summary>
        /// <value>
        /// The surname.
        /// </value>
        [Required(ErrorMessage = "Please enter the Surname")]
        [MinLength(2, ErrorMessage = "Enter minimum 2 characters")]
        [MaxLength(50, ErrorMessage = "Surname cannot be more than 50 characters")]
        [StringLength(50, MinimumLength = 2)]
        [DataMember(Name = "Surname")]
        [XmlElement(ElementName = "Surname")]
        public string Surname { get; set; }

        /// <summary>
        /// Gets or sets the date of birth.
        /// </summary>
        /// <value>
        /// The date of birth.
        /// </value>
        [DataMember(Name = "DateOfBirth")]
        [DataType(DataType.Date)]
        ////[RegularExpression(@"(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$", ErrorMessage = "Invalid date format.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [XmlElement(ElementName = "DateOfBirth")]
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Patient"/> is gender.
        /// </summary>
        /// <value>
        ///   <c>true</c> if gender; otherwise, <c>false</c>.
        /// </value>
        [DataMember(Name = "Gender")]
        [XmlElement(ElementName = "Gender")]
        [Required]
        public bool Gender { get; set; }

        /// <summary>
        /// Gets or sets the telephone number.
        /// </summary>
        /// <value>
        /// The telephone number.
        /// </value>
        [DataMember(Name = "TelephoneNumber")]
        [XmlElement(ElementName = "TelephoneNumber")]
        public PatientTelephoneNumber TelephoneNumber { get; set; }
    }
}