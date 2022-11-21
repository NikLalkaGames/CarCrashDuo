using Code.UI;
using UnityEngine;

namespace Code.PlayerControl
{
    public class ScoreCounter : MonoBehaviour
    {
        [SerializeField] private UIScore _uiScore;

        private void OnCollisionEnter(Collision other)
        {
            if (!other.collider.CompareTag("Obstacle")) return;
            _uiScore.IncrementScore();
            _uiScore.UpdateScore();
        }
    }
}