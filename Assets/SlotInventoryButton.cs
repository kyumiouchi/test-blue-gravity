using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotInventoryButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Image _highlightImage;

    private int itemIndex;
    
    public void SetIndex(int index)
    {
        itemIndex = index;
    }

    public void SetData(ItemSlot itemSlot)
    {
        _icon.sprite = itemSlot.item.Icon;
        _icon.gameObject.SetActive(true);
        
        _text.text = itemSlot.quantity.ToString();
        _text.gameObject.SetActive(true);
    }

    public void CleanData()
    {
        _icon.sprite = null;
        _icon.gameObject.SetActive(false);
        _text.gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ItemPanel itemPanel = transform.parent.GetComponent<ItemPanel>();
        itemPanel.OnCLick(itemIndex);
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
