using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Assignment
{
    class Account
    {
       [Key]
        public int S_NO { get; set; }
        public int Account_Number { get; set; }
        public string Full_Name { get; set; }
        public int Amount { get; set; }
        public string Account_Type { get; set; }
    }
}
