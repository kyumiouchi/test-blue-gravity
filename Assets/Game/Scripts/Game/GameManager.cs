using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                var objs = FindObjectsOfType(typeof(GameManager)) as GameManager[];
                if (objs.Length > 0)
                    _instance = objs[0];
                if (objs.Length > 1)
                {
                    Debug.LogError("There is more than one " + typeof(GameManager).Name + " in the scene.");
                }

                if (_instance == null)
                {
                    GameObject singleton = new GameObject(nameof(GameManager))
                    {
                        hideFlags = HideFlags.HideAndDontSave
                    };
                    _instance = singleton.AddComponent<GameManager>();
                    DontDestroyOnLoad(singleton);
                }
            }

            return _instance;
        }
    }
    
    [SerializeField] private GameObject _player;
    [SerializeField] public ItemInventorySo _itemInventorySo;
    [SerializeField] public ItemInventorySo _shopInventorySo;
    [SerializeField] private ItemDragAndDropController _itemDragAndDropController;
    public GameObject Player => _player;
    public ItemInventorySo ItemInventorySo => _itemInventorySo;
    public ItemInventorySo ShopInventorySo => _shopInventorySo;
    public ItemDragAndDropController ItemDragAndDropController => _itemDragAndDropController;

    private void OnEnable()
    {
        _instance = this;
    }
}
