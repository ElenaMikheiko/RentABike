using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentABike.DataProvider.Interfaces;
using RentABike.Logic.Interfaces;
using RentABike.Models;

namespace RentABike.Logic
{
    public class TarriffService : ITarriffService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TarriffService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Tarriff> GetAllDaysTarriffsByBikeTypeId(int bikeTypeId)
        {
            return GetAllTarriffsByBikeTypeId(bikeTypeId).Where(t => t.KindOfRent.Kind == "day(s)");
        }

        public IEnumerable<Tarriff> GetAllHoursTarriffsByBikeTypeId(int bikeTypeId)
        {
            return GetAllTarriffsByBikeTypeId(bikeTypeId).Where(t => t.KindOfRent.Kind == "hour(s)");
        }

        public IEnumerable<Tarriff> GetAllTarriffsByBikeTypeId(int bikeTypeId)
        {
            var allTarriffs = _unitOfWork.TarriffRepository.GetWithInclude(t => t.KindOfRent);

            var tarriffs = allTarriffs.SelectMany(tarriff => tarriff.BikeTypes,
                    (tarriff, bikeType) => new {Tarriff = tarriff, BikeType = bikeType})
                .Where(tarriff => tarriff.BikeType.Id == bikeTypeId).Select(tarriff => tarriff.Tarriff);

            return tarriffs;
        }

        public IEnumerable<Tarriff> GetAllTarriffsWithKindRent(int tarriffId)
        {
            throw new NotImplementedException();
        }

        public Tarriff GetTarriffById(int tarriffId)
        {
            return _unitOfWork.TarriffRepository.FindById(tarriffId);
        }

        public Tarriff GetTarriffByIdWithKindRent(int tarriffId)
        {
            var tarriffs = _unitOfWork.TarriffRepository.GetWithInclude(t => t.KindOfRent);
            return tarriffs.FirstOrDefault(t => t.Id == tarriffId);
        }
    }
}
