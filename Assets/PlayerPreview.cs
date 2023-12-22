using UnityEngine;

public class PlayerPreview : MonoBehaviour
{
    [SerializeField] private WearController _wearController;
    
    public void WearItem(ItemDataSo itemDataSo)
    {
        if (itemDataSo.ItemType != ItemType.Clothes) return;
        _wearController.SetWearItem(itemDataSo);
    }
    
    public void ClearItem(ItemDataSo itemDataSo)
    {
        if (itemDataSo.ItemType != ItemType.Clothes) return;
        _wearController.ClearItem(itemDataSo);
    }
}
