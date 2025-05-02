using Modules.BankAccounts.Core.Enums;

namespace Modules.BankAccounts.Core.Extensions;

public static class TransactionTypeExtensions
{
    public static string ToDatabaseValue(this TransactionType type)
    {
        return type.ToString().ToLowerInvariant();
    }

    public static TransactionType FromDatabaseValue(string value)
    {
        return Enum.Parse<TransactionType>(value, true);
    }
}