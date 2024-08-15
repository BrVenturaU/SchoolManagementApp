using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SchoolManagementApp.Shared.Abstractions;

public interface IModule
{
    IServiceCollection AddModule(IServiceCollection services, IConfiguration configuration);
}
