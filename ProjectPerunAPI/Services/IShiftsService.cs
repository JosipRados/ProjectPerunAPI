using ProjectPerunAPI.Models;

namespace ProjectPerunAPI.Services
{
    public interface IShiftsService
    {
        Task<ResponseModelNew> DeleteShift(int id);
        Task<ResponseModelNew> GetOneShift(int id);
        Task<ResponseModelNew> GetShifts();
        Task<ResponseModelNew> InsertShift(ShiftModel shiftData);
        Task<ResponseModelNew> UpdateShift(ShiftModel shiftData);
    }
}
