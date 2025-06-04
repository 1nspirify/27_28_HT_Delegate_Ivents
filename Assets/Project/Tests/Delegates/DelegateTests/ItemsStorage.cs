using System.Collections.Generic;

public class ItemsStorage 
{
    private List<Item> _items;
    public ItemsStorage()
    {
        _items = new List<Item>();
        
        _items.Add(new Item("Sword", ItemType.Fire, 1));
        _items.Add(new Item("Sword", ItemType.Windy, 1));
        _items.Add(new Item("Sword", ItemType.Frozen, 1));
        
        _items.Add(new Item("Shield", ItemType.Fire, 2));
        _items.Add(new Item("Shield", ItemType.Windy, 1));
        _items.Add(new Item("Shield", ItemType.Frozen, 2));  
        
        _items.Add(new Item("Axe", ItemType.Frozen, 2));
        _items.Add(new Item("Axe", ItemType.Fire, 2));
        _items.Add(new Item("Axe", ItemType.Windy, 2));
    }

    public List<Item> GetItemsBy(ItemFilter filter)
    {
        List<Item> fireItems = new List<Item>();
        foreach (Item item in _items)
        { 
            if(filter.Invoke(item))
                fireItems.Add(item);
        }
        return fireItems;
    }
}