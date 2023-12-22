using System;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public event Action OnOpenInventory;
    public event Action OnOpenShop;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            OnOpenInventory?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            OnOpenShop?.Invoke();
        }
    }
}
