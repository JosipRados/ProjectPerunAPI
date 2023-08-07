using ProjectPerunAPI.Models;
using System.Data;

namespace ProjectPerunAPI.Repository
{
    public interface IShiftsRepository
    {
        Task<DataTable> DeleteShiftDatabase(int id);
        Task<DataTable> GetOneShiftDatabase(int id);
        Task<DataTable> GetShiftsDatabase();
        Task<DataTable> InsertShiftDatabase(ShiftModel shiftData);
        Task<DataTable> UpdateShiftDatabase(ShiftModel shiftData);
    }
}