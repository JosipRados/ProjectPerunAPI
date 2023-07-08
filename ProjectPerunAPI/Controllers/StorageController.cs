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

        [HttpGet]
        public ActionResult<ResponseModel> GetAllStorage()
        {
            return _storageService.GetAllStorage();
        }

        [HttpGet("{id}")]
        public ActionResult<string> GetOneMaterial(int id)
        {
            var serviceObject = _storageService.GetOneMaterial(id);
            var json = JsonConvert.SerializeObject(serviceObject);
            return json;
        }

        [HttpPut]
        public ActionResult<string> UpdateOneMaterial([FromBody] MaterialModel materialData)
        {
            var serviceObject = _storageService.UpdateMaterialData(materialData);
            return "";
        }
    }
}
