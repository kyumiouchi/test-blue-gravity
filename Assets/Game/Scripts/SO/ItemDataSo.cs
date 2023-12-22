using UnityEngine;
using UnityEngine.U2D.Animation;

[CreateAssetMenu(menuName = "Data/Item", fileName = "Item_Name_SO")]
public class ItemDataSo : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private bool _stackable;
    [SerializeField] private Sprite _icon;
    [SerializeField] private ItemType _itemType;
    [SerializeField] private BodyPositionType _bodyPositionType;
    [SerializeField] private int _priceToBuy = 2;
    [SerializeField] private int _priceToSell = 1;
    [SerializeField] private SpriteLibraryAsset _spriteLibrary;
    
    public string Name => _name;
    public bool Stakable => _stackable;
    public Sprite Icon => _icon;
    public ItemType ItemType => _itemType;
    public BodyPositionType BodyPositionType => _bodyPositionType;
    public int PriceToBuy => _priceToBuy;
    public int PriceToSell => _priceToSell;
    public SpriteLibraryAsset SpriteLibrary => _spriteLibrary;
}
