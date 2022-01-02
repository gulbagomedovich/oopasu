using Microsoft.EntityFrameworkCore;
using OOPASU.Domain;

namespace OOPASU.Infrastructure
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<Class> Classes { get; set; }
        public DbSet<ClassRoom> ClassRooms { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Visit> Visits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>()
                .HasOne(c => c.ClassRoom)
                .WithMany(cr => cr.Classes)
                .HasForeignKey(c => c.ClassRoomId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Class>()
                .HasOne(c => c.Teacher)
                .WithMany(t => t.Classes)
                .HasForeignKey(c => c.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Class>()
                .HasOne(c => c.Discipline)
                .WithMany(d => d.Classes)
                .HasForeignKey(c => c.DisciplineId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Class>()
                .HasOne(c => c.Group)
                .WithMany(g => g.Classes)
                .HasForeignKey(c => c.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Class>()
            .HasMany(c => c.Students)
            .WithMany(s => s.Classes)
            .UsingEntity<Visit>(
                j => j
                    .HasOne(v => v.Student)
                    .WithMany(s => s.Visits)
                    .HasForeignKey(v => v.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull),
                j => j
                    .HasOne(v => v.Class)
                    .WithMany(c => c.Visits)
                    .HasForeignKey(v => v.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull),
                j =>
                {
                    j.Property(v => v.Status);
                    j.HasKey(v => new { v.ClassId, v.StudentId });
                });
        }
    }
}
