using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class DiaryDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Diary> Diaries { get; set; }
    public DbSet<DiaryNote> DiaryNotes { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Family> Families { get; set; }
    public DbSet<FamilyRole> FamilyRoles { get; set; }

    public DiaryDbContext(DbContextOptions<DiaryDbContext> options) : base(options)
    {

    }
}