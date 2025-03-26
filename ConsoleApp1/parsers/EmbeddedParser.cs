namespace Tutorial3_Task;

public class EmbeddedParser:DeviceParserInterface
{
    public bool whichDevice(string line)
    {
        if (line.StartsWith("ED-"))
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
    
    public Device parse(string line, int lineNumber)
    {
        const int IpAddressPosition = 3;
        const int NetworkNamePosition = 4;
        
        var infoSplits = line.Split(',');

        if (infoSplits.Length < MinimumRequiredElements + 1)
        {
            throw new ArgumentException($"Corrupted line {lineNumber}", line);
        }
        
        if (bool.TryParse(infoSplits[EnabledStatusPosition], out bool _) is false)
        {
            throw new ArgumentException($"Corrupted line {lineNumber}: can't parse enabled status for embedded device.", line);
        }

        return new Embedded(infoSplits[IndexPosition], infoSplits[DeviceNamePosition], 
            bool.Parse(infoSplits[EnabledStatusPosition]), infoSplits[IpAddressPosition], 
            infoSplits[NetworkNamePosition]);
    }
}