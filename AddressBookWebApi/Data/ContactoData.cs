using AddressBookWebApi.IData;
using AddressBookWebApi.IServices;
using AddressBookWebApi.Model;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace AddressBookWebApi.Data
{
    public class ContactoData : IContactoData
    {
        private readonly IDataBaseService _dataBase;
        public ContactoData(IDataBaseService dataBase)
        {
            _dataBase = dataBase;
        }

        public List<ContactoModel> GetContacto(string id)
        {
            var data = _dataBase.GetDatos();
            var result = data.Where(x => x.id == id).Select(x => new ContactoModel
            {
                id = x.id,
                name = x.name,
                phone = x.phone,
                addressLines = x.addressLines
            }).ToList();
            return result;
        }

        public List<ContactoModel> GetContactos(string phrase)
        {
            var data = _dataBase.GetDatos();
            var result = data.Where(x => x.name.ToLower().Contains(phrase.ToLower())).OrderBy(c => c.name).Select(x => new ContactoModel
            {
                id = x.id,
                name = x.name,
                phone = x.phone,
                addressLines = x.addressLines
            }).ToList();
            return result;
        }

        public bool DeleteContacto(string contact_id)
        {
            var data = _dataBase.GetDatos();
            var result = data.RemoveAll(x => x.id == contact_id);
            if(result == 0)
            {
                return false;
            }
            var json = JsonConvert.SerializeObject(data);
            var isDelete =_dataBase.DeleteDatos(json);
            if(!isDelete)
            {
                return false;
            }
            return true;
        }

    }
}
