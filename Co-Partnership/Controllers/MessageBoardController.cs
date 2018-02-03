﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Co_Partnership.Models.AccountViewModels;
using Co_Partnership.Models;
using Co_Partnership.Services;
using Co_Partnership.Models.Database;
using Newtonsoft.Json;

namespace Co_Partnership.Controllers
{
    [Produces("application/json")]
    [Route("Admin/api/MessageBoard")]
    public class MessageBoardController : Controller
    {
        // This controller creates Apis for the message panel

        //It requires the message repository
        private IMessageInterface messageInterface;
       

        // Constructor
        public MessageBoardController(IMessageInterface messageInterface)
        {
            this.messageInterface = messageInterface;
        }


        // GET: api/MessageBoard
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/MessageBoard/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/MessageBoard
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/MessageBoard/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}