namespace Tutorial3_Task;

public interface ParserIntreface// created to adhere to the dependency inversion principle
{
    public List<Device> ParseDevices(string[] lines);
}