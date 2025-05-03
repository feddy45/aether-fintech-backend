using Microsoft.EntityFrameworkCore;
using Modules.Contacts.Core.Dependencies;
using Modules.Contacts.Core.Dtos;
using Modules.Contacts.DataAccess.DatabaseModels;

namespace Modules.Contacts.DataAccess;

internal class ContactsReader(ContactsDbContext dbContext) : IContactsReader
{
    public async Task<ContactListDto> Read(Guid userId)
    {
        var contacts = await dbContext.Contact
            .AsNoTracking()
            .Where(c => c.UserId == userId)
            .Select(contact => new ContactDto(
                contact.UserId,
                contact.FirstName,
                contact.LastName,
                contact.Iban
            ))
            .ToListAsync();

        return new ContactListDto(contacts);
    }
}