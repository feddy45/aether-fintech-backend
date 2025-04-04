using Microsoft.Extensions.DependencyInjection;
using Modules.Contacts.Core.Dependencies;
using Modules.Shared.DependencyInjection;

namespace Modules.Contacts.DataAccess;

public class ContactsDataAccessDependencyRegistration : IModuleDependencyRegistration
{
    public void Execute(IServiceCollection services)
    {
        services.AddScoped<IContactsReader, ContactsReader>();
    }
}