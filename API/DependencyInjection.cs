using Domain.Interfaces.Repositories;
using Infrastructure.Repositories;

namespace API;

public static class DependencyInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPatientRepository, PatientRepository>();
        services.AddScoped<IDiaryRepository, DiaryRepository>();
        services.AddScoped<IDiaryNoteRepository, DiaryNoteRepository>();
        services.AddScoped<IFamilyRepository, FamilyRepository>();
        services.AddScoped<IFamilyRoleRepository, FamilyRoleRepository>();
        services.AddScoped<IUserRoleRepository, UserRoleRepository>();
        services.AddScoped<IDoctorRepository, DoctorRepository>();
        services.AddScoped<IRecipeRepository, RecipeRepository>();

        return services;
    }
}