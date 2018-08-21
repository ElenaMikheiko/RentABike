using System.Collections.Generic;
using RentABike.Models;
using RentABike.ViewModels;

namespace RentABike.Common.Interfaces
{
    public interface ITarriffService
    {
        Tarriff GetTarriffById(int tarriffId);

        IEnumerable<Tarriff> GetAllTarriffsByBikeTypeId(int? bikeTypeId);

        IEnumerable<Tarriff> GetAllTarriffs();

        Tarriff GetTarriffByIdWithKindRent(int tarriffId);

        IEnumerable<Tarriff> GetAllHoursTarriffsByBikeTypeId(int bikeTypeId);

        IEnumerable<Tarriff> GetAllDaysTarriffsByBikeTypeId(int bikeTypeId);

        void UpdateTarriff(TarriffViewModel vm);

        void CreateNewTarriff(TarriffViewModel vm);

        void DeleteTarriffByBikeTypeIdAndKindOfRent(int bikeTypeId, string kindOfRent);
    }
}
