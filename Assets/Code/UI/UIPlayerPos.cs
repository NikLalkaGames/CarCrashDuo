using TMPro;
using UnityEngine;

namespace Code.UI
{
    public class UIPlayerPos : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _firstPlayerPos;
        
        [SerializeField] private TextMeshProUGUI _secondPlayerPos;


        public void UpdatePositions(int firstPlayerPos, int secondPlayerPos)
        {
            _firstPlayerPos.text = $"{firstPlayerPos}";
            _secondPlayerPos.text = $"{secondPlayerPos}";
        }
    }
}