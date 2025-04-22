namespace Modules.Transfers.Core.Dtos;

public record CreateTransferDto(string Iban, string Beneficiary, decimal Amount, string Description, Guid CardId);