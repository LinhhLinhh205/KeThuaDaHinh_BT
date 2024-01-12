using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT01
{
    class Account
    {
        private double _balance;
        protected double Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }
        public Account()
        {

        }

        public Account(double balance)
        {
            this._balance = balance;
        }
        public virtual bool Withdraw(double amount)
        {
            return false;
        }
        public virtual bool Deposit(double amount)
        {
            return false;
        }
        public virtual void PrintBalance()
        {
            Console.WriteLine($"So du:{_balance}");
        }
    }
    class SavingAccount : Account
    {
        private double _interesRate = 0.8;
        public double InteresRate
        {
            get { return _interesRate; }
            set { _interesRate = value; }
        }
        public SavingAccount(double balance) : base(balance)
        {

        }
        public override bool Withdraw(double amount)
        {
            if (0 < amount && amount <= Balance)
            {
                Balance = Balance - (amount + amount * InteresRate);

                Console.WriteLine($"Rut tien thanh cong.So tien da rut la:{amount}");
                return true;
            }


            else Console.WriteLine("Giao dich that bai");
            return false;
        }
        public override bool Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance = Balance + (amount + amount * InteresRate);

                Console.WriteLine($"Them tien thanh cong.So tien da them vao so du:{amount}");
                return true;
            }
            else Console.WriteLine("Them tien that bai");
            return false;
        }
        public override void PrintBalance()
        {
            Console.WriteLine($"The saving account balance is:{Balance}");
        }

    }
    class CheckingAccount : Account
    {
        public CheckingAccount(double balance) : base(balance)
        {

        }
        public override bool Withdraw(double amount)
        {
            if (amount > 0 && amount < Balance)
            {
                Balance = Balance - amount;

                Console.WriteLine($"Giao dich thanh cong.So tien da rut la:{amount}");
                return true;

            }


            else Console.WriteLine("Giao dich that bai");
            return false;

        }
        public override bool Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance = Balance + amount;

                Console.WriteLine($"Them tien thanh cong.So tien da them:{amount}");
                return true;
            }
            else Console.WriteLine("Them tien that bai");
            return false;
        }
        public override void PrintBalance()
        {
            Console.WriteLine($"The checking account balance is:{Balance}");
        }
        class Program
        {
            static void Main(string[] args)
            {


                Console.WriteLine("SavingsAccount");
                Account ac2 = new SavingAccount(2000);
                ac2.Withdraw(200);
                ac2.Deposit(400);
                ac2.PrintBalance();
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("CheckingAccount");
                Account ac1 = new CheckingAccount(1000);
                ac1.Withdraw(200);
                ac1.Deposit(500);
                ac1.PrintBalance();

                Console.ReadLine();
            }
        }
    }
}
