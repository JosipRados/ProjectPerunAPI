using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectPerunAPI.Models;
using ProjectPerunAPI.Services;

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

        [HttpGet]
        public async Task<ActionResult<ResponseModel>> GetOrders()
        {
            return await _ordersService.GetOrders();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseModel>> GetOneOrder(int id)
        {
            return await _ordersService.GetOneOrder(id);
        }

        [HttpPut]
        public async Task<ActionResult<ResponseModel>> UpdateOrder([FromBody] OrderModel orderData)
        {
            return await _ordersService.UpdateOrder(orderData);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel>> InsertOrder([FromBody] OrderModel orderData)
        {
            return await _ordersService.InsertOrder(orderData);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseModel>> DeleteOrder(int id)
        {
            return await _ordersService.DeleteOrder(id);
        }
    }
}
