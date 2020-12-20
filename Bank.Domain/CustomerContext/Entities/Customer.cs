using System;
using System.Text;
using Bank.Shared.Entities;
using Flunt.Notifications;
using Flunt.Validations;

namespace Bank.Domain.CustomerContext.Entities
{
    public class Customer : Entity
    {
        public Customer(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
            
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Name, "Nome", "Nome não pode ser vazio")
                .IsNotNullOrEmpty(Email, "Email", "E-mail não pode ser vazio")
                .IsNotNullOrEmpty(Password, "Senha", "A senha não pode ser vazia")
            );
        }
        
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        
        public bool Authenticate(string email, string password)
        {
            if (Email == email && Password == HashPassword(password))
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