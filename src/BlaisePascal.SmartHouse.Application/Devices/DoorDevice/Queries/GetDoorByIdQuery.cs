using BlaisePascal.SmartHouse.Domain.Devices.Door.Repositories;
using BlaisePascal.SmartHouse.Domain.Devices.Door;

namespace BlaisePascal.SmartHouse.Application.Devices.DoorDevice.Queries
{
    public class GetDoorByIdQuery
    {
        private readonly IDoorRepository _repository;

        public GetDoorByIdQuery (IDoorRepository repository)
        {
            _repository = repository;
        }

        public Door Execute(Guid id)
        {
            return _repository.GetById(id);
        } 

    }
}
