using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolManagementApp.Application.Students;
using SchoolManagementApp.Domain.Contracts;
using SchoolManagementApp.Infrastructure.Database;
using SchoolManagementApp.Infrastructure.Repositories;
using SchoolManagementApp.Shared.Abstractions;

namespace SchoolManagementApp.Infrastructure;

public class InfrastructureModule : IModule
{
    public IServiceCollection AddModule(IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddTransient<IStudentRepository, StudentRepository>();
        services.AddTransient<ITeacherRepository, TeacherRepository>();
        services.AddTransient<IGradeRepository, GradeRepository>();
        services.AddTransient<IEnrollmentRepository, EnrollmentRepository>();

        services.AddDbContext<SchoolDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("Default"), configs =>
            {
                configs.MigrationsAssembly(typeof(InfrastructureModule).Assembly.GetName().Name);
            });
        });


        return services;
    }
}
