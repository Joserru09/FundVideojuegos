using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public static InventorySystem Instance;

    public delegate void onInventoryChangedEvent();
    public event onInventoryChangedEvent onInventoryChangedEventCallback;
    private Dictionary<InventoryItemData, InventoryItem> _itemDictionary;
    public List<InventoryItem> inventory;

    private void Awake()
    {
        inventory = new List<InventoryItem>();
        _itemDictionary = new Dictionary<InventoryItemData, InventoryItem>();

       
        Instance = this;
    }

    public void Add(InventoryItemData itemData)
    {
        if (_itemDictionary.TryGetValue(itemData, out InventoryItem value))
        {
            Debug.Log("SUMAR STACK EN ITEM.");

            onInventoryChangedEventCallback.Invoke();
        }
        else
        {
            Debug.Log("AGREGAR NUEVO ITEM");
            InventoryItem newItem = new InventoryItem(itemData);
            inventory.Add(newItem);
            _itemDictionary.Add(itemData, newItem);
            onInventoryChangedEventCallback.Invoke();
        }
    }
    public void Remove(InventoryItemData itemData)
    {
        if (_itemDictionary.TryGetValue(itemData, out InventoryItem value)){            
            inventory.Remove(value);
            _itemDictionary.Remove(itemData);
        }
        onInventoryChangedEventCallback.Invoke();
    }
    public bool HasItem(string itemName)
    {
        foreach (InventoryItem item in inventory)
        {
            if (item.data.itemName == itemName)
            {
                return true;
            }
        }
        return false;
    }
    public  InventorySystem dameInst()
    {
        return Instance;
    }
    
}

