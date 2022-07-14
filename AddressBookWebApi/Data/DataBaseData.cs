using AddressBookWebApi.Model;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;
using AddressBookWebApi.IData;
using System.IO;
using System;
using System.Reflection;

namespace AddressBookWebApi.Data
{
    public class DataBaseData : IDataBaseData
    {
        public List<ContactoModel> GetDatos()
        {
            List<ContactoModel> doc = null;
            var file_path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Script\fakedatabase.js");

            string file_data = System.IO.File.ReadAllText(file_path, Encoding.UTF8);
            //Se podria agregar un logger en caso que no tenga valor.

            //deserialize del json
            doc = JsonConvert.DeserializeObject<List<ContactoModel>>(file_data);
            return doc;
        }

        public bool DeleteDatos(string json)
        {
            try
            {
                var file_path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Script\fakedatabase.js");
                System.IO.File.WriteAllText(file_path, json);
                FileStream obj = new FileStream(file_path, FileMode.Append);
                obj.Close();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }

        }
    }
}
