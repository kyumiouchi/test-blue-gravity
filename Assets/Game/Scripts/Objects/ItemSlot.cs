using System;

[Serializable]
public class ItemSlot
{
    public ItemDataSo item;
    public int quantity;
    public void Clear()
    {
        item = null;
        quantity = 0;
    }

    public void Copy(ItemSlot itemSlot)
    {
        item = itemSlot.item;
        quantity = itemSlot.quantity;
    }

    public void Set(ItemDataSo item, int quantity)
    {
        this.item = item;
        this.quantity = quantity;
    }

    public override string ToString()
    {
        return $"Item Slot " +
               $"name = {(item==null?"null":item.Name)} " +
               $"stackable = {(item==null?"null":item.Stakable)} " +
               $"quantity = {quantity} " +
               $"icon = {(item==null?"null":item.Icon)}";
    }
}