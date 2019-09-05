namespace Demo01.Api.Helper
{
    using System.Linq;
    using System.Threading.Tasks;

    using Demo01.Api.Model;
    using Demo01.Api.UtilDbContext;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Patient DbContext Extension class
    /// </summary>
    public static class PatientDbContextExtension
    {
        /// <summary>
        /// Gets the stock items.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <returns></returns>
        public static IQueryable<Patient> GetPatientDetails(this PatientDbContext dbContext, int pageSize = 10, int pageNumber = 1)
        {
            // Get query from DbSet
            var query = dbContext.PatientDetails.AsQueryable();

            return query;
        }

        /// <summary>
        /// Gets the patient detail by name asynchronous.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public static async Task<Patient> GetPatientDetailByNameAsync(this PatientDbContext dbContext, Patient entity)
            => await dbContext.PatientDetails.FirstOrDefaultAsync(item => item.Forename == entity.Forename && item.Surname == entity.Surname);
    }

    /// <summary>
    /// \extension class for IQueryable class
    /// </summary>
    public static class IQueryableExtensions
    {
        /// <summary>
        /// Pagings the specified page size.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="query">The query.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <returns></returns>
        public static IQueryable<TModel> Paging<TModel>(this IQueryable<TModel> query, int pageSize = 0, int pageNumber = 0) where TModel : class
        {
            return pageSize > 0 && pageNumber > 0 ? query.Skip((pageNumber - 1) * pageSize).Take(pageSize) : query;
        }
    }
}