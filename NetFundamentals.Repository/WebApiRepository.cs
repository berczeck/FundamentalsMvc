using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using NetFundamentals.Model;
using RestSharp;

namespace NetFundamentals.Repository
{
    public class WebApiRepository : IRepository<Customer>
    {
        private const string URL_API = "http://localhost:55953";
        
        public int Add(Customer entity)
        {
            var client = new RestClient(URL_API);
            var request = new RestRequest(Method.PUT);
            request.Resource = "/customer";
            request.AddJsonBody(entity);
            request.RequestFormat = DataFormat.Json;
            return client.Execute<int>(request).Data;
        }

        public int Delete(Customer entity)
        {
            var client = new RestClient(URL_API);
            var request = new RestRequest(Method.DELETE);
            request.Resource = "/customer";
            request.AddJsonBody(entity);
            return client.Execute<int>(request).Data;
        }

        public Customer GetById(Customer customer)
        {
            var client = new RestClient(URL_API);            
            var request = new RestRequest(Method.GET);
            request.Resource = $"/customer/{customer.CustomerId}";  
            return client.Execute<Customer>(request).Data;
        }

        public Customer GetById(Expression<Func<Customer, bool>> match)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetList()
        {
            var client = new RestClient(URL_API);
            var request = new RestRequest(Method.GET);
            request.Resource = "/customer";
            return client.Execute<List<Customer>>(request).Data;
        }

        public int Update(Customer entity)
        {
            var client = new RestClient(URL_API);
            var request = new RestRequest(Method.POST);
            request.Resource = "/customer";
            request.AddJsonBody(entity);
            return client.Execute<int>(request).Data;
        }
    }
}
