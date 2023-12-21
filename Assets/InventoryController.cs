using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private GameObject _inventoryPanel;
    [SerializeField] private GameObject _toolbarPanel;
    [SerializeField] private GameObject _shopPanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            _inventoryPanel.SetActive(!_inventoryPanel.activeInHierarchy);
            _toolbarPanel.SetActive(!_toolbarPanel.activeInHierarchy);
            _shopPanel.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            _shopPanel.SetActive(true);
            _inventoryPanel.SetActive(false);
            _toolbarPanel.SetActive(false);
        }
    }
}
