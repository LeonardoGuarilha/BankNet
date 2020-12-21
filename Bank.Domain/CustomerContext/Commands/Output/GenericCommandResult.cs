using Bank.Shared.Commands;

namespace Bank.Domain.CustomerContext.Commands.Output
{
    public class GenericCommandResult : ICommandResult
    {
        public GenericCommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
        
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}