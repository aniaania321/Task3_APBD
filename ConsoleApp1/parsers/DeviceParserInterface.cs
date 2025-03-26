namespace Tutorial3_Task;

public interface DeviceParserInterface//I created the interface so that when we add another device type we can just add another implementation to parse it
{
    bool whichDevice(string line);
    Device parse(string line, int lineNumber);
}