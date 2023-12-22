using System;
using UnityEngine;

public class ToolbarController : MonoBehaviour
{
    [SerializeField] private int _toolbarSize = 9;
    
    private WearController _wearController;
    private int _selectedTool;

    public Action<int> onChange;

    private void Awake()
    {
        _wearController = GetComponent<WearController>();
    }
    
    private void Update()
    {
        float delta = Input.mouseScrollDelta.y;
        if (delta != 0)
        {
            if (delta > 0)
            {
                _selectedTool++;
                _selectedTool = (_selectedTool >= _toolbarSize ? 0 : _selectedTool);
            }
            else
            {
                _selectedTool--;
                _selectedTool = (_selectedTool <= 0 ? _toolbarSize - 1 : _selectedTool);
            }
        }
        onChange?.Invoke(_selectedTool);
    }

    public void Set(int index)
    {
        _selectedTool = index;
    }
    
    public void RemoveItem(ItemDataSo itemDataSo)
    {
        _wearController.ClearItem(itemDataSo);
    }

    public void AttachPlayer(ItemDataSo itemDataSo)
    {
        _wearController.SetWearItem(itemDataSo);
    }
}
