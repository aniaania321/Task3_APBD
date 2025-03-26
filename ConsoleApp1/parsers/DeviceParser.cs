namespace Tutorial3_Task;

class DeviceParser
{
    private List<DeviceParserInterface> _parsers;

    public DeviceParser()
    {
        _parsers = new List<DeviceParserInterface>
        {
            new PCParser(),
            new SmartwatchParser(),
            new EmbeddedParser()
        };
    }

    public List<Device> ParseDevices(string[] lines)
    {
        List<Device> devices = new List<Device>();

        for (int i = 0; i < lines.Length; i++)
        {
            try
            {
                Device parsedDevice = null;

                foreach (var parser in _parsers)
                {
                    if (parser.whichDevice(lines[i]))
                    {
                        parsedDevice = parser.parse(lines[i], i);
                        break;
                    }
                }

                if (parsedDevice == null)
                {
                    throw new ArgumentException($"Line {i} was failed to parse.");
                }

                devices.Add(parsedDevice);
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine(argEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        return devices;
    }
}