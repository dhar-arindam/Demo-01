
namespace Demo01.Api.Test.Extension
{
    using System;

    using Demo01.Api.Model;
    using Demo01.Api.UtilDbContext;

    /// <summary>
    /// DbContextExtensions class
    /// </summary>
    public static class DbContextExtensions
    {
        /// <summary>
        /// Seeds the specified patient database context.
        /// </summary>
        /// <param name="patientDbContext">The patient database context.</param>
        public static void Seed(this PatientDbContext patientDbContext)
        {
            patientDbContext.Add(new Patient
            {
                Forename = $"Arindam",
                Surname = $"Dhar",
                DateOfBirth = Convert.ToDateTime("23/10/1985"),
                Gender = true,
                TelephoneNumber = "{\"WorkNumber\" : \"123456789\"}"
            });

            patientDbContext.Add(new Patient
            {
                Forename = $"User1",
                Surname = $"Surname1",
                DateOfBirth = Convert.ToDateTime("03/01/1989"),
                Gender = true,
                TelephoneNumber = "{\"MobileNumber\" : \"123456789\", \"WorkNumber\" : \"234567\" }"
            });

            patientDbContext.Add(new Patient
            {
                Forename = $"User2",
                Surname = $"Surname2",
                DateOfBirth = Convert.ToDateTime("03/01/1999"),
                Gender = false,
                TelephoneNumber = "{\"MobileNumber\" : \"123456789\", \"HomeNumber\" : \"9998645\"}"
            });

            patientDbContext.SaveChanges();
        }
    }
}