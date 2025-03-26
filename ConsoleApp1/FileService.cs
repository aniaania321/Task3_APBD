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
    
    public void SaveDevices(List<Device> devices)// I added an abstract method for saving devices so that we can have a universal one here
    {
        StringBuilder devicesSb = new();

        foreach (var storedDevice in devices)
        {
            devicesSb.AppendLine(storedDevice.saveDevice());
        }

        File.WriteAllText("input.txt", devicesSb.ToString());
    }


}