using Bank.Domain.CustomerContext.Commands.Handler;
using Bank.Domain.CustomerContext.Commands.Input;
using Bank.Domain.CustomerContext.Repository;
using Bank.Shared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Api.Controllers
{
    [ApiController]
    [Route("v1/customer")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly CreateCustomerHandler _handler;

        public CustomerController(ICustomerRepository customerRepository, IAddressRepository addressRepository, CreateCustomerHandler handler)
        {
            _customerRepository = customerRepository;
            _addressRepository = addressRepository;
            _handler = handler;
        }

        [HttpPost]
        [Route("")]
        public ICommandResult Post([FromBody] CreateCustomerCommand command)
        {
            var result = _handler.Handle(command);
            return result;
        }
        
    }
}