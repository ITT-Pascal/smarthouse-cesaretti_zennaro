using BlaisePascal.SmartHouse.Application.Devices.Luminuos.Lamps.Commands;
using BlaisePascal.SmartHouse.Application.Devices.LuminuosDevices.LampDevice.DeviceMapper;
using BlaisePascal.SmartHouse.Application.Devices.LuminuosDevices.Lamps.Commands;
using BlaisePascal.SmartHouse.Application.Devices.LuminuosDevices.Lamps.Dto;
using BlaisePascal.SmartHouse.Domain.Devices.Illumination;
using BlaisePascal.SmartHouse.Domain.Devices.Illumination.Repositories;


public class LampController
{
    private readonly ILampRepository _repository;

    public LampController(ILampRepository repository)
    {
        _repository = repository;
    }

    public void AddLamp()
    {
        Console.WriteLine("Lamp name: ");
        string name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Name not valid \n[Press a key to continue]");
            Console.ReadKey();
        }

        new AddLampCommand(_repository).Execute(name);
        Console.WriteLine("Lamp added");
    }

    public void RemoveLamp()
    {
        if (_repository.GetAll().Count == 0)
        {
            Console.WriteLine("there are no lamps \n" +
                "[Premere un tasto per continuare]");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("Lamp id: ");
        string id = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(id))
        {
            Console.WriteLine("Id not valid \n[Press a key to continue]");
            Console.ReadKey();
            return;
        }

        try
        {
            Guid.TryParse(id.Trim(), out Guid newId);
            new RemoveLampCommand(_repository).Execute(newId);
        }

        catch
        {
            Console.WriteLine("Lamp not found \n[Press a key to continue]");
            Console.ReadKey();
        }
    }

    public void SwitchOn()
    {
        if(_repository.GetAll().Count == 0)
        {
            Console.WriteLine("there are no lamps \n" +
                "[Premere un tasto per continuare]");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("Lamp id: ");
        string id = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(id))
        {
            Console.WriteLine("Id not valid \n[Press a key to continue]");
            Console.ReadKey();
        }

        try
        {
            Guid newId = new(id);
            new SwitchOnLampCommand(_repository).Execute(newId);
        }

        catch
        {
            Console.WriteLine("Lamp not found \n[Press a key to continue]");
            Console.ReadKey();
        }
    }

    public void SwitchOff()
    {

        if (_repository.GetAll().Count == 0)
        {
            Console.WriteLine("there are no lamps \n" +
                "[Press a key to continue]");
            Console.ReadKey();
            return;
        }


        Console.WriteLine("Lamp id: ");
        string id = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(id))
        {
            Console.WriteLine("Id not valid \n[Press a key to continue]");
            Console.ReadKey();
        }

        try
        {
            Guid newId = new(id);
            new SwitchOffLampCommand(_repository).Execute(newId);
        }

        catch
        {
            Console.WriteLine("Lamp not found \n[Press a key to continue]");
            Console.ReadKey();
        }
    }

    public void SetBrightness()
    {

        if (_repository.GetAll().Count == 0)
        {
            Console.WriteLine("there are no lamps \n" +
                "[Press a key to continue]");
            Console.ReadKey();
            return;
        }


        Console.WriteLine("Lamp id: ");
        string id = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(id))
        {
            Console.WriteLine("Id not valid \n[Press a key to continue]");
            Console.ReadKey();
        }

        Console.WriteLine("Brightness: ");
        string brightness = Console.ReadLine();
        Console.ReadLine();

        if (string.IsNullOrEmpty(brightness))
        { 
            Console.WriteLine("Brightness not valid \n[Press a key to continue]");
            Console.ReadKey();
        }

        try
        {
            Guid newId = new(id);
            int.TryParse(brightness, out int newBrightness);
            new SetBrightnessLampCommand(_repository).Execute(newId, newBrightness);
        }

        catch (Exception)
        {
            Console.WriteLine("Error. Lamp not found or britness not valid \n[Press a key to continue]");
            Console.ReadKey();
        } 
    }

    public void Brighten()
    {

        if (_repository.GetAll().Count == 0)
        {
            Console.WriteLine("there are no lamps \n" +
                "[Premere un tasto per continuare]");
            Console.ReadKey();
            return;
        }


        Console.WriteLine("Lamp id: ");
        string id = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(id))
        {
            Console.WriteLine("Id not valid \n[Press a key to continue]");
            Console.ReadKey();
        }

        Console.WriteLine("Brightness");
        string brightness = Console.ReadLine();

        if (string.IsNullOrEmpty(brightness))
        {
            Console.WriteLine("Brightness not valid \n[Press a key to continue]");
            Console.ReadKey();
        }

        try
        {
            Guid newId = new(id.Trim());
            int.TryParse(brightness, out int newBrightness);
            new BrightenLampCommand(_repository).Execute(newId, newBrightness);
        }

        catch (Exception)
        {
            Console.WriteLine("Error. Lamp not found or britness not valid \n[Press a key to continue]");
            Console.ReadKey();
        }
    }


    public void Dimmer()
    {

        if (_repository.GetAll().Count == 0)
        {
            Console.WriteLine("there are no lamps \n" +
                "[Premere un tasto per continuare]");
            Console.ReadKey();
            return;
        }


        Console.WriteLine("Lamp id: ");
        string id = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(id))
        {
            Console.WriteLine("Id not valid \n[Press a key to continue]");
            Console.ReadKey();
        }

        Console.WriteLine("Brightness");
        string brightness = Console.ReadLine();

        if (string.IsNullOrEmpty(brightness))
        {
            Console.WriteLine("Brightness not valid \n[Press a key to continue]");
            Console.ReadKey();
        }

        try
        {
            int.TryParse(brightness, out int newBrightness);
            Guid.TryParse(id, out Guid newId);
            new DimmerLampCommand(_repository).Execute(newId, newBrightness);
        }

        catch (Exception)
        {
            Console.WriteLine("Error. Lamp not found or britness not valid \n[Press a key to continue]");
            Console.ReadKey();
        }  
    }

    public void ShowAll()
    {
        foreach (Lamp lamp in _repository.GetAll())
        {
            LampDto lampDto = LampMapper.ToDto(lamp);

            Console.WriteLine($"Lamp Id: {lamp.Id} \n" +
                $"Lamp name: {lamp.Name.Value} \n" +
                $"Device status: {lamp.DeviceStatus} \n" +
                $"Lamp brightness: {lamp.Brightness.Value} \n" +
                $"Creation hour: {lamp.CreationHour} \n" +
                $"Last modified at: {lamp.LastModified} \n" + 
                $"---------------------------------- \n");
        }
    }


    public void ShowAllLampName()
    {
        foreach(Lamp lamp in _repository.GetAll())
        {
            LampDto lampDto = LampMapper.ToDto(lamp);
            Console.WriteLine($"1) {lamp.Name} \n" + "\n");
        }
    }
}

