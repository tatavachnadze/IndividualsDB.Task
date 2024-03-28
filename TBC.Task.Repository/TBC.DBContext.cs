using Microsoft.EntityFrameworkCore;
using TBC.DTO;

namespace TBC.Repository
{
    public class TbcDbContext : DbContext
    {
        public TbcDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // amas ratom vidzaxebt
            modelBuilder.Entity<Individual>().Property(a => a.FirstName).HasColumnType("nvarchar(30)").IsRequired();
            modelBuilder.Entity<Individual>().Property(a => a.LastName).HasColumnType("nvarchar(30)").IsRequired();
            modelBuilder.Entity<Individual>().Property(a => a.PhoneNumber).HasColumnType("nvarchar(20)").IsRequired();
            modelBuilder.Entity<Individual>().Property(a => a.HomeNumber).HasColumnType("nvarchar(20)").IsRequired(false);
            modelBuilder.Entity<Individual>().Property(a => a.OfficeNumber).HasColumnType("nvarchar(20)").IsRequired(false);
            modelBuilder.Entity<Individual>().Property(a => a.PersonalNumber).HasColumnType("nvarchar(11)").IsRequired();
            modelBuilder.Entity<Individual>().Property(a => a.CreateDate).HasColumnType("date").IsRequired();
            modelBuilder.Entity<Individual>().Property(a => a.IsDeleted).HasColumnType("bit").IsRequired();
            modelBuilder.Entity<Individual>().HasOne(u => u.City).WithMany(a => a.Individuals).IsRequired(true);

            modelBuilder.Entity<City>().Property(c => c.Name).HasColumnType("nvarchar(25)").IsRequired();
            modelBuilder.Entity<City>().HasIndex(c => c.Name).IsUnique(true);
            modelBuilder.Entity<City>().Property(c => c.IsDeleted).HasColumnType("bit");
            modelBuilder.Entity<City>().Property(c => c.CreateDate).HasColumnType("date");
            modelBuilder.Entity<City>().HasMany(c => c.Individuals).WithOne(c => c.City).IsRequired(false).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<IndividualRelations>().Property(r => r.RelationType).IsRequired();
            modelBuilder.Entity<IndividualRelations>().Property(a => a.CreateDate).HasColumnType("date").IsRequired();
            modelBuilder.Entity<IndividualRelations>().Property(a => a.IsDeleted).HasColumnType("bit").IsRequired();
            modelBuilder.Entity<IndividualRelations>().HasOne(r => r.FromIndividual).WithMany(c => c.FromRelations).HasForeignKey(r => r.FromId).IsRequired().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<IndividualRelations>().HasOne(r => r.ToIndividual).WithMany(c => c.ToRelations).HasForeignKey(r => r.ToId).IsRequired().OnDelete(DeleteBehavior.NoAction);
            
        }

        public DbSet<Individual> Individuals { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<IndividualRelations> Relations { get; set; }
    }
}
