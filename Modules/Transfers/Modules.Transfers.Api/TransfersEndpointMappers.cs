using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Modules.Shared.DependencyInjection;
using Modules.Transfers.Api.Handlers;
using Modules.Transfers.Core.Dtos;

namespace Modules.Transfers.Api;

public class TransfersEndpointsMapper : IEndpointMapper
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var transfersEndpoints = endpoints.MapGroup("transfers");

        transfersEndpoints.MapPost("", TransfersHandler.CreateTransfer)
            .Produces<CreatedTransferDto>();

        return transfersEndpoints;
    }
}