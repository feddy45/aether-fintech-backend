using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modules.Shared.Results;
using Modules.Transfers.Core;

namespace Modules.Transfers.Api.Handlers;

internal static class TransfersHandler
{
    public static async Task<IResult> GetTransfers([FromServices] ITransfersRead transfersRead)
    {
        var result = await transfersRead.Read();

        return result.Match(Results.Ok,
            err => err switch
            {
                GenericErrorResult error => Results.BadRequest(error.Message),
                _ => Results.BadRequest()
            });
    }
}