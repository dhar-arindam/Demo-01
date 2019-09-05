
namespace Demo01.Api.Test.Mock
{
    using Demo01.Api.Test.Extension;
    using Demo01.Api.UtilDbContext;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// DbContextMocker class
    /// </summary>
    public static class DbContextMocker
    {
        /// <summary>
        /// Gets the patient database context.
        /// </summary>
        /// <param name="dbName">Name of the database.</param>
        /// <returns></returns>
        public static PatientDbContext GetPatientDbContext(string dbName)
        {
            // Create options for DbContext instance
            var options = new DbContextOptionsBuilder<PatientDbContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            // Create instance of DbContext
            var dbContext = new PatientDbContext(options);

            // Add entities in memory
            dbContext.Seed();

            return dbContext;
        }
    }
}