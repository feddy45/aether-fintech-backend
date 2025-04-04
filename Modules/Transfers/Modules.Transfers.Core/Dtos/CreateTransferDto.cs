namespace Modules.Transfers.Core.Dtos;

public record CreateTransferDto(string Iban, string Beneficiary, float Amount, string Description, Guid CardId);