using System.Collections.Generic;
using UnityEngine;

public abstract class ItemPanel : MonoBehaviour
{
    [SerializeField] protected List<SlotInventoryButton> _slotButtons;
    protected ItemInventorySo _inventorySo;

    private void OnEnable()
    {
        if (_inventorySo == null)
            _inventorySo = GameManager.Instance.ItemInventorySo;
        _inventorySo.UpdateItems += Initialize;
    }
    private void Start()
    {
        Initialize();
    }

    protected void Initialize()
    {
        InitializeInventory();
        ShowItems();
    }

    private void InitializeInventory()
    {
        for (int i = 0; i < _inventorySo.Slots.Count && i < _slotButtons.Count; i++)
        {
            _slotButtons[i].SetIndex(i);
        }
    }

    public void ShowItems()
    {
        for (int i = 0; i < _inventorySo.Slots.Count && i < _slotButtons.Count; i++)
        {
            if (_inventorySo.Slots[i].item == null)
            {
                _slotButtons[i].CleanData();
            }
            else
            {
                _slotButtons[i].SetData(_inventorySo.Slots[i]);
            }
        }
    }
    
    public virtual void OnCLick(int index){}
    
    private void OnDisable()
    {
        _inventorySo.UpdateItems -= Initialize;
    }
}
