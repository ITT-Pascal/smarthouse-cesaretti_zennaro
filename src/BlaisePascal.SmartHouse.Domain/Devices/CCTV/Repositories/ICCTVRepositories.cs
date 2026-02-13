using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.CCTV.Repositories
{
    public interface ICCTVRepositories
    {
        void Add(CCTV cctv);
        void Update(CCTV cctv);
        void Remove(Guid id);
        CCTV GetById(Guid id);
        List<CCTV> GetAll();
    }
}
