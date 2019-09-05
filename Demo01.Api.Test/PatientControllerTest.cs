
namespace Demo01.Api.Test
{
    using Demo_01.Api.Controllers;
    using Demo01.Api.Test.Mock;
    using Demo01.Model;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using System;
    using System.Threading.Tasks;
    using Xunit;

    /// <summary>
    /// PatientControllerTest class
    /// </summary>
    public class PatientControllerTest
    {
        /// <summary>
        /// Tests the get patient details asynchronous.
        /// </summary>
        [Fact]
        public async Task TestGetPatientDetailsAsync()
        {
            var dbContext = DbContextMocker.GetPatientDbContext(nameof(TestGetPatientDetailsAsync));
            var controller = new PatientsController(null, dbContext);

            var value = await controller.GetDetailsAsync();

            dbContext.Dispose();

            Assert.False(value.DidError);
        }

        /// <summary>
        /// Tests the post patient details asynchronous.
        /// </summary>
        [Fact]
        public async Task TestPostPatientDetailsAsync()
        {
            var dbContext = DbContextMocker.GetPatientDbContext(nameof(TestPostPatientDetailsAsync));
            var controller = new PatientsController(null, dbContext);

            var data = new PatientModel
            {
                Forename = $"User09",
                Surname = $"Surname09",
                DateOfBirth = Convert.ToDateTime("25/12/2010"),
                Gender = true,
                TelephoneNumber = JsonConvert.DeserializeObject<PatientTelephoneNumber>("{\"MobileNumber\" : \"123456789\", \"WorkNumber\" : \"1234567\" }")
            };

            // Act
            var response = await controller.PostRecordAsync(data) as ObjectResult;
            var value = response.Value as ISingleResponse<PatientModel>;

            dbContext.Dispose();

            // Assert
            Assert.False(value.DidError);
        }
    }
}