using RentABike.ViewModels;

namespace RentABike.Common.Interfaces
{
    public interface IBikeRentPointService
    {
        void SaveBikeAndRentPoint(CreationBikeViewModel vm);
    }
}