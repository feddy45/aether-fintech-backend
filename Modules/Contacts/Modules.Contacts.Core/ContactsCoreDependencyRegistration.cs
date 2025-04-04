using Microsoft.Extensions.DependencyInjection;
using Modules.Contacts.Core.Concretes;
using Modules.Shared.DependencyInjection;

namespace Modules.Contacts.Core;

public class ContactsCoreDependencyRegistration : IModuleDependencyRegistration
{
    public void Execute(IServiceCollection services)
    {
        services.AddScoped<IContactsRead, ContactsRead>();
    }
}