using System.Collections.Generic;
using System;
using RestAPI_With_ASP_NET.Entities;

namespace RestAPI_With_ASP_NET.Repository
{
    public interface IItemRepository
    {
         Item GetItem(Guid id);

         List<Item> GetAllItems();

         void InseartNewItem(Item item);

         void UpdateItem(Item item);

         void DeleteItem(Guid id);
    }
}