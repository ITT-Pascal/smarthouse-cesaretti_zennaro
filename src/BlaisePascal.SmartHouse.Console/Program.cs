using BlaisePascal.SmartHouse.Domain.Devices.Door.Repositories;
using BlaisePascal.SmartHouse.Domain.Devices.Illumination.Repositories;
using BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.DoorDevice;
using BlaisePascal.SmartHouse.Infrastructure.Repositories.InMemory.Devices.LuminousDevices;

class Program
{
    public static void Main()
    { 
        Console.WriteLine("Choose controller: \n" +
            "1) Lamp controller\n" +
            "2) Door controller");
        string input = Console.ReadLine();

        switch (input)
        {
            case "1":
                ILampRepository lampRepository = new InMemoryLampRepository();
                LampController lampController = new LampController(lampRepository);
                lampController.ShowMenu();
                break;

            case "2":
                IDoorRepository doorRepository = new InMemoryDoorRepository();
                DoorController doorController = new DoorController(doorRepository);
                doorController.ShowMenu();
                break;
        }
    }
}
        

    

