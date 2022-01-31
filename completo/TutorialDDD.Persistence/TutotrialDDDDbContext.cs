using TutotrialDDD.Persistence.Model;
using DFlow.Persistence.EntityFramework.Model;
using Microsoft.EntityFrameworkCore;
using TutorialDDD.Persistence.ReadModel;

namespace TutotrialDDD.Persistence
{
    public class TutotrialDDDDbContext : AggregateDbContext
    {
        public TutotrialDDDDbContext(DbContextOptions<TutotrialDDDDbContext> options)
            : base(options)
        {
        }

        public DbSet<ProjectState> Projects { get; set; }
        public DbSet<ProjectProjection> ProjectsProjection { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProjectState>(
                b =>
                {
                    b.Property(e => e.Id).ValueGeneratedNever().IsRequired();
                    b.Property(e => e.Code).IsRequired();
                    b.Property(e => e.Name).IsRequired();
                    b.Property(e => e.Budget).IsRequired();
                    b.HasKey(e => e.Id);
                    b.Property(e => e.ClientId).IsRequired();
                    b.Property(e => e.StartDate).IsRequired();

                    b.Property(p => p.PersistenceId);
                    b.Property(q => q.IsDeleted);
                    b.HasQueryFilter(project => EF.Property<bool>(project, "IsDeleted") == false);
                    b.Property(e => e.CreateAt);
                    b.Property(e => e.RowVersion);
                });

            #region projection

            modelBuilder.Entity<ProjectProjection>(p =>
            {
                p.Property(pr => pr.Id).ValueGeneratedNever();
                p.HasKey(pr => pr.Id);
                p.Property(pr => pr.Name);
                p.Property(pr => pr.Code);
                p.Property(pr => pr.StartDate);
                p.Property(pr => pr.Budget);
                p.Property(pr => pr.ClientId);
                p.HasQueryFilter(proj => EF.Property<bool>(proj, "IsDeleted") == false);
            });

            #endregion
        }
    }
}