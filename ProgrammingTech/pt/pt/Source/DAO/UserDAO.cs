using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using pt.Source.DataModel;

namespace pt.Source.DAO
{
    public class UserDao
    {
        private DataProvider<List<UserDataModel>> provider;
        private string storagePath;
        private List<UserDataModel> users;

        public UserDao(string storage)
        {
            storagePath = storage;
            provider = new DataProvider<List<UserDataModel>>(storage);
            Deserialize();
        }

        private void Deserialize()
        {
            if (users == null)
            {
                users = new List<UserDataModel>();
            }
            users = provider.Deserialize();
        }

        private void Serialize()
        {
            if (users == null)
            {
                throw new Exception("List of user is null.");
            }
            provider.Serialize(users);
        }

        public int GetEmailContainsSymbol(char symbol)
        {
            return (from user in users
                    where user.Email.StartsWith(symbol.ToString())
                    select user).Count();
        }

        public List<Data> GetEmailContainsSymbol()
        {
            return users.GroupBy(user => user.LastName[0]).Select(user => new Data()
            {
                Symbol = user.Key,
                Count = user.Count()
            }
            ).OrderByDescending(user => user.Count).Take(3).ToList();
        }

        ~UserDao()
        {
            try
            {
                Serialize();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error save data. Message = {1}", ex.Message);
            }
        }
    }

    public class Data
    {
        public char Symbol { get; set; }
        public int Count { get; set; }

    }
}
