using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectPerunAPI.Models;
using ProjectPerunAPI.Services;
using ProjectPerunAPI.Services.Implementation;

namespace ProjectPerunAPI.Controllers
{
    [Route("api/material-data")]
    [ApiController]
    public class MaterialDataContoller : ControllerBase
    {
        IMaterialDataService _materialDataService;

        public MaterialDataContoller(IMaterialDataService materialDataService)
        {
            _materialDataService = materialDataService;
        }

        [HttpGet]
        public async Task<ActionResult<string>> GetElements()
        {
            return JsonConvert.SerializeObject( await _materialDataService.GetMaterialData());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseModel>> GetOneElement(int id)
        {
            return await _materialDataService.GetOneMaterialData(id);
        }

        [HttpPut]
        public async Task<ActionResult<ResponseModel>> UpdateElement([FromBody] MaterialDataModel elementData)
        {
            return await _materialDataService.UpdateMaterialData(elementData);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel>> InsertElement([FromBody] MaterialDataModel elementData)
        {
            return await _materialDataService.InsertMaterialData(elementData);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseModel>> DeleteElement(int id)
        {
            return await _materialDataService.DeleteMaterialData(id);
        }
    }
}
