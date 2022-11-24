using UnityEngine;
using UnityEngine.UI;

namespace Code.Managers
{
    public class HealthController : MonoBehaviour
    {
        [SerializeField] private Slider UIHealth;

        [SerializeField] private float _maxHealth;

        private void Start()
        {
            UIHealth.maxValue = _maxHealth;
        }

        public void ChangeHealth(float amountToChange)      // can be negative
        {
            UIHealth.value += amountToChange;
        }

        public void UpdateHealth(float healthValueToUpdate)
        {
            UIHealth.value = healthValueToUpdate;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                UpdateHealth(_maxHealth);
            }
            
            if (Input.GetKeyDown(KeyCode.R))
            {
                ChangeHealth(-30);
            }
        }
    }
}