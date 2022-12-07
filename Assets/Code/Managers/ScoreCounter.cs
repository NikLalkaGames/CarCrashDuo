using Code.Common;
using Code.UI;
using UnityEngine;

namespace Code.Managers
{
    public class ScoreCounter : MonoBehaviour
    {
        [SerializeField] private PlayerInfo _playerInfo;
        
        private void OnCollisionEnter(Collision other)
        {
            if (!other.collider.CompareTag("Obstacle")) return;
            _playerInfo.Score++;
        }
    }
}