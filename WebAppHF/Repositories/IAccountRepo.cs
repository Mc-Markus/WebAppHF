using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppHF.Models;

namespace WebAppHF.Repositories
{
    interface IAccountRepo
    {
        AdminAccount GetAccount(string userName, string password);
    }
}
