using BlaisePascal.SmartHouse.Domain.Devices.Illumination.Repositories;
using BlaisePascal.SmartHouse.Infrastructure.Repositories.InMemory.Devices.LuminousDevices;

class Program
{
    public static void Main()
    {
        ILampRepository repository = new InMemoryLampRepository();
        LampController controller = new LampController(repository);

        bool finished = false;
        while (!finished)
        {
            Console.Clear();
            Console.Write("\x1b[3J");
            controller.ShowAllLamps();
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
                    controller.AddLamp();
                    break;
                case "2":
                    controller.RemoveLamp();
                    break;
                case "3":
                    controller.SwitchOn();
                    break;
                case "4":
                    controller.SwitchOff();
                    break;
                case "5":
                    controller.SetBrightness();
                    break;
                case "6":
                    controller.Brighten();
                    break;
                case "7":
                    controller.Dimmer();
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
}
        

    

