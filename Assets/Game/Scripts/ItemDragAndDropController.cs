using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ItemDragAndDropController : MonoBehaviour
{
    [FormerlySerializedAs("_itemInInventory")] [SerializeField] private ItemSlot _itemDrag;
    [SerializeField] private GameObject _itemDragged;
    private RectTransform _position;
    private Image _image;
    private void Start()
    {
        _itemDrag = new ItemSlot();
        _position = _itemDragged.GetComponent<RectTransform>();
        _image = _itemDragged.GetComponent<Image>();
    }

    private void Update()
    {
        if (_itemDragged.activeInHierarchy)
        {
            _position.position = Input.mousePosition;

            if (Input.GetMouseButtonDown(0))
            {
                if (EventSystem.current.IsPointerOverGameObject() == false)
                {
                    Debug.Log("out");
                }
            }
        }
    }

    public void OnClick(ItemSlot itemInInventory)
    {
        if (_itemDrag.item == null)
        {
            _itemDrag.Copy(itemInInventory);
            itemInInventory.Clear();
        }
        else
        {
            ItemDataSo item = itemInInventory.item;
            int quantity = itemInInventory.quantity;
            
            itemInInventory.Copy(_itemDrag);
            _itemDrag.Set(item, quantity);
        }
        Debug.Log("Inventory " + itemInInventory);
        Debug.Log("Dragged " + _itemDrag);

        UpdateImage();
    }

    private void UpdateImage()
    {
        if (_itemDrag.item == null)
        {
            _itemDragged.SetActive(false);
        }
        else
        {
            _itemDragged.SetActive(true);
            _image.sprite = _itemDrag.item.Icon;
        }
    }
}
