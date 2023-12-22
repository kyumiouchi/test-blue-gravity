using UnityEngine;

public class WearController : MonoBehaviour
{
    [SerializeField] private WearItem _bodyItem;
    [SerializeField] private WearItem _hairItem;
    [SerializeField] private WearItem _hatItem;
    
    public void SetWearItem(ItemDataSo itemDataSo)
    {
        if(itemDataSo == null) return;
        if(itemDataSo.ItemType != ItemType.Clothes) return;

        switch (itemDataSo.BodyPositionType)
        {
            case BodyPositionType.Body:
                _bodyItem.UpdateData(itemDataSo);
                break;
            case BodyPositionType.Head:
                _hairItem.UpdateData(itemDataSo);
                break;
            case BodyPositionType.TopHead:
                _hatItem.UpdateData(itemDataSo);
                break;
            case BodyPositionType.None:
                Debug.Log("Item can not wear");
                return;
        }
    }

    public void ClearItem(ItemDataSo itemDataSo)
    {
        if(itemDataSo == null) return;
        if(itemDataSo.ItemType != ItemType.Clothes) return;

        switch (itemDataSo.BodyPositionType)
        {
            case BodyPositionType.Body:
                _bodyItem.ClearData();
                break;
            case BodyPositionType.Head:
                _hairItem.ClearData();
                break;
            case BodyPositionType.TopHead:
                _hatItem.ClearData();
                break;
            case BodyPositionType.None:
                Debug.Log("Item can not wear");
                return;
        }
    }

    public void SetAnimation(string name, bool value)
    {
        _bodyItem.SetAnimation(name, value);
        _hairItem.SetAnimation(name, value);
        _hatItem.SetAnimation(name, value);
    }
    public void SetAnimation(string name, float value)
    {
        _bodyItem.SetAnimation(name, value);
        _hairItem.SetAnimation(name, value);
        _hatItem.SetAnimation(name, value);
    }
}
