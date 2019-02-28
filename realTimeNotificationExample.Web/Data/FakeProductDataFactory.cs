using Bogus;
using realTimeNotificationExample.Web.Models;
using System;
using System.Collections.Generic;

namespace realTimeNotificationExample.Web.Data
{
    public static class FakeProductDataFactory
    {
        private static Random _random = new Random();

        public static List<Product> GetProducts()
        {
            var result = new List<Product>();

            for (int i = 0; i <= 100; i++)
                result.Add(item: GetProduct());

            return result;
        }

        public static Product GetProduct()
        {
            return new Faker<Product>()
                            .RuleFor(o => o.Id, f => f.Random.Int(1, 10000))
                            .RuleFor(o => o.Name, f => f.Commerce.ProductName())
                            .RuleFor(o => o.Price, f => Convert.ToDecimal(f.Commerce.Price()))
                            .RuleFor(o => o.Supplier, f => f.Company.CompanyName()).Generate();
        }
    }
}
