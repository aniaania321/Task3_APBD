namespace Tutorial3_Task;

public interface DataInterface//Created to adhere to the dependency inversion principle (so that device manager doesnt depend on the lower level file service class)
{
    public string[] GetDevices();
    
    public void SaveDevices(List<Device> devices);

}