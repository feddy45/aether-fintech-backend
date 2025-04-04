using Modules.Contacts.Core.Dependencies;
using Modules.Contacts.Core.Dtos;

namespace Modules.Contacts.DataAccess;

internal class ContactsReader : IContactsReader
{
    public Task<ContactListDto> Read()
    {
        return Task.FromResult(new ContactListDto([
            new ContactDto(new Guid("cf9e6485-db96-4942-a07c-65f106d47542"), "Federico", "Ghezzo",
                "IT60X0542811101000000123456"),
            new ContactDto(new Guid("cf9e6485-db96-4942-a07c-65f106d47542"), "Pluto", "Pippo",
                "IT60X0542811101000000123458"),
            new ContactDto(new Guid("cf9e6485-db96-4942-a07c-65f106d47542"), "Mario", "Rossi",
                "IT60X0542811101000000123459"),
            new ContactDto(new Guid("cf9e6485-db96-4942-a07c-65f106d47542"), "Luigi", "Verdi",
                "IT60X0542811101000000123462"),
            new ContactDto(new Guid("cf9e6485-db96-4942-a07c-65f106d47542"), "Giovanna", "Bianca",
                "IT60X0542811101000000123466")
        ]));
    }
}