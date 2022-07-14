using AddressBookWebApi.Model;
using System.Collections.Generic;

namespace AddressBookWebApi.IServices
{
    public interface IDataBaseService
    {
        List<ContactoModel> GetDatos();
        bool DeleteDatos(string json);
    }
}
