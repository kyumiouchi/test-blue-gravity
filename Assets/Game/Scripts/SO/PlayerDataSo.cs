using UnityEngine;

namespace GameValley
{
    [CreateAssetMenu(menuName = "Player/Player Data", fileName = "PlayerData_Name_SO")]
    public class PlayerDataSo : ScriptableObject
    {
        [SerializeField] private float _walkSpeed;


        public float WalkSpeed => _walkSpeed;
    }
}
