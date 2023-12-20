using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance => _instance;
    
    [SerializeField] private  GameObject _player;

    public GameObject Player => _player;

    private void Awake()
    {
        _instance = this;
    }
}
