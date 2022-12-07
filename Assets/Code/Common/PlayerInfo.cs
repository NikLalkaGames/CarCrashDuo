using System;
using UnityEngine;

namespace Code.Common
{
    [CreateAssetMenu]
    public class PlayerInfo : ScriptableObject
    {
        public string Identity;
        public int Place;
        public int Score;
        public float Health;
        public bool IsDead;

        private void OnEnable()
        {
            Place = 0;
            Score = 0;
            Health = 0f;
        }
        
        public void ClearValues()
        {
            Place = 0;
            Score = 0;
            Health = 0f;
        }
    }
}