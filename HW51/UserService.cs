using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW51
{
    public  class UserService
    {
        
        private User[] Users = new User[2000];
        public static int UserCount;
        public UserService(User[] users)
        {
            
            int count = 0;
            foreach (User user in users)
            {
               
                Users[count] = user;
                count++;
                UserCount = count;
            }
        }
        public void AddAccount(User u)
        {
            if (repetitiveAccount(u.email) == true)
            {
                Console.Write("The account already exists.");
                Console.ReadKey();
            }
            else
            {
                 Users[UserCount] = u;
                UserCount++;
            }
        }
        //private void RemoveAccount(BankAccount account) { }
        private bool repetitiveAccount(string email)
        {
            if (SearchEmail(email) == true) { return true; }
            return false;

        }
        public bool SearchEmail(string email,string pass)
        {
            for (int i = 0; i < Users.Length; i++)
            {
                if (Users[i] is null) { break; }
                if (Users[i].email.ToLower() == email.ToLower() && Users[i].Getpass() == pass)
                {
                    return true;
                }
            }
            return false;
        }
public bool SearchEmail(string email)
        {
            for (int i = 0; i < Users.Length; i++)
            {
                if (Users[i] is null) { break; }
                if (Users[i].email.ToLower() == email.ToLower())
                {
                    return true;
                }
            }
            return false;
        }
        public int SearchIndex(string Email)
        {
            for (int i = 0; i < Users.Length; i++)
            {
                if (Users[i] is null) { break; }
                if (Users[i].email.ToLower() == Email.ToLower())
                {
                    return i;
                }
            }
            return 2;
        }
        public bool manageronly(User user1)
        {
            if ( user1.Getmanagerid() == 0 )
            { return false; }
            else
            { return true; }
        }
      public User[] GetUsers()
        {
            return Users;
        }
    }
}
