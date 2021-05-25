using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace pt.Source.DAO
{
    public class DataProvider<DataModel>
    {
        private string path;
        private DataContractJsonSerializer marshaller = new DataContractJsonSerializer(
                typeof(DataModel)
        );

        public DataProvider(string path)
        {
            this.path = path;
        }

        private string GetRightPathString(string path)
        {
            if (!path.Equals(""))
            {
                return path;
            }
            return this.path;
        }

        public DataModel Deserialize(string path = "")
        {
            DataModel deserializeContent;
            FileStream file = new FileStream(GetRightPathString(path), FileMode.Open);
            deserializeContent = (DataModel)marshaller.ReadObject(file);
            file.Close();
            return deserializeContent;
        }

        public void Serialize(DataModel serializeContent, string path = "")
        {
            FileStream file = new FileStream(GetRightPathString(path), FileMode.OpenOrCreate);
            file.SetLength(0);
            marshaller.WriteObject(file, serializeContent);
            file.Close();
            return;
        }
        
    }
}
