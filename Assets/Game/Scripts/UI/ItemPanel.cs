using System.Collections.Generic;
using UnityEngine;

public abstract class ItemPanel : MonoBehaviour
{
    [SerializeField] protected List<SlotContainerButton> _slotButtons;
    protected ItemInventorySo _containerSO;

    protected virtual void OnEnable()
    {
        if (_containerSO == null)
            _containerSO = GameManager.Instance.ItemInventorySo;
        _containerSO.UpdateItems += Initialize;
        Initialize();
    }

    protected virtual void Initialize()
    {
        InitializeInventory();
        ShowItems();
    }
    
    private void InitializeInventory()
    {
        for (int i = 0; i < _slotButtons.Count; i++)
        {
            _slotButtons[i].SetIndex(i);
        }
    }

    protected virtual void ShowItems()
    {
        for (int i = 0; i < _containerSO.Slots.Count && i < _slotButtons.Count; i++)
        {
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

    public abstract void OnCLick(int index);
    public abstract void DoubleClick(int itemIndex);
    
    protected virtual void OnDisable()
    {
        _containerSO.UpdateItems -= Initialize;
    }

}
