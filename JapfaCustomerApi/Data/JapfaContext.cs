using JapfaApi.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JapfaCustomerApi.Data
{
    public class JapfaContext :DbContext
    {
        public JapfaContext(DbContextOptions<JapfaContext> options) : base(options)
        {


        }

        //public DbSet<OrderStatus> OrderStatus { get; set; }

        public DbSet<Place_Order> Place_Order { get; set; }

        public DbSet<Product_Master> Product_Master { get; set; }


        public DbSet<Vehicle_Master> Vehicle_Master { get; set; }

        public DbSet<User_Master> User_Master { get; set; }

        public DbSet<Customer_Master> Customer_Master { get; set; }

        public DbSet<CustomerOrder_Master> CustomerOrder_Master { get; set; }



    }
}
