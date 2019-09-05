namespace Demo01.Api.EntityConfig
{
    using System;

    using Demo01.Api.Model;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// PatientEntityConfig class
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{Model.Patient}" />
    public class PatientEntityConfig : IEntityTypeConfiguration<Patient>
    {
        /// <summary>
        /// Configures the entity of type <typeparamref name="TEntity" />.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("PatientDetail");
            builder.HasKey(b => b.PatientId);

            builder.Property(b => b.Forename).HasColumnType("nvarchar(50)").IsRequired().HasMaxLength(50);
            builder.Property(b => b.Surname).HasColumnType("nvarchar(50)").IsRequired().HasMaxLength(50);
            builder.Property(b => b.Gender).HasColumnType("bit)").IsRequired().HasDefaultValue(false);
            builder.Property(b => b.DateOfBirth).HasColumnType("date");
            builder.Property(b => b.TelephoneNumber).HasColumnType("nvarchar(4000)");

            builder.Property(b => b.CreatedOn).HasColumnType("datetime").HasDefaultValue(DateTime.UtcNow);
            builder.Property(b => b.CreatedBy).HasColumnType("nvarchar(50)").HasDefaultValue("System");
            builder.Property(b => b.ModifiedOn).HasColumnType("datetime");
            builder.Property(b => b.ModifiedBy).HasColumnType("nvarchar(50)");

            builder.Property(b => b.PatientId).HasColumnType("int").IsRequired().HasDefaultValueSql("NEXT VALUE FOR [PatientDetail].[PatientId]");
        }
    }
}