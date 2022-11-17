using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class UIScore : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreUIValue;

        private int _scoreValue;

        public void Start() => _scoreUIValue.text = "0";

        public void IncrementScore() => _scoreValue++;

        public void UpdateScore() => _scoreUIValue.text = $"{_scoreValue}";
    }
}