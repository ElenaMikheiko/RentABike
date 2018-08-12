using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentABike.Models;

namespace RentABike.Logic.Interfaces
{
    public interface ITarriffService
    {
        Tarriff GetTarriffById(int tarriffId);

        IEnumerable<Tarriff> GetAllTarriffsByBikeTypeId(int bikeTypeId);

        IEnumerable<Tarriff> GetAllTarriffsWithKindRent(int tarriffId);

        Tarriff GetTarriffByIdWithKindRent(int tarriffId);

        IEnumerable<Tarriff> GetAllHoursTarriffsByBikeTypeId(int bikeTypeId);

        IEnumerable<Tarriff> GetAllDaysTarriffsByBikeTypeId(int bikeTypeId);

    }
}
