﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Modules.Cards.Api.Handlers;
using Modules.Cards.Core.Dtos;
using Modules.Shared.DependencyInjection;

namespace Modules.Cards.Api;

public class CardsEndpointsMapper : IEndpointMapper
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var cardsEndpoints = endpoints.MapGroup("cards").WithTags("Cards").RequireAuthorization();

        cardsEndpoints.MapGet("", CardsHandler.GetCards)
            .Produces<CardListDto>();

        return cardsEndpoints;
    }
}