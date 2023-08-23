using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectPerunAPI.Models;
using ProjectPerunAPI.Services;
using System.Data;

namespace ProjectPerunAPI.Controllers
{
    [Route("api/warehouse")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        IWarehouseService _warehouseService;
        public WarehouseController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        [HttpGet]
        public async Task<ActionResult<string>> GetWarehouseData()
        {
            return JsonConvert.SerializeObject(await _warehouseService.GetWarehouseData());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<string>> GetOneWarehouseData(int id)
        {
            return JsonConvert.SerializeObject(await _warehouseService.GetOneWarehouseData(id));
        }

        [HttpPut]
        public async Task<ActionResult<string>> UpdateWarehouseData([FromBody] WarehouseDataWrapperModel? warehouseData)
        {
            if (warehouseData == null)
                return JsonConvert.SerializeObject(new ResponseModelNew(false, "Empty request!", new DataTable()));
            return JsonConvert.SerializeObject(await _warehouseService.UpdateWarehouseData(warehouseData.WarehouseData));
        }

        [HttpPost]
        public async Task<ActionResult<string>> InsertWarehouseData([FromBody] WarehouseDataWrapperModel? batchData)
        {
            if (batchData == null)
                return JsonConvert.SerializeObject(new ResponseModelNew(false, "Empty request!", new DataTable()));
            return JsonConvert.SerializeObject(await _warehouseService.InsertWarehouseData(batchData.WarehouseData));
        }

        [HttpDelete]
        public async Task<ActionResult<string>> DeleteWarehouseData(WarehouseDataWrapperModel? batchData)
        {
            if (batchData == null)
                return JsonConvert.SerializeObject(new ResponseModelNew(false, "Empty request!", new DataTable()));
            return JsonConvert.SerializeObject(await _warehouseService.DeleteWarehouseData(batchData.WarehouseData));
        }
    }
}
