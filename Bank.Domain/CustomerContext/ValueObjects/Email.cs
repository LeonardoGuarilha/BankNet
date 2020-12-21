using Flunt.Notifications;
using Flunt.Validations;

namespace Bank.Domain.CustomerContext.ValueObjects
{
    public class Email : Notifiable
    {
        public Email(string address)
        {
            Address = address;
            
            
            AddNotifications(new Contract()
                    .Requires()
                    .IsEmail(Address, "Email", "O e-mail é inválido") // Posso colocar o que eu quiser na property
            );
        }
        public string Address { get; private set; }
    }
}