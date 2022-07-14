using AddressBookWebApi.Model;
using System.Collections.Generic;

namespace AddressBookWebApi.IData
{
    public interface IDataBaseData
    {
        List<ContactoModel> GetDatos();
        bool DeleteDatos(string json);
    }
}
