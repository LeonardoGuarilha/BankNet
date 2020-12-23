using Bank.Domain.CustomerContext.Commands.Input;
using Bank.Domain.CustomerContext.Commands.Output;
using Bank.Domain.CustomerContext.Entities;
using Bank.Domain.CustomerContext.Repository;
using Bank.Domain.CustomerContext.ValueObjects;
using Bank.Shared;
using Bank.Shared.Commands;
using Flunt.Notifications;

namespace Bank.Domain.CustomerContext.Commands.Handler
{
    public class CreateCustomerHandler : 
        Notifiable,
        ICommandHandler<CreateCustomerCommand>
    {
        private readonly ICustomerRepository _repository;
        private readonly IAddressRepository _address;

        public CreateCustomerHandler(ICustomerRepository repository, IAddressRepository address)
        {
            _repository = repository;
            _address = address;
        }

        public ICommandResult Handle(CreateCustomerCommand command)
        {
            // Verificar se o CPF existe na base
            if (_repository.CheckDocument(command.Document) != null)
                AddNotification("Document", "CPF já cadastrado");
            
            // Verificar se o email já existe na base
            if (_repository.CheckEmail(command.Email) != null)
                AddNotification("Email", "E-mail já cadastrado");
            
            // Ciar os VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            
            // Criar as entidades
            var address = new Address(command.Street, command.Number, command.Complement,command.District, command.City, 
                command.State, command.Country, command.ZipCode);
            
            var account = new Account(Configurations.BankNumber, 0m);

            var customer = new Customer(name, email, command.Password, address.Id, document, account.AccountNumber);

            // Validar entidades e VOs
            AddNotifications(name, document, email, address, account, customer);
            
            // Padronizar retorno
            if (Invalid)
                return new GenericCommandResult(
                    false,
                    "Erro ao cadastrar o cliente",
                    new
                    {
                        // Verificar mensagens
                        message = customer.Notifications, address.Notifications
                    });
            
            // Persistir o customer e o address
            _address.Save(address);
            _repository.Save(customer, address.Id);
            
            // Retornar o resultado para a tela, com a padronização
            return new GenericCommandResult(
                true,
                "Cliente cadastrado com sucesso!",
                new
                {
                    message = "Pronto, agora você já pode usar todos os recursos do nosso banco!"
                });
        }
    }
}