using LanguageExt;
using Modules.Contacts.Core.Dependencies;
using Modules.Contacts.Core.Dtos;
using Modules.Shared.Results;

namespace Modules.Contacts.Core.Concretes;

internal class ContactsRead(IContactsReader contactsReader) : IContactsRead
{
    public async Task<Either<ErrorResult, ContactListDto>> Read(Guid userId)
    {
        try
        {
            return await contactsReader.Read(userId);
        }
        catch (Exception e)
        {
            return new GenericErrorResult(e.Message);
        }
    }
}