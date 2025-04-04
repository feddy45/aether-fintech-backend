using LanguageExt;
using Modules.Contacts.Core.Dtos;
using Modules.Shared.Results;

namespace Modules.Contacts.Core;

public interface IContactsRead
{
    Task<Either<ErrorResult, ContactListDto>> Read();
}