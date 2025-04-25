namespace Modules.Transfers.Core.Dtos;

public record CreateInternalTransferDto(
    Guid OriginBankAccountId,
    Guid DestinationBankAccountId,
    decimal Amount,
    string Description);