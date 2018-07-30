using System;
using System.Linq;
namespace Banking_Assignment
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome!!");
            Console.WriteLine();
            int flag = 0;
            Console.WriteLine("Enter 1 to use Entity Framework\n2 to use ADO.NET");
            int databaseType = int.Parse(Console.ReadLine());
            if (databaseType == 1)
            {
                flag = 1;
            }
            int choice;
            Accounts accountObj = new Accounts();
            EntityClass entityObj = new EntityClass();
            do
            {
                Console.WriteLine("Enter 1 to insert user" +
                    "\n2 to print all the users" +
                    "\n3 to print user by id" +
                    "\n4 to deposit money" +
                    "\n5 to withdraw money" +
                    "\n6 to calculate interest" +
                    "\n7 to exit");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Account Id :- ");
                        int accoountId = int.Parse(Console.ReadLine());
                        Console.Write("\nEnter Full name :- ");
                        string fullName = Console.ReadLine();
                        Console.Write("\nEnter Account Type :- ");
                        string type = Console.ReadLine();
                        if (flag == 0)
                        {
                            accountObj.Add(accoountId, fullName, type);
                        }
                        else
                        {
                            entityObj.PerformDatabaseOperations(accoountId,fullName,type);
                            Console.WriteLine("Account Added");
                        }
                        break;
                    case 2:
                        if (flag == 0)
                        {
                            accountObj.DisplayAccountDetails();
                        }
                        else
                        {
                            entityObj.PerformDatabasePrinting();
                        }
                        break;
                    case 3:
                        Console.Write("Enter id :- ");
                        int accountId = int.Parse(Console.ReadLine());
                        if (flag == 0)
                        {
                            accountObj.SearchByAccountId(accountId);
                        }
                        else
                        {
                            entityObj.PerformeDatabasePrint(accountId);
                        }
                        break;
                    case 4:
                        Console.Write("Enter id :- ");
                        accountId = int.Parse(Console.ReadLine());
                        Console.Write("\nEnter Money :- ");
                        int money = int.Parse(Console.ReadLine());
                        if (flag == 0)
                        {
                            accountObj.Deposit(accountId, money);
                        }
                        else
                        {
                            entityObj.PerformDatabaseUpdate(accountId, money);
                        }
                        break;
                    case 5:
                        Console.Write("Enter id :- ");
                        accountId = int.Parse(Console.ReadLine());
                        Console.Write("\nEnter Money :- ");
                        money = int.Parse(Console.ReadLine());
                        if (flag == 0)
                        {
                            accountObj.Withdrawl(accountId, money);
                        }
                        else
                        {
                            entityObj.PerformDatabaseWithdrawl(accountId, money);
                        }
                        break;
                        
                        break;
                    case 6:
                        Console.Write("Enter id :- ");
                        accountId = int.Parse(Console.ReadLine());
                        if (flag == 0)
                        {
                            accountObj.CalculateInterest(accountId);
                        }
                        else
                        {
                            entityObj.PerformDatabaseInterest(accountId);
                        }
                        break;
                    case 7: break;
                    default: Console.WriteLine("wrong input!");
                        break;
                }
            }
            while (choice != 7);
            Console.WriteLine("thanks for using!!!");
        }
    }
}
