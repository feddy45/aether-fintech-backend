using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Modules.Contacts.Core.Dependencies;
using Modules.Contacts.DataAccess.DatabaseModels;
using Modules.Shared.DependencyInjection;
using Modules.Shared.Models;

namespace Modules.Contacts.DataAccess;

public class ContactsDataAccessDependencyRegistration : IModuleDependencyRegistration
{
    public void Execute(IServiceCollection services)
    {
        services.AddDbContext<ContactsDbContext>((serviceProvider, options) =>
            {
                var connectionString = serviceProvider.GetRequiredService<ConnectionString>();
                options.UseNpgsql(connectionString.Value);
            }
        );
        services.AddScoped<IContactsReader, ContactsReader>();
    }
}