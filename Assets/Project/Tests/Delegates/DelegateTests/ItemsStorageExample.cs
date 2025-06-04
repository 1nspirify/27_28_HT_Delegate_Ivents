using System.Collections.Generic;
using UnityEngine;

public class ItemsStorageExample : MonoBehaviour
{
    Transform transform;
    private void Awake()
    {
        ItemsStorage itemsStorage = new ItemsStorage();

        List<Item> items = itemsStorage.GetItemsBy(FireFilter);

        Debug.Log("Filter by type");

        foreach (Item item in items)
            Debug.Log(item.GetInfo());

        items = itemsStorage.GetItemsBy(SwordFilter);

        Debug.Log("Filter by Title");

        foreach (Item item in items)
            Debug.Log(item.GetInfo());

        items = itemsStorage.GetItemsBy(WeightFilter);

        Debug.Log("Filter by Wight");

        foreach (Item item in items)
            Debug.Log(item.GetInfo());
    }

    private bool FireFilter(Item item) => item.Type == ItemType.Fire;

    private bool SwordFilter(Item item) => item.Title == "Sword";

    private bool WeightFilter(Item item) => item.Weight > 0;
    
   
    
    
}