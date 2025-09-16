using FullTextSearch.Request.Abstractions;
namespace FullTextSearch.Request.Processor;

public class RequestProcessor
{
    IHelperMessage _message;
    IGetInput _input;
    
    public string ClientRequestProcess()
    {
        _message.MessageShowToHelpClientRequest();
        return  _input.GetInputRequest();
    }
}
