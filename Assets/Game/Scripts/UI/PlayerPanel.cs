using GameValley;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPanel : MonoBehaviour
{
    [SerializeField] private PlayerDataSo _playerDataSo;
    
    [SerializeField] private TextMeshProUGUI _textPlayerCoins;
    [SerializeField] private Button _shopButton;
    [SerializeField] private Button _inventoryButton;
    [SerializeField] private Button _closeShopButton;
    [SerializeField] private Button _closeInventoryButton;

    [SerializeField] private GameObject _backgroundUI;
    [SerializeField] private GameObject _toolbarPanel;
    [SerializeField] private GameObject _inventoryPanel;
    [SerializeField] private GameObject _shopPanel;

    [SerializeField] private InventoryController _inventoryController;
    
    private void OnEnable()
    {
        _shopButton.onClick.AddListener(OpenSwitchShopAndToolbar);
        _inventoryButton.onClick.AddListener(OpenSwitchToolbarAndInventory);
        
        _closeShopButton.onClick.AddListener(OpenSwitchShopAndToolbar);
        _closeInventoryButton.onClick.AddListener(OpenSwitchToolbarAndInventory);
        
        _playerDataSo.UpdateCoins += UpdateTextPlayerCoins;
        
        _inventoryController.OnOpenShop += OpenSwitchShopAndToolbar;
        _inventoryController.OnOpenInventory += OpenSwitchToolbarAndInventory;
    }

    private void Start()
    {
        UpdateTextPlayerCoins(_playerDataSo.Coins);
    }

    private void UpdateTextPlayerCoins(int value)
    {
        _textPlayerCoins.text = value.ToString();
    }

    private void OpenShop()
    {
        _backgroundUI.SetActive(true);
        _shopPanel.SetActive(true);
        _inventoryPanel.SetActive(false);
        _toolbarPanel.SetActive(false);
    }

    private void OpenSwitchToolbarAndInventory()
    {
        OpenToolbar(_inventoryPanel.activeInHierarchy);
    }

    private void OpenToolbar(bool open)
    {
        _backgroundUI.SetActive(!open);
        _toolbarPanel.SetActive(open);
        _inventoryPanel.SetActive(!open);
        _shopPanel.SetActive(false);
    }

    private void OpenSwitchShopAndToolbar()
    {
        if (!_shopPanel.activeInHierarchy)
        {
            OpenShop();
        }
        else
        {    
            OpenToolbar(true);
        }
    }

    private void OnDisable()
    {
        _shopButton.onClick.RemoveListener(OpenSwitchShopAndToolbar);
        _inventoryButton.onClick.RemoveListener(OpenSwitchToolbarAndInventory);
        
        _closeShopButton.onClick.RemoveListener(OpenSwitchShopAndToolbar);
        _closeInventoryButton.onClick.RemoveListener(OpenSwitchToolbarAndInventory);
        
        _playerDataSo.UpdateCoins -= UpdateTextPlayerCoins;
        
        _inventoryController.OnOpenShop -= OpenSwitchShopAndToolbar;
        _inventoryController.OnOpenInventory -= OpenSwitchToolbarAndInventory;
    }
}
