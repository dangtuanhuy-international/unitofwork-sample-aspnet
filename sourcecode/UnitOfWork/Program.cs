using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Models;

namespace UnitOfWork
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            CustomerService obj = new CustomerService("1000", "shiv-1000");
            SimpleExampleUOW<CustomerService> o1 = new SimpleExampleUOW<CustomerService>();
            o1.Add(obj);
            obj = new CustomerService("1001", "shiv-1001");
            o1.Add(obj);
            o1.Committ();
            */

            CustomerService obj = new CustomerService("1003", "shiv-1003-add");
            SimpleExampleUOW<CustomerService> o2 = new SimpleExampleUOW<CustomerService>();
            o2.Add(obj);
            CustomerService obj2 = new CustomerService("1002", "shiv-1002-update");
            o2.Load(obj2);
            o2.Committ();

            Console.ReadLine();
        }
    }
}
