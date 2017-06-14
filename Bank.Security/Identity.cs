using Bank.Data.Context;
using Bank.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Security
{
    public class Identity
    {
        public static bool Authenticate(User user, string password)
        {
            using (var context = new BankDatabaseContext())
            {
                User entity = context.Users.Where(u => u.Username == user.Username).First();
                if(CryptoEngine.Decrypt(entity.Password, true) == password)
                {
                    return true;
                }
                return false;
            }
        }

        public static User CreateUser(User user)
        {
            using (var context = new BankDatabaseContext())
            {
                user.Password = CryptoEngine.Encrypt(user.Password, true);
                context.Users.Add(user);
                context.SaveChanges();
                return user;
            }
        }
    }
}
