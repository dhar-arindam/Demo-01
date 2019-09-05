namespace Demo_01.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Demo01.Api.Helper;
    using Demo01.Api.Model;
    using Demo01.Api.UtilDbContext;
    using Demo01.Model;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;

    using Newtonsoft.Json;

    /// <summary>
    /// PatientsController class
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        /// <summary>
        /// The logger
        /// </summary>
        protected readonly ILogger Logger;

        /// <summary>
        /// The database context
        /// </summary>
        protected readonly PatientDbContext DbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="PatientsController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="dbContext">The database context.</param>
        public PatientsController(ILogger<PatientsController> logger, PatientDbContext dbContext)
        {
            Logger = logger;
            DbContext = dbContext;
        }

        // GET api/values
        /// <summary>
        /// Gets the details asynchronous.
        /// </summary>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <returns></returns>
        [HttpGet("Data")]
        ////[Produces("application/xml")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<PagedResponse<PatientModel>> GetDetailsAsync(int pageSize = 10, int pageNumber = 1)
        {
            Logger?.LogDebug("'{0}' has been invoked", nameof(GetDetailsAsync));

            var response = new PagedResponse<PatientModel>();
            List<PatientModel> patientData = null;
            try
            {
                var query = DbContext.GetPatientDetails();

                // Set paging values
                response.PageSize = pageSize;
                response.PageNumber = pageNumber;

                // Get the total rows
                response.ItemsCount = await query.CountAsync();

                // Get the specific page from database
                var temp = await query.Paging(pageSize, pageNumber).ToListAsync();
                patientData = temp.Select(t => new PatientModel
                {
                    Forename = t.Forename,
                    Surname = t.Surname,
                    DateOfBirth = t.DateOfBirth,
                    Gender = t.Gender,
                    PatientId = t.PatientId,
                    TelephoneNumber = !string.IsNullOrEmpty(t.TelephoneNumber) ? JsonConvert.DeserializeObject<PatientTelephoneNumber>(t.TelephoneNumber)
                    : new PatientTelephoneNumber()
                }).ToList();

                response.Model = patientData;

                response.Message = string.Format("Page {0} of {1}, Total of records: {2}.", pageNumber, response.PageCount, response.ItemsCount);

                Logger?.LogInformation("The records have been retrieved successfully.");
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";

                Logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(GetDetailsAsync), ex);
            }

            return response;
        }

        // POST api/values
        /// <summary>
        /// Posts the record asynchronous.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost("Data")]
        [ProducesResponseType(200)]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> PostRecordAsync([FromBody]PatientModel request)
        {
            Logger?.LogDebug("'{0}' has been invoked", nameof(PostRecordAsync));

            var response = new SingleResponse<PatientModel>();
            try
            {
                var existingEntity = await DbContext
                    .GetPatientDetailByNameAsync(new Patient { Forename = request.Forename, Surname = request.Surname });

                if (existingEntity != null)
                {
                    ModelState.AddModelError("PatientModel", "Patient name already exists");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                Patient entity = new Patient
                {
                    Forename = request.Forename,
                    Surname = request.Surname,
                    Gender = request.Gender,
                    DateOfBirth = request.DateOfBirth,
                    TelephoneNumber = request.TelephoneNumber != null ? JsonConvert.SerializeObject(request.TelephoneNumber) : null,
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = "System"
                };

                // Add entity to repository
                DbContext.Add(entity);

                // Save entity in database
                await DbContext.SaveChangesAsync();

                // Set the entity to response model
                response.Model = request;
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to support.";

                Logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(PostRecordAsync), ex);
            }

            return response.ToHttpResponse();
        }
    }
}