namespace FullTextSearch.Request.Process;

using FullTextSearch.Request.Abstractions;
using FullTextSearch.Request.WordSpiliter;

public class InputProcessor
{
    private readonly IHelperMessage _message;
    private readonly IGetInput _input;
    private readonly InputWordSpiliter _spiliter;

    public InputProcessor(IHelperMessage message,IGetInput input,InputWordSpiliter spiliter)
    {
        _message = message;
        _input = input;
        _spiliter = spiliter;
    }
    public List<string> Process()
    {
        _message.ShowHelperRequestMessage();
        string inputContent = _input.GetRequest();
        return _spiliter.Spilit(inputContent);
        
    }
}