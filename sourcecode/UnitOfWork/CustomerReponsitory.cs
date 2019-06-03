using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Models;

namespace UnitOfWork
{
    public class CustomerReponsitory
    {
        private readonly NorthwindContext dbContext = new NorthwindContext();
       
        public bool Insert(Customer customer)
        {
            try
            {
                dbContext.Customers.Add(customer);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        public int Update(Customer customer)
        {
            try
            {
                var custo = dbContext.Customers.Find(customer.CustomerID);
                custo.CompanyName = customer.CompanyName;
                dbContext.Entry(custo).State = EntityState.Modified;
                dbContext.Customers.Attach(customer);
                dbContext.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
