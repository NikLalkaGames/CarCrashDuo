using Code.Common;
using TMPro;
using UnityEngine;

namespace Code.UI
{
    public class UIPlayerPos : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _firstPlayerPos;
        
        [SerializeField] private TextMeshProUGUI _secondPlayerPos;

        [SerializeField] private PlayerInfo[] _playerInfos;

        public void Update()
        {
            _firstPlayerPos.text = $"{_playerInfos[0].Place}";
            _secondPlayerPos.text = $"{_playerInfos[1].Place}";
        }
    }
}