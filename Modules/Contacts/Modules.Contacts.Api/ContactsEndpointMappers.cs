using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Modules.Contacts.Api.Handlers;
using Modules.Contacts.Core.Dtos;
using Modules.Shared.DependencyInjection;

namespace Modules.Contacts.Api;

public class ContactsEndpointsMapper : IEndpointMapper
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var contactsEndpoints = endpoints.MapGroup("contacts").WithTags("Contacts");

        contactsEndpoints.MapGet("", ContactsHandler.GetContacts)
            .Produces<ContactListDto>();

        return contactsEndpoints;
    }
}