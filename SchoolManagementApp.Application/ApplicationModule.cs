using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolManagementApp.Application.Enrollments;
using SchoolManagementApp.Application.Grades;
using SchoolManagementApp.Application.Students;
using SchoolManagementApp.Application.Teachers;
using SchoolManagementApp.Shared.Abstractions;

namespace SchoolManagementApp.Application
{
    public class ApplicationModule : IModule
    {
        public IServiceCollection AddModule(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<ITeacherService, TeacherService>();
            services.AddTransient<IGradeService, GradeService>();
            services.AddTransient<IEnrollmentService, EnrollmentService>();

            return services;
        }
    }
}
