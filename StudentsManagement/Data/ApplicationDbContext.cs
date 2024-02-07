using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentsManagement.Client.Models;

namespace StudentsManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,ApplicationRole,string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<SystemCode> SystemCodes { get; set; }
        public DbSet<SystemCodeDetail> SystemCodeDetails { get; set; }

        public DbSet<Parent> Parents { get; set; }

        public DbSet<Subject> Subjects { get; set; }    
        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<BookIssuance> BookIssuanceHistory { get; set; }

        public DbSet<AcademicYear> AcademicYears { get; set; }

        public DbSet<Hostel> Hostels { get; set; }
        public DbSet<HostelRoom> HostelRooms { get; set; }
        public  DbSet<Grade> Grades { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(builder);

            builder.Entity<Student>()
             .HasOne(f => f.Country)
             .WithMany()
             .HasForeignKey(f => f.CountryId)
             .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ApplicationRole>()
             .HasOne(f => f.CreatedBy)
             .WithMany()
             .HasForeignKey(f => f.CreatedById)
             .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ApplicationUser>()
           .HasOne(f => f.Gender)
           .WithMany()
           .HasForeignKey(f => f.GenderId)
           .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<ApplicationRole>()
            .HasOne(f => f.ReviewedBy)
            .WithMany()
            .HasForeignKey(f => f.ReviewedById)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
