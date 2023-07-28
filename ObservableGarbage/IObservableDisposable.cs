namespace ToolBX.ObservableGarbage;

public interface IObservableDisposable : IDisposable
{
    bool IsDisposed { get; }
    [Obsolete("Event handler type will be renamed to DisposalEventHanlder in 3.0.0")]
    event DisposalEvent OnDispose;
}