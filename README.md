![ObservableGarbage](https://github.com/Moreault/ObservableGarbage/blob/master/observablegarbage.png)
# ObservableGarbage
Adds an IObservableDisposable interface on top of IDisposable to help keep track of disposal status and trigger an event when an object is disposed.

```c#
public class Example : IObservableDisposable
{
    public bool IsDisposed { get; private set; }

    public event DisposalEvent? OnDispose;

    private readonly SomeDisposableThingy _thingy;

    public Example(SomeDisposableThingy thingy)
    {
        _thingy = thingy;
    }

    public void Dispose()
    {
        //You probably don't want to trigger this event multiple times for the same object
        if (!IsDisposed)
        {
            //You may want to manually unsubscribe this event on listeners after this to ensure proper disposal
            OnDispose?.Invoke(this);
            IsDisposed = true;
            //Spoiler alert : No, you don't need to do _thingy = null;
            _thingy.Dispose();
        }
    }
}
```

## Breaking changes
2.X.X -> 3.0.0
* `DisposalEvent` was renamed `DisposalEventHandler`