using AddressBookWebApi.IData;
using AddressBookWebApi.IServices;
using AddressBookWebApi.Model;
using System.Collections.Generic;

namespace AddressBookWebApi.Services
{
    public class ContactoService : IContactoService
    {
        private readonly IContactoData _contactoData;
        public ContactoService(IContactoData contactoData)
        {
            _contactoData = contactoData;  
        }

        public List<ContactoModel> GetContacto(string id)
        {
            return _contactoData.GetContacto(id);
        }

        public List<ContactoModel> GetContactos(string phrase)
        {
            return _contactoData.GetContactos(phrase);
        }

        public bool DeleteContacto(string contact_id)
        {
            return _contactoData.DeleteContacto(contact_id);
        }

    }
}
