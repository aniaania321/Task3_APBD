namespace Tutorial3_Task;

public class DeviceManagerFactory
{
    public static DeviceManager CreateDeviceManager(DataInterface fileService, ParserIntreface deviceParser)
    {
        return new DeviceManager(fileService, deviceParser);
    }
}