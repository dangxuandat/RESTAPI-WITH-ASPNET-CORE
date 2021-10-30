using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RestAPI_With_ASP_NET.Entities;
using RestAPI_With_ASP_NET.Repository;
using RestAPI_With_ASP_NET.Dtos;

namespace RestAPI_With_ASP_NET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemRepository _repository;

        public ItemsController(IItemRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<List<Item>> GetItems(){
            var items = _repository.GetAllItems().ToList();
            return items;
        }

        [HttpGet("{id}")]
        public ActionResult<Item> GetItem(Guid id){
            var item = _repository.GetItem(id);
            if(item is null){
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public ActionResult<Item> CreateNewItem(ItemDTO newItem){
            Item item = new(){
                Id = Guid.NewGuid(),
                Name = newItem.Name,
                Price = newItem.Price,
            };
            _repository.InseartNewItem(item);

            return CreatedAtAction(nameof(GetItem), new {id = item.Id}, new Item{
                    Id = item.Id,
                    Name = item.Name,
                    Price = item.Price,
            });
        }

        [HttpPut("{id}")]
        public ActionResult UpdateItem(Guid id, ItemDTO updateItem){
            var existingItem = _repository.GetItem(id);
            if(existingItem is null){
                return NotFound();
            }
            existingItem.Name = updateItem.Name;
            existingItem.Price = updateItem.Price;
            _repository.UpdateItem(existingItem);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public ActionResult DeleteItem(Guid id){
            var existingItem = _repository.GetItem(id);
            if(existingItem is null){
                return NotFound();
            }
            _repository.DeleteItem(id);
            return NoContent();
        }
     }
}