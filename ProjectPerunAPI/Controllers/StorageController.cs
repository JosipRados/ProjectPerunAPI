using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using ProjectPerunAPI.Models;
using ProjectPerunAPI.Services;
using ProjectPerunAPI.Services.Implementation;
using System.Data;
using System.Net;

namespace ProjectPerunAPI.Controllers
{
    [Route("api/storage")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        IStorageService _storageService;
        public StorageController(IStorageService storageService)
        {
            _storageService = storageService;
        }

        [HttpGet("all/{pageNumber}")]
        public async Task<ActionResult<string>> GetAllStorage(int pageNumber)
        {
            return JsonConvert.SerializeObject(await _storageService.GetAllStorage());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<string>> GetOneMaterial(int id)
        {
            return JsonConvert.SerializeObject(await _storageService.GetOneMaterial(id));
        }

        [HttpGet("material-number")]
        public async Task<ActionResult<string>> GetLastMaterialNumber()
        {
            return JsonConvert.SerializeObject(await _storageService.GetLastMaterialNumber());
        }

        [HttpPut]
        public async Task<ActionResult<string>> UpdateMaterial([FromBody] MaterialTransactionWrapperModel materialData)
        {
            return JsonConvert.SerializeObject(await _storageService.UpdateMaterialData(materialData.StorageData));
        }

        [HttpPost]
        public async Task<string> InsertMaterialData([FromBody] MaterialTransactionWrapperModel materialData)
        {
            return JsonConvert.SerializeObject( await _storageService.InsertMaterialData(materialData.StorageData));
        }

        [HttpDelete]
        public async Task<string> DeleteMaterialData([FromBody] MaterialDeleteWrapperModel materialData)
        {
            return JsonConvert.SerializeObject( await _storageService.DeleteMaterialData(materialData.materialData));
        }

        [HttpPut("export-to-order")]
        public async Task<string> ExportMaterialToOrder([FromBody] OrderMaterialWrapperModel materialData)
        {
            return JsonConvert.SerializeObject(await _storageService.ExportMaterialToOrder(materialData.OrderMaterialData));
        }
    }
}
