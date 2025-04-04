using Modules.Contacts.Api;
using Modules.Contacts.Core;
using Modules.Contacts.DataAccess;
using Modules.Shared.DependencyInjection;

namespace Web.Api.Modules;

public class ContactsModule : Module
{
    protected override IModuleDependencyRegistration[] DependencyRegistrations =>
    [
        new ContactsCoreDependencyRegistration(),
        new ContactsDataAccessDependencyRegistration()
    ];

    protected override IEndpointMapper[] EndpointMappers =>
    [
        new ContactsEndpointsMapper()
    ];
}