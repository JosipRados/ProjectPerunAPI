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
            var invocationObject = _storageService.GetAllElements();
            invocationObject.TableName = "StorageMaterial";
            var json = JsonConvert.SerializeObject(invocationObject);
            return json;
            
        } 
    }
}
