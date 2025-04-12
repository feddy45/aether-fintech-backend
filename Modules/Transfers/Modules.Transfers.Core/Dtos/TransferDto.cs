namespace Modules.Transfers.Core.Dtos;

public record TransferDto(
    Guid Id,
    string Iban,
    string Beneficiary,
    float Amount,
    DateTime Date,
    string Description,
    Guid CardId);