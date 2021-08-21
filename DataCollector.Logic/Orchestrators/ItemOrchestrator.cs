using DataCollector.Data.Database.Dtos;
using DataCollector.Database.Repositories;
using DataCollector.Logic.Models;
using System.Collections.Generic;

namespace DataCollector.Logic.Orchestrators
{
    class ItemOrchestrator
    {
        private ItemRepository repo = new ItemRepository();
        public bool AddItem(Item item)
        {
            if (item == null)
            {
                return false;
            }

            ItemDto itemDto = new ItemDto()
            {
                Id = item.Id,
                Name = item.Name
            };

            repo.AddItem(itemDto);

            return true;
        }

        public void DeleteItem(int id)
        {
            repo.DeleteItem(id);
        }

        public List<Item> GetAllItems()
        {
            IEnumerable<ItemDto> itemsDtos = repo.GetAllItems();
            List<Item> items = new List<Item>();

            if (itemsDtos == null)
            {
                return null;
            }

            foreach (var item in itemsDtos)
            {
                items.Add(new Item()
                {
                    Id = item.Id,
                    Name = item.Name
                });
            }

            return items;

        }

        public Item GetItemById(int id)
        {
            ItemDto itemDto = repo.GetItemById(id);

            if (itemDto == null)
            {
                return null;
            }

            return new Item()
            {
                Id = itemDto.Id,
                Name = itemDto.Name
            };
        }

        public bool UpdateItem(Item item)
        {
            if (item == null)
            {
                return false;
            }

            ItemDto itemDto = new ItemDto()
            {
                Id = item.Id,
                Name = item.Name
            };

            repo.UpdateItem(itemDto);

            return true;
        }

    }
}
