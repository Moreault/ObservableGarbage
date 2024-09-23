namespace ToolBX.ObservableGarbage;

public interface IObservableDisposable : IDisposable
{
    bool IsDisposed { get; }
    event DisposalEventHandler OnDispose;
}