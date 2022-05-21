namespace ToolBX.ObservableGarbage;

public interface IObservableDisposable : IDisposable
{
    bool IsDisposed { get; }
    event DisposalEvent OnDispose;
}