using BlaisePascal.SmartHouse.Application.Devices.DoorDevice.Commands;
using BlaisePascal.SmartHouse.Application.Devices.DoorDevice.Dto;
using BlaisePascal.SmartHouse.Domain.Devices.Door.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DoorController
{
    private readonly IDoorRepository _repository;

    public DoorController(IDoorRepository repository)
    {
        _repository = repository;
    }

    public void AddDoor()
    {
        Console.WriteLine("Door name: ");
        string name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Name not valid \n[Press a key to continue]");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("Password: ");
        string password = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(password))
        {
            Console.WriteLine("Password not valid \n[Press a key to continue]");
            Console.ReadKey();
            return;
        }

        new AddDoorCommand(_repository).Execute(name, password);
    }

    public void ShowAllDoors()
    {
        List<DoorDto> doors = new List<DoorDto>();
        for (int i = 0; i < doors.Count; i++)
        {
            Console.WriteLine($"{i + 1}")
        }


}

