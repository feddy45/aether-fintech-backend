using Modules.Contacts.Core.Dependencies;
using Modules.Contacts.Core.Dtos;

namespace Modules.Contacts.DataAccess;

internal class ContactsReader : IContactsReader
{
    public Task<ContactListDto> Read()
    {
        return Task.FromResult(new ContactListDto([
            new ContactDto(new Guid("cf9e6485-db96-4942-a07c-65f106d47542"), "Federico", "Ghezzo", "IT1289o7oguih1")
        ]));
    }
}