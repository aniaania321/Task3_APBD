using System.Text;

namespace Tutorial3_Task;

public class FileService//created file service to apply single responsibility principle (taken away from device manager)
{
    private string _inputDeviceFile;

    public FileService(string filePath)
    {
        _inputDeviceFile = filePath;
        
    }

    public string[] GetDevices()
    {
        if (!File.Exists(_inputDeviceFile))
        {
            throw new FileNotFoundException("The input device file could not be found.");
        }

        var lines = File.ReadAllLines(_inputDeviceFile);
        return lines;
    }
    
    public void SaveDevices(List<Device> devices)
    {
        StringBuilder devicesSb = new();

        foreach (var storedDevice in devices)
        {
            if (storedDevice is Smartwatch smartwatchCopy)
            {
                devicesSb.AppendLine($"{smartwatchCopy.Id},{smartwatchCopy.Name}," +
                                     $"{smartwatchCopy.IsEnabled},{smartwatchCopy.BatteryLevel}%");
            }
            else if (storedDevice is PersonalComputer pcCopy)
            {
                devicesSb.AppendLine($"{pcCopy.Id},{pcCopy.Name}," +
                                     $"{pcCopy.IsEnabled},{pcCopy.OperatingSystem}");
            }
            else
            {
                var embeddedCopy = storedDevice as Embedded;
                devicesSb.AppendLine($"{embeddedCopy.Id},{embeddedCopy.Name}," +
                                     $"{embeddedCopy.IsEnabled},{embeddedCopy.IpAddress}," +
                                     $"{embeddedCopy.NetworkName}");
            }
        }
        
        File.WriteAllLines(_inputDeviceFile, devicesSb.ToString().Split('\n'));
    }

}