using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectPerunAPI.Models;
using ProjectPerunAPI.Services;

namespace ProjectPerunAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftsController : ControllerBase
    {
        IShiftsService _shiftsService;
        public ShiftsController(IShiftsService shiftsService)
        {
            _shiftsService = shiftsService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseModel>> GetShifts()
        {
            return await _shiftsService.GetShifts();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseModel>> GetOneShift(int id)
        {
            return await _shiftsService.GetOneShift(id);
        }

        [HttpPut]
        public async Task<ActionResult<ResponseModel>> UpdateShift([FromBody] ShiftModel shiftData)
        {
            return await _shiftsService.UpdateShift(shiftData);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel>> InsertShift([FromBody] ShiftModel shiftData)
        {
            return await _shiftsService.InsertShift(shiftData);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseModel>> DeleteShift(int id)
        {
            return await _shiftsService.DeleteShift(id);
        }
    }
}
