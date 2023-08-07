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

        public async Task<ResponseModel> GetShifts()
        {
            DataTable resultDatabase;
            resultDatabase = await _shiftsRepository.GetShiftsDatabase();
            if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                return new ResponseModel(false, "Unable to get elements from database.", "");
            return new ResponseModel(true, "", JsonConvert.SerializeObject(resultDatabase));
        }

        public async Task<ResponseModel> GetOneShift(int id)
        {
            DataTable resultDatabase;
            resultDatabase = await _shiftsRepository.GetOneShiftDatabase(id);
            if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                return new ResponseModel(false, "Unable to get Shift " + id + " from database.", "");
            return new ResponseModel(true, "", JsonConvert.SerializeObject(resultDatabase));
        }

        public async Task<ResponseModel> UpdateShift(ShiftModel shiftData)
        {
            DataTable resultDatabase;
            resultDatabase = await _shiftsRepository.UpdateShiftDatabase(shiftData);
            if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                return new ResponseModel(false, "Unable to get Shifts from database.", "");
            return new ResponseModel(true, "", JsonConvert.SerializeObject(resultDatabase));
        }

        public async Task<ResponseModel> InsertShift(ShiftModel shiftData)
        {
            DataTable resultDatabase;
            resultDatabase = await _shiftsRepository.InsertShiftDatabase(shiftData);
            if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                return new ResponseModel(false, "Unable to get Shifts from database.", "");
            return new ResponseModel(true, "", JsonConvert.SerializeObject(resultDatabase));
        }

        public async Task<ResponseModel> DeleteShift(int id)
        {
            DataTable resultDatabase;
            resultDatabase = await _shiftsRepository.DeleteShiftDatabase(id);
            if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                return new ResponseModel(false, "Unable to get Shift " + id + " from database.", "");
            return new ResponseModel(true, "", JsonConvert.SerializeObject(resultDatabase));
        }
    }
}
