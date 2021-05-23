using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace pt.Source.DataModel
{
    [DataContract]
    public class UserDataModel
    {
        [DataMember(Name = "id")]
        public int ID { get; set; }

        [DataMember(Name = "last_name")]
        public string LastName { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }
    }
}
