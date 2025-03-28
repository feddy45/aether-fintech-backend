using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Modules.Shared.DependencyInjection;
using Microsoft.AspNetCore.Routing;
using Modules.Cards.Api.Handlers;
using Modules.Cards.Core.Dtos;

namespace Modules.Cards.Api;

public class CardsEndpointsMapper : IEndpointMapper
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var cardsEndpoints = endpoints.MapGroup("cards");

        cardsEndpoints.MapGet("", CardsHandler.GetCards)
            .Produces<CardListDto>();


        return cardsEndpoints;
    }
}