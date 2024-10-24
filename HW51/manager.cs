using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW51
{
    public class Manager : User
    {
        
        public Manager(string Name, string Lastname, string Email,string password) : base(Name, Lastname, Email,password)
        {
            managerId = Convert.ToInt32(Lastname[0]) * Convert.ToInt32(Name[0]) + Convert.ToInt32(password[0]) ;
        }
      
        public override void AccountInfo()
        {
            Console.WriteLine("----Manager----");
            Console.WriteLine("Owner: " + Owner);
            Console.WriteLine("Email: " + email);
            Console.WriteLine("Phone number: " + phonenumber);
            Console.WriteLine("Balance: " + Showbalance());
            Console.WriteLine("Password: " + password);
        }
        public void Listofusers(User[] users5)
        {
           Console.WriteLine("*****List of users*****");
            for (int i = 0; i < UserService.UserCount; i++)
            {
                string I = Convert.ToString(i);
                Console.Write($"{I}.");
                users5[i].AccountInfo();
            }
        }
    }
}
