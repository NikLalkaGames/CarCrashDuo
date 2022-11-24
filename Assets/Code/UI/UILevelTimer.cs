using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Code.UI
{
    public class UILevelTimer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _timeLeftCounter;
        
        private float _minutes, _seconds;
        
        public void UpdateTime(float timeLeft)
        {
            _minutes = (int)(timeLeft / 60f);
            _seconds = (int)(timeLeft % 60f); 
            
            _timeLeftCounter.text = $"{_minutes}:{_seconds}";
        }
    }
}