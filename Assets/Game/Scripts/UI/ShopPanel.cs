using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : ItemPanel
{
    [SerializeField] private PlayerPreview _playerPreview;
    [SerializeField] private ShopController _shop;
    [SerializeField] private TextMeshProUGUI _textCoinsToBuy;
    [SerializeField] private Button _btnToBuy;

    private int _currentHighlight;
    private int _coinsToBuy = 0;
    
    protected override void OnEnable()
    {
        if (_containerSO == null)
            _containerSO = GameManager.Instance.ShopInventorySo;
        _containerSO.UpdateItems += Initialize;
        Initialize();
    }

    protected override void Initialize()
    {
        base.Initialize();
        
        _coinsToBuy = 0;
        SetCoinsOnText(_coinsToBuy);
        _btnToBuy.onClick.AddListener(BuyItem);
    }

    private void BuyItem()
    {
        _shop.SubtractCoin(_coinsToBuy);
        _shop.AddItemToInventory(_containerSO.Slots[_currentHighlight]);
        ClearData();
    }

    private void ClearData()
    {
        _coinsToBuy = 0;
        SetCoinsOnText(_coinsToBuy);
        _slotButtons[_currentHighlight].ShowHighlight();
        _btnToBuy.interactable = false;
    }

    public override void OnCLick(int index)
    {
        if (index >= _containerSO.Slots.Count)
        {
            ClearData();
            return;
        }
        
        UpdateSlot(index);
        _coinsToBuy = _containerSO.Slots[index].item.PriceToBuy;
        SetCoinsOnText(_coinsToBuy);
        
        _btnToBuy.interactable = _shop.CanSpend(_coinsToBuy);
    }

    public override void DoubleClick(int itemIndex)
    {
        //nothing
    }

    private void SetCoinsOnText(int value)
    {
        _textCoinsToBuy.text = value.ToString();
    }

    private void UpdateSlot(int index)
    {
        _slotButtons[_currentHighlight].HideHighlight();
        _playerPreview.ClearItem(_containerSO.Slots[_currentHighlight].item);
        _currentHighlight = index;
        _slotButtons[_currentHighlight].ShowHighlight();
        _playerPreview.WearItem(_containerSO.Slots[_currentHighlight].item);
    }
    
    protected override void ShowItems()
    {
        for (int i = 0;i < _slotButtons.Count; i++)
        {
            if (i >= _containerSO.Slots.Count)
            {
                _slotButtons[i].CleanData();
                continue;
            }
            if (_containerSO.Slots[i].item == null)
            {
                _slotButtons[i].CleanData();
            }
            else
            {
                _slotButtons[i].SetData(_containerSO.Slots[i]);
            }
        }
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        _btnToBuy.onClick.RemoveListener(BuyItem);
    }
}
