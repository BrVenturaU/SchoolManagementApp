using SchoolManagementApp.Shared.Abstractions;

namespace SchoolManagementApp.Web.Extensions;

public static class AppServicesExtensions
{
    public static WebApplicationBuilder ConfigureModule(this WebApplicationBuilder builder, IModule module)
    {

        module.AddModule(builder.Services, builder.Configuration);
        return builder;
    }
}
