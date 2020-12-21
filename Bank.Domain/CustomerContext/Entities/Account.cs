using System;
using Bank.Shared.Entities;
using Flunt.Validations;

namespace Bank.Domain.CustomerContext.Entities
{
    public class Account : Entity
    {
        public Account(int bankNumber, decimal balance)
        {
            BankNumber = bankNumber;
            AccountNumber = GenerateAccountNumber();
            Balance = balance;
            
            AddNotifications(new Contract()
                .Requires()
                .IsNotNull(BankNumber, "BankNumber", "O númmero do banco não pode ser vazio")
                .IsNotNullOrEmpty(AccountNumber, "AccountNumber", "O númmero da conta não pode ser vazio")
                .IsNotNull(Balance, "Balance", "O saldo não pode ser vazio")
            );
        }
        
        public int BankNumber { get; private set; }
        public string AccountNumber { get; private set; }
        public decimal Balance { get; private set; }

        public string GenerateAccountNumber()
        {
            var random = new Random();
            var account = random.Next(11111, 99999);
            var DVNumber = random.Next(9);

            return $"{account}-{DVNumber}";
        }
        
    }
}