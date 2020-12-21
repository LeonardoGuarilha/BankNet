using System.Text;
using Bank.Domain.CustomerContext.ValueObjects;
using Bank.Shared.Entities;
using Flunt.Validations;

namespace Bank.Domain.CustomerContext.Entities
{
    public class Customer : Entity
    {
        public Customer(Name name, Email email, string password, Address address, Document document, string accountNumber)
        {
            Name = name;
            Email = email;
            Password = HashPassword(password);
            Address = address;
            Document = document;
            AccountNumber = accountNumber;
            
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Password, "Password", "A senha não pode ser vazia")
                .IsNotNullOrEmpty(AccountNumber, "AccountNumber", "Numero da conta não pode ser vazio.")
            );
        }
        
        public Name Name { get; private set; }
        public Email Email { get; private set; }
        public string Password { get; private set; }
        public Document Document { get; private set; }
        public Address Address { get; private set; }
        public string AccountNumber { get; private set; }
        
        public bool Authenticate(string email, string password)
        {
            if (Email.Address == email && Password == HashPassword(password))
                return true;

            AddNotification("User", "Usuário ou senha inválidos");
            return false;
        }

        private string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password)) return "";
            var hashedPassword = (password += "|2d331cca-f6c0-40c0-bb43-6e32989c2881");
            var md5 = System.Security.Cryptography.MD5.Create();
            var data = md5.ComputeHash(Encoding.Default.GetBytes(hashedPassword));
            var sbString = new StringBuilder();
            foreach (var t in data)
                sbString.Append(t.ToString("x2"));

            return sbString.ToString();
        }
    }
}