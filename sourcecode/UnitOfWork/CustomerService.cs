using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Models;

namespace UnitOfWork
{
    internal class CustomerService : IEntity
    {

        CustomerReponsitory customerRepo = new CustomerReponsitory();
        private string customerId;
        private string companyName;
        public CustomerService(string customerId, string companyName)
        {
            this.customerId = customerId;
            this.companyName = companyName;
        }

        public void Insert()
        {
            var customer = new Customer
            {
                CustomerID = customerId,
                CompanyName = companyName
            };
            customerRepo.Insert(customer);
        }

        public List<IEntity> Load()
        {
            CustomerService cs = new CustomerService(customerId, companyName);
            List<IEntity> Li = (new List<CustomerService>()).ToList<IEntity>();
            Li.Add(cs);
            return Li;
        }

        public void Update()
        {
            var customer = new Customer();
            customer.CustomerID = customerId;
            customer.CompanyName = companyName;
            customerRepo.Update(customer);
        }
    }
}
