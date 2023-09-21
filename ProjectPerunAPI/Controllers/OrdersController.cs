using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectPerunAPI.Models;
using ProjectPerunAPI.Services;
using System.Data;

namespace ProjectPerunAPI.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        IOrdersService _ordersService;
        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        [HttpGet("{filter}")]
        public async Task<ActionResult<string>> GetOrders(string filter)
        {
            return JsonConvert.SerializeObject(await _ordersService.GetOrders(filter));
        }

        [HttpGet("one/{id}")]
        public async Task<ActionResult<string>> GetOneOrder(int id)
        {
            return JsonConvert.SerializeObject(await _ordersService.GetOneOrder(id));
        }

        [HttpPut]
        public async Task<ActionResult<string>> UpdateOrder([FromBody] OrderWrapperModel orderData)
        {
            if (orderData == null || orderData.OrderData == null)
                return JsonConvert.SerializeObject(new ResponseModelNew(false, "Empty request!", new DataTable()));
            return JsonConvert.SerializeObject(await _ordersService.UpdateOrder(orderData.OrderData));
        }

        [HttpPost]
        public async Task<ActionResult<string>> InsertOrder([FromBody] OrderWrapperModel? orderData)
        {
            if (orderData == null || orderData.OrderData == null)
                return JsonConvert.SerializeObject(new ResponseModelNew(false, "Empty request!", new DataTable()));
            return JsonConvert.SerializeObject(await _ordersService.InsertOrder(orderData.OrderData));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteOrder(int id)
        {
            return JsonConvert.SerializeObject(await _ordersService.DeleteOrder(id));
        }

        [HttpPut("finished")]
        public async Task<ActionResult<string>> UpdateOrder([FromBody] int orderID)
        {
            return JsonConvert.SerializeObject(await _ordersService.SetOrderAsFinished(orderID));
        }
    }
}
