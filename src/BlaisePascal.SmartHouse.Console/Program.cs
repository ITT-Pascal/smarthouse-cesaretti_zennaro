using BlaisePascal.SmartHouse.Domain.Devices.Illumination.Repositories;
using BlaisePascal.SmartHouse.Infrastructure.Repositories.InMemory.Devices.LuminousDevices;

class Program
{
    public static void Main()
    {
        ILampRepository repository = new InMemoryLampRepository();
        LampController controller = new LampController(repository);
        bool firstTime = true;
        bool finished = false;
        while (!finished)
        {
            Console.Clear();
            Console.Write("\x1b[3J");
            controller.ShowAllLamps();

            if (firstTime)
            {
                controller.ShowAdvises();
                firstTime = false;
            }

            controller.ShowMenu();
        }
    }
}
        

    

