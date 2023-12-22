using GameValley;
using UnityEngine;

[RequireComponent(typeof(WearController))]
public class ShopController : MonoBehaviour
{
    [SerializeField] private PlayerDataSo _playerDataSo;

    public PlayerDataSo PlayerDataSo => _playerDataSo;

    
    public void AddCoin(int value)
    {
        _playerDataSo.AddCoin(value);
    }
    
    public void SubtractCoin(int value)
    {
        _playerDataSo.SubtractCoin(value);
    }

    public bool CanSpend(int coinsToBuy)
    {
        return _playerDataSo.Coins >= coinsToBuy;
    }

    public void AddItemToInventory(ItemSlot containerSoSlot)
    {
        GameManager.Instance.ItemInventorySo.Add(containerSoSlot.item);
    }
}
