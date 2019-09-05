namespace Demo01.Api.UtilDbContext
{
    using Demo01.Api.EntityConfig;
    using Demo01.Api.Model;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Patient Db context class
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class PatientDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PatientDbContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public PatientDbContext(DbContextOptions<PatientDbContext> options) : base(options) { }

        /// <summary>
        /// Override this method to further configure the model that was discovered by convention from the entity types
        /// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
        /// and re-used for subsequent instances of your derived context.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
        /// define extension methods on this object that allow you to configure aspects of the model that are specific
        /// to a given database.</param>
        /// <remarks>
        /// If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
        /// then this method will not be run.
        /// </remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                 .ApplyConfiguration(new PatientEntityConfig());

            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Gets or sets the patient details.
        /// </summary>
        /// <value>
        /// The patient details.
        /// </value>
        public DbSet<Patient> PatientDetails { get; set; }
    }
}