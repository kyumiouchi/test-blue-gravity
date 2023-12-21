using UnityEngine;

public class CollectItem : MonoBehaviour
{
    [SerializeField] private ItemDataSo _item;
    [SerializeField] private int _quantity = 1;
    
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _collectDistance = 1.5f;
    [SerializeField] private float _timeToDestroy = 5f;
    
    private Transform _player;

    private void Start()
    {
        _player = GameManager.Instance.Player.transform;
    }

    void Update()
    {
        _timeToDestroy -= Time.deltaTime;
        if (_timeToDestroy < 0)
        {
            Destroy(gameObject);
            return;
        }
        float distance = Vector3.Distance(transform.position, _player.position);
        if (distance > _collectDistance) return;

        MoveObjectToPlayer();

        if (distance < 0.1f)
        {
            if (GameManager.Instance.ItemInventorySo != null)
            {
                GameManager.Instance.ItemInventorySo.Add(_item, _quantity);
            }
            else
            {
                Debug.Log("Empty inventory so in GameManager");
            }
            Destroy(gameObject);
        }
    }

    private void MoveObjectToPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, _player.position, 
            _speed * Time.deltaTime);
    }
}
