using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class SlotContainerButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] protected Image _icon;
    [SerializeField] protected TextMeshProUGUI _text;
    [SerializeField] protected Image _highlightImage;

    private int itemIndex;
    
    public void SetIndex(int index)
    {
        itemIndex = index;
    }

    public abstract void SetData(ItemSlot itemSlot);

    public abstract void CleanData();

    public void OnPointerClick(PointerEventData eventData)
    {
        ItemPanel itemPanel = transform.parent.GetComponent<ItemPanel>();
        itemPanel.OnCLick(itemIndex);
        
        if (eventData.clickCount == 2)
        {
            itemPanel.DoubleClick(itemIndex);
        }
    }
    
    public void HideHighlight()
    {
        _highlightImage.gameObject.SetActive(false);
    }
    public void ShowHighlight()
    {
        _highlightImage.gameObject.SetActive(true);
    }
}
