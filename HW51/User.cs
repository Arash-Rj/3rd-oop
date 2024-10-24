using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW51
{
    public abstract class User
    {
        public string name { get; set; }
        protected string password { get; set; }
        public int OwnerID { get; set; }
        public int AccountNumber { get; set; }
        public string phonenumber { get; private set; }
        public long Cardnumber { get; private set; }
        private string lastname { get; set; }
        public string Owner { get; set; }
        private long Balance { get; set; }
        private string Establishmentdate { get; set; }
        public string email { get; private set; }
        protected int managerId { get; set; }
        public User(string Name, string Lastname, string Email,string password)
        {
            name = Name;
            email = Email;
            lastname = Lastname;
            AccountNumber = Convert.ToInt32(Lastname[0]) * Convert.ToInt32(Name[0]);
            Owner = Name + Lastname;
            this.password = password;
        }
        public User() { }
        public void changepassword(string pass)
        {
            Console.Write("Password must be combination of characters and numbers and at least one (!).");
            Console.WriteLine(" password langth must be lower than 10");
            if (pass.Length > 10)
            {
                Console.Write("Too long.please try again.");
                Console.ReadKey();
            }
            else if (pass.Length < 10)
            {
                for (int i = 0; i < pass.Length; i++)
                {
                    if (pass[i] != '!')
                    {
                        Console.WriteLine("there is no ! found in the password.");
                        Console.ReadKey();
                    }
                    else if ( pass.All(char.IsNumber)==true )
                    {
                        Console.Write("password must contain at least one character.");
                    }
                }
            }
            else { password = pass; }
        }
        public void Deposit(long Amount)
        {
            Balance += Amount;
        }
        public void withdraw(long Amount)
        {
            if (Balance < Amount)
            {
                {
                    Console.Write("Not enough Balance.");
                }
            }
            Balance -= Amount;
        }
        public long Showbalance()
        {
            return Balance;
        }
        public bool setPhone(string PN)
        {
            bool check = PN.All(char.IsNumber);
            string PN2 = PN.Replace("+98", "0");
            bool C = false;
            switch (check)
            {
                case true:
                    if (PN2.Length > 14 && PN2.Length < 11 && PN2.Length == 12.13)
                    {
                        Console.WriteLine("incorrect phone number, please try agian.");
                        return C;
                    }
                    else if (PN2.Length == 11 && PN2.Substring(0, 2) == "09")
                    {
                        phonenumber = PN2; return !C;
                    }
                    else if (PN.Substring(0, 4) == "0098" && PN.Length == 14)
                    {
                        phonenumber = PN2; return !C;
                    }
                    else
                    {
                        Console.WriteLine("incorrect phone number, please try agian.");
                        return C;
                    }
                    break;
                default:
                    {
                        Console.WriteLine("Incorrect characters.");
                        return C;
                    }
                    break;

            }
        }
        public string Getpass()
        {
            return password;
        }
        public abstract void AccountInfo();
        public int Getmanagerid()
        {
            return managerId;
        }
    }
}
