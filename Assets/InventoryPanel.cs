public class InventoryPanel : ItemPanel
{
    public override void OnCLick(int index)
    {
        GameManager.Instance.ItemDragAndDropController.OnClick(_inventorySo.Slots[index]);
        ShowItems();
    }
}
