namespace Tutorial3_Task;

class DeviceParser
{
    private const int MinimumRequiredElements = 4;

    private const int IndexPosition = 0;
    private const int DeviceNamePosition = 1;
    private const int EnabledStatusPosition = 2;
    
    public PersonalComputer ParsePC(string line, int lineNumber)
    {
        const int SystemPosition = 3;
        
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
            bool.Parse(infoSplits[EnabledStatusPosition]), infoSplits[SystemPosition]);
    }

    public Smartwatch ParseSmartwatch(string line, int lineNumber)
    {
        const int BatteryPosition = 3;
        
        var infoSplits = line.Split(',');

        if (infoSplits.Length < MinimumRequiredElements)
        {
            throw new ArgumentException($"Corrupted line {lineNumber}", line);
        }
        
        if (bool.TryParse(infoSplits[EnabledStatusPosition], out bool _) is false)
        {
            throw new ArgumentException($"Corrupted line {lineNumber}: can't parse enabled status for smartwatch.", line);
        }

        if (int.TryParse(infoSplits[BatteryPosition].Replace("%", ""), out int _) is false)
        {
            throw new ArgumentException($"Corrupted line {lineNumber}: can't parse battery level for smartwatch.", line);
        }

        return new Smartwatch(infoSplits[IndexPosition], infoSplits[DeviceNamePosition], 
            bool.Parse(infoSplits[EnabledStatusPosition]), int.Parse(infoSplits[BatteryPosition].Replace("%", "")));
    }

    public Embedded ParseEmbedded(string line, int lineNumber)
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

    public List<Device> ParseDevices(string[] lines)//Moved parce devices method to device parser to keep SRP
    {
        List<Device> devices = new List<Device>();
        for (int i = 0; i < lines.Length; i++)
        {
            try
            {
                Device parsedDevice;

                if (lines[i].StartsWith("P-"))
                {
                    parsedDevice = ParsePC(lines[i], i);
                }
                else if (lines[i].StartsWith("SW-"))
                {
                    parsedDevice = ParseSmartwatch(lines[i], i);
                }
                else if (lines[i].StartsWith("ED-"))
                {
                    parsedDevice = ParseEmbedded(lines[i], i);
                }
                else
                {
                    throw new ArgumentException($"Line {i} is corrupted.");
                }

                devices.Add(parsedDevice);
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine(argEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"Something went wrong during parsing this line: {lines[i]}. The exception message: {ex.Message}");
            }
        }
        return devices;
    }
    
}