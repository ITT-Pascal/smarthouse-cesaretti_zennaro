using BlaisePascal.SmartHouse.Application.Devices.Luminuos.Lamps.Commands;
using BlaisePascal.SmartHouse.Application.Devices.Luminuos.Lamps.Queries;
using BlaisePascal.SmartHouse.Application.Devices.LuminuosDevices.LampDevice.Commands;
using BlaisePascal.SmartHouse.Application.Devices.LuminuosDevices.Lamps.Commands;
using BlaisePascal.SmartHouse.Application.Devices.LuminuosDevices.Lamps.Dto;
using BlaisePascal.SmartHouse.Domain.Devices.Abstraction.ValueObjects;
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
            return;
        }

        new AddLampCommand(_repository).Execute(name);
    }

    public void RemoveLamp()
    {
        List<LampDto> lamps = new GetAllLampsQuery(_repository).Execute();

        if (lamps.Count == 0)
        {
            Console.WriteLine("There are no lamps\n[Premere un tasto per continuare]");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("Lamp number: ");
        string number = Console.ReadLine();


        if (string.IsNullOrWhiteSpace(number) || !int.TryParse(number, out int n))
        {
            Console.WriteLine("Number not valid \n[Press a key to continue]");
            Console.ReadKey();
            return;
        }

        try
        {
            int.TryParse(number, out int lampNumber);
            new RemoveLampCommand(_repository).Execute(lamps[lampNumber - 1].Id);
        }

        catch (Exception)
        {
            Console.WriteLine("Lamp not found \n[Press a key to continue]");
            Console.ReadKey();
            return;
        }
    }

    public void RenameLamp()
    {
        List<LampDto> lamps = new GetAllLampsQuery(_repository).Execute();

        if (lamps.Count == 0)
        {
            Console.WriteLine("There are no lamps \n[Premere un tasto per continuare]");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("Lamp number: ");
        string number = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(number) || !int.TryParse(number, out int n))
        {
            Console.WriteLine("Number not valid \n[Press a key to continue]");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("New name: ");
        string newName = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(newName))
        {
            Console.WriteLine("Name not valid \n[Press a key to continue]");
            Console.ReadKey();
            return;
        }

        new RenameLampCommand(_repository).Execute(newName, lamps[n - 1].Id);
    }

    public void SwitchOn()
    {
        List<LampDto> lamps = new GetAllLampsQuery(_repository).Execute();

        if (lamps.Count == 0)
        {
            Console.WriteLine("There are no lamps \n[Premere un tasto per continuare]");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("Lamp number: ");
        string number = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(number) || !int.TryParse(number, out int n))
        {
            Console.WriteLine("Number not valid \n[Press a key to continue]");
            Console.ReadKey();
            return;
        }

        try
        {
            int.TryParse(number, out int lampNumber);
            new SwitchOnLampCommand(_repository).Execute(lamps[lampNumber - 1].Id);
        }

        catch (InvalidOperationException)
        {
            Console.WriteLine("Lamp is already on\n[Press a key to continue]");
            Console.ReadKey();
            return;

        }

        catch (Exception)
        {
            Console.WriteLine("Lamp not found \n[Press a key to continue]");
            Console.ReadKey();
            return;
        }
    }

    public void SwitchOff()
    {
        List<LampDto> lamps = new GetAllLampsQuery(_repository).Execute();

        if (lamps.Count == 0)
        {
            Console.WriteLine("There are no lamps \n[Premere un tasto per continuare]");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("Lamp number: ");
        string number = Console.ReadLine();

        if(string.IsNullOrWhiteSpace(number) || !int.TryParse(number, out int n))
        {
            Console.WriteLine("Number not valid \n[Press a key to continue]");
            Console.ReadKey();
            return;
        }

        try
        {
            int.TryParse(number, out int lampNumber);
            new SwitchOffLampCommand(_repository).Execute(lamps[lampNumber - 1].Id);
        }

        catch (InvalidOperationException)
        {
            Console.WriteLine("Lamp is already off\n[Press a key to continue]");
            Console.ReadKey();
            return;
        }

        catch (Exception)
        {
            Console.WriteLine("Lamp not found \n[Press a key to continue]");
            Console.ReadKey();
            return;
        }
    }

    public void SetBrightness()
    {
        List<LampDto> lamps = new GetAllLampsQuery(_repository).Execute();

        if (lamps.Count == 0)
        {
            Console.WriteLine("there are no lamps \n[Press a key to continue]");
            Console.ReadKey();
            return;
        }


        Console.WriteLine("Lamp number: ");
        string number = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(number) || !int.TryParse(number, out int n))
        {
            Console.WriteLine("Number not valid \n[Press a key to continue]");
            Console.ReadKey();
            return;
        }

        if(n < 0 || n > lamps.Count)
        {
            Console.WriteLine("Lamp not found\n[Press a key to continue]");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("Brightness: ");
        string brightness = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(number) || !int.TryParse(brightness, out int b))
        {
            Console.WriteLine("Brightness not valid \n[Press a key to continue]");
            Console.ReadKey();
            return;
        }

        try
        {
            int.TryParse(brightness, out int newBrightness);
            int.TryParse(number, out int lampNumber);
            new SetBrightnessLampCommand(_repository).Execute(lamps[lampNumber - 1].Id, newBrightness);
        }
        catch (InvalidOperationException)
        {
            Console.WriteLine("Cannot change brightness when lamp is off.\n[Press a key to continue]");
            Console.ReadKey();
            return;
        }

        catch (Exception)
        {
            Console.WriteLine("Error.\n[Press a key to continue]");
            Console.ReadKey();
            return;
        }
    }

    public void Brighten()
    {
        List<LampDto> lamps = new GetAllLampsQuery(_repository).Execute();

        if (lamps.Count == 0)
        {
            Console.WriteLine("there are no lamps \n[Premere un tasto per continuare]");
            Console.ReadKey();
            return;
        }


        Console.WriteLine("Lamp number: ");
        string number = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(number) || !int.TryParse(number, out int n))
        {
            Console.WriteLine("Number not valid \n[Press a key to continue]");
            Console.ReadKey();
            return;
        }

        if (n < 0 || n > lamps.Count)
        {
            Console.WriteLine("Lamp not found\n[Press a key to continue]");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("Value: ");
        string value = Console.ReadLine();

        if (string.IsNullOrEmpty(value) || !int.TryParse(value, out int v))
        {
            Console.WriteLine("Value not valid \n[Press a key to continue]");
            Console.ReadKey();
            return;
        }

        try
        {
            int.TryParse(number, out int lampNumber);
            int.TryParse(value, out int newBrightness);
            new BrightenLampCommand(_repository).Execute(lamps[lampNumber - 1].Id, newBrightness);
        }

        catch (InvalidOperationException)
        {
            Console.WriteLine("Cannot change brightness when lamp is off.\n[Press a key to continue]");
            Console.ReadKey();
            return;
        }

        catch (Exception)
        {
            Console.WriteLine("Error.\n[Press a key to continue]");
            Console.ReadKey();
            return;
        }
    }


    public void Dimmer()
    {
        List<LampDto> lamps = new GetAllLampsQuery(_repository).Execute();

        if (lamps.Count == 0)
        {
            Console.WriteLine("there are no lamps \n[Premere un tasto per continuare]");
            Console.ReadKey();
            return;
        }


        Console.WriteLine("Lamp number: ");
        string number = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(number) || !int.TryParse(number, out int n))
        {
            Console.WriteLine("Number not valid \n[Press a key to continue]");
            Console.ReadKey();
            return;
        }

        if (n < 0 || n > lamps.Count)
        {
            Console.WriteLine("Lamp not found\n[Press a key to continue]");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("Value: ");
        string value = Console.ReadLine();

        if (string.IsNullOrEmpty(value) || !int.TryParse(value, out int v))
        {
            Console.WriteLine("Value not valid \n[Press a key to continue]");
            Console.ReadKey();
            return;
        }

        try
        {
            int.TryParse(number, out int lampNumber);
            int.TryParse(value, out int newBrightness);
            new DimmerLampCommand(_repository).Execute(lamps[lampNumber - 1].Id, newBrightness);
        }

        catch (InvalidOperationException)
        {
            Console.WriteLine("Cannot change brightness when lamp is off.\n[Press a key to continue]");
            Console.ReadKey();
            return;
        }

        catch (Exception)
        {
            Console.WriteLine("Error.\n[Press a key to continue]");
            Console.ReadKey();
            return;
        }
    }

    public void ShowAdvises()
    {
        Console.Write("ADVISES:\n" +
                    "- Cannot modify lamp when it is off\n" +
                    "- Lamp brightness min value: 0\n" +
                    "- Lamp brightness max value: 100\n" +
                    "- Switch off does not change lamp brightness\n" +
                    "- If you set value under the min or over the max, brightness will be set at min or max\n" +
                    "\n");
    }

    public void ShowAllLamps()
    {
        List<LampDto> lamps = new GetAllLampsQuery(_repository).Execute();

        for (int i = 0; i < lamps.Count; i++)
        {
            Console.WriteLine($"{i + 1}) {lamps[i].Name}\n{lamps[i].ToString()}\n--------------------\n");
        }
    }

    public void ShowMenu()
    {
        Console.WriteLine("Select a command: \n" +
            "1 [Add lamp] \n" +
            "2 [Remove lamp] \n" +
            "3 [Rename lamp] \n" +
            "4 [Switch on lamp] \n" +
            "5 [Switch off lamp] \n" +
            "6 [Set lamp brightness] \n" +
            "7 [Brighten lamp] \n" +
            "8 [Dimmer lamp] \n" +
            "9 [ShowAdvises] \n" +
            "10 [Exit]\n" +
            "\n" +
            "Choose an option:");

        string input = Console.ReadLine();

        switch (input)
        {
            case "1":
                AddLamp();
                break;
            case "2":
                RemoveLamp();
                break;
            case "3":
                RenameLamp();
                break;
            case "4":
                SwitchOn();
                break;
            case "5":
                SwitchOff();
                break;
            case "6":
                SetBrightness();
                break;
            case "7":
                Brighten();
                break;
            case "8":
                Dimmer();
                break;
            case "9":
                Console.Clear();
                Console.Write("\x1b[3J");
                ShowAdvises();
                Console.Write("Press a key to continue");
                Console.ReadKey();
                break;
            case "10":
                Console.Write("Press a key to exit");
                Console.ReadKey();
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Command not valid");
                break;
        }
    }

    
}

