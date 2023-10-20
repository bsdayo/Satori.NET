namespace Satori.Protocol.Events;

public class Signal
{
    public SignalOperation Op { get; set; }
}

public class Signal<TBody> : Signal where TBody : class
{
    public TBody? Body { get; set; }
}