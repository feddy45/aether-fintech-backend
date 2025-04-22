namespace Modules.Transfers.Core.Dtos;

public record TransferDto(
    Guid Id,
    string Iban,
    string Beneficiary,
    decimal Amount,
    DateTime Date,
    string Description,
    Guid CardId);