using System;
using UnityEngine;

public class ItemToolbarPanel : ItemPanel
{
    [SerializeField] private ToolbarController _toolbar;

    private int _currentHighlight;
    private readonly int _startPosition = 0;


    private void Start()
    {
        Initialize();
        _toolbar.onChange += Highlight;
        Highlight(_startPosition);
    }
    public override void OnCLick(int index)
    {
        _toolbar.Set(index);
        Highlight(index);
    }

    public void Highlight(int index)
    {
        _slotButtons[_currentHighlight].HideHighlight();
        _currentHighlight = index;
        _slotButtons[_currentHighlight].ShowHighlight();
    }

}
