using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectPerunAPI.Models;
using ProjectPerunAPI.Services;
using System.Data;

namespace ProjectPerunAPI.Controllers
{
    [Route("api/batch")]
    [ApiController]
    public class BatchController : ControllerBase
    {
        IBatchService _batchService;
        public BatchController(IBatchService batchService)
        {
            _batchService = batchService;
        }

        [HttpGet]
        public async Task<ActionResult<string>> GetBatchData()
        {
            return JsonConvert.SerializeObject(await _batchService.GetBatchData());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<string>> GetOneBatchData(int id)
        {
            return JsonConvert.SerializeObject(await _batchService.GetOneBatchData(id));
        }

        [HttpGet("batch-number")]
        public async Task<ActionResult<string>> GetNewBatchNumber(int id)
        {
            return JsonConvert.SerializeObject(await _batchService.GetNewBatchNumber());
        }

        [HttpPut]
        public async Task<ActionResult<string>> UpdateBatchData([FromBody] BatchDataWrapperModel? batchData)
        {
            if (batchData == null || batchData.BatchData == null)
                return JsonConvert.SerializeObject(new ResponseModelNew(false, "Empty request!", new DataTable()));
            return JsonConvert.SerializeObject(await _batchService.UpdateBatchData(batchData.BatchData));
        }

        [HttpPost]
        public async Task<ActionResult<string>> InsertBatchData([FromBody] BatchDataWrapperModel? batchData)
        {
            if (batchData == null || batchData.BatchData == null)
                return JsonConvert.SerializeObject(new ResponseModelNew(false, "Empty request!", new DataTable()));
            return JsonConvert.SerializeObject(await _batchService.InsertBatchData(batchData.BatchData));
        }

        [HttpDelete]
        public async Task<ActionResult<string>> DeleteBatchData(BatchDataWrapperModel? batchData)
        {
            if (batchData == null || batchData.BatchData == null)
                return JsonConvert.SerializeObject(new ResponseModelNew(false, "Empty request!", new DataTable()));
            return JsonConvert.SerializeObject(await _batchService.DeleteBatchData(batchData.BatchData));
        }
    }
}
