﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using TestSolutions.Application.Customers;
using TestSolutions.Application.Customers.Commands.CreateCustomer;
using TestSolutions.Application.Messaging;
using TestSolutions.Application.Customers.Queries.Abstractions;

namespace TestSolutions.Service.Customers
{
    public class CustomersController : ApiController
    {
        private readonly IGetCustomersQuery _query;
        private readonly ICreateCustomerCommand _command;

        public CustomersController(IGetCustomersQuery query, 
            ICreateCustomerCommand command)
        {
            _command = command;
            _query = query;
        }

        
        public async Task<IEnumerable<CustomerModel>> Get()
        {
            return await _query.ExecuteAsync();
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Create(CustomerModel model)
        {

            await _command.ExecuteAsync(model);

            CreateCustomerMessagingClient client = new CreateCustomerMessagingClient();
            client.CreateConnection();
            client.AddCustomerDataToQueue(model);
            client.Close();

            return new HttpResponseMessage(HttpStatusCode.Created);
        }
    }
}