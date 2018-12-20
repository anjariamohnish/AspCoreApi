using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryService.Models;
using InventoryService.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InventoryService.Controllers
{
    [Route("v1/")]
    public class InventoryController : ControllerBase
    {

        private readonly IInventoryServices _services;

        public InventoryController(IInventoryServices services) => _services = services;

        [HttpPost]
        [Route("AddInventoryItems")]
        public ActionResult<InventoryItems> AddInventoryItems(InventoryItems items)
        {
            var inventoryItems = _services.AddInventoryItems(items);
            if (inventoryItems == null)
            {
                return NotFound();
            }

            return inventoryItems;
        }

        [HttpGet]
        [Route("GetInventoryItems")]
        public ActionResult<Dictionary<string, InventoryItems>> GetInventoryItems()
        {
            var inventoryItems = _services.GetInventoryItems();
            if (inventoryItems.Count == 0)
            {
                return NotFound();
            }

            return inventoryItems;
        }
    }
}
