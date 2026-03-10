using BlaisePascal.SmartHouse.Application.Devices.Luminuos.Lamps.Commands;
using BlaisePascal.SmartHouse.Application.Devices.Luminuos.Lamps.Queries;
using BlaisePascal.SmartHouse.Application.Devices.LuminuosDevices.Lamps.Commands;
using BlaisePascal.SmartHouse.Application.Devices.LuminuosDevices.Lamps.Dto;
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

        catch (Exception)
        {
            Console.WriteLine("Error.\n[Press a key to continue]");
            Console.ReadKey();
            return;
        }
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
        ShowAllLamps();
        Console.WriteLine("Select a command: \n" +
            "1 [Add lamp] \n" +
            "2 [Remove lamp] \n" +
            "3 [Switch on lamp] \n" +
            "4 [Switch off lamp] \n" +
            "5 [Set lamp brightness] \n" +
            "6 [Brighten lamp] \n" +
            "7 [Dimmer lamp] \n" +
            "8 [Exit] \n");

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
                SwitchOn();
                break;
            case "4":
                SwitchOff();
                break;
            case "5":
                SetBrightness();
                break;
            case "6":
                Brighten();
                break;
            case "7":
                Dimmer();
                break;
            case "8":
                Console.Write("Press a key to exit");
                Console.ReadKey();
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("command not valid");
                break;
        }
    } 
}

