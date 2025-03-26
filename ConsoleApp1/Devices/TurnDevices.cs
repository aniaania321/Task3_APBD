namespace Tutorial3_Task;

public abstract class TurnDevices:Device//I added this class as only the PC and smartwatch turn on and off, the embedded device can only be connected. Therefore, the method in embedded device has a different fucntionality and violates the Liskov Substitution principle
{
    public bool IsEnabled { get; private set; }

    protected TurnDevices(string id, string name, bool isEnabled) : base(id, name)
    {
        IsEnabled = isEnabled;
    }

    public virtual void TurnOn() => IsEnabled = true;
    public virtual void TurnOff() => IsEnabled = false;

    public override string saveDevice()
    {
        return $"{Id},{Name},{IsEnabled}";
    }
    
}