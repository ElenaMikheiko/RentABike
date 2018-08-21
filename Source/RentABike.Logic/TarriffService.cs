using System.Collections.Generic;
using System.Linq;
using RentABike.Common.Interfaces;
using RentABike.Models;
using RentABike.ViewModels;

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

        public IEnumerable<Tarriff> GetAllTarriffsByBikeTypeId(int? bikeTypeId)
        {
            var allTarriffs = _unitOfWork.TarriffRepository.GetWithInclude(t => t.KindOfRent);

            var tarriffs = allTarriffs.SelectMany(tarriff => tarriff.BikeTypes,
                    (tarriff, bikeType) => new {Tarriff = tarriff, BikeType = bikeType})
                .Where(tarriff => tarriff.BikeType.Id == bikeTypeId).Select(tarriff => tarriff.Tarriff);

            return tarriffs;
        }

        public IEnumerable<Tarriff> GetAllTarriffs()
        {
            return _unitOfWork.TarriffRepository.GetAll();
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

        public void UpdateTarriff(TarriffViewModel vm)
        {
            var tarriffs = _unitOfWork.BikeTypeRepository.FindById(vm.BikeType.Id).Tarriffs;

            foreach (var tarriff in tarriffs)
            {
                var vmTarriff = vm.Tarriffs.FirstOrDefault(vmt =>
                    vmt.KindOfRent.Id == tarriff.KindOfRentId && vmt.Quantity == tarriff.Quantity);
                if (vmTarriff!=null)
                {
                    tarriff.Amount = vmTarriff.Amount;
                    _unitOfWork.TarriffRepository.Update(tarriff);
                }
            }
            _unitOfWork.Save();
        }

        public void CreateNewTarriff(TarriffViewModel vm)
        {
            List<Tarriff> newTarriffs = new List<Tarriff>();
            foreach (var tarriff in vm.Tarriffs)
            {
                var itemTarriff = new Tarriff();
                itemTarriff.BikeTypes.Add(_unitOfWork.BikeTypeRepository.FindById(vm.BikeType.Id));
                itemTarriff.KindOfRent = _unitOfWork.KindOfRentRepository.FindById(tarriff.KindOfRent.Id);
                itemTarriff.Quantity = tarriff.Quantity;
                itemTarriff.Amount = tarriff.Amount;
                newTarriffs.Add(itemTarriff);
            }

            foreach (var newTarriff in newTarriffs)
            {
                _unitOfWork.TarriffRepository.Create(newTarriff);

            }
            _unitOfWork.Save();
        }

        public void DeleteTarriffByBikeTypeIdAndKindOfRent(int bikeTypeId, string kindOfRent)
        {
            var tarriffs = _unitOfWork.BikeTypeRepository.FindById(bikeTypeId).Tarriffs;

            tarriffs = tarriffs.Where(t => t.KindOfRent.Kind == kindOfRent).ToList();
            foreach (var tarriff in tarriffs)
            {
                _unitOfWork.TarriffRepository.Remove(tarriff);
            }
            _unitOfWork.Save();
        }
    }
}
