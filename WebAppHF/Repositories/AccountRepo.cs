using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppHF.Models;

namespace WebAppHF.Repositories
{
    public class AccountRepo : IAccountRepo
    {
        public AdminAccount GetAccount(string userName, string password)
        {
            using (HFContext context = new HFContext())
            {
                AdminAccount account;

                account = context.AdminAccounts.SingleOrDefault(a => a.UserName == userName && a.Password == password);

                return account;
            }
        }
    }
}