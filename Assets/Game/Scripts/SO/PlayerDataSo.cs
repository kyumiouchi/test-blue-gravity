using System;
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

        public event Action<int> UpdateCoins;

        public int AddCoin(int value)
        {
            if (value > 0)
                _coins += value;
            UpdateCoins?.Invoke(_coins);
            return _coins;
        }

        public int SubtractCoin(int value)
        {
            if (value > 0)
                _coins -= value;
            UpdateCoins?.Invoke(_coins);
            return _coins;
        }
    }
}
