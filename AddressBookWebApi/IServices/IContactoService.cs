using AddressBookWebApi.Model;
using System.Collections.Generic;

namespace AddressBookWebApi.IServices
{
    public interface IContactoService
    {
        List<ContactoModel> GetContacto(string id);
        List<ContactoModel> GetContactos(string phrase);
        bool DeleteContacto(string contact_id);
    }
}
