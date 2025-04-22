using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Modules.Mediator.Api.Handlers;
using Modules.Shared.DependencyInjection;
using Modules.Transfers.Core.Dtos;

namespace Modules.Mediator.Api;

public class MediatorEndpointsMapper : IEndpointMapper
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var transfersEndpoints = endpoints.MapGroup("transfers").WithTags("Transfers").RequireAuthorization();

        transfersEndpoints.MapPost("", MediatorTransfersHandler.CreateTransfer)
            .Produces<CreatedTransferDto>();

        return transfersEndpoints;
    }
}