using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        public async Task<ActionResult<string>> GetShifts()
        {
            return JsonConvert.SerializeObject( await _shiftsService.GetShifts());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<string>> GetOneShift(int id)
        {
            return JsonConvert.SerializeObject(await _shiftsService.GetOneShift(id));
        }

        [HttpPut]
        public async Task<ActionResult<string>> UpdateShift([FromBody] ShiftModel shiftData)
        {
            return JsonConvert.SerializeObject(await _shiftsService.UpdateShift(shiftData));
        }

        [HttpPost]
        public async Task<ActionResult<string>> InsertShift([FromBody] ShiftModel shiftData)
        {
            return JsonConvert.SerializeObject(await _shiftsService.InsertShift(shiftData));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteShift(int id)
        {
            return JsonConvert.SerializeObject(await _shiftsService.DeleteShift(id));
        }
    }
}
