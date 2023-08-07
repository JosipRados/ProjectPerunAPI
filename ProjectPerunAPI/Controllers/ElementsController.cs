using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectPerunAPI.Models;
using ProjectPerunAPI.Services;
using ProjectPerunAPI.Services.Implementation;

namespace ProjectPerunAPI.Controllers
{
    [Route("api/elements")]
    [ApiController]
    public class ElementsController : ControllerBase
    {
        IElementsService _elementsService;

        public ElementsController(IElementsService elementsService)
        {
            _elementsService = elementsService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseModel>> GetElements()
        {
            return await _elementsService.GetElements();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseModel>> GetOneElement(int id)
        {
            return await _elementsService.GetOneElement(id);
        }

        [HttpPut]
        public async Task<ActionResult<ResponseModel>> UpdateElement([FromBody] ElementModel elementData)
        {
            return await _elementsService.UpdateElement(elementData);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel>> InsertElement([FromBody] ElementModel elementData)
        {
            return await _elementsService.InsertElement(elementData);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseModel>> DeleteElement(int id)
        {
            return await _elementsService.DeleteElement(id);
        }
    }
}
