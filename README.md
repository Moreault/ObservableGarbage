![ObservableGarbage](https://github.com/Moreault/ObservableGarbage/blob/master/observablegarbage.png)
# ObservableGarbage
Adds an event to IDisposable that is triggered when the object is disposed.

## Good to know
This should be obvious but you can only use this interface on your own types. 

## Why
I implemented my own custom memory management system for Rough Trigger so that disposed objects could actually be eventually reclaimed and reused (I call this process "recycling.")

It may or may not fit your needs but it exists regardless.

## Getting started

```c#
public class Example : IObservableDisposable
{
    public bool IsDisposed { get; private set; }

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

    public event DisposalEvent? OnDispose;
}
```

## You made a whole package for a single interface and an event handler? Are you insane?!
ToolBX is a framework that comes in small chunks so that you can use what you like and leave out the rest. 

For instance, I see no reason why you should have dependencies to the Grid collection if all you want to use is the IObservableDisposable interface.

You can just copy and paste it for all I care. It's like four lines of code.

However, it does also provide you with a uniformized way of observing your garbage together with other parts of the ToolBX framework that may also rely on IObservableDisposable.