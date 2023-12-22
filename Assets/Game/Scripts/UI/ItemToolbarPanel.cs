using UnityEngine;

public class ItemToolbarPanel : ItemPanel
{
    [SerializeField] private ToolbarController _toolbar;

    private int _currentHighlight;
    private readonly int _startPosition = 0;
    private bool _doubleClicked = false;

    protected override void OnEnable()
    {
        base.OnEnable();
        _doubleClicked = false;
        _toolbar.onChange += Highlight;
    }

    private void Start()
    {
        Initialize();
        Highlight(_startPosition);
    }
    public override void OnCLick(int index)
    {
        _toolbar.Set(index);
        ClearDoubleClick(index);
        Highlight(index);
    }

    public override void DoubleClick(int itemIndex)
    {
        if (!_doubleClicked)
        {
            _toolbar.AttachPlayer(_containerSO.Slots[itemIndex].item);
        }
        else
        {
            _toolbar.RemoveItem(_containerSO.Slots[itemIndex].item);
        }
        _doubleClicked = !_doubleClicked;
    }

    private void ClearDoubleClick(int index)
    {
        if (_currentHighlight != index)
            _doubleClicked = false;
    }

    public void Highlight(int index)
    {
        _slotButtons[_currentHighlight].HideHighlight();
        _currentHighlight = index;
        _slotButtons[_currentHighlight].ShowHighlight();
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        _toolbar.onChange -= Highlight;
    }
}
