public class InventoryPanel : ItemPanel
{
    public override void OnCLick(int index)
    {
        GameManager.Instance.ItemDragAndDropController.OnClick(_containerSO.Slots[index]);
        ShowItems();
    }

    public override void DoubleClick(int itemIndex)
    {
        //nothing
    }
}