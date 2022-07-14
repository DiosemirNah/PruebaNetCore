using AddressBookWebApi.Model;
using System.Collections.Generic;

namespace AddressBookWebApi.IData
{
    public interface IContactoData
    {
        List<ContactoModel> GetContacto(string id);
        List<ContactoModel> GetContactos(string phrase);
        bool DeleteContacto(string contact_id);
    }
}
