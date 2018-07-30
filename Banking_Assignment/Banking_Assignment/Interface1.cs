using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Assignment
{
    interface IBanking
    {
        void Add(int accountId, string accountName, string accountType);
        void DisplayAccountDetails();
        void SearchByAccountId(int id);
        void Deposit(int id, int money);
        void Withdrawl(int id, int money);
        void CalculateInterest(int id);
    }
}
