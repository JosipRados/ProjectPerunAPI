using ProjectPerunAPI.Models;

namespace ProjectPerunAPI.Services
{
    public interface IShiftsService
    {
        Task<ResponseModel> DeleteShift(int id);
        Task<ResponseModel> GetOneShift(int id);
        Task<ResponseModel> GetShifts();
        Task<ResponseModel> InsertShift(ShiftModel shiftData);
        Task<ResponseModel> UpdateShift(ShiftModel shiftData);
    }
}
