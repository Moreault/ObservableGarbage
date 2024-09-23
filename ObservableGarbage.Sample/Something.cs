namespace ObservableGarbage.Sample;

public class Something : IObservableDisposable
{
    public bool IsDisposed { get; private set; }

    public event DisposalEventHandler OnDispose;

    public void Dispose()
    {
        if (!IsDisposed)
        {
            IsDisposed = true;
            OnDispose?.Invoke(this);
        }
    }
}