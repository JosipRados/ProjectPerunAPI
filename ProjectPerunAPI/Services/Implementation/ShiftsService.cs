using Newtonsoft.Json;
using ProjectPerunAPI.Models;
using ProjectPerunAPI.Repository;
using System.Data;

namespace ProjectPerunAPI.Services.Implementation
{
    public class ShiftsService : IShiftsService
    {
        IShiftsRepository _shiftsRepository;
        public ShiftsService(IShiftsRepository shiftsRepository)
        {
            _shiftsRepository = shiftsRepository;
        }

        public async Task<ResponseModelNew> GetShifts()
        {
            DataTable resultDatabase;
            resultDatabase = await _shiftsRepository.GetShiftsDatabase();
            if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                return new ResponseModelNew(false, "Unable to get elements from database.", new DataTable());
            return new ResponseModelNew(true, "", resultDatabase);
        }

        public async Task<ResponseModelNew> GetOneShift(int id)
        {
            DataTable resultDatabase;
            resultDatabase = await _shiftsRepository.GetOneShiftDatabase(id);
            if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                return new ResponseModelNew(false, "Unable to get Shift " + id + " from database.", new DataTable());
            return new ResponseModelNew(true, "", resultDatabase);
        }

        public async Task<ResponseModelNew> UpdateShift(ShiftModel shiftData)
        {
            DataTable resultDatabase;
            resultDatabase = await _shiftsRepository.UpdateShiftDatabase(shiftData);
            if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                return new ResponseModelNew(false, "Unable to get Shifts from database.", new DataTable());
            return new ResponseModelNew(true, "", resultDatabase);
        }

        public async Task<ResponseModelNew> InsertShift(ShiftModel shiftData)
        {
            DataTable resultDatabase;
            resultDatabase = await _shiftsRepository.InsertShiftDatabase(shiftData);
            if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                return new ResponseModelNew(false, "Unable to get Shifts from database.", new DataTable());
            return new ResponseModelNew(true, "", resultDatabase);
        }

        public async Task<ResponseModelNew> DeleteShift(int id)
        {
            DataTable resultDatabase;
            resultDatabase = await _shiftsRepository.DeleteShiftDatabase(id);
            if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                return new ResponseModelNew(false, "Unable to get Shift " + id + " from database.", new DataTable());
            return new ResponseModelNew(true, "", resultDatabase);
        }
    }
}
