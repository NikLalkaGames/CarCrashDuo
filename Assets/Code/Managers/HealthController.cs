using UnityEngine;
using UnityEngine.UI;

namespace Code.Managers
{
    public class HealthController : MonoBehaviour
    {
        [SerializeField] private Slider UIHealth;

        [Range(0,100)]
        [SerializeField] private float _maxHealth;

        private void Start()
        {
            UIHealth.minValue = 0;
            UIHealth.maxValue = _maxHealth;
            UpdateHealth(_maxHealth);
        }

        public void ChangeHealth(float amountToChange)      // can be negative
        {
            UIHealth.value += amountToChange;
        }

        public void UpdateHealth(float healthValueToUpdate)
        {
            UIHealth.value = healthValueToUpdate;
        }
    }
}