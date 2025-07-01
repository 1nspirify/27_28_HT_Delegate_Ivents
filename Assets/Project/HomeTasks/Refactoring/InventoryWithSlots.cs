using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RefactoringTwo
{
    public class Inventory
    {
        private List<InventorySlot> _slots;
        private int _maxSlots;

        public Inventory(int maxSlots)
        {
            _maxSlots = maxSlots;
            _slots = new List<InventorySlot>(_maxSlots);

            for (int i = 0; i < _maxSlots; i++)
                _slots.Add(new InventorySlot());
        }

        public bool Add(Item newItem)
        {
            InventorySlot emptySlot = _slots.FirstOrDefault(slot => !slot.HasItem);

            if (emptySlot != null)
            {
                emptySlot.SetItem(newItem);
                return true;
            }

            Debug.Log("Инвентарь переполнен!");
            return false;
        }

        public Item TakeItemById(int id)
        {
            InventorySlot targetSlot = _slots.FirstOrDefault(slot => slot.HasItem && slot.Item.ID == id);

            if (targetSlot != null)
            {
                Item takenItem = targetSlot.Item;
                targetSlot.Clear();
                return takenItem;
            }

            Debug.Log($"В инвентаре нет предмета с ID {id}");
            return null;
        }

        public List<Item> GetAllItems()
        {
            return _slots
                .Where(slot => slot.HasItem)
                .Select(slot => slot.Item)
                .ToList();
        }
    }

    public class InventorySlot
    {
        public Item Item { get; private set; }

        public bool HasItem => Item != null;

        public void SetItem(Item item)
        {
            Item = item;
        }

        public void Clear()
        {
            Item = null;
        }
    }

    public class Item
    {
        public int ID { get; private set; }

        public Item(int id)
        {
            ID = id;
        }
    }
}