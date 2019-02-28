using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using realTimeNotificationExample.Web.Data;
using realTimeNotificationExample.Web.Hubs;
using realTimeNotificationExample.Web.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace realTimeNotificationExample.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IHubContext<NotificationHub> _notificationHub;

        private static List<Product> _products = new List<Product>();

        public ProductsController(IHubContext<NotificationHub> notificationHub)
        {
            _notificationHub = notificationHub;

            _products.AddRange(FakeProductDataFactory.GetProducts());
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await _notificationHub.Clients.All.SendAsync("BroadcastTextMessage", $"{_products.Count} product have been listed from API.");

            return Ok(_products);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = _products.Find(p => p.Id == id);

            if (product == null)
                return NotFound();

            await _notificationHub.Clients.All.SendAsync("BroadcastTextMessage", $"{product.Name} have been consumed from API.");

            return Ok(product);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            var product = _products.Find(p => p.Id == id);

            if (product == null)
                return;

            _products.Remove(product);

            await _notificationHub.Clients.All.SendAsync("BroadcastTextMessage", $"{product.Name} have been deleted from API.");
        }
    }
}
