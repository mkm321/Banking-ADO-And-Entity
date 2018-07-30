using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace Banking_Assignment
{
    class AccountDbContext :DbContext
    {
        public AccountDbContext() : base("name=AccountContext")
        {

        }
        public DbSet<Account> SetAccount{ get; set; }
    }
}
