using HW51;
using System;
Ordinary_User u1 = new Ordinary_User("Arash","borhani","rajabiarash356@gmail.com","!14325");
Ordinary_User u2 = new Ordinary_User("Arash", "Rajabi", "rajabiarsh256@gmail.com", "!147556");
Ordinary_User u3 = new Ordinary_User("mohammad","Rajabi", "mohammadR566@gmail.com", "6333!25");
Ordinary_User u4 = new Ordinary_User("Mahdi","Aslani","MahdiAs234@gmail.com", "774325!");
Manager m1 = new Manager("Arash", "Rajabi", "rajabiarash36@gmail.com", "3!");
User[] users = new User[5];
users[0] = u1;
users[1] = u2;
users[2] = u3;
users[3] = u4;
users[4] = m1;
UserService Users = new UserService(users);
string E = "";
int option = 0;
do
{
    Console.Clear();
    Console.WriteLine("Welcome to our bank.");
    Console.WriteLine("1.Log in.");
    Console.WriteLine("2.New to our bank? Sign in.");
    Console.WriteLine("3.Exit.");

    option = int.Parse(Console.ReadLine());
    switch (option)
    {
        case 1:
            Console.Clear();
            Console.Write("Please enter your email: ");
            E = Console.ReadLine();
            Console.WriteLine("Password: ");
            string P = Console.ReadLine();
            if (Users.SearchEmail(E,P) == true)
            {
                Gotousersmenu();

            }
            else
            {
                Console.WriteLine("No Accounts Found, try again.");
                Console.ReadKey();
            }
            break;
        case 2:
            Console.Clear();
            bool CH = Adduser();
            if (CH == true)
            {
                Console.WriteLine("Congrats! you have created an account.");
                Console.WriteLine("We recommend you to set a password and phonenumber.");
                Console.WriteLine("1.Advance to menu     2.Exit");
                int Op = 0;
                Op = int.Parse(Console.ReadLine());
                if (Op == 1)
                { Gotousersmenu(); }
                else { }
            }

            break;
    }
}
while (option < 3);
void Gotousersmenu()
{
    int option2 = 0;
    int index = 0;
    index = Users.SearchIndex(E);
    do
    {
        User us = Users.GetUsers()[index];
        Console.Clear();
        Console.WriteLine($"Hi {us.name} Please choose what you wanna do:  ");
        Console.WriteLine("1.Add new Account.");
        Console.WriteLine("2.Change Password.");
        Console.WriteLine("3.Deposit money.");
        Console.WriteLine("4.Withdraw money.");
        Console.WriteLine("5.See Account information.");
        Console.WriteLine("6.set new phone number.");
        Console.WriteLine("7.List of users");
        Console.WriteLine("8.Exit.");
        option2 = int.Parse(Console.ReadLine());
        switch (option2)
        {
            case 1:
                Adduser();
                break;
            case 2:
                Console.Clear();
                if (Users.manageronly(us) == false)
                {
                    Console.Write("New password: ");
                    string p = Console.ReadLine();
                    us.changepassword(p);
                }
                else
                { 
                    Console.WriteLine("only users are allowed to change the password.");
                }
                Console.WriteLine("----press any botton.----");
                Console.ReadKey();
                break;
            case 3:
                Console.Clear();
                Console.Write("Enter an amount: ");
                long D = Convert.ToInt64(Console.ReadLine());
                us.Deposit(D);
                break;
            case 4:
                Console.Clear();
                Console.Write("Enter an amount: ");
                long W = Convert.ToInt64(Console.ReadLine());
                us.withdraw(W);
                break;
            case 5:
                Console.Clear();
                us.AccountInfo();
                Console.WriteLine("press any botton.");
                Console.ReadKey();
                break;
            case 6:
                Console.Clear();
                Console.Write("Enter the new number: ");
                string pn = Console.ReadLine();
                us.setPhone(pn);
                break;
            case 7:
                Console.Clear();
                if (Users.manageronly(us)==true)
                {
                    Manager m = (Manager)us;
                    m.Listofusers(Users.GetUsers());
                }
                else
                {
                    Console.WriteLine("only managers are allowed to access the list of users.");
                }
                Console.WriteLine("----press any botton.----");
                Console.ReadKey();
                break;
        }

    }
    while (option2 < 8);
}
bool Adduser()
{
    Console.Clear();
    Console.WriteLine("Sign in as:");
    Console.WriteLine("1.Manager  2.User");
    int choice = Convert.ToInt32(Console.ReadLine());

    Console.Write("Write your name: ");
    string N = Console.ReadLine();
    Console.Write("Write your lastname: ");
    string L = Console.ReadLine();
    Console.Write("Write your Email: ");
    string E1 = Console.ReadLine();
    Console.Write("Enter your password.(the password should have less than 10 characters and have at leaste one (!).");
    Console.WriteLine("It should contain characters and numbers");
    string p = Console.ReadLine();
    Manager M = new Manager(N,L,E1,p);
    Ordinary_User U = new Ordinary_User(N,L,E1,p);
    User[] NewUser = new User[1];
    if (choice == 1)
    {
        NewUser[0] = M;
    }
    else if (choice == 2)
    {
        NewUser[0] = U;
    }

    Console.Write("Write your phone number:");
    string Ph = Console.ReadLine();
    bool Ch = NewUser[0].setPhone(Ph);
    if (Ch == true)
    { Users.AddAccount(NewUser[0]); return true; }
    else
    {

    }
    return false;
}