using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modules.Shared.Results;
using Modules.Transfers.Core;
using Modules.Transfers.Core.Dtos;

namespace Modules.Transfers.Api.Handlers;

internal static class TransfersHandler
{
    public static async Task<IResult> CreateTransfer([FromServices] ITransferWrite transferWrite,
        [FromBody] CreateTransferDto request,
        CancellationToken cancellationToken)
    {
        var result = await transferWrite.Write(request);

        return result.Match(Results.Ok,
            err => err switch
            {
                GenericErrorResult error => Results.BadRequest(error.Message),
                _ => Results.BadRequest()
            });
    }

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