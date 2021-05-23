using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace pt.Source.DataModel
{
    [DataContract]
    public class UsersDataModel
    {
        [DataMember]
        public List<UserDataModel> List {get; set;}
    }
}
