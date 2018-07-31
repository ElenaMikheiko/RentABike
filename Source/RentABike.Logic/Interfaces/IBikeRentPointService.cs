using RentABike.ViewModels;

namespace RentABike.Logic.Interfaces
{
    public interface IBikeRentPointService
    {
        void SaveBikeAndRentPoint(CreationBikeViewModel vm);
    }
}