using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AddressBookWebApi.Model
{
    public class ContactoModel
    {
        /// <summary>
        /// Contacts id identity
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// Contacts name
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Contacts phone
        /// </summary>
        public string phone { get; set; }
        /// <summary>
        /// List contacts address
        /// </summary>
        public List<string> addressLines { get; set; }
    }

}
