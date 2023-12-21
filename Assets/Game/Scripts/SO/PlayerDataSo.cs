using UnityEngine;

namespace GameValley
{
    [CreateAssetMenu(menuName = "Data/Player", fileName = "Player_Name_SO")]
    public class PlayerDataSo : ScriptableObject
    {
        [SerializeField] private float _walkSpeed;
        [SerializeField] private int _coins;


        public float WalkSpeed => _walkSpeed;
        public int Coins => _coins;
    }
}
