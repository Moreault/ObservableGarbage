namespace ObservableGarbage.Sample;

public interface ISample
{
    void Start();
}

[AutoInject]
public class Sample : ISample
{
    private readonly ITerminal _terminal;

    public Sample(ITerminal terminal)
    {
        _terminal = terminal;
    }

    public void Start()
    {
        _terminal.Write("Creating <italic>something</italic>...");
        using (var something = new Something())
        {
            _terminal.Write("<italic>Something</italic> was just created. Let's subscribe to its <color green=255>OnDispose</color> event.");
            something.OnDispose += (_) => _terminal.Write("This just in : <italic>Something</italic> was <color red=255>disposed</color>!");
            _terminal.Write("And now we wait...");
        }
        _terminal.Write("The demonstration... is <bold>over</bold>!");
    }
}