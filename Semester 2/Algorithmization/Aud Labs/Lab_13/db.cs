using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casual
{
    internal class Product
    {
        static private int lastId = 0;
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public Product(string name, int amount)
        {
            Id = ++lastId;
            Name = name;
            Amount = amount;
        }
    }

    internal class Provider
    {
        private static int lastId = 0;
        public int Id { get; set; }
        public string Name { get; set; } = "Unknown";
        public Provider(string name)
        {
            Id = ++lastId;
            Name = name;
        }
    }

    internal class Supply
    {
        public int ProviderId { get; set; }
        public int ProductId { get; set; }
        public int ProductAmount { get; set; }
        public DateTime Date { get; set; }
        public Supply(int providerId, int productId, int productAmount, DateTime date)
        {
            ProviderId = providerId;
            ProductId = productId;
            ProductAmount = productAmount;
            Date = date;
        }
    }
}
