using Code.Common;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Code.Managers
{
    public class HealthController : MonoBehaviour
    {
        [SerializeField] private PlayerInfo _playerInfo;
        [Range(0,100)]
        [SerializeField] private float _maxHealth;

        private void Start()
        {
            _playerInfo.Health = _maxHealth;
        }

        public void ChangeHealth(float amountToChange)      // can be negative
        {
            _playerInfo.Health += amountToChange;
            if (_playerInfo.Health <= 0)
            {
                _playerInfo.IsDead = true;
                SceneManager.LoadScene("LevelFinish");
            }
        }
    }
}