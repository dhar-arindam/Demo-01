namespace Demo01.Api.Model
{
    using System;

    using Demo01.Model;

    /// <summary>
    /// Patient model class
    /// </summary>
    /// <seealso cref="Demo01.Api.Model.BaseModel" />
    public class Patient : BaseModel
    {
        /// <summary>Initializes a new instance of the <see cref="Patient"/> class.</summary>
        public Patient()
        {
        }

        /// <summary>
        /// Gets or sets the patient identifier.
        /// </summary>
        /// <value>
        /// The patient identifier.
        /// </value>
        public int? PatientId { get; set; }

        /// <summary>
        /// Gets or sets the forename.
        /// </summary>
        /// <value>
        /// The forename.
        /// </value>
        public string Forename { get; set; }

        /// <summary>
        /// Gets or sets the surname.
        /// </summary>
        /// <value>
        /// The surname.
        /// </value>
        public string Surname { get; set; }

        /// <summary>
        /// Gets or sets the date of birth.
        /// </summary>
        /// <value>
        /// The date of birth.
        /// </value>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Patient"/> is gender.
        /// </summary>
        /// <value>
        ///   <c>true</c> if gender; otherwise, <c>false</c>.
        /// </value>
        public bool Gender { get; set; }

        /// <summary>
        /// Gets or sets the telephone number.
        /// </summary>
        /// <value>
        /// The telephone number.
        /// </value>
        public string TelephoneNumber { get; set; }
    }
}