using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DatabaseReference
{
    public class MyDatabase
    {
        public SqlConnection CreatingConnection()
        {
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = new SqlConnection();
                sqlConnection.ConnectionString = "Data Source=TAVDESK154;Initial Catalog= Mohit;Integrated Security=true";
                sqlConnection.Open();
                return sqlConnection;
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
                return sqlConnection;
            }
        }
        public void InsertIntoDB(int id,string name,string type)
        {
            SqlConnection connection = CreatingConnection();
            string sqlInsertQuery = "";
            if (type == "savings")
            {
                sqlInsertQuery = "insert into Accounts (Account_Number,Full_Name,Amount,Account_Type) values(" + id + ",'" + name + "'," + 1000 + ",'" + type + "')";
                SqlCommand sqlCommand = new SqlCommand(sqlInsertQuery, connection);
                sqlCommand.ExecuteNonQuery();
            }
            else if (type == "current")
            {
                sqlInsertQuery = "insert into Accounts (Account_Number,Full_Name,Amount,Account_Type) values(" + id + ",'" + name + "'," + 0 + ",'" + type + "')";
                SqlCommand sqlCommand = new SqlCommand(sqlInsertQuery, connection);
                sqlCommand.ExecuteNonQuery();
            }
            connection.Close();
        }
        public void SelectAll()
        {
            SqlConnection connection = CreatingConnection();
            string sqlSelectQuery = "select * from Accounts";
            SqlCommand sqlCommand = new SqlCommand(sqlSelectQuery, connection);
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();
            
            while (sqlReader.Read())
            {
                Console.Write("Account Number :- {0} \nFull Name :- {1} \nAmount :- {2} \nAccount Type  :- {3}", sqlReader.GetValue(1), sqlReader.GetValue(2), sqlReader.GetValue(3), sqlReader.GetValue(4));
                Console.WriteLine();
                Console.WriteLine();
            }
            connection.Close();
        }
        public string SelectRow(int id)
        {
            string output = "Account Number :- ";
            SqlConnection connection = CreatingConnection();
            string sqlSelectQuery = "select * from Accounts where S_NO=" + id;
            SqlCommand sqlCommand = new SqlCommand(sqlSelectQuery, connection);
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();
            if (sqlReader.Read())
            {
                output += sqlReader.GetValue(1);
                output += "\n Full Name is :- ";
                output += sqlReader.GetValue(2);
                output += "\n Amount is :- ";
                output += sqlReader.GetValue(3);
                output += "\n Account Type is :- ";
                output += sqlReader.GetValue(4);
            }
            connection.Close();
            return output;
        }
        public void DepositAmount(int id,int money)
        {
            SqlConnection connection = CreatingConnection();
            string sqlUpdateQuery = "update Accounts set Amount=Amount+" + money + "where S_NO=" + id;
            SqlCommand sqlCommand = new SqlCommand(sqlUpdateQuery, connection);
            sqlCommand.ExecuteNonQuery();
            connection.Close();
        }
        public void WithdrawAmount(int id,int money)
        {
            string updateQuery = "";
            SqlConnection connection = CreatingConnection();
            string checkBalanceQuery = "select Amount,Account_Type from Accounts where S_NO=" + id;
            SqlCommand sqlCommand = new SqlCommand(checkBalanceQuery, connection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            int flag = 0;
            if (sqlDataReader.Read())
            {
                int amount = (int)sqlDataReader.GetValue(0);
                string type = (string)sqlDataReader.GetValue(1);
                if(type=="savings" && amount>(1000 + money))
                {
                    flag = 1;
                }
                else if(type=="current" && amount > (0 + money))
                {
                    flag = 1;
                }
                else
                {
                    Console.WriteLine("Amount can not be less than 0 for current account type or 1000 for savings account type");
                }
            }
            connection.Close();
            if (flag == 1)
            {
                connection = CreatingConnection();
                updateQuery = "update Accounts set Amount=Amount-" + money + " where S_NO=" + id;
                sqlCommand = new SqlCommand(updateQuery, connection);
                sqlCommand.ExecuteNonQuery();
                Console.WriteLine("Amount Deducted");
            }
        }
        public float CalcInterest(int id)
        {
            float interest=0;
            SqlConnection connection = CreatingConnection();
            string checkBalanceQuery = "select Amount,Account_Type from Accounts where S_NO=" + id;
            SqlCommand sqlCommand = new SqlCommand(checkBalanceQuery, connection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                int amount = (int)sqlDataReader.GetValue(0);
                string type = (string)sqlDataReader.GetValue(1);
                if (type == "savings")
                {
                    interest = (amount * 4) / 100;
                }
                else if (type == "current")
                {
                    interest = (amount) / 100;
                }
            }
            connection.Close();
            return interest;
        }
    }
}
