using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
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
        public ActionResult<string> GetAllStorage()
        {
            var invocationObject = _storageService.GetAllStorage();
            invocationObject.TableName = "StorageMaterial";
            var json = JsonConvert.SerializeObject(invocationObject);
            return json;

        }

        [HttpGet("{id}")]
        public ActionResult<string> GetOneMaterial(int id)
        {
            var invocationObject = _storageService.GetOneMaterial(id);
            var json = JsonConvert.SerializeObject(invocationObject);
            return json;
        }
    }
}
