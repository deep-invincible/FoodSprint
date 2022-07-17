using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodSprint.Models;
using FoodSprint.Controllers;

namespace Food_order.Controllers
{
    [ApiController]

    public class OrderItemsController : Controller
    {
        private Sprint1Context _dbContext;
        private List<OrderItem> getdetails;

        public OrderItemsController(Sprint1Context dbContext)
        {
            _dbContext = dbContext;
        }

        [Route("OrderItemData/OrderItem")]
        [HttpGet]
        public List<OrderItem> GetOrderItem()
        {
            var getdatails = _dbContext.OrderItem.ToList();

            return getdatails;
        }

        [Route("OrderItemData/OrderItemid")]
        [HttpGet]
        public List<OrderItem> GetItemId(int id)
        {

            var getdetails = _dbContext.OrderItem.Where(x => x.ItemId == id);

            return getdetails.ToList();
        }

        [Route("OrderItemData/SaveOrderItem")]
        [HttpPost]

        public List<OrderItem> SaveOrderItem(OrderItem model)
        {
            _dbContext.OrderItem.Add(model);

            _dbContext.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";


            var getdetails = _dbContext.OrderItem.ToList();

            return getdetails;
        }

        [Route("OrderItemData/EditOrderItem")]
        [HttpPost]

        public List<OrderItem> UpdateOrderItem(OrderItem model)
        {
            var data = _dbContext.OrderItem.Where(x => x.ItemId == model.ItemId).FirstOrDefault();
            if (data != null)
            {
                data.Orderid = model.Orderid;
                data.Menuid = model.Menuid;
                data.Amount = model.Amount;
                data.NoofServing = model.NoofServing;
                data.Total = model.Total;
                data.Status = model.Status;
                data.ItemId = model.ItemId;
                _dbContext.SaveChanges();
            }

            var getdatails = _dbContext.OrderItem.ToList();
            return getdatails;
        }

        [Route("OrderItemData/DeleteOrderItemById")]
        [HttpGet]
        public string DeleteOrderItem(int id)
        {
            var ord = _dbContext.OrderItem.Find(id); //Add the record
            _dbContext.OrderItem.Remove(ord);
            _dbContext.SaveChanges();   //it Save Changes
            return "Deleted";
        }
    }


}