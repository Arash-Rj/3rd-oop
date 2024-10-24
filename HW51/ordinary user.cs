using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW51
{
    public class Ordinary_User : User
    {
        public Ordinary_User(string Name, string Lastname, string Email,string password) : base(Name, Lastname, Email,password)
        {
        }
        
        public override void AccountInfo()
        {
            Console.WriteLine("----Ordinary user----");
            Console.WriteLine("Owner: " + Owner);
            Console.WriteLine("Email: " + email);
            Console.WriteLine("Phone number: " + phonenumber);
            Console.WriteLine("Balance: " + Showbalance());
            Console.WriteLine("Password: " + password);
        }
    }
}
