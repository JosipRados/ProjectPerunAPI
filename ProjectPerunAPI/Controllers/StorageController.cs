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
        public async Task<ActionResult<ResponseModel>> GetOneMaterial(int id)
        {
            return await _storageService.GetOneMaterial(id);
        }

        [HttpPut]
        public async Task<ActionResult<ResponseModel>> UpdateMaterial([FromBody] MaterialTransactionWrapperModel materialData)
        {
            return await _storageService.UpdateMaterialData(materialData.materialData);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel>> InsertMaterialData([FromBody] MaterialTransactionWrapperModel materialData)
        {
            return await _storageService.InsertMaterialData(materialData.materialData);
        }

        [HttpDelete]
        public async Task<ActionResult<ResponseModel>> DeleteMaterialData([FromBody] MaterialDeleteWrapperModel materialData)
        {
            return await _storageService.DeleteMaterialData(materialData.materialData);
        }
    }
}
