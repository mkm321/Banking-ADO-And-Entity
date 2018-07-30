using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Assignment
{
    class EntityClass
    {
        public void PerformDatabaseOperations(int accountId, string name, string type)
        {
            using (var db = new AccountDbContext())
            {
                if (type == "savings")
                {
                    var person = new Account
                    {
                        Account_Number = accountId,
                        Full_Name = name,
                        Amount = 1000,
                        Account_Type = type
                    };
                    db.SetAccount.Add(person);
                    db.SaveChanges();
                }
                else
                {
                    var person = new Account
                    {
                        Account_Number = accountId,
                        Full_Name = name,
                        Amount = 0,
                        Account_Type = type
                    };
                    db.SetAccount.Add(person);
                    db.SaveChanges();
                }

            }
            Console.WriteLine();
        }
        public void PerformDatabasePrinting()
        {
            using (var db = new AccountDbContext())
            {
                var list = db.SetAccount.ToList();
                if (list != null)
                {
                    foreach (var accountInfo in list)
                    {
                        Console.Write("Account Number :- {0} \nFull Name :- {1} \nAmount :- {2} \nAccount Type  :- {3}", accountInfo.Account_Number, accountInfo.Full_Name, accountInfo.Amount, accountInfo.Account_Type);
                        Console.WriteLine();
                        Console.WriteLine("-------------------------------------------------------------------------------------");
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }
            }
        }
        public void PerformeDatabasePrint(int id)
        {
            using (var db = new AccountDbContext())
            {
                var accountDetail = db.SetAccount.Find(id);
                if (accountDetail != null)
                {
                    string output = "Account Number :- ";
                    output += accountDetail.Account_Number;
                    output += "\n Full Name is :- ";
                    output += accountDetail.Full_Name;
                    output += "\n Amount is :- ";
                    output += accountDetail.Amount;
                    output += "\n Account Type is :- ";
                    output += accountDetail.Account_Type;
                    Console.WriteLine(output);
                    Console.WriteLine();
                }
            }
        }
        public void PerformDatabaseUpdate(int id, int money)
        {
            using (var db = new AccountDbContext())
            {
                var entity = db.SetAccount.Find(id);
                if (entity != null)
                {
                    entity.Amount = entity.Amount + money;
                    db.SaveChanges();
                }
            }
            Console.WriteLine();
            Console.WriteLine("Amount Deposited");
            Console.WriteLine();
        }
        public  void PerformDatabaseWithdrawl(int id, int money)
        {
            using (var db = new AccountDbContext())
            {
                var entity = db.SetAccount.Find(id);
                if (entity != null)
                {
                    if (entity.Account_Type == "savings" && entity.Amount > (1000 + money))
                    {
                        entity.Amount = entity.Amount - money;

                        Console.WriteLine("Amount Withdrawl");
                    }
                    else if (entity.Account_Type == "current" && entity.Amount > money)
                    {
                        entity.Amount = entity.Amount - money;

                        Console.WriteLine("Amount Withdrawl");
                    }
                    else
                    {
                        Console.WriteLine("Amount can not be less than 0 for current account type or 1000 for savings account type");
                    }
                    db.SaveChanges();
                }
            }
            Console.WriteLine();
            Console.WriteLine();
        }
        public void PerformDatabaseInterest(int id)
        {
            using (var db = new AccountDbContext())
            {
                var entity = db.SetAccount.Find(id);
                if (entity != null)
                {
                    if (entity.Account_Type == "savings")
                    {
                        int interest = (entity.Amount * 4) / 100;
                        Console.WriteLine("Interest is :- " + interest);
                    }
                    else
                    {
                        int interest = (entity.Amount * 1) / 100;
                        Console.WriteLine("Interest is :- " + interest);
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
