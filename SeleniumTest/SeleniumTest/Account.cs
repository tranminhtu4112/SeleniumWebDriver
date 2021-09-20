using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTest
{
    public class Account
    {
        public String email { get; set; }
        public String password { get; set; }
        public Account(String email, String password)
        {
            this.email = email;
            this.password = password;
        }
    }
    public class AccountList
    {
        public Account[] accounts = new Account[]
        {
            new Account("tu5@gmail.com","12345"), 
            new Account("tu6@gmail.com","123456"), 
            new Account("tu7@gmail.com","1234567"),
            new Account("tu23@gmail.com","12345678912345678912345"), 
            new Account("tu24@gmail.com","123456789123456789123454"), 
            new Account("tu25@gmail.com","1234567891234567891234545"),
        };
    }
}
