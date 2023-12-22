using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Item Inventory", fileName = "ItemInventory_SO")]
public class ItemInventorySo : ScriptableObject
{
    [SerializeField] private List<ItemSlot> _slots;
    public List<ItemSlot> Slots => _slots;

    public event Action UpdateItems;

    public void Add(ItemDataSo item, int quantity = 1)
    {
        if (item == null)
        {
            Debug.Log("Error no item");
            return;
        }
        if (_slots == null)
        {
            Debug.Log("Error no slots");
            return;
        }
        if (item.Stakable)
        {
            ItemSlot itemSlot = _slots.Find(x => x.item == item);
            if (itemSlot != null)
            {
                itemSlot.quantity += quantity;
            }
            else
            {
                ItemSlot itemSlotEmpty = _slots.Find(x => x.item == null);
                if (itemSlotEmpty != null)
                {
                    itemSlotEmpty.item = item;
                    itemSlotEmpty.quantity = quantity;
                }
            }
        }
        else
        {
            ItemSlot itemSlot = _slots.Find(x => x.item == null);
            if (itemSlot != null)
            {
                itemSlot.item = item;
                itemSlot.quantity = quantity;
            }
        }
        UpdateItems?.Invoke();
    }

    public void Remove(ItemDataSo item, int quantity = 1)
    {
        if (item == null)
        {
            Debug.Log("Error no item");
            return;
        }
        if (_slots == null)
        {
            Debug.Log("Error no slots");
            return;
        }
        
        var itemSlot = _slots.Find(x => x.item == item);
        if (item.Stakable)
        {
            if (itemSlot != null)
            {
                if (itemSlot.quantity > quantity)
                {
                    itemSlot.quantity -= quantity;
                }
                else
                {
                    itemSlot.Clear();
                }
            }
        }
        else
        {
            itemSlot?.Clear();
        }
        UpdateItems?.Invoke();
    }

    public void ClearInventory()
    {
        for (int i = 0; i < _slots.Count; i++)
        {
            _slots[i].Clear();
        }
    }
}
