using DFlow.Persistence.EntityFramework.Model;
using Microsoft.EntityFrameworkCore;
using TutorialDDD.Persistence.ReadModel;
using TutotrialDDD.Persistence.Model;

namespace TutorialDDD.Persistence
{
    public class TutorialDddDbContext : AggregateDbContext
    {
        public TutorialDddDbContext(DbContextOptions<TutorialDddDbContext> options)
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
                    b.Property(e => e.Name).IsRequired();
                    b.HasKey(e => e.Id);

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
                p.HasQueryFilter(proj => EF.Property<bool>(proj, "IsDeleted") == false);
            });

            #endregion
        }
    }
}