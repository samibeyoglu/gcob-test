﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rabobank.TechnicalTest.GCOB.Dtos;

namespace Rabobank.TechnicalTest.GCOB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public Task<CustomerDto> Get(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public CustomerDto Post()
        {
            throw new NotImplementedException();
        }
    }
}
