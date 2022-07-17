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

    public class OrdersController : Controller
    {
        private Sprint1Context _dbContext;
        private List<Order> getdetails;

        public OrdersController(Sprint1Context dbContext)
        {
            _dbContext = dbContext;
        }

        [Route("OrderData/Order")]
        [HttpGet]
        public List<Order> GetOrder()
        {
            var getdatails = _dbContext.Order.ToList();

            return getdatails;
        }

        [Route("OrderData/OrderId")]
        [HttpGet]
        public List<Order> GetOrderid(int id)
        {

            var getdetails = _dbContext.Order.Where(x => x.Orderid == id);

            return getdetails.ToList();
        }

        [Route("OrderData/SaveOrder")]
        [HttpPost]

        public List<Order> SaveOrder(Order model)
        {
            _dbContext.Order.Add(model);

            _dbContext.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";


            var getdetails = _dbContext.Order.ToList();

            return getdetails;
        }

        [Route("OrderData/EditOrder")]
        [HttpPost]

        public List<Order> UpdateOrder(Order model)
        {
            var data = _dbContext.Order.Where(x => x.Orderid == model.Orderid).FirstOrDefault();
            if (data != null)
            {
                data.Orderid = model.Orderid;
                data.Orderdate = model.Orderdate;
                data.TotalAmount = model.TotalAmount;
                data.Customerid = model.Customerid;
                data.OrderStatus = model.OrderStatus;
                _dbContext.SaveChanges();
            }

            var getdatails = _dbContext.Order.ToList();
            return getdatails;
        }

        [Route("OrderData/DeleteOrderById")]
        [HttpGet]
        public string DeleteOrder(int id)
        {
            var ord = _dbContext.Order.Find(id); //Add the record
            _dbContext.Order.Remove(ord);
            _dbContext.SaveChanges();   //it Save Changes
            return "Deleted";
        }
    }


}