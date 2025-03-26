namespace Tutorial3_Task;

public class PCParser:DeviceParserInterface
{
    public bool whichDevice(string line)
    {
        if (line.StartsWith("P-"))
            return true;
        else
        {
            return false;
        }
    }
    private const int MinimumRequiredElements = 4;

    private const int IndexPosition = 0;
    private const int DeviceNamePosition = 1;
    private const int EnabledStatusPosition = 2;
    
    private const int _SystemPosition = 3;

    public Device parse(string line, int lineNumber)
    {

    var infoSplits = line.Split(',');

        if (infoSplits.Length < MinimumRequiredElements)
    {
        throw new ArgumentException($"Corrupted line {lineNumber}", line);
    }
        
    if (bool.TryParse(infoSplits[EnabledStatusPosition], out bool _) is false)
    {
        throw new ArgumentException($"Corrupted line {lineNumber}: can't parse enabled status for computer.", line);
    }
        
    return new PersonalComputer(infoSplits[IndexPosition], infoSplits[DeviceNamePosition], 
    bool.Parse(infoSplits[EnabledStatusPosition]), infoSplits[_SystemPosition]);
    }
    
}