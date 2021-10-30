using System;
using System.Collections.Generic;
using System.Linq;
using RestAPI_With_ASP_NET.Entities;

namespace RestAPI_With_ASP_NET.Repository
{
    public class ImplItemRepository : IItemRepository
    {
        //Initialize List of Items
        private readonly List<Item> items = new(){
            new Item{ Id = Guid.NewGuid() , Name = "Potion", Price = 9},
            new Item{ Id = Guid.NewGuid() , Name = "Iron Sword", Price = 20},
            new Item{ Id = Guid.NewGuid() , Name = "Brozen Shield", Price = 18}
        };

        public List<Item> GetAllItems() // Get List of Items
        {
            return items;
        }

        public Item GetItem(Guid id) //Get Item by Id
        {
            var item = items.Where(item => item.Id == id).Single();
            return item; 
        }

        public void InseartNewItem(Item item) // Add new Item
        {
            items.Add(item);
        }

        public void UpdateItem(Item item) // Update Item
        {
            var index = items.FindIndex(existingItem => existingItem.Id == item.Id);
            items[index] = item;
        }

        public void DeleteItem(Guid id) // Delete Item
        {
            var index = items.FindIndex(existingItem => existingItem.Id == id);
            items.RemoveAt(index);
        }
    }
}