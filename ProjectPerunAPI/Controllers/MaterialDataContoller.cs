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
        public async Task<ActionResult<string>> GetOneElement(int id)
        {
            return JsonConvert.SerializeObject( await _materialDataService.GetOneMaterialData(id));
        }

        [HttpPut]
        public async Task<ActionResult<string>> UpdateElement([FromBody] MaterialDataWrapperModel materialData)
        {
            return JsonConvert.SerializeObject( await _materialDataService.UpdateMaterialData(materialData.MaterialData));
        }

        [HttpPost]
        public async Task<ActionResult<string>> InsertMaterialData([FromBody] MaterialDataWrapperModel materialData)
        {
            return JsonConvert.SerializeObject( await _materialDataService.InsertMaterialData(materialData.MaterialData));
        }

        [HttpDelete]
        public async Task<ActionResult<string>> DeleteElement([FromBody] MaterialDataWrapperModel materialData)
        {
            return JsonConvert.SerializeObject( await _materialDataService.DeleteMaterialData(materialData.MaterialData));
        }
    }
}
