using LanguageExt;
using Modules.Contacts.Core.Dependencies;
using Modules.Contacts.Core.Dtos;
using Modules.Shared.Results;

namespace Modules.Contacts.Core.Concretes;

internal class ContactsRead(IContactsReader contactsReader) : IContactsRead
{
    public async Task<Either<ErrorResult, ContactListDto>> Read()
    {
        try
        {
            return await contactsReader.Read();
        }
        catch (Exception e)
        {
            return new GenericErrorResult(e.Message);
        }
    }
}