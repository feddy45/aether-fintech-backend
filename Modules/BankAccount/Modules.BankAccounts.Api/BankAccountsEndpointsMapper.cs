using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Modules.BankAccounts.Api.Handlers;
using Modules.BankAccounts.Core.Dtos;
using Modules.Shared.DependencyInjection;

namespace Modules.BankAccounts.Api;

public class BankAccountsEndpointsMapper : IEndpointMapper
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var cardsEndpoints = endpoints.MapGroup("bank-accounts").WithTags("Bank Accounts").RequireAuthorization();

        cardsEndpoints.MapGet("", BankAccountsHandler.GetBankAccounts)
            .Produces<BankAccountListDto>();

        return cardsEndpoints;
    }
}