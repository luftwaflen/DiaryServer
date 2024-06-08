using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class DiaryDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Diary> Diaries { get; set; }
    public DbSet<DiaryNote> DiaryNotes { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Family> Families { get; set; }
    public DbSet<FamilyRole> FamilyRoles { get; set; }

    public DiaryDbContext(DbContextOptions<DiaryDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Doctor>()
            .HasMany(d => d.Recipes)
            .WithOne(r => r.Doctor)
            .HasForeignKey(r => r.DoctorId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Patient>()
            .HasMany(p => p.Recipes)
            .WithOne(r => r.Patient)
            .HasForeignKey(r => r.PatientId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}