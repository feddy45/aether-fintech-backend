using Modules.Contacts.Core.Dtos;

namespace Modules.Contacts.Core.Dependencies;

public interface IContactsReader
{
    Task<ContactListDto> Read(Guid userId);
}