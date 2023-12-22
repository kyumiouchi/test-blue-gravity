public class SlotInventoryButton : SlotContainerButton
{
    public override void SetData(ItemSlot itemSlot)
    {
        _icon.sprite = itemSlot.item.Icon;
        _icon.gameObject.SetActive(true);
        
        _text.text = itemSlot.quantity.ToString();
        _text.gameObject.SetActive(true);
    }

    public override void CleanData()
    {
        _icon.sprite = null;
        _icon.gameObject.SetActive(false);
        _text.gameObject.SetActive(false);
    }
}
