using System;

namespace RestAPI_With_ASP_NET.Entities
{
    public class Item
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

    }
}