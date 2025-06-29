using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Refactoring
{
    public class Inventory
    {
        private List<Item> _items = new List<Item>();
        private int _maxSize;

        public int CurrentSize => _items.Sum(item => item.Count);

        public Inventory(int maxSize)
        {
            _maxSize = maxSize;
        }

        public List<Item> GetAllItems()
        {
            return new List<Item>(_items);
        }

        public bool Add(Item newItem)
        {
            if (CurrentSize + newItem.Count > _maxSize)
            {
                Debug.Log("Инвентарь переполнен!");
                return false;
            }

            Item existingItem = _items.FirstOrDefault(item => item.ID == newItem.ID);

            if (existingItem != null)
            {
                existingItem.Count += newItem.Count;
            }
            else
            {
                _items.Add(new Item(newItem.ID, newItem.Count));
            }

            return true;
        }

        public List<Item> TakeItemsById(int id, int count)
        {
            List<Item> takenItems = new List<Item>();
            int remainingToTake = count;

            foreach (Item item in _items.Where(item => item.ID == id).ToList())
            {
                if (remainingToTake <= 0)
                    break;

                if (item.Count <= remainingToTake)
                {
                    takenItems.Add(new Item(item.ID, item.Count));
                    remainingToTake -= item.Count;
                    _items.Remove(item);
                }
                else
                {
                    takenItems.Add(new Item(item.ID, remainingToTake));
                    item.Count -= remainingToTake;
                    remainingToTake = 0;
                }
            }

            if (remainingToTake > 0)
            {
                Debug.Log($"В инвентаре не хватает предметов с ID {id} для запроса {count} шт.");
            }

            return takenItems;
        }
    }

    public class Item
    {
        public int ID { get; private set; }
        public int Count { get; set; }

        public Item(int id, int count)
        {
            ID = id;
            Count = count;
        }
    }
}