﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodSprint.Models;
using FoodSprint.Controllers;

namespace FoodSprint.Controllers
{
    [ApiController]

    public class CustomersController : Controller
    {
        private Sprint1Context _dbContext;
        private List<Customer> getdetails;

        public CustomersController(Sprint1Context dbContext)
        {
            _dbContext = dbContext;
        }

        [Route("CustomerData/Customer")]
        [HttpGet]
        public List<Customer> GetCustomer()
        {
            var getdatails = _dbContext.Customer.ToList();

            return getdatails;
        }

        [Route("CustomerData/Customerid")]
        [HttpGet]
        public List<Customer> GetCustomerid(int id)
        {

            var getdetails = _dbContext.Customer.Where(x => x.Customerid == id);

            return getdetails.ToList();
        }

        [Route("CustomerData/SaveCustomer")]
        [HttpPost]

        public List<Customer> SaveCustomer(Customer model)
        {
            _dbContext.Customer.Add(model);

            _dbContext.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";


            var getdetails = _dbContext.Customer.ToList();

            return getdetails;
        }

        [Route("CustomerData/EditCustomer")]
        [HttpPost]

        public List<Customer> UpdateCustomer(Customer model)
        {
            var data = _dbContext.Customer.Where(x => x.Customerid == model.Customerid).FirstOrDefault();
            if (data != null)
            {
                data.Customerid = model.Customerid;
                data.FisrtName = model.FisrtName;
                data.LastName = model.LastName;
                data.Email = model.Email;
                data.Mobile = model.Mobile;
                data.Password = model.Password;
                data.Status = model.Status;
                _dbContext.SaveChanges();
            }

            var getdatails = _dbContext.Customer.ToList();
            return getdatails;
        }

        [Route("CustomerData/DeleteCustomerById")]
        [HttpGet]
        public string DeleteCustomer(int id)
        {
            var ord = _dbContext.Customer.Find(id); //Add the record
            _dbContext.Customer.Remove(ord);
            _dbContext.SaveChanges();   //it Save Changes
            return "Deleted";
        }
    }


}

