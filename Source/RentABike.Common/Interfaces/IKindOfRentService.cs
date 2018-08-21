using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentABike.Models;

namespace RentABike.Logic.Interfaces
{
    public interface IKindOfRentService
    {
        IEnumerable<KindOfRent> GetAllKindsOfRent();

        KindOfRent GetKindOfRentByName(string kind);
    }
}
