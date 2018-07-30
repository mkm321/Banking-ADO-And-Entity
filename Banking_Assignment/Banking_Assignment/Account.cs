using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseReference;
using System.Data.SqlClient;
namespace Banking_Assignment
{
    class Accounts : IBanking
    {
        static MyDatabase databasObject = new MyDatabase();
        public void Add(int accountId, string fullName, string accountType)
        {
            databasObject.InsertIntoDB(accountId, fullName, accountType);
            Console.WriteLine("Account Added");
            Console.WriteLine();
        }
        public void DisplayAccountDetails()
        {
            databasObject.SelectAll();
        }
        public void SearchByAccountId(int Accountid)
        {
            Console.WriteLine(databasObject.SelectRow(Accountid));
        }
        public void Deposit(int accountId,int Money)
        {
            databasObject.DepositAmount(accountId, Money);
            Console.WriteLine("Amount Added");
        }
        public void Withdrawl(int accountId,int Money)
        {
            databasObject.WithdrawAmount(accountId, Money);
            
        }
        public void CalculateInterest(int accountID)
        {
            float value = databasObject.CalcInterest(accountID);
            Console.WriteLine("Interest is :- "+value);
        }
    }
}
