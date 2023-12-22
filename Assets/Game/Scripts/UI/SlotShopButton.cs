public class SlotShopButton : SlotContainerButton
{
    public override void SetData(ItemSlot itemSlot)
    {
        _icon.sprite = itemSlot.item.Icon;
        _icon.gameObject.SetActive(true);
        
        _text.text = itemSlot.item.PriceToBuy.ToString();
        _text.gameObject.SetActive(true);
    }
    
    public override void CleanData()
    {
        _icon.sprite = null;
        _icon.gameObject.SetActive(false);
        _text.gameObject.SetActive(false);
    }
}
