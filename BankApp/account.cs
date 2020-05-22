using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BankApp
{
    [Serializable()]
    public class Account
    {
        public string userName;
        public string password;
        public string IBAN;
        public int amount;
        public DateTime lastVisited;

        
        public Account(string user, string pass, string iban, int money, DateTime lastvisited)
        {
            userName = user;
            password = pass;
            IBAN = iban;
            amount = money;
            lastVisited = lastvisited;


        }
        public Account()
        {
            userName = "default";
            password = "password";
            IBAN = "none";
            amount = 0;
            lastVisited = DateTime.Now;
        }
        public string toString()
        {
            return $"User: {userName} with an IBAN: {IBAN}, has {amount} on his account. {Environment.NewLine}" +
                $"Last visited on: {lastVisited.ToString("dd/MM/yyyy")} {Environment.NewLine}Account Balance: {Convert.ToDecimal(amount) / 100:c2}";
        }
    }
}
