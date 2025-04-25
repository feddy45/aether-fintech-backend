namespace Modules.Transfers.Core.Dtos;

public record CreateBankTransferDto(
    string Iban,
    string Beneficiary,
    decimal Amount,
    string Description,
    Guid BankAccountId);