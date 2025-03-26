namespace Tutorial3_Task;

public abstract class Device
{
    public string Id { get; set; }
    public string Name { get; set; }
    public bool IsEnabled { get; set; }

    public Device(string id, string name)
    {
        Id = id;
        Name = name;
    }
    
    public abstract string saveDevice();//method added so that we don't have to differentate for different devices, it will be implemented in their classes
    
}
